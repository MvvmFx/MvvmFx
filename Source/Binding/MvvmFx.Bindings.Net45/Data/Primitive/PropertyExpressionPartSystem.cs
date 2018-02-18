using System;
using System.Diagnostics;
using System.Reflection;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Represents a single part in the chain of parts held in a <see cref="PropertyExpression"/>.
    /// </summary>
    public abstract partial class PropertyExpressionPart
    {
        #region System.Windows.DependencyProperty

        /// <summary>
        /// A property observation strategy that looks for <see cref="System.Windows.DependencyProperty"/> instances on the target object.
        /// </summary>
        private sealed class SystemDependencyPropertyPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public string StrategyName
            {
                get { return "SystemDependencyProperty"; }
            }

            public IPropertyObservation AttemptAttach(object obj, string propertyName)
            {
                if (obj == null)
                {
                    return null;
                }

                var dependencyPropertyField = obj.GetType().GetField(propertyName + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);

                if (dependencyPropertyField != null)
                {
                    var dependencyProperty = dependencyPropertyField.GetValue(null) as System.Windows.DependencyProperty;

                    if (dependencyProperty != null)
                    {
                        return new DependencyPropertyPropertyObservation(dependencyProperty, obj);
                    }
                }

                return null;
            }

            private sealed class DependencyPropertyPropertyObservation : IPropertyObservation
            {
                public DependencyPropertyPropertyObservation(System.Windows.DependencyProperty dependencyProperty, object obj)
                {
                    System.ComponentModel.DependencyPropertyDescriptor.FromProperty(dependencyProperty, obj.GetType()).AddValueChanged(obj, OnPropertyValueChanged);
                }

                public event EventHandler<EventArgs> ValueChanged;

                public void Detach(object obj, string propertyName)
                {
                    var dependencyPropertyField = obj.GetType().GetField(propertyName + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                    Debug.Assert(dependencyPropertyField != null);
                    var dependencyProperty = dependencyPropertyField.GetValue(null) as System.Windows.DependencyProperty;
                    Debug.Assert(dependencyProperty != null);
                    System.ComponentModel.DependencyPropertyDescriptor.FromProperty(dependencyProperty, obj.GetType()).RemoveValueChanged(obj, OnPropertyValueChanged);
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
    }
}
