using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Allows subsequent sources to be specified in a multi-binding fluent expression.
    /// </summary>
    public interface ISubsequentSourceBindingOptions :
        IConverterSelection<ISubsequentSourceBindingOptions, IValueConverter>,
        IModeSelection<ISubsequentSourceBindingOptions>, IActivation
    {
        /// <summary>
        /// Binds to another source with the given path.
        /// </summary>
        /// <param name="sourceObject">
        /// The source object to bind to.
        /// </param>
        /// <param name="sourcePath">
        /// The path within the source object to bind to.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        ISubsequentSourceBindingOptions AndTo(object sourceObject, string sourcePath);

        /// <summary>
        /// Binds to another source with the given expression.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the source object.
        /// </typeparam>
        /// <param name="sourceObject">
        /// The source object.
        /// </param>
        /// <param name="sourceExpression">
        /// The expression that resolves to a path within the source object.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        ISubsequentSourceBindingOptions AndTo<TSource>(TSource sourceObject, Expression<Func<TSource, object>> sourceExpression);
    }
}
