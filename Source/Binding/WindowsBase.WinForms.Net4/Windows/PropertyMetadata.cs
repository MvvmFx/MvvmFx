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
//
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//   Iain McCoy (iain@mccoy.id.au)
//   Chris Toshok (toshok@ximian.com)
//
using System;

namespace MvvmFx.Windows
{
    /// <summary>
    /// PropertyMetadata
    /// </summary>
    public class PropertyMetadata
    {
        private object _defaultValue;
        private bool _isSealed;
        private PropertyChangedCallback _propertyChangedCallback;
        private CoerceValueCallback _coerceValueCallback;

        protected bool IsSealed
        {
            get { return _isSealed; }
        }

        public object DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                if (IsSealed)
                    throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");

                if (value == DependencyProperty.UnsetValue)
                    throw new ArgumentException("Cannot set property metadata's default value to 'Unset'");

                _defaultValue = value;
            }
        }

        public PropertyChangedCallback PropertyChangedCallback
        {
            get { return _propertyChangedCallback; }
            set
            {
                if (IsSealed)
                    throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");

                _propertyChangedCallback = value;
            }
        }

        public CoerceValueCallback CoerceValueCallback
        {
            get { return _coerceValueCallback; }
            set
            {
                if (IsSealed)
                    throw new InvalidOperationException("Cannot change metadata once it has been applied to a property");

                _coerceValueCallback = value;
            }
        }

        public PropertyMetadata()
            : this(null, null, null)
        {
        }

        public PropertyMetadata(object defaultValue)
            : this(defaultValue, null, null)
        {
        }

        public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
            : this(null, propertyChangedCallback, null)
        {
        }

        public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
            : this(defaultValue, propertyChangedCallback, null)
        {
        }

        public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback,
                                CoerceValueCallback coerceValueCallback)
        {
            if (defaultValue == DependencyProperty.UnsetValue)
                throw new ArgumentException("Cannot initialize property metadata's default value to 'Unset'");

            _defaultValue = defaultValue;
            _propertyChangedCallback = propertyChangedCallback;
            _coerceValueCallback = coerceValueCallback;
        }

        protected virtual void Merge(PropertyMetadata baseMetadata, DependencyProperty dp)
        {
            if (baseMetadata == null)
                throw new ArgumentNullException("baseMetadata");

            if (dp == null)
                throw new ArgumentNullException("dp");

            if (_defaultValue == null)
                _defaultValue = baseMetadata._defaultValue;

            if (_propertyChangedCallback == null)
                _propertyChangedCallback = baseMetadata._propertyChangedCallback;

            if (_coerceValueCallback == null)
                _coerceValueCallback = baseMetadata._coerceValueCallback;
        }

        protected virtual void OnApply(DependencyProperty dp, Type targetType)
        {
        }

        internal void DoMerge(PropertyMetadata baseMetadata, DependencyProperty dp, Type targetType)
        {
            Merge(baseMetadata, dp);
            OnApply(dp, targetType);
            _isSealed = true;
        }
    }
}
