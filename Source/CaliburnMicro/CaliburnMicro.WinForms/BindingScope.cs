namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
#if WEBGUI
    using Gizmox.WebGUI.Forms;
#else
    using System.Windows.Forms;
#endif

    /// <summary>
    /// Provides methods for searching a given scope for named elements.
    /// </summary>
    public static class BindingScope
    {
        /// <summary>
        /// Searches through the list of named elements looking for a case-insensitive match.
        /// </summary>
        /// <param name="elementsToSearch">The named elements to search through.</param>
        /// <param name="name">The name to search for.</param>
        /// <returns>The named element or null if not found.</returns>
        public static Control FindName(this IEnumerable<Control> elementsToSearch, string name)
        {
            return elementsToSearch.FirstOrDefault(
                    x => (x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                          x.GetAttachedMessage().Equals(name, StringComparison.InvariantCultureIgnoreCase)));
        }

        /// <summary>
        /// Searches through the list of named elements looking for a case-insensitive match.
        /// </summary>
        /// <param name="elementsToSearch">The named elements to search through.</param>
        /// <param name="name">The name to search for.</param>
        /// <returns>The named elements or null if none found.</returns>
        public static IEnumerable<Control> FindNames(this IEnumerable<Control> elementsToSearch, string name)
        {
            return elementsToSearch.Where(x =>
            {
                return x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                       x.GetAttachedMessage().Equals(name, StringComparison.InvariantCultureIgnoreCase);
            });
        }

        /// <summary>
        /// Gets all the <see cref="Control"/> instances with names in the scope.
        /// </summary>
        /// <returns>Named <see cref="Control"/> instances in the provided scope.</returns>
        /// <remarks>Pass in a <see cref="DependencyObject"/> and receive a list of named <see cref="Control"/> instances in the same scope.</remarks>
        public static Func<Control, IEnumerable<Control>> GetNamedElements =
            elementInScope => { return elementInScope.GetNamedElements(); };
    }
}