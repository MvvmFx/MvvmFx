using System;
using System.ComponentModel;

namespace MvvmFx.WebGUI.Forms
{
    /// <summary>
    /// Encapsulates the data source for a form.
    /// </summary>
    /// <remarks>
    /// http://stackoverflow.com/questions/21535431/how-to-solve-data-member-not-found-design-time-error-with-an-inherited-binding
    /// </remarks>
    public class BindingSource : System.Windows.Forms.BindingSource
    {
        /// <summary>
        /// Retrieves an array of <see cref="T:System.ComponentModel.PropertyDescriptor"/> objects representing the bindable properties of the data source list type.
        /// </summary>
        /// <returns>
        /// An array of <see cref="T:System.ComponentModel.PropertyDescriptor"/> objects that represents the properties on this list type used to bind data.
        /// </returns>
        /// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"/> objects to find in the list as bindable.</param>
        public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (DesignMode)
            {
                var baseProperties = base.GetItemProperties(listAccessors);
                var array = new PropertyDescriptor[baseProperties.Count];
                baseProperties.CopyTo(array, 0);
                // Return an identical class, but with a modified Find behaviour.
                return new DesignerPropertyDescriptorCollection(array);
            }

            // At runtime, the inherited BindingSource does nothing special.
            return base.GetItemProperties(listAccessors);
        }


        private class DesignerPropertyDescriptorCollection : PropertyDescriptorCollection
        {
            public DesignerPropertyDescriptorCollection(PropertyDescriptor[] properties)
                : base(properties, readOnly: true)
            {
            }

            /// <summary>
            /// Returns the <see cref="T:System.ComponentModel.PropertyDescriptor"/> with the specified name, using a Boolean to indicate whether to ignore case.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.PropertyDescriptor"/> with the specified name, or null if the property does not exist.
            /// </returns>
            /// <param name="name">The name of the <see cref="T:System.ComponentModel.PropertyDescriptor"/> to return from the collection. </param><param name="ignoreCase">true if you want to ignore the case of the property name; otherwise, false. </param>
            public override PropertyDescriptor Find(string name, bool ignoreCase)
            {
                // Guaranteed to return a descriptor for any property that is being looked up, whether it has any meaning or not.
                return base.Find(name, ignoreCase) ?? new DummyPropertyDescriptor(name);
            }
        }

        /// <summary>
        /// A property descriptor that has no state whatsoever.
        /// </summary>
        private class DummyPropertyDescriptor : PropertyDescriptor
        {
            public DummyPropertyDescriptor(string name)
                : base(name, new Attribute[0])
            {
            }

            /// <summary>
            /// When overridden in a derived class, returns whether resetting an object changes its value.
            /// </summary>
            /// <returns>
            /// true if resetting the component changes its value; otherwise, false.
            /// </returns>
            /// <param name="component">The component to test for reset capability. </param>
            public override bool CanResetValue(object component)
            {
                return false;
            }

            /// <summary>
            /// When overridden in a derived class, gets the type of the component this property is bound to.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.Type"/> that represents the type of component this property is bound to. When the <see cref="M:System.ComponentModel.PropertyDescriptor.GetValue(System.Object)"/> or <see cref="M:System.ComponentModel.PropertyDescriptor.SetValue(System.Object,System.Object)"/> methods are invoked, the object specified might be an instance of this type.
            /// </returns>
            public override Type ComponentType
            {
                get { return typeof (object); }
            }

            /// <summary>
            /// When overridden in a derived class, gets the current value of the property on a component.
            /// </summary>
            /// <returns>
            /// The value of a property for a given component.
            /// </returns>
            /// <param name="component">The component with the property for which to retrieve the value. </param>
            public override object GetValue(object component)
            {
                return null;
            }

            /// <summary>
            /// When overridden in a derived class, gets a value indicating whether this property is read-only.
            /// </summary>
            /// <returns>
            /// true if the property is read-only; otherwise, false.
            /// </returns>
            public override bool IsReadOnly
            {
                get { return false; }
            }

            /// <summary>
            /// When overridden in a derived class, gets the type of the property.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.Type"/> that represents the type of the property.
            /// </returns>
            public override Type PropertyType
            {
                get { return typeof (object); }
            }

            /// <summary>
            /// When overridden in a derived class, resets the value for this property of the component to the default value.
            /// </summary>
            /// <param name="component">The component with the property value that is to be reset to the default value. </param>
            public override void ResetValue(object component)
            {
            }

            /// <summary>
            /// When overridden in a derived class, sets the value of the component to a different value.
            /// </summary>
            /// <param name="component">The component with the property value that is to be set. </param><param name="value">The new value. </param>
            public override void SetValue(object component, object value)
            {
            }

            /// <summary>
            /// When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted.
            /// </summary>
            /// <returns>
            /// true if the property should be persisted; otherwise, false.
            /// </returns>
            /// <param name="component">The component with the property to be examined for persistence. </param>
            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
}