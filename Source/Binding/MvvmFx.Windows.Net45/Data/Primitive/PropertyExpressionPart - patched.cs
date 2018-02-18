using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Windows;
using Kent.Boogaart.HelperTrinity.Extensions;
using MvvmFx.Bindings.WindowsBase.Diagnostics;

namespace MvvmFx.Bindings.WindowsBase.Primitive
{
    /// <summary>
    /// Represents a single part in the chain of parts held in a <see cref="PropertyExpression"/>.
    /// </summary>
    [DebuggerDisplay("PropertyName={PropertyName}, Type={PropertyType}")]
    public abstract class PropertyExpressionPart
    {
        private readonly PropertyExpressionPart _nextPart;
        private readonly WeakReference _object;
        private bool _ignoreValueChangesLatch;
        private IPropertyObservation _propertyObservation;

        private static readonly ICollection<IPropertyObservationStrategy> _propertyObservationStrategies =
            new List<IPropertyObservationStrategy>(new IPropertyObservationStrategy[]
            {
                new INPCPropertyObservationStrategy(), new XxxChangedPropertyObservationStrategy(),
                new DependencyPropertyPropertyObservationStrategy()
            });

        /// <summary>
        /// The value yielded by a property expression part when it has not yet successfully resolved to the property.
        /// </summary>
        public static readonly object Unresolved = new object();

        /// <summary>
        /// Constructs an instance of <c>PropertyExpressionPart</c>.
        /// </summary>
        /// <param name="nextPart">
        /// The next part in the chain of parts held in the <see cref="PropertyExpression"/>.
        /// </param>
        protected PropertyExpressionPart(PropertyExpressionPart nextPart)
        {
            _nextPart = nextPart;
            _object = new WeakReference(null);
        }

        /// <summary>
        /// Occurs whenever the value of the property to which this expression part resolves changes.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets the name of the property that this expression part will attempt to resolve to.
        /// </summary>
        public abstract string PropertyName { get; }

        /// <summary>
        /// Gets the type of the property that this expression part has resolved to, or <see langword="null"/> if it is not yet resolved.
        /// </summary>
        public abstract Type PropertyType { get; }

        /// <summary>
        /// Gets or sets the object that this expression part is attempting to resolve its property against, or <see langword="null"/> if the object has not yet been
        /// resolved.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The object may not yet be resolved if this expression part is not the first in its chain. Any expression part appearing before this part may not yet have
        /// resolved its own object, or may have a <see langword="null"/> value. In either of those cases, this expression part will not yet know its object.
        /// </para>
        /// <para>
        /// Only a <see cref="WeakReference"/> is maintained against any object set on the property.
        /// </para>
        /// </remarks>
        public object Object
        {
            get { return _object.Target; }
            set
            {
                Detach();
                _object.Target = value;
                Attach();

                //if the object has changed, then the value must have too
                OnValueChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value of the property that this expression part resolves to, or <see langword="Unresolved"/> if it is not yet resolved.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031", Justification = "All exceptions thrown during binding are 'swallowed' by design. Details of the exception are logged.")]
        public object Value
        {
            get { return GetValueCore(); }
            set
            {
                var oldValue = GetValueCore();

                if (value != null && !PropertyType.IsAssignableFrom(value.GetType()))
                {
                    value = AttemptConversion(value);
                }

                if (!object.Equals(oldValue, value))
                {
                    _ignoreValueChangesLatch = true;

                    try
                    {
                        SetValueCore(value);
                        OnValueChanged();
                    }
                    catch (Exception ex)
                    {
                        Log.Write(TraceEventType.Error,
                            "An error occurred attempting to set property with name '{0}': {1}", PropertyName, ex);
                    }
                    finally
                    {
                        _ignoreValueChangesLatch = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value that this expression part resolves to, or <see langword="Unresolved"/> if it is not yet resolved.
        /// </summary>
        /// <returns>
        /// The value of the resolved property, or <see langword="Unresolved"/> if the property is not yet resolved.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1024", Justification = "The cost of the logic behind getting the value is unclear, so a method seems more appropriate here.")]
        protected abstract object GetValueCore();

        /// <summary>
        /// Sets the value of the property that this expression part has resolved to.
        /// </summary>
        /// <remarks>
        /// If the property is not yet resolved, this method should do nothing.
        /// </remarks>
        /// <param name="value">
        /// The value for the property.
        /// </param>
        protected abstract void SetValueCore(object value);

        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event, and passes changes onto the next expression part in the chain.
        /// </summary>
        protected virtual void OnValueChanged()
        {
            ValueChanged.Raise(this, EventArgs.Empty);

            if (_nextPart != null)
            {
                //if the value of this PropertyExpressionPart changes, we need to update the Object in the next PropertyExpressionPart with the new value
                _nextPart.Object = Value;
            }
        }

        private void Attach()
        {
            var obj = _object.Target;

            if (obj == null)
            {
                return;
            }

            foreach (var propertyObservationStrategy in _propertyObservationStrategies)
            {
                _propertyObservation = propertyObservationStrategy.AttemptAttach(obj, PropertyName);

                if (_propertyObservation != null)
                {
                    //found a strategy that works with object and property combination
                    break;
                }
            }

            if (_propertyObservation != null)
            {
                _propertyObservation.ValueChanged += _propertyObservation_ValueChanged;
            }
        }

        private void Detach()
        {
            var obj = _object.Target;

            if (obj == null)
            {
                return;
            }

            if (_propertyObservation != null)
            {
                _propertyObservation.Detach(obj, PropertyName);
                _propertyObservation.ValueChanged -= _propertyObservation_ValueChanged;
                _propertyObservation = null;
            }
        }

        private void _propertyObservation_ValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreValueChangesLatch)
            {
                OnValueChanged();
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031", Justification = "All exceptions thrown during binding are 'swallowed' by design. Details of the exception are logged.")]
        private object AttemptConversion(object value)
        {
            Log.Write(TraceEventType.Information,
                "Attempting automatic conversion of value from type {0} to type {1} for property '{2}'.",
                value.GetType(), PropertyType, PropertyName);

            try
            {
                value = Convert.ChangeType(value, PropertyType, CultureInfo.CurrentCulture);
                Log.Write(TraceEventType.Information, "Conversion was successful.");
            }
            catch (Exception ex)
            {
                Log.Write(TraceEventType.Error,
                    "Conversion Failed. Unable to convert type {0} to {1} for property '{2}' due to an exception: {3}.",
                    value.GetType(), PropertyType, PropertyName, ex);
            }

            return value;
        }

        //interface for all strategies that observe properties
        private interface IPropertyObservationStrategy
        {
            IPropertyObservation AttemptAttach(object obj, string propertyName);
        }

        //interface for all actual observations of a property
        private interface IPropertyObservation
        {
            event EventHandler<EventArgs> ValueChanged;

            void Detach(object obj, string propertyName);
        }

        //a property observation strategy that uses the System.ComponentModel.INotifyPropertyChanged interface
        private sealed class INPCPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                var notifyObject = obj as INotifyPropertyChanged;

                if (notifyObject != null)
                {
                    return new INPCPropertyObservation(notifyObject, propertyName);
                }

                return null;
            }

            private sealed class INPCPropertyObservation : IPropertyObservation
            {
                private readonly string _propertyName;

                public INPCPropertyObservation(INotifyPropertyChanged notifyObject, string propertyName)
                {
                    _propertyName = propertyName;
                    notifyObject.PropertyChanged += notifyObject_PropertyChanged;
                }

                private void notifyObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == _propertyName)
                    {
                        ValueChanged.Raise(this, EventArgs.Empty);
                    }
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var notifyObject = obj as INotifyPropertyChanged;
                    Debug.Assert(notifyObject != null);
                    notifyObject.PropertyChanged -= notifyObject_PropertyChanged;
                }
            }
        }

        //a property observation strategy that looks for XxxChanged events on the target object
        private sealed class XxxChangedPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                var changedEvent = TypeDescriptor.GetEvents(obj).Find(propertyName + "Changed", false);
                if (changedEvent == null)
                    return null;

                if (changedEvent.EventType == typeof (EventHandler<EventArgs>) ||
                    changedEvent.EventType == typeof (EventHandler))
                {
                    return new XxxChangedPropertyObservation(changedEvent, obj);
                }

                return null;
            }

