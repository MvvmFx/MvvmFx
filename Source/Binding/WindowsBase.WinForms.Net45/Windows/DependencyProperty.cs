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
// (C) 2005 Iain McCoy
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
// Copyright (c) 2012 MvvmFx project (http://mvvmfx.codeplex.com)
//
// Authors:
//	Iain McCoy (iain@mccoy.id.au)
//	Chris Toshok (toshok@ximian.com)
//  Tiago Freitas Leal
//
using System;
using System.Collections.Concurrent;
using System.Globalization;
using MvvmFx.Properties;

namespace MvvmFx.Windows
{
    /// <summary>
    /// Represents a WPF like dependency property that accepts specifications for a default value and callbacks for property changed, coerce value and validate.
    /// </summary>
    public sealed class DependencyProperty
    {
        private static int _lastGlobalIndex;
        private readonly int _globalIndex;

        private readonly ConcurrentDictionary<Type, PropertyMetadata> _metadataByType = new ConcurrentDictionary<Type, PropertyMetadata>();

        public static readonly object UnsetValue = new object();

        private DependencyProperty(bool isAttached, string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata, ValidateValueCallback validateValueCallback)
        {
            if (defaultMetadata == null)
                defaultMetadata = new PropertyMetadata();

            if (defaultMetadata.DefaultValue == null)
            {
                var defaultValue = AutoDefaultValue(propertyType);
                if (validateValueCallback != null && !validateValueCallback(defaultValue))
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Failed to auto generate default value."), "defaultMetadata");
                defaultMetadata.DefaultValue = defaultValue;
            }

            _globalIndex = System.Threading.Interlocked.Increment(ref _lastGlobalIndex);
            IsAttached = isAttached;
            DefaultMetadata = defaultMetadata;
            Name = name;
            OwnerType = ownerType;
            PropertyType = propertyType;
            ValidateValueCallback = validateValueCallback;
        }

        internal bool IsAttached { get; set; }

        public bool ReadOnly { get; private set; }

        public PropertyMetadata DefaultMetadata { get; private set; }

        public string Name { get; private set; }

        public Type OwnerType {get; private set; }

        public Type PropertyType { get; private set; }

        public ValidateValueCallback ValidateValueCallback { get; private set; }

        public int GlobalIndex
        {
            get { return _globalIndex; }
        }

        public DependencyProperty AddOwner(Type ownerType)
        {
            return AddOwner(ownerType, null);
        }

        public DependencyProperty AddOwner(Type ownerType, PropertyMetadata typeMetadata)
        {
            DependencyObject.Register(ownerType, this);

            if (typeMetadata == null)
                typeMetadata = new PropertyMetadata();

            OverrideMetadata(ownerType, typeMetadata);

            // MS seems to always return the same DependencyProperty
            return this;
        }

        public PropertyMetadata GetMetadata(Type forType)
        {
            PropertyMetadata metadata = null;
            if (_metadataByType.ContainsKey(forType))
                _metadataByType.TryGetValue(forType, out metadata);

            return metadata;
        }

        public PropertyMetadata GetMetadata(IDependencyObject dependencyObject)
        {
            if (dependencyObject != null)
                return GetMetadata(dependencyObject.GetType());

            return null;
        }

        public PropertyMetadata GetMetadata(DependencyObjectType dependencyObjectType)
        {
            if (dependencyObjectType != null)
                return GetMetadata(dependencyObjectType.SystemType);

            return null;
        }

        public bool IsValidType(object value)
        {
            return IsValidTypeCore(value);
        }

        public bool IsValidValue(object value)
        {
            if (!IsValidTypeCore(value))
                return false;

            if (ValidateValueCallback == null)
                return true;

            return ValidateValueCallback(value);
        }

        public void OverrideMetadata(Type forType, PropertyMetadata typeMetadata)
        {
            if (forType == null)
                throw new ArgumentNullException("forType");
            if (typeMetadata == null)
                throw new ArgumentNullException("typeMetadata");

            if (ReadOnly)
                throw new InvalidOperationException(
                    String.Format(CultureInfo.InvariantCulture,
                                  Resources.CannotOverrideMetadataOnReadonlyPropertyWithoutUsingDependencyPropertyKey,
                                  Name));

            typeMetadata.DoMerge(DefaultMetadata, this, forType);
            _metadataByType.TryAdd(forType, typeMetadata);
        }

