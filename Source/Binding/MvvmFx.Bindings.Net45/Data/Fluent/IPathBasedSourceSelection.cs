using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Allows the source to be specified for a path-based binding fluent expression.
    /// </summary>
    public interface IPathBasedSourceSelection : IHideObjectMembers
    {
        /// <summary>
        /// Binds to the source with the specified path.
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
        [SuppressMessage("Microsoft.Naming", "CA1716", Justification = "Member is not designed to be implemented by consumers.")]
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        ISingleSourceBindingOptions To(object sourceObject, string sourcePath);
    }
}
