using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Connects a target property to a single source property using lambda expression to resolve the bound properties on the target
    /// and source objects.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of the <c>TypedBinding</c> class can be used to connect together two properties. The properties are specified via
    /// lambda expression, so they are checked at compile-time. Because of this, it is recommended that a <c>TypedBinding</c>be used in
    /// preference to a <see cref="Binding"/> wherever possible.
    /// </para>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="TypedBinding.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="TypedBinding.Simple.Fluent"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="TypedBinding.Complex"]/*'/>
    /// <typeparam name="TTarget">
    /// The type of the target object.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// The type of the source object.
    /// </typeparam>
    public class TypedBinding<TTarget, TSource> : SingleSourceBinding
    {
        private Expression<Func<TTarget, object>> _targetExpression;
        private Expression<Func<TSource, object>> _sourceExpression;

        /// <summary>
        /// Constructs an instance of <c>TypedBinding</c>.
        /// </summary>
        public TypedBinding()
        {
        }

        /// <summary>
        /// Constructs an instance of <c>TypedBinding</c> using the specified details.
        /// </summary>
        /// <param name="targetObject">
        /// The target object for the binding.
        /// </param>
        /// <param name="targetExpression">
        /// A lambda expression used to resolve the bound property on the target object.
        /// </param>
        /// <param name="sourceObject">
        /// The source object for the binding.
        /// </param>
        /// <param name="sourceExpression">
        /// A lambda expression used to resolve the bound property on the source object.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public TypedBinding(TTarget targetObject, Expression<Func<TTarget, object>> targetExpression,
                            TSource sourceObject, Expression<Func<TSource, object>> sourceExpression)
        {
            TargetObject = targetObject;
            SourceObject = sourceObject;
            _targetExpression = targetExpression;
            _sourceExpression = sourceExpression;
        }

        /// <summary>
        /// Gets or sets the target lambda expression for this <c>TypedBinding</c>.
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
        /// Gets or sets the source lambda expression for this <c>TypedBinding</c>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public Expression<Func<TSource, object>> SourceExpression
        {
            get { return _sourceExpression; }
            set
            {
                VerifyNotActivated();
                _sourceExpression = value;
            }
        }

        /// <summary>
        /// Attempts to create the <see cref="PropertyExpression"/> for this <c>TypedBinding</c>'s target.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyExpression"/>, or <see langword="null"/> if the property expression cannot be created.
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

        /// <summary>
        /// Attempts to create the <see cref="PropertyExpression"/> for this <c>TypedBinding</c>'s source.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyExpression"/>, or <see langword="null"/> if the property expression cannot be created.
        /// </returns>
        protected override PropertyExpression AttemptCreateSourcePropertyExpression()
        {
            var sourceObject = SourceObject;

            if (sourceObject == null || _sourceExpression == null)
            {
                return null;
            }

            return LambdaPropertyExpression.FromLambdaExpression(sourceObject, _sourceExpression, BindOnValidation);
        }
    }
}
