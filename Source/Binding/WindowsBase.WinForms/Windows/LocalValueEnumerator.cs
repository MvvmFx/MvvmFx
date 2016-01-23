//
// LocalValueEnumerator.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//
// (C) 2005 Iain McCoy
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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Windows
{
    /// <summary>
    /// LocalValueEnumerator
    /// </summary>
    /// <remarks>This class isn't completely implemented.</remarks>
    public struct LocalValueEnumerator : IEnumerator
    {
        private IDictionaryEnumerator _propertyEnumerator;
        private Dictionary<DependencyProperty, object> _properties;
        private int _count;

        internal LocalValueEnumerator(Dictionary<DependencyProperty, object> properties)
        {
            _count = properties.Count;
            _properties = properties;
            _propertyEnumerator = properties.GetEnumerator();
        }

        public int Count
        {
            get { return _count; }
        }

        public LocalValueEntry Current
        {
            get
            {
                return new LocalValueEntry((DependencyProperty) _propertyEnumerator.Key, _propertyEnumerator.Value);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            return _propertyEnumerator.MoveNext();
        }

        public void Reset()
        {
            _propertyEnumerator.Reset();
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator !=(LocalValueEnumerator obj1, LocalValueEnumerator obj2)
        {
            throw new NotImplementedException("LocalValueEnumerator");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator ==(LocalValueEnumerator obj1, LocalValueEnumerator obj2)
        {
            throw new NotImplementedException("LocalValueEnumerator");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        public override bool Equals(object obj)
        {
            throw new NotImplementedException("LocalValueEnumerator.Equals");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        public override int GetHashCode()
        {
            throw new NotImplementedException("LocalValueEnumerator.GetHashCode");
        }
    }
}
