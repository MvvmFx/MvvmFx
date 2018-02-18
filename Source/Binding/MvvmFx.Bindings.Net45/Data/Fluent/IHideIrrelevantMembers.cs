using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Used to hide irrelevant members in the fluent API to make Intellisense cleaner. Note that this only works for people referencing this assembly. It doesn't
    /// work within this solution.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the current instance.
        /// </summary>
        /// <returns>The <see cref="System.Type"/> instance that represents the exact runtime type of the current instance.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024", Justification = "It's a method so we can hide it.")]
        [SuppressMessage("Microsoft.Naming", "CA1716", MessageId = "GetType", Justification = "Has same name so we can hide it.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object other);
    }
}