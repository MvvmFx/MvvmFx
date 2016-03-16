//
// DependencyObject.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Chris Toshok (toshok@ximian.com)
//   Tiago Freitas Leal
//
// (C) 2005 Iain McCoy
// (C) 2007 Novell, Inc.
// Copyright (c) 2012 MvvmFx project (http://mvvmfx.codeplex.com)
//
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
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MvvmFx.ComponentModel;

namespace MvvmFx.Windows
{
    /// <summary>
    /// Represents an object that participates in the dependency property system.
    /// </summary>
    /// <remarks>This implementation of this class isn't completed.</remarks>
    public class DependencyObject : IDependencyObject
    {
        // for each (owner) Type, keeps a list of key value pairs of: DP name / DP object
        private static readonly Dictionary<Type, Dictionary<string, DependencyProperty>> PropertyDeclarations =
            new Dictionary<Type, Dictionary<string, DependencyProperty>>();

        // keeps a list of key value pairs of: DP object / value
        private readonly Dictionary<DependencyProperty, object> _properties = new Dictionary<DependencyProperty, object>();

        public bool IsSealed
        {
            get { return false; }
        }

        public DependencyObjectType DependencyObjectType
        {
            get { return DependencyObjectType.FromSystemType(GetType()); }
        }

        public void ClearValue(DependencyPropertyKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            ClearValue(key.DependencyProperty);
        }

        public void ClearValue(DependencyProperty dp)
        {
            if (IsSealed)
                throw new InvalidOperationException("Cannot manipulate property values on a sealed Dependency Object");

            _properties[dp] = null;
        }

        public void CoerceValue(DependencyProperty dp)
        {
            if (dp == null)
                throw new ArgumentNullException("dp");

            PropertyMetadata pm = dp.GetMetadata(this);
            if (pm.CoerceValueCallback != null)
                pm.CoerceValueCallback(this, GetValue(dp));
        }

        public override sealed bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override sealed int GetHashCode()
        {
            return base.GetHashCode();
        }

        public LocalValueEnumerator GetLocalValueEnumerator()
        {
            return new LocalValueEnumerator(_properties);
        }

        public object GetValue(DependencyProperty dp)
        {
            if (dp == null)
                throw new ArgumentNullException("dp");

            if (_properties.ContainsKey(dp))
            {
                object val = _properties[dp];
                return val ?? dp.DefaultMetadata.DefaultValue;
                //return val == null ? dp.DefaultMetadata.DefaultValue : val;
            }
            return dp.DefaultMetadata.DefaultValue;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Naming", "CA2204", Justification = "Debug while the feature isn't implemented.")]
        public void InvalidateProperty(DependencyProperty dp)
        {
            throw new NotImplementedException("DependencyObject - InvalidateProperty(DependencyProperty dp)");
        }

        protected virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            PropertyMetadata pm = e.Property.GetMetadata(this);
            if (pm != null && pm.PropertyChangedCallback != null)
                pm.PropertyChangedCallback(this, e);
        }

        public object ReadLocalValue(DependencyProperty dp)
        {
            object val = _properties[dp];
            return val == null ? DependencyProperty.UnsetValue : val;
        }

        public void SetValue(DependencyPropertyKey key, object value)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            SetValue(key.DependencyProperty, value);
        }

        public void SetValue(DependencyProperty dp, object value)
        {
            if (IsSealed)
                throw new InvalidOperationException("Cannot manipulate property values on a sealed Dependency Object");

//            if (dp.ReadOnly)
//                throw new InvalidOperationException("Cannot manipulate read-only Dependency Property");

            if (dp == null)
                throw new ArgumentNullException("dp");

            if (!dp.IsValidType(value))
                throw new ArgumentException("Value not of the correct type for this Dependency Property");

            ValidateValueCallback validate = dp.ValidateValueCallback;
            if (validate != null && !validate(value))
                throw new ArgumentException("Value does not validate");

            object oldValue = null;
            if(_properties.ContainsKey(dp))
                oldValue = _properties[dp];

            if (!Equals(oldValue, value))
            {
                _properties[dp] = value;
                var property = DependencyPropertyDescriptor.FromProperty(dp);
                if (property != null)
                    property.OnValueChanged(this);

                OnPropertyChanged(new DependencyPropertyChangedEventArgs(dp, oldValue, value));
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA2204", Justification = "Debug while the feature isn't implemented.")]
        protected virtual bool ShouldSerializeProperty(DependencyProperty dp)
        {
            throw new NotImplementedException("DependencyObject - ShouldSerializeProperty(DependencyProperty dp)");
        }

        internal static void Register(Type t, DependencyProperty dp)
        {
            if (!PropertyDeclarations.ContainsKey(t))
                PropertyDeclarations[t] = new Dictionary<string, DependencyProperty>();

            Dictionary<string, DependencyProperty> typeDeclarations = PropertyDeclarations[t];
            if (!typeDeclarations.ContainsKey(dp.Name))
                typeDeclarations[dp.Name] = dp;
            else
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "'{0}' property was already registered by '{1}'.", dp.Name, t.Name));
        }

        internal static DependencyProperty FromName(string name, Type t)
        {
            if (PropertyDeclarations.ContainsKey(t))
            {
                Dictionary<string, DependencyProperty> typeDeclarations = PropertyDeclarations[t];
                if (typeDeclarations.ContainsKey(name))
                    return typeDeclarations[name];
            }

            return null;
        }
    }
}
