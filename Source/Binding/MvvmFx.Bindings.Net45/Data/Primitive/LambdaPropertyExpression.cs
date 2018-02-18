using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using MvvmFx.Bindings.Properties;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// A <see cref="PropertyExpression"/> that uses a <see cref="LambdaExpression"/> to resolve its property.
    /// </summary>
    [DebuggerDisplay("Value={Value}, PropertyType={PropertyType}, FinalPart={_finalPart}, NumberOfParts={_parts.Count}")]
    public sealed class LambdaPropertyExpression : PropertyExpression
    {
        private LambdaPropertyExpression(object obj, IEnumerable<PropertyExpressionPart> parts)
            : base(obj, parts)
        {
        }

        /// <summary>
        /// Creates a <see cref="LambdaPropertyExpression" /> from a given lambda expression.
        /// </summary>
        /// <param name="obj">The object against which the lambda expression will be resolved.</param>
        /// <param name="lambdaExpression">The lambda expression.</param>
        /// <param name="bindOnValidation">if set to <c>true</c> the bound value should be updated on property validation.</param>
        /// <returns>
        /// A <see cref="LambdaPropertyExpression" /> based on the supplied lambda expression.
        /// </returns>
        /// <exception cref="ArgumentNullException">lambdaExpression</exception>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        public static LambdaPropertyExpression FromLambdaExpression(object obj, LambdaExpression lambdaExpression, bool bindOnValidation)
        {
            if(lambdaExpression == null)
                throw new ArgumentNullException("lambdaExpression");

            var propertyExpressionParts = new List<PropertyExpressionPart>();
            var currentMemberExpression = DetermineMemberExpression(lambdaExpression, lambdaExpression.Body);
            MemberExpressionPropertyExpressionPart nextPart = null;

            while (currentMemberExpression != null)
            {
                var part = new MemberExpressionPropertyExpressionPart(nextPart, currentMemberExpression, bindOnValidation);
                nextPart = part;
                propertyExpressionParts.Insert(0, part);
                currentMemberExpression = currentMemberExpression.Expression as MemberExpression;
            }

            return new LambdaPropertyExpression(obj, propertyExpressionParts);
        }

        private static MemberExpression DetermineMemberExpression(LambdaExpression lambdaExpression, System.Linq.Expressions.Expression expression)
        {
            var memberExpression = expression as MemberExpression;

            if (memberExpression != null)
            {
                //this is the common case
                return memberExpression;
            }

            var unaryExpression = expression as UnaryExpression;

            if (unaryExpression != null &&
                (unaryExpression.NodeType == ExpressionType.Convert ||
                 unaryExpression.NodeType == ExpressionType.ConvertChecked))
            {
                return DetermineMemberExpression(lambdaExpression, unaryExpression.Operand);
            }
            throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.UnsupportedExpression, lambdaExpression));
        }

        /// <summary>
        /// An implementation of PropertyExpressionPart that uses a member expression to resolve the underlying property.
        /// </summary>
        private sealed class MemberExpressionPropertyExpressionPart : PropertyExpressionPart
        {
            private readonly PropertyInfo _propertyInfo;

            public MemberExpressionPropertyExpressionPart(MemberExpressionPropertyExpressionPart nextPart, MemberExpression memberExpression, bool bindOnValidation)
                : base(nextPart, bindOnValidation)
            {
                Debug.Assert(memberExpression != null);
                _propertyInfo = memberExpression.Member as PropertyInfo;
            }

            public override string PropertyName
            {
                get { return _propertyInfo.Name; }
            }

            public override Type PropertyType
            {
                get { return _propertyInfo.PropertyType; }
            }

            protected override object GetValueCore()
            {
                var obj = Object;

                if (obj == null)
                {
                    return null;
                }

                return _propertyInfo.GetValue(obj, null);
            }

            protected override void SetValueCore(object value)
            {
                var obj = Object;

                if (obj == null)
                {
                    return;
                }

                _propertyInfo.SetValue(obj, value, null);
            }
        }
    }
}
