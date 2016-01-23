using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Provides options for a multi-source binding fluent expression.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702", Justification = "'Multi' and 'Source' are two words and the intention is to use them as such.")]
    public interface IMultiSourceBindingOptions : IModeSelection<IMultiSourceBindingOptions>
    {
        /// <summary>
        /// Binds to a source object with the specified path.
        /// </summary>
        /// <param name="sourceObject">
        /// The source object.
        /// </param>
        /// <param name="sourcePath">
        /// The path within the source object to bind to.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        [SuppressMessage("Microsoft.Naming", "CA1716", Justification = "Member is not designed to be implemented by consumers.")]
        ISubsequentSourceBindingOptions To(object sourceObject, string sourcePath);

        /// <summary>
        /// Binds to a source object with the specified expression.
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
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        [SuppressMessage("Microsoft.Naming", "CA1716", Justification = "Member is not designed to be implemented by consumers.")]
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        ISubsequentSourceBindingOptions To<TSource>(TSource sourceObject, Expression<Func<TSource, object>> sourceExpression);
    }
}
