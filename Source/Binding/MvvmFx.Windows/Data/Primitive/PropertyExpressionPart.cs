using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MvvmFx.Windows.Diagnostics;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Represents a single part in the chain of parts held in a <see cref="PropertyExpression"/>.
    /// </summary>
    [DebuggerDisplay("PropertyName={PropertyName}, Type={PropertyType}")]
    public abstract partial class PropertyExpressionPart
    {
        private readonly bool _bindOnValidation;
        private readonly PropertyExpressionPart _nextPart;
        private readonly WeakReference _object;
        private bool _ignoreValueChangesLatch;
        private IPropertyObservation _propertyObservation;

        private static readonly ICollection<IPropertyObservationStrategy> PropertyObservationStrategies =
            new List<IPropertyObservationStrategy>(new IPropertyObservationStrategy[]
            {
                new INPCPropertyObservationStrategy(),
                new ValidatedPropertyObservationStrategy(),
                new XxxChangedPropertyObservationStrategy(),
#if WPF
                new SystemDependencyPropertyPropertyObservationStrategy(),
#endif
#if MVVMFX
                new MvvmFxDependencyPropertyPropertyObservationStrategy()
#endif
            });

        /// <summary>
        /// The value yielded by a property expression part when it has not yet successfully resolved to the property.
        /// </summary>
        public static readonly object Unresolved = new object();

        /// <summary>
        /// Constructs an instance of <c>PropertyExpressionPart</c>.
        /// </summary>
        /// <param name="nextPart">The next part in the chain of parts held in the <see cref="PropertyExpression" />.</param>
        /// <param name="bindOnValidation">if set to <c>true</c> the bound value should be updated on property validation.</param>
        protected PropertyExpressionPart(PropertyExpressionPart nextPart, bool bindOnValidation)
        {
            _nextPart = nextPart;
            _object = new WeakReference(null);
            _bindOnValidation = bindOnValidation;
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

                //if (value != null && !PropertyType.IsAssignableFrom(value.GetType()))
                if (value != null && !PropertyType.IsInstanceOfType(value))
                {
                    value = AttemptConversion(value);
                }

                if (!Equals(oldValue, value))
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
            //thread safe
            EventHandler<EventArgs> handler;
            lock (this)
            {
                handler = ValueChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

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

            foreach (var propertyObservationStrategy in PropertyObservationStrategies)
            {
                if (!_bindOnValidation && propertyObservationStrategy.StrategyName == "Validated")
                    continue;

                _propertyObservation = propertyObservationStrategy.AttemptAttach(obj, PropertyName);

                if (_propertyObservation != null)
                {
                    //found a strategy that works with object and property combination
                    break;
                }
            }

            if (_propertyObservation != null)
            {
                _propertyObservation.ValueChanged += PropertyObservationOnValueChanged;
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
                _propertyObservation.ValueChanged -= PropertyObservationOnValueChanged;
                _propertyObservation = null;
            }
        }

        private void PropertyObservationOnValueChanged(object sender, EventArgs e)
        {
            if (!_ignoreValueChangesLatch)
            {
                OnValueChanged();
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031", Justification = "All exceptions thrown during binding are 'swallowed' by design. Details of the exception are logged.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303", Justification = "Do not translate log messages.")]
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

        #region Actual observation (private)

        #region INotifyPropertyChanged

        /// <summary>
        /// A property observation strategy that uses the <see cref="System.ComponentModel.INotifyPropertyChanged"/> interface.
        /// </summary>
        private sealed class INPCPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public string StrategyName
            {
                get { return "INPC"; }
            }

            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                var notifyObject = obj as System.ComponentModel.INotifyPropertyChanged;

                if (notifyObject != null)
                {
                    return new INPCPropertyObservation(notifyObject, propertyName);
                }

                return null;
            }

            private sealed class INPCPropertyObservation : IPropertyObservation
            {
                private readonly string _propertyName;

                public INPCPropertyObservation(System.ComponentModel.INotifyPropertyChanged notifyObject, string propertyName)
                {
                    _propertyName = propertyName;
                    notifyObject.PropertyChanged += NotifyObjectOnPropertyChanged;
                }

                private void NotifyObjectOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == _propertyName)
                    {
                        //thread safe
                        EventHandler<EventArgs> handler;
                        lock (this)
                        {
                            handler = ValueChanged;
                        }

                        if (handler != null)
                        {
                            handler(this, EventArgs.Empty);
                        }
                    }
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var notifyObject = obj as System.ComponentModel.INotifyPropertyChanged;
                    Debug.Assert(notifyObject != null);
                    notifyObject.PropertyChanged -= NotifyObjectOnPropertyChanged;
                }
            }
        }

        #endregion

        #region XxxChanged

        /// <summary>
        /// A property observation strategy that looks for XxxChanged events on the target object.
        /// </summary>
        private sealed class XxxChangedPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public string StrategyName
            {
                get { return "XxxChanged"; }
            }

            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                var changedEvent = System.ComponentModel.TypeDescriptor.GetEvents(obj).Find(propertyName + "Changed", false);

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
                public XxxChangedPropertyObservation(System.ComponentModel.EventDescriptor changedEvent, object obj)
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
                    var changedEvent = System.ComponentModel.TypeDescriptor.GetEvents(obj).Find(propertyName + "Changed", false);
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
                    //thread safe
                    EventHandler<EventArgs> handler;
                    lock (this)
                    {
                        handler = ValueChanged;
                    }

                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
        }

        #endregion

        #region Validated

        /// <summary>
        /// A property observation strategy that looks for Validated event on the target object.
        /// </summary>
        private sealed class ValidatedPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public string StrategyName
            {
                get { return "Validated"; }
            }

            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                var validateddEvent = System.ComponentModel.TypeDescriptor.GetEvents(obj)
                    .Find("Validated", false);

                if (validateddEvent == null)
                    return null;

                if (validateddEvent.EventType == typeof (EventHandler<EventArgs>) ||
                    validateddEvent.EventType == typeof (EventHandler))
                {
                    return new ValidatedChangedPropertyObservation(validateddEvent, obj);
                }

                return null;
            }

            private sealed class ValidatedChangedPropertyObservation : IPropertyObservation
            {
                public ValidatedChangedPropertyObservation(System.ComponentModel.EventDescriptor validateddEvent, object obj)
                {
                    if (validateddEvent.EventType == typeof (EventHandler<EventArgs>))
                    {
                        validateddEvent.AddEventHandler(obj, (EventHandler<EventArgs>) OnControlValidated);
                    }
                    else if (validateddEvent.EventType == typeof (EventHandler))
                    {
                        validateddEvent.AddEventHandler(obj, (EventHandler) OnControlValidated);
                    }
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var changedEvent = System.ComponentModel.TypeDescriptor.GetEvents(obj).Find("Validated", false);
                    Debug.Assert(changedEvent != null);

                    if (changedEvent.EventType == typeof (EventHandler<EventArgs>))
                    {
                        changedEvent.RemoveEventHandler(obj, (EventHandler<EventArgs>) OnControlValidated);
                    }
                    else if (changedEvent.EventType == typeof (EventHandler))
                    {
                        changedEvent.RemoveEventHandler(obj, (EventHandler) OnControlValidated);
                    }
                }

                private void OnControlValidated(object sender, EventArgs e)
                {
                    //thread safe
                    EventHandler<EventArgs> handler;
                    lock (this)
                    {
                        handler = ValueChanged;
                    }

                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
            }
        }

        #endregion

        #endregion
    }

    #region Interfaces

    /// <summary>
    /// Interface for all strategies that observe properties.
    /// </summary>
    internal interface IPropertyObservationStrategy
    {
        IPropertyObservation AttemptAttach(object obj, string propertyName);
        string StrategyName { get; }
    }

    /// <summary>
    /// Interface for all actual observations of a property.
    /// </summary>
    internal interface IPropertyObservation
    {
        event EventHandler<EventArgs> ValueChanged;

        void Detach(object obj, string propertyName);
    }

    #endregion
}