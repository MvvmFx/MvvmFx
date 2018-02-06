namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
    using MvvmFx.Windows.Data;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="MenuBar"/> control.
    /// </summary>
    /// <seealso cref="MenuItemProxy" />
    public static class MenuBarAgent
    {
        #region GetNamedItems

        /// <summary>
        /// Return the <see cref="MenuBar" /> named items.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetNamedItems = (control) =>
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!(control is MenuBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(MenuBar).FullName),
                    nameof(control));

            return GetNamedElements((MenuBar) control);
        };

        private static IEnumerable<Control> GetNamedElements(MenuBar control)
        {
            foreach (MenuItem menuItem in control.MenuItems)
            {
                yield return new MenuItemProxy(menuItem, control.Parent, true);

                foreach (var item in RecursiveGetItems(menuItem, control))
                    yield return item;
            }
        }

        private static IEnumerable<Control> RecursiveGetItems(Component component, Control control)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (component is MenuItem)
            {
                foreach (MenuItem t in ((MenuItem) component).MenuItems)
                {
                    yield return new MenuItemProxy(t, control.Parent, true);

                    foreach (var subItem in RecursiveGetItems(t, control))
                        yield return subItem;
                }
            }
        }

        #endregion

        #region BindVisualProperties

        /// <summary>
        /// Binds the visible and enabled properties of a <see cref="Control"/> to 
        /// the ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (namedElements, viewModel, bindingManager) =>
            {

            };

        #endregion
    }
}