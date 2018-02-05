namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
    using MvvmFx.Windows.Data;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="ToolBar"/> control.
    /// </summary>
    /// <seealso cref="ToolBarButtonProxy" />
    public static class ToolBarAgent
    {
        #region GetNamedItems

        /// <summary>
        /// Return the <see cref="ToolBar" /> named items.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetNamedItems = (control) =>
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!(control is ToolBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(ToolBar).FullName),
                    nameof(control));

            return GetNamedElements((ToolBar) control);
        };

        private static IEnumerable<Control> GetNamedElements(ToolBar control)
        {
            foreach (ToolBarButton toolBarButton in ((ToolBar) control).Buttons)
            {
                yield return new ToolBarButtonProxy(toolBarButton, control.Parent, true);

                foreach (var item in RecursiveGetItems(toolBarButton, control))
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
                foreach (MenuItem item in ((MenuItem) component).MenuItems)
                {
                    yield return new MenuItemProxy(item, control.Parent, true);

                    foreach (var subItem in RecursiveGetItems(item, control))
                        yield return subItem;
                }
            }
            else if ((component as ToolBarButton)?.DropDownMenu != null)
            {
                foreach (MenuItem item in ((ToolBarButton) component).DropDownMenu.MenuItems)
                {
                    yield return new MenuItemProxy(item, control.Parent, true);

                    foreach (var subItem in RecursiveGetItems(item, control))
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