        public void OverrideMetadata(Type forType, PropertyMetadata typeMetadata, DependencyPropertyKey key)
        {
            if (forType == null)
                throw new ArgumentNullException("forType");
            if (typeMetadata == null)
                throw new ArgumentNullException("typeMetadata");
            if (key == null)
                throw new ArgumentNullException("key");

            // further checking?  should we check
            // key.DependencyProperty == this?

            typeMetadata.DoMerge(DefaultMetadata, this, forType);
            _metadataByType.TryAdd(forType, typeMetadata);
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return GlobalIndex;
            //return Name.GetHashCode() ^ PropertyType.GetHashCode() ^ OwnerType.GetHashCode();
        }

        public static DependencyProperty Register(string name, Type propertyType, Type ownerType)
        {
            return Register(name, propertyType, ownerType, null, null);
        }

        public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
        {
            return Register(name, propertyType, ownerType, typeMetadata, null);
        }

        public static DependencyProperty Register(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata, ValidateValueCallback validateValueCallback)
        {
            ValidateRegisterParameters(name, propertyType, ownerType);
            var dp = new DependencyProperty(false, name, propertyType, ownerType, typeMetadata, validateValueCallback);
            DependencyObject.Register(ownerType, dp);

            // is this needed?
            //dp.OverrideMetadata(ownerType, typeMetadata);

            return dp;
        }

        public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType)
        {
            return RegisterAttached(name, propertyType, ownerType, null, null);
        }

        public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata)
        {
            return RegisterAttached(name, propertyType, ownerType, defaultMetadata, null);
        }

        public static DependencyProperty RegisterAttached(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata, ValidateValueCallback validateValueCallback)
        {
            ValidateRegisterParameters(name, propertyType, ownerType);
            var dp = new DependencyProperty(true, name, propertyType, ownerType, defaultMetadata, validateValueCallback);
            DependencyObject.Register(ownerType, dp);
            return dp;
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata)
        {
            return RegisterAttachedReadOnly(name, propertyType, ownerType, defaultMetadata, null);
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly(string name, Type propertyType, Type ownerType, PropertyMetadata defaultMetadata, ValidateValueCallback validateValueCallback)
        {
            ValidateRegisterParameters(name, propertyType, ownerType);
            DependencyProperty dp = RegisterAttached(name, propertyType, ownerType, defaultMetadata, validateValueCallback);
            dp.ReadOnly = true;
            return new DependencyPropertyKey(dp);
        }

        public static DependencyPropertyKey RegisterReadOnly(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
        {
            return RegisterReadOnly(name, propertyType, ownerType, typeMetadata, null);
        }

        public static DependencyPropertyKey RegisterReadOnly(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata, ValidateValueCallback validateValueCallback)
        {
            ValidateRegisterParameters(name, propertyType, ownerType);
            DependencyProperty dp = Register(name, propertyType, ownerType, typeMetadata, validateValueCallback);
            dp.ReadOnly = true;
            return new DependencyPropertyKey(dp);
        }

        #region internal methods

        internal static DependencyProperty FromName(string name, Type ownerType)
        {
            DependencyProperty dp = null;

            while ((dp == null) && (ownerType != null))
            {
                System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(ownerType.TypeHandle);
                dp = DependencyObject.FromName(name, ownerType);
                ownerType = ownerType.BaseType;
            }

            return dp;
        }

        internal bool IsValidTypeCore(object value)
        {
            if (value == null)
            {
                if (PropertyType.IsValueType &&
                    !(PropertyType.IsGenericType && PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    return false;
            }
            else
            {
                return PropertyType.IsInstanceOfType(value);
            }

            return true;
        }

        #endregion

        #region private methods

        private static void ValidateRegisterParameters(string name, Type propertyType, Type ownerType)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (propertyType == null)
                throw new ArgumentNullException("propertyType");
            if (ownerType == null)
                throw new ArgumentNullException("ownerType");

            if (name.Length == 0)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Not an empty string."), "name");
        }

        private static object AutoDefaultValue(Type propertyType)
        {
            if (propertyType.IsValueType)
            {
                return Activator.CreateInstance(propertyType);
            }

            return null;
        }

        #endregion
    }
}
