using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MvvmFx.Bindings.Diagnostics;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// A <see cref="PropertyExpression"/> that accepts a <see cref="String"/> in standard property accessor syntax.
    /// </summary>
    public sealed class PathPropertyExpression : PropertyExpression
    {
        private PathPropertyExpression(object obj, IEnumerable<PropertyExpressionPart> parts)
            : base(obj, parts)
        {
        }

        /// <summary>
        /// Creates a <see cref="PathPropertyExpression" /> from a given path.
        /// </summary>
        /// <param name="obj">The object against which the path will be resolved.</param>
        /// <param name="path">The path.</param>
        /// <param name="bindOnValidation">if set to <c>true</c> the bound value should be updated on property validation.</param>
        /// <returns>
        /// A <see cref="PathPropertyExpression" /> based on the supplied path.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// obj
        /// or
        /// path
        /// </exception>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        [SuppressMessage("Microsoft.Design", "CA1062", Justification = "'path' is checked not null or ArgumentNullException will be thrown.")]
        public static PathPropertyExpression FromPath(object obj, string path, bool bindOnValidation)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (path == null)
                throw new ArgumentNullException("path");

            var pathParts = path.Split('.');
            var propertyExpressionParts = new List<PropertyExpressionPart>(pathParts.Length);
            PathPropertyExpressionPart nextPart = null;

            for (var i = pathParts.Length - 1; i >= 0; --i)
            {
                var part = new PathPropertyExpressionPart(nextPart, pathParts[i], bindOnValidation);
                nextPart = part;
                propertyExpressionParts.Insert(0, part);
            }

            return new PathPropertyExpression(obj, propertyExpressionParts);
        }

        /// <summary>
        /// An implementation of PropertyExpressionPart that uses a path part to resolve the underlying property.
        /// </summary>
        private sealed class PathPropertyExpressionPart : PropertyExpressionPart
        {
            private readonly string _pathPart;
            private PropertyDescriptor _propertyDescriptor;

            public PathPropertyExpressionPart(PathPropertyExpressionPart nextPart, string pathPart, bool bindOnValidation)
                : base(nextPart, bindOnValidation)
            {
                Debug.Assert(pathPart != null);
                _pathPart = pathPart;
            }

            public override string PropertyName
            {
                get { return _pathPart; }
            }

            public override Type PropertyType
            {
                get { return _propertyDescriptor == null ? null : _propertyDescriptor.PropertyType; }
            }

            protected override object GetValueCore()
            {
                var obj = Object;

                if (obj == null || _propertyDescriptor == null)
                {
                    return Unresolved;
                }

                return _propertyDescriptor.GetValue(obj);
            }

            protected override void SetValueCore(object value)
            {
                var obj = Object;

                if (obj == null || _propertyDescriptor == null)
                {
                    return;
                }

                _propertyDescriptor.SetValue(obj, value);
            }

            protected override void OnValueChanged()
            {
                //update our PropertyInfo instance whenever the object changes for this expression part changes
                var obj = Object;

                if (obj == null)
                {
                    _propertyDescriptor = null;
                }
                else
                {
                    _propertyDescriptor = TypeDescriptor.GetProperties(obj).Find(_pathPart, false);

                    if (_propertyDescriptor == null)
                    {
                        Log.Write(TraceEventType.Warning,
                                  "Binding failure: unable to resolve property '{0}' on type '{1}'.", _pathPart,
                                  obj.GetType().FullName);
                    }
                }

                base.OnValueChanged();
            }
        }
    }
}
