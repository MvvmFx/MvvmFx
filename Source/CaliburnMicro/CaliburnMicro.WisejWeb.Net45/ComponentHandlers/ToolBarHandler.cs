namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using MvvmFx.Windows.Data;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="ToolBar"/> and binder agent for <see cref="ToolBarButtonProxy"/>.
    /// </summary>
    /// <seealso cref="ToolBarButtonProxy" />
    /// <seealso cref="MenuItemProxy" />
    public static class ToolBarHandler
    {
        #region GetChildItems

        /// <summary>
        /// Return the <see cref="ToolBar" /> child items as 
        /// <see cref="ToolBarButtonProxy"/> or <see cref="MenuItemProxy"/>.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetChildItems = (control) =>
        {
            if (!(control is ToolBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(ToolBar).FullName),
                    @"control");

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
        /// Binds the visible and enabled properties of a <see cref="ToolBarButtonProxy"/> to 
        /// the ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (control, viewModel, bindingManager) =>
            {
                if (!(control is ToolBarButtonProxy))
                    throw new ArgumentException(
                        string.Format("Expecting type {0}", typeof(ToolBarButtonProxy).FullName),
                        @"control");

                BindComponentProperties((ToolBarButtonProxy) control, viewModel, bindingManager);
            };

        private static void BindComponentProperties(ToolBarButtonProxy control, object viewModel,
            BindingManager bindingManager)
        {
            var property = viewModel.GetPropertyCaseInsensitive(control.Name + "Visible");
            if (property != null)
            {
                // must enforce the Visible property
                control.Item.Visible =
                    (bool) property.GetValue(viewModel,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null,
                        null);
                WinFormExtensionMethods.DoBind(control, "Visible", viewModel, property.Name, bindingManager);
            }
            else
            {
                property = viewModel.GetPropertyCaseInsensitive(control.Name + "Enabled");
                if (property != null)
                {
                    // no need for enforce the Enabled property
                    /*control.Item.Enabled =
                        (bool) property.GetValue(viewModel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null, null);*/
                    WinFormExtensionMethods.DoBind(control, "Enabled", viewModel, property.Name,
                        bindingManager);
                }
            }
        }

        #endregion
    }
}