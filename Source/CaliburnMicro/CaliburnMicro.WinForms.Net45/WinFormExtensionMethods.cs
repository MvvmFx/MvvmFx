namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using MvvmFx.Windows.Data;
#if WISEJ
    using Wisej.Web;
#else
    using System.Windows.Forms;
#endif
    using Binding = MvvmFx.Windows.Data.Binding;

    /// <summary>
    /// Extension methods for Windows Forms and Wisej
    /// </summary>
    public static class WinFormExtensionMethods
    {
        /// <summary>
        /// Gets the attached message on the Control's Tag property
        /// </summary>
        /// <param name="control">The control to search for the attached message.</param>
        /// <returns>The attached message text.</returns>
        public static string GetAttachedMessage(this Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!string.IsNullOrEmpty(control.Tag as string) &&
                ((string) control.Tag).StartsWith("message.attach=", StringComparison.OrdinalIgnoreCase))
            {
                var startParameters = ((string) control.Tag).IndexOf("(", StringComparison.Ordinal);
                if (startParameters == -1)
                    return ((string) control.Tag).Substring(15);

                return ((string) control.Tag).Substring(15, startParameters - 15);
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the attached message on the Control's Tag property
        /// </summary>
        /// <param name="control">The control to search for the attached message.</param>
        /// <returns>The attached message text.</returns>
        public static string GetFullAttachedMessage(this Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!string.IsNullOrEmpty(control.Tag as string) &&
                ((string) control.Tag).StartsWith("message.attach=", StringComparison.OrdinalIgnoreCase))
            {
                return ((string) control.Tag).Substring(15);
            }

            return string.Empty;
        }

#if WINFORMS
        /// <summary>
        /// Gets all the <see cref="Control" /> instances with names in the scope.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// Named <see cref="Control" /> instances in the provided scope.
        /// </returns>
        public static IEnumerable<Control> GetNamedElements(this Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            foreach (var x in control.Controls.Cast<Control>())
            {
                if (x is ToolStrip)
                {
                    foreach (ToolStripItem item in ((ToolStrip) x).Items)
                    {
                        yield return new ToolStripItemProxy(item, x.Parent, true);

                        foreach (var toolStripItems in RecursiveGetToolStripItems(item, x))
                            yield return toolStripItems;
                    }
                }

                yield return x;
                foreach (var child in GetNamedElements(x))
                    yield return child;
            }
        }

        private static IEnumerable<Control> RecursiveGetToolStripItems(ToolStripItem item, Control x)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (x == null)
                throw new ArgumentNullException(nameof(x));

            if (item is ToolStripDropDownItem)
            {
                foreach (ToolStripItem t in ((ToolStripDropDownItem) item).DropDownItems)
                {
                    yield return new ToolStripItemProxy(t, x.Parent, true);

                    foreach (var toolStripItems in RecursiveGetToolStripItems(t, x))
                        yield return toolStripItems;
                }
            }
        }

        /// <summary>
        /// Binds the control visible and enabled properties.
        /// </summary>
        /// <param name="namedElements">The list of elements in scope.</param>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <param name="bindingManager">The binding manager to use.</param>
        public static void BindToolStripItemProxyProperties(List<Control> namedElements, object viewModel,
            BindingManager bindingManager)
        {
            if (namedElements == null)
                throw new ArgumentNullException(nameof(namedElements));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (bindingManager == null)
                throw new ArgumentNullException(nameof(bindingManager));

            foreach (var control in namedElements)
            {
                if (control is ToolStripItemProxy)
                {
                    var property = viewModel.GetPropertyCaseInsensitive(control.Name + "Visible");
                    if (property != null)
                    {
                        // must enforce the Visible property
                        ((ToolStripItemProxy) control).Item.Visible =
                            (bool) property.GetValue(viewModel,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null,
                                null);
                        BindToolStripItemProxyProperties(property.Name, control, "Visible", viewModel, bindingManager);
                    }
                    else
                    {
                        property = viewModel.GetPropertyCaseInsensitive(control.Name + "Enabled");
                        if (property != null)
                        {
                            // no need for enforce the Enabled property
                            /*((ToolStripItemProxy) control).Item.Enabled =
                                (bool) property.GetValue(viewModel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null, null);*/
                            BindToolStripItemProxyProperties(property.Name, control, "Enabled", viewModel,
                                bindingManager);
                        }
                    }
                }
            }
        }
