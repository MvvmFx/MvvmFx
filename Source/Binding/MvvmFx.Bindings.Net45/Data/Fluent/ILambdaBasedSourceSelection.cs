using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Allows the source to be specified for a lamda-based binding fluent expression.
    /// </summary>
    public interface ILambdaBasedSourceSelection : IHideObjectMembers
    {
        /// <summary>
        /// Binds to the source with the specified expression.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the source object.
        /// </typeparam>
        /// <param name="sourceObject">
        /// The source object.
        /// </param>
        /// <param name="sourceExpression">
        /// The expression that resolves to a property within the source object.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        [SuppressMessage("Microsoft.Naming", "CA1716", Justification = "Member is not designed to be implemented by consumers.")]
        ISingleSourceBindingOptions To<TSource>(TSource sourceObject, Expression<Func<TSource, object>> sourceExpression);
    }
}
