//using System.Collections.Generic;

// ReSharper disable CheckNamespace
namespace System.Windows
// ReSharper restore CheckNamespace
{
#pragma warning disable 1591
    public delegate bool ValidateValueCallback(object value);

    public delegate void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs args);

    public class PropertyMetadata
    {
        public PropertyMetadata()
            : this(new object(), null)
        {
        }

        public PropertyMetadata(object defaultValue)
            : this(defaultValue, null)
        {
        }

        public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
            : this(null, propertyChangedCallback)
        {
        }

        public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
        {
            if (defaultValue == DependencyProperty.UnsetValue)
                throw new ArgumentException("Cannot initialize property metadata's default value to 'Unset'");

            DefaultValue = defaultValue;
            PropertyChangedCallback = propertyChangedCallback;
        }

        public PropertyChangedCallback PropertyChangedCallback { get; private set; }
        public object DefaultValue { get; set; }
    }

    public class DependencyPropertyChangedEventArgs
    {
        public DependencyPropertyChangedEventArgs(DependencyProperty property, object oldValue, object newValue)
        {
            Property = property;
            NewValue = newValue;
            OldValue = oldValue;
        }

        public static bool operator !=(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
        {
            return left != null && !left.Equals(right);
        }

        public static bool operator ==(DependencyPropertyChangedEventArgs left, DependencyPropertyChangedEventArgs right)
        {
            return left != null && left.Equals(right);
        }

        public object NewValue { get; private set; }
        public object OldValue { get; private set; }
        public DependencyProperty Property { get; private set; }

        public bool Equals(DependencyPropertyChangedEventArgs args)
        {
            if (Property == args.Property
                && (OldValue == args.OldValue && NewValue == args.NewValue))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals((DependencyPropertyChangedEventArgs) obj);
        }

        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }
    }

    public class DependencyProperty
    {
        //private static readonly List<DependencyProperty> RegisteredProperties = new List<DependencyProperty>();

        public static readonly object UnsetValue = new object();

        private DependencyProperty(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata)
        {
            Name = name;
            PropertyType = propertyType;
            OwnerType = ownerType;
            DefaultMetadata = (defaultMetadata == null
                ? new PropertyMetadata(GetDefaultValue(propertyType))
                : defaultMetadata);

            //RegisteredProperties.Add(this);
        }

        public string Name { get; private set; }
        public Type PropertyType { get; private set; }
        public Type OwnerType { get; private set; }
        public PropertyMetadata DefaultMetadata { get; private set; }
        public ValidateValueCallback ValidateValueCallback { get; private set; }

        public bool IsValidType(object value)
        {
            return PropertyType.IsInstanceOfType(value);
        }

        public bool IsValidValue(object value)
        {
            if (!IsValidType(value))
                return false;
            if (ValidateValueCallback == null)
                return true;
            return ValidateValueCallback(value);
        }

        public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType)
        {
            return RegisterAttached(name, propertyType, ownerType, null);
        }

        public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata metaData)
        {
            var dp = new DependencyProperty(name, propertyType, ownerType, metaData);
            DependencyObject.Register(ownerType, dp);
            return dp;
        }

        private static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }
    }
#pragma warning restore 1591
}