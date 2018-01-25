namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Extension methods to use with dependency objects.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Gets a dependency object for a given object.
        /// </summary>
        /// <param name="obj">The object for which a dependency object is required.</param>
        /// <returns>A dependency object.</returns>
        public static DependencyObject GetDependencyObject(this object obj)
        {
            return DependencyObject.AddObject(obj);
        }

        /// <summary>
        /// Sets the value on the dependency object of the given object
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="System.ArgumentException">DependencyObject not found.</exception>
        public static void SetValue(this object obj, object value)
        {
            DependencyObject result;
            DependencyObject.TryGet(obj, out result);

            if (result == null)
                throw new ArgumentException("DependencyObject not found.");

            result.SetValue(value);
        }
    }

    /// <summary>
    /// Represents an object that participates in the dependency property system.
    /// </summary>
    public class DependencyObject
    {
        private static readonly IList<DependencyObject> RegisteredObjects = new List<DependencyObject>();

        private static readonly Dictionary<Type, Dictionary<string, DependencyProperty>> PropertyDeclarations
            = new Dictionary<Type, Dictionary<string, DependencyProperty>>();

        private readonly Dictionary<DependencyProperty, WeakReference> _weakReferences =
            new Dictionary<DependencyProperty, WeakReference>();

        private readonly Dictionary<DependencyProperty, object> _values =
            new Dictionary<DependencyProperty, object>();

        private DependencyObject()
        {
            // Force to use GetDependencyObject extension method.
        }

        private DependencyObject(object obj) : this()
        {
            Object = obj;

            if (obj is Component)
                ((Component) obj).Disposed += (sender, e) => RemoveObject(Object);
            RegisteredObjects.Add(this);
        }

        //public static readonly Object UnsetValue;

        /// <summary>
        /// Gets the object that is associated with this dependency object.
        /// </summary>
        /// <value>
        /// The associated object.
        /// </value>
        public object Object { get; }

        /// <summary>
        /// Clears the value of a dependency property.
        /// </summary>
        /// <param name="property">The dependency property whose value is to be cleared.</param>
        public void ClearValue(DependencyProperty property)
        {
            if (property.PropertyType.IsValueType)
                _values[property] = null;
            else
                _weakReferences[property] = null;
        }

        /// <summary>
        /// Sets the value of a dependency property.
        /// </summary>
        /// <param name="property">The dependency property whose value is to be set.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="System.ArgumentException">Value is of wrong type for this DependencyProperty.</exception>
        public void SetValue(DependencyProperty property, object value)
        {
            if (!property.IsValidType(value))
                throw new ArgumentException("Value is of wrong type for this DependencyProperty.");

            if (property.PropertyType.IsValueType)
                SetValueType(property, value);
            else
                SetValueWeakRef(property, value);
        }

        private void SetValueWeakRef(DependencyProperty property, object value)
        {
            WeakReference oldValue;
            _weakReferences.TryGetValue(property, out oldValue);
            _weakReferences[property] = new WeakReference(value);

            if (property.DefaultMetadata.PropertyChangedCallback != null)
            {
                property.DefaultMetadata.PropertyChangedCallback(
                    this,
                    new DependencyPropertyChangedEventArgs(
                        property,
                        oldValue == null ? null : oldValue.Target,
                        _weakReferences[property].Target
                    ));
            }
        }

        private void SetValueType(DependencyProperty property, object value)
        {
            object oldValue;
            _values.TryGetValue(property, out oldValue);
            _values[property] = value;

            if (property.DefaultMetadata.PropertyChangedCallback != null)
            {
                property.DefaultMetadata.PropertyChangedCallback(
                    this,
                    new DependencyPropertyChangedEventArgs(
                        property,
                        oldValue == null ? null : oldValue,
                        value
                    ));
            }
        }

        /// <summary>
        /// Gets the value of a dependency property.
        /// </summary>
        /// <param name="property">The dependency property for which the value is required.</param>
        /// <returns>The value of a dependency property</returns>
        public object GetValue(DependencyProperty property)
        {
            if (property.PropertyType.IsValueType)
                return GetValueType(property);

            return GetValueWeakRef(property);
        }

        private object GetValueWeakRef(DependencyProperty property)
        {
            object response = null;
            WeakReference wr;

            if (_weakReferences.TryGetValue(property, out wr))
            {
                response = wr.Target;
                if (response == null)
                {
                    _weakReferences.Remove(property);
                }
            }

            return response ?? property.DefaultMetadata.DefaultValue;
        }

        private object GetValueType(DependencyProperty property)
        {
            object value;
            _values.TryGetValue(property, out value);
            return value ?? property.DefaultMetadata.DefaultValue;
        }

        /// <summary>
        /// Gets a dependency object for a given object.
        /// If dependency object for that object doesn't exist, creates a new one.
        /// </summary>
        /// <param name="obj">The object for which a dependency object is required.</param>
        /// <returns>The existing or new dependency object.</returns>
        internal static DependencyObject AddObject(object obj)
        {
            var ro = RegisteredObjects.FirstOrDefault(x => x.Object == obj);

            if (ro == null)
            {
                ro = new DependencyObject(obj);
            }

            return ro;
        }

        private static void RemoveObject(object obj)
        {
            var foundDo = RegisteredObjects.FirstOrDefault(x => x.Object == obj);
            if (null == foundDo)
                return;

            RegisteredObjects.Remove(foundDo);
        }

        /// <summary>
        /// Tries to get a dependency object for a given object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool TryGet(object obj, out DependencyObject dependencyObject)
        {
            dependencyObject = RegisteredObjects.FirstOrDefault(x => x.Object == obj);
            return (dependencyObject != null);
        }

        /// <summary>
        /// Registers a dependency property for the specified type.
        /// </summary>
        /// <param name="type">The type for which the dependency property is to be registered.</param>
        /// <param name="dp">The dependency property to register.</param>
        /// <exception cref="System.ArgumentException">The specified property name already exists on the given object type.</exception>
        internal static void Register(Type type, DependencyProperty dp)
        {
            if (!PropertyDeclarations.ContainsKey(type))
                PropertyDeclarations[type] = new Dictionary<string, DependencyProperty>();
            Dictionary<string, DependencyProperty> typeDeclarations = PropertyDeclarations[type];
            if (!typeDeclarations.ContainsKey(dp.Name))
                typeDeclarations[dp.Name] = dp;
#if WINFORMS
            else
                throw new ArgumentException("The specified property name already exists on the given object type.");
#endif
        }
    }
}