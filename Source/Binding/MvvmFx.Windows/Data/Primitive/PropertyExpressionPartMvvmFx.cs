using System;
using System.Diagnostics;
using System.Reflection;
using MvvmFx.ComponentModel;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Represents a single part in the chain of parts held in a <see cref="PropertyExpression"/>.
    /// </summary>
    public abstract partial class PropertyExpressionPart
    {
        #region MvvmFx.Windows.DependencyProperty

        /// <summary>
        /// A property observation strategy that looks for <see cref="MvvmFx.Windows.DependencyProperty"/> instances on the target object.
        /// </summary>
        private sealed class MvvmFxDependencyPropertyPropertyObservationStrategy : IPropertyObservationStrategy
        {
            public string StrategyName
            {
                get { return "MvvmFxDependencyProperty"; }
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
                    var dependencyPropertyField = obj.GetType().GetField(propertyName + "Property", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                    Debug.Assert(dependencyPropertyField != null);
                    var dependencyProperty = dependencyPropertyField.GetValue(null) as DependencyProperty;
                    Debug.Assert(dependencyProperty != null);
                    DependencyPropertyDescriptor.FromProperty(dependencyProperty, obj.GetType()).RemoveValueChanged(obj, OnPropertyValueChanged);
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
