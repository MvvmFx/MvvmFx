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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//	Brian O'Keefe (zer0keefie@gmail.com)
//
using System;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.ComponentModel
{
    /// <summary>
    /// PropertyFilterAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class PropertyFilterAttribute : Attribute
    {
        [SuppressMessage("Microsoft.Security", "CA2104", Justification = "The feature isn't implemented.")]
        public static readonly PropertyFilterAttribute Default = new PropertyFilterAttribute(PropertyFilterOptions.All);

        private PropertyFilterOptions _options;

        private PropertyFilterAttribute()
        {
        }

        public PropertyFilterAttribute(PropertyFilterOptions filter)
            : this()
        {
            _options = filter;
        }

        public PropertyFilterOptions Filter
        {
            get { return _options; }
        }

        [SuppressMessage("Microsoft.Naming", "CA1725", Justification = "Resemblance with original signature.")]
        public override bool Equals(object value)
        {
            /*if (!(value is PropertyFilterAttribute))
                return false;
            return ((PropertyFilterAttribute) value).options == options;*/
            var propertyFilterAttribute = value as PropertyFilterAttribute;
            if (propertyFilterAttribute == null)
                return false;

            return propertyFilterAttribute._options == _options;
        }

        public override int GetHashCode()
        {
            return _options.GetHashCode();
        }

        [SuppressMessage("Microsoft.Naming", "CA1725", Justification = "Resemblance with original signature.")]
        public override bool Match(object value)
        {
            /*if (!(value is PropertyFilterAttribute))
                return false;

            PropertyFilterOptions other = ((PropertyFilterAttribute) value).options;*/

            var propertyFilterAttribute  = value as PropertyFilterAttribute;
            if (propertyFilterAttribute == null)
                return false;

            PropertyFilterOptions other = propertyFilterAttribute._options;
            PropertyFilterOptions common = other & _options;

            return common == _options;
        }
    }
}
