using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Connects a target property to multiple source properties using a lambda expression to resolve the target property.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of the <c>TypedMultiBinding</c> class can be used to connect together multiple source properties to a single target
    /// property. The target property is specified via a lambda expression, so it is checked at compile-time. Because of this, it is
    /// recommended that a <c>TypedMultiBinding</c>be used in preference to a <see cref="MultiBinding"/> wherever possible.
    /// </para>
    /// <para>
    /// The bindings comprising the sources for the <c>TypedMultiBinding</c> must be added to the <see cref="MultiSourceBinding.Sources"/>
    /// collection prior to activation. Only <see cref="SingleSourceBinding"/>s are supported, and target information for those bindings
    /// must be absent. Only the source information should be provided.
    /// </para>
    /// <para>
    /// A <c>TypedMultiBinding</c> always requires a converter be set via the <see cref="MultiSourceBinding.Converter"/> property before
    /// it can be activated.
    /// </para>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="TypedMultiBinding.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="TypedMultiBinding.Simple.Fluent"]/*'/>
    /// <typeparam name="TTarget">
    /// The type of the target object.
    /// </typeparam>
    public class TypedMultiBinding<TTarget> : MultiSourceBinding
    {
        private Expression<Func<TTarget, object>> _targetExpression;

        /// <summary>
        /// Constructs an instance of <c>TypedMultiBinding</c>.
        /// </summary>
        public TypedMultiBinding()
        {
        }

        /// <summary>
        /// Constructs an instance of <c>TypedMultiBinding</c> using the specified information.
        /// </summary>
        /// <param name="targetObject">
        /// The target object for the binding.
        /// </param>
        /// <param name="targetExpression">
        /// A lambda expression used to resolve the bound property on the target object.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public TypedMultiBinding(TTarget targetObject, Expression<Func<TTarget, object>> targetExpression)
        {
            TargetObject = targetObject;
            _targetExpression = targetExpression;
        }

        /// <summary>
        /// Gets or sets the target lambda expression for this <c>TypedMultiBinding</c>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public Expression<Func<TTarget, object>> TargetExpression
        {
            get { return _targetExpression; }
            set
            {
                VerifyNotActivated();
                _targetExpression = value;
            }
        }

        /// <summary>
        /// Attempts to create the target property expressions for this <c>TypedMultiBinding</c>.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the target property expression was successfully created, otherwise <see langword="false"/>.
        /// </returns>
        protected override PropertyExpression AttemptCreateTargetPropertyExpression()
        {
            var targetObject = TargetObject;

            if (targetObject == null || _targetExpression == null)
            {
                return null;
            }

            return LambdaPropertyExpression.FromLambdaExpression(targetObject, _targetExpression, BindOnValidation);
        }
    }
}
