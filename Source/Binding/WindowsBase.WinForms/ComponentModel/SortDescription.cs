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
using System.ComponentModel;

namespace MvvmFx.ComponentModel
{
    /// <summary>
    /// SortDescription
    /// </summary>
    public struct SortDescription
    {
        private string _sortPropertyName;
        private ListSortDirection _sortDirection;
        private bool _isSealed;

        public SortDescription(string propertyName, ListSortDirection direction)
        {
            if (direction != ListSortDirection.Ascending && direction != ListSortDirection.Descending)
                throw new InvalidEnumArgumentException("direction", (int) direction, typeof (ListSortDirection));

            _sortPropertyName = propertyName;
            _sortDirection = direction;
            _isSealed = false;
        }

        public static bool operator !=(SortDescription sd1, SortDescription sd2)
        {
            return !(sd1 == sd2);
        }

        public static bool operator ==(SortDescription sd1, SortDescription sd2)
        {
            return sd1._sortDirection == sd2._sortDirection && sd1._sortPropertyName == sd2._sortPropertyName;
        }

        public ListSortDirection Direction
        {
            get { return _sortDirection; }
            set
            {
                if (_isSealed)
                    throw new InvalidOperationException(
                        "Cannot change Direction once the Sort Description has been sealed.");

                if (value != ListSortDirection.Ascending && value != ListSortDirection.Descending)
                    throw new InvalidEnumArgumentException("value", (int) value, typeof (ListSortDirection));

                _sortDirection = value;
            }
        }

        public bool IsSealed
        {
            get { return _isSealed; }
        }

        public string PropertyName
        {
            get { return _sortPropertyName; }
            set
            {
                if (_isSealed)
                    throw new InvalidOperationException(
                        "Cannot change Direction once the Sort Description has been sealed.");

                _sortPropertyName = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SortDescription))
                return false;
            return ((SortDescription) obj) == this;
        }

        public override int GetHashCode()
        {
            if (_sortPropertyName == null)
                return _sortDirection.GetHashCode();

            return _sortPropertyName.GetHashCode() ^ _sortDirection.GetHashCode();
        }

        internal void Seal()
        {
            _isSealed = true;
        }
    }
}
