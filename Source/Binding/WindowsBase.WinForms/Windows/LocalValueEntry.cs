//
// LocalValueEntry.cs
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
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Windows
{
    /// <summary>
    /// LocalValueEntry
    /// </summary>
    /// <remarks>This class isn't implemented.</remarks>
    public struct LocalValueEntry
    {
        private DependencyProperty _property;
        private object _value;

        internal LocalValueEntry(DependencyProperty property, object value)
        {
            _property = property;
            _value = value;
        }

        public DependencyProperty Property
        {
            get { return _property; }
        }

        public object Value
        {
            get { return _value; }
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator !=(LocalValueEntry obj1, LocalValueEntry obj2)
        {
            throw new NotImplementedException("LocalValueEntry");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public static bool operator ==(LocalValueEntry obj1, LocalValueEntry obj2)
        {
            throw new NotImplementedException("LocalValueEntry");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public override bool Equals(object obj)
        {
            throw new NotImplementedException("LocalValueEntry.Equals");
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        public override int GetHashCode()
        {
            throw new NotImplementedException("LocalValueEntry.GetHashCode");
        }
    }
}
