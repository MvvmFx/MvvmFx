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
// (C) 2007 Novell, Inc.
//
// Authors:
//   Iain McCoy (iain@mccoy.id.au)
//   Chris Toshok (toshok@ximian.com)
//
//
using System;
using System.Collections.Generic;

namespace MvvmFx.Bindings
{
    /// <summary>
    /// DependencyObjectType
    /// </summary>
    public class DependencyObjectType
    {
        private static Dictionary<Type, DependencyObjectType> _typeMap = new Dictionary<Type, DependencyObjectType>();
        private static int _currentID;

        private int _id;
        private Type _systemType;

        private DependencyObjectType(int id, Type systemType)
        {
            _id = id;
            _systemType = systemType;
        }

        public DependencyObjectType BaseType
        {
            get { return FromSystemType(_systemType.BaseType); }
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _systemType.Name; }
        }

        public Type SystemType
        {
            get { return _systemType; }
        }

        public static DependencyObjectType FromSystemType(Type systemType)
        {
            if (_typeMap.ContainsKey(systemType))
                return _typeMap[systemType];

            DependencyObjectType dot;

            _typeMap[systemType] = dot = new DependencyObjectType(_currentID++, systemType);

            return dot;
        }

        public bool IsInstanceOfType(DependencyObject dependencyObject)
        {
            return _systemType.IsInstanceOfType(dependencyObject);
        }

        public bool IsSubclassOf(DependencyObjectType dependencyObjectType)
        {
            return dependencyObjectType != null && _systemType.IsSubclassOf(dependencyObjectType.SystemType);
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}