#else
        /// <summary>
        /// Gets all the <see cref="Control" /> instances with names in the scope.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// Named <see cref="Control" /> instances in the provided scope.
        /// </returns>
        public static IEnumerable<Control> GetNamedElements(this Control control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            foreach (var x in control.Controls.Cast<Control>())
            {
                if (x is MenuBar)
                {
                    foreach (MenuItem menuItem in ((MenuBar) x).MenuItems)
                    {
                        yield return new MenuItemProxy(menuItem, x.Parent, true);

                        foreach (var item in RecursiveGetItems(menuItem, x))
                            yield return item;
                    }
                }
                else if (x is ToolBar)
                {
                    foreach (ToolBarButton toolBarButton in ((ToolBar) x).Buttons)
                    {
                        yield return new ToolBarButtonProxy(toolBarButton, x.Parent, true);

                        foreach (var item in RecursiveGetItems(toolBarButton, x))
                            yield return item;
                    }
                }
                else if (x is StatusBar)
                {
                    foreach (StatusBarPanel statusBarPanel in ((StatusBar) x).Panels)
                    {
                        yield return new StatusBarPanelProxy(statusBarPanel, x.Parent, true);

                        foreach (var item in RecursiveGetItems(statusBarPanel, x))
                            yield return item;
                    }
                }

                yield return x;
                foreach (var child in GetNamedElements(x))
                    yield return child;
            }
        }

        private static IEnumerable<Control> RecursiveGetItems(Component component, Control x)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            if (x == null)
                throw new ArgumentNullException(nameof(x));

            if (component is MenuItem)
            {
                foreach (MenuItem t in ((MenuItem) component).MenuItems)
                {
                    yield return new MenuItemProxy(t, x.Parent, true);

                    foreach (var item in RecursiveGetItems(t, x))
                        yield return item;
                }
            }
            else if ((component as ToolBarButton)?.DropDownMenu != null)
            {
                foreach (MenuItem t in ((ToolBarButton) component).DropDownMenu.MenuItems)
                {
                    yield return new MenuItemProxy(t, x.Parent, true);

                    foreach (var item in RecursiveGetItems(t, x))
                        yield return item;
                }
            }

            /*else if (component is StatusBarPanel)
            {
                foreach (StatusBarPanel t in ((StatusBarPanel)component).Panels)
                {
                    yield return new StatusBarPanelProxy(t, x.Parent, true);

                    foreach (var item in RecursiveGetItems(t, x))
                        yield return item;
                }
            }*/
        }

        /// <summary>
        /// Binds the control visible and enabled properties.
        /// </summary>
        /// <param name="namedElements">The list of elements in scope.</param>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <param name="bindingManager">The binding manager to use.</param>
        public static void BindToolStripItemProxyProperties(List<Control> namedElements, object viewModel,
            BindingManager bindingManager)
        {
            if (namedElements == null)
                throw new ArgumentNullException(nameof(namedElements));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (bindingManager == null)
                throw new ArgumentNullException(nameof(bindingManager));

            foreach (var control in namedElements)
            {
                if (control is MenuItemProxy)
                {
                    var property = viewModel.GetPropertyCaseInsensitive(control.Name + "Visible");
                    if (property != null)
                    {
                        // must enforce the Visible property
                        ((MenuItemProxy) control).Item.Visible =
                            (bool) property.GetValue(viewModel,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null,
                                null);
                        BindToolStripItemProxyProperties(property.Name, control, "Visible", viewModel, bindingManager);
                    }
                    else
                    {
                        property = viewModel.GetPropertyCaseInsensitive(control.Name + "Enabled");
                        if (property != null)
                        {
                            // no need for enforce the Enabled property
                            /*((ToolStripItemProxy) control).Item.Enabled =
                                (bool) property.GetValue(viewModel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null, null);*/
                            BindToolStripItemProxyProperties(property.Name, control, "Enabled", viewModel,
                                bindingManager);
                        }
                    }
                }
                else if (control is ToolBarButtonProxy)
                {
                    var property = viewModel.GetPropertyCaseInsensitive(control.Name + "Visible");
                    if (property != null)
                    {
                        // must enforce the Visible property
                        ((ToolBarButtonProxy) control).Item.Visible =
                            (bool) property.GetValue(viewModel,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null,
                                null);
                        BindToolStripItemProxyProperties(property.Name, control, "Visible", viewModel, bindingManager);
                    }
                    else
                    {
                        property = viewModel.GetPropertyCaseInsensitive(control.Name + "Enabled");
                        if (property != null)
                        {
                            // no need for enforce the Enabled property
                            /*((ToolStripItemProxy) control).Item.Enabled =
                                (bool) property.GetValue(viewModel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null, null);*/
                            BindToolStripItemProxyProperties(property.Name, control, "Enabled", viewModel,
                                bindingManager);
                        }
                    }
                }
            }
        }

#endif

        private static void BindToolStripItemProxyProperties(string sourcePath, Control target, string targetPath,
            object viewModel, BindingManager bindingManager)
        {
            if (sourcePath == null)
                throw new ArgumentNullException(nameof(sourcePath));
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (targetPath == null)
                throw new ArgumentNullException(nameof(targetPath));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (bindingManager == null)
                throw new ArgumentNullException(nameof(bindingManager));

            bindingManager.Bindings.Add(new Binding(target, targetPath, viewModel, sourcePath)
            {
                Mode = BindingMode.OneWayToTarget
            });
        }

        /// <summary>
        /// Gets a property by name, ignoring case and searching all interfaces.
        /// </summary>
        /// <param name="type">The type to inspect.</param>
        /// <param name="propertyName">The property to search for.</param>
        /// <returns>The property or null if not found.</returns>
        public static PropertyInfo GetPropertyCaseInsensitive(this object type, string propertyName)
        {
            return GetPropertyCaseInsensitive(type.GetType(), propertyName);
        }

        /// <summary>
        /// Gets a property by name, ignoring case and searching all interfaces.
        /// </summary>
        /// <param name="type">The type to inspect.</param>
        /// <param name="propertyName">The property to search for.</param>
        /// <returns>The property or null if not found.</returns>
        public static PropertyInfo GetPropertyCaseInsensitive(this Type type, string propertyName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            return type.GetProperty(propertyName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets a method by name, ignoring case and searching all interfaces.
        /// </summary>
        /// <param name="type">The type to inspect.</param>
        /// <param name="methodName">The method to search for.</param>
        /// <returns>The method or null if not found.</returns>
        public static MethodInfo GetMethodCaseSensitive(this object type, string methodName)
        {
            return GetMethodCaseSensitive(type.GetType(), methodName);
        }

        /// <summary>
        /// Gets a method by name, ignoring case and searching all interfaces.
        /// </summary>
        /// <param name="type">The type to inspect.</param>
        /// <param name="methodName">The method to search for.</param>
        /// <returns>The method or null if not found.</returns>
        public static MethodInfo GetMethodCaseSensitive(this Type type, string methodName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (methodName == null)
                throw new ArgumentNullException(nameof(methodName));

            return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
        }
    }
}