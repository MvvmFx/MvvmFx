namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using MvvmFx.Bindings.Data;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="MenuBar"/> and binder agent for <see cref="MenuItemProxy"/>.
    /// </summary>
    /// <seealso cref="MenuItemProxy" />
    public static class MenuBarHandler
    {
        #region GetChildItems

        /// <summary>
        /// Return the <see cref="MenuBar" /> child items as <see cref="MenuItemProxy"/>.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetChildItems = (control) =>
        {
            if (!(control is MenuBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(MenuBar).FullName),
                    @"control");

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
        /// Binds the visible and enabled properties of a <see cref="MenuItemProxy"/> to 
        /// the ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (control, viewModel, bindingManager) =>
            {
                if (!(control is MenuItemProxy))
                    throw new ArgumentException(
                        string.Format("Expecting type {0}", typeof(MenuItemProxy).FullName),
                        @"control");

                BindComponentProperties((MenuItemProxy) control, viewModel, bindingManager);
            };

        private static void BindComponentProperties(MenuItemProxy control, object viewModel,
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