            private sealed class XxxChangedPropertyObservation : IPropertyObservation
            {
                public XxxChangedPropertyObservation(EventDescriptor changedEvent, object obj)
                {
                    if (changedEvent.EventType == typeof (EventHandler<EventArgs>))
                    {
                        changedEvent.AddEventHandler(obj, (EventHandler<EventArgs>) OnPropertyValueChanged);
                    }
                    else if (changedEvent.EventType == typeof (EventHandler))
                    {
                        changedEvent.AddEventHandler(obj, (EventHandler) OnPropertyValueChanged);
                    }
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var changedEvent = TypeDescriptor.GetEvents(obj).Find(propertyName + "Changed", false);
                    Debug.Assert(changedEvent != null);

                    if (changedEvent.EventType == typeof (EventHandler<EventArgs>))
                    {
                        changedEvent.RemoveEventHandler(obj, (EventHandler<EventArgs>) OnPropertyValueChanged);
                    }
                    else if (changedEvent.EventType == typeof (EventHandler))
                    {
                        changedEvent.RemoveEventHandler(obj, (EventHandler) OnPropertyValueChanged);
                    }
                }

                private void OnPropertyValueChanged(object sender, EventArgs e)
                {
                    ValueChanged.Raise(this, EventArgs.Empty);
                }
            }
        }

        //a property observation strategy that looks for DependencyProperty instances on the target object
        private sealed class DependencyPropertyPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                if (obj == null)
                {
                    return null;
                }

                var dependencyPropertyField = obj.GetType().GetField(propertyName + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);

                if (dependencyPropertyField != null)
                {
                    var dependencyProperty = dependencyPropertyField.GetValue(null) as DependencyProperty;

                    if (dependencyProperty != null)
                    {
                        return new DependencyPropertyPropertyObservation(dependencyProperty, obj);
                    }
                }

                return null;
            }

            private sealed class DependencyPropertyPropertyObservation : IPropertyObservation
            {
                public DependencyPropertyPropertyObservation(DependencyProperty dependencyProperty, object obj)
                {
                    DependencyPropertyDescriptor.FromProperty(dependencyProperty, obj.GetType()).AddValueChanged(obj, OnPropertyValueChanged);
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var dependencyPropertyField = obj.GetType().GetField(propertyName + "Property", BindingFlags.Static | BindingFlags.Public);
                    Debug.Assert(dependencyPropertyField != null);
                    var dependencyProperty = dependencyPropertyField.GetValue(null) as DependencyProperty;
                    Debug.Assert(dependencyProperty != null);
                    DependencyPropertyDescriptor.FromProperty(dependencyProperty, obj.GetType()).RemoveValueChanged(obj, OnPropertyValueChanged);
                }

                private void OnPropertyValueChanged(object sender, EventArgs e)
                {
                    ValueChanged.Raise(this, EventArgs.Empty);
                }
            }
        }
    }
}