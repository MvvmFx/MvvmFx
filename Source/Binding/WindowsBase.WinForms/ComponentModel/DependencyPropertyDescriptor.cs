// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2012 MvvmFx project (http://mvvmfx.codeplex.com)
//
// Authors:
//	Tiago Freitas Leal
//
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MvvmFx.Windows;

namespace MvvmFx.ComponentModel
{
    /// <summary>
    /// DependencyPropertyDescriptor
    /// </summary>
    public sealed class DependencyPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor _property;
        private readonly Type _componentType;
        private readonly DependencyProperty _dependencyProperty;
        private readonly PropertyMetadata _metadata;

        private static readonly ConcurrentDictionary<object, DependencyPropertyDescriptor> CachedDpd =
            new ConcurrentDictionary<object, DependencyPropertyDescriptor>(new ReferenceEqualityComparer());

        private DependencyPropertyDescriptor()
            : base(null)
        {
        }

        [SuppressMessage("Microsoft.Security", "CA2122", Justification = "temp")]
        private DependencyPropertyDescriptor(PropertyDescriptor property, Type componentType, DependencyProperty dependencyProperty)
            : base(dependencyProperty.Name, null)
        {
            _property = property;
            _componentType = componentType;
            _dependencyProperty = dependencyProperty;
            _metadata = dependencyProperty.GetMetadata(componentType);
        }

        public override AttributeCollection Attributes
        {
            get { return _property.Attributes; }
        }

        public override string Category
        {
            get
            {
                if (string.IsNullOrEmpty(_property.Category))
                    return "Misc";

                return _property.Category;
            }
        }

        public override Type ComponentType
        {
            get { return _componentType; }
        }

        public override TypeConverter Converter
        {
            get { return _property.Converter; }
        }

        public DependencyProperty DependencyProperty
        {
            get { return _dependencyProperty; }
        }

        public override string Description
        {
            get { return _property.Description; }
        }

        public override bool DesignTimeOnly
        {
            get { return _property.DesignTimeOnly; }
        }

        public override string DisplayName
        {
            get { return _property.DisplayName; }
        }

        public bool IsAttached
        {
            get { return _dependencyProperty.IsAttached; }
        }

        public override bool IsBrowsable
        {
            get { return _property.IsBrowsable; }
        }

        public override bool IsLocalizable
        {
            get { return _property.IsLocalizable; }
        }

        public override bool IsReadOnly
        {
            get { return _property.IsReadOnly; }
        }

        public PropertyMetadata Metadata
        {
            get { return _metadata; }
        }

        public override Type PropertyType
        {
            get { return _dependencyProperty.PropertyType; }
        }

        public override bool SupportsChangeEvents
        {
            get
            {
                return true;
                //return _prop.SupportsChangeEvents;
            }
        }

        public override void AddValueChanged(object component, EventHandler handler)
        {
            base.AddValueChanged(component, handler);
        }

        public override bool CanResetValue(object component)
        {
            return _property.CanResetValue(component);
        }

        public override bool Equals(object obj)
        {
            var dpd = obj as DependencyPropertyDescriptor;
            if (dpd != null && dpd.DependencyProperty == _dependencyProperty && dpd.ComponentType == _componentType)
                return true;

            return false;
        }

        public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
        {
            return _property.GetChildProperties(instance, filter);
        }

        public override object GetEditor(Type editorBaseType)
        {
            return _property.GetEditor(editorBaseType);
        }

        public override int GetHashCode()
        {
            return _dependencyProperty.GetHashCode() ^ _componentType.GetHashCode();
        }

        public override object GetValue(object component)
        {
            return _property.GetValue(component);
        }

        public override void RemoveValueChanged(object component, EventHandler handler)
        {
            base.RemoveValueChanged(component, handler);
        }

        public override void ResetValue(object component)
        {
            _property.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            if (ComponentType.IsInstanceOfType(component))
            {
                if (_property.GetValue(component) != value)
                {
                    _property.SetValue(component, value);
                    OnValueChanged(component);
                }
            }
        }

        internal void OnValueChanged(object component)
        {
            OnValueChanged(component, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return _property.ShouldSerializeValue(component);
        }

        public override string ToString()
        {
            return Name;
        }

        public static DependencyPropertyDescriptor FromName(string name, Type ownerType, Type targetType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (ownerType == null)
                throw new ArgumentNullException("ownerType");
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            var dp = DependencyProperty.FromName(name, ownerType);
            if (dp != null)
                return FromProperty(dp, targetType);

            return null;
        }

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "Signature compatibility.")]
        public static DependencyPropertyDescriptor FromName(string name, Type ownerType, Type targetType, bool ignorePropertyType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (ownerType == null)
                throw new ArgumentNullException("ownerType");
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            var dp = DependencyObject.FromName(name, ownerType);
            if (dp != null)
                return FromProperty(dp, targetType);

            return null;
        }

        public static DependencyPropertyDescriptor FromProperty(PropertyDescriptor property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            DependencyPropertyDescriptor dpd;
            if (!CachedDpd.TryGetValue(property, out dpd))
            {
                var dp = DependencyObject.FromName(property.Name, property.ComponentType);
                if (dp != null)
                {
                    dpd = new DependencyPropertyDescriptor(property, dp.OwnerType, dp);
                    CachedDpd.TryAdd(property, dpd);
                }
            }

            return dpd; // null if could't get a DependencyProperty
        }

        public static DependencyPropertyDescriptor FromProperty(DependencyProperty dependencyProperty, Type targetType)
        {
            if (dependencyProperty == null)
                throw new ArgumentNullException("dependencyProperty");
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            #region find PropertyDescriptor

            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(targetType);
            /*foreach (PropertyDescriptor pd in pdc)
            {
                if (pd.Name == dependencyProperty.Name)
                {
                    property = pd;
                    break;
                }
            }*/
            var property = pdc.Cast<PropertyDescriptor>().FirstOrDefault(pd => pd.Name == dependencyProperty.Name);

            #endregion

            DependencyPropertyDescriptor dpd = null;
            if (property != null)
            {
                if (!CachedDpd.TryGetValue(property, out dpd))
                {
                    dpd = new DependencyPropertyDescriptor(property, targetType, dependencyProperty);
                    CachedDpd.TryAdd(property, dpd);
                }
            }

            return dpd;
        }

        public CoerceValueCallback DesignerCoerceValueCallback { get; set; }

        #region internal methods

        internal static DependencyPropertyDescriptor FromProperty(DependencyProperty dependencyProperty)
        {
            if (dependencyProperty == null)
                throw new ArgumentNullException("dependencyProperty");

            #region find PropertyDescriptor

            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(dependencyProperty.OwnerType);
            /*foreach (PropertyDescriptor pd in pdc)
            {
                if (pd.Name == dependencyProperty.Name)
                {
                    property = pd;
                    break;
                }
            }*/
            var property = pdc.Cast<PropertyDescriptor>().FirstOrDefault(pd => pd.Name == dependencyProperty.Name);

            #endregion

            DependencyPropertyDescriptor dpd = null;
            if (property != null)
            {
                if (!CachedDpd.TryGetValue(property, out dpd))
                {
                    dpd = new DependencyPropertyDescriptor(property, dependencyProperty.OwnerType, dependencyProperty);
                    CachedDpd.TryAdd(property, dpd);
                }
            }

            return dpd;
        }

        #endregion
    }
}
