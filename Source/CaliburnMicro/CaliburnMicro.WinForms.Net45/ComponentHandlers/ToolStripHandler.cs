namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    using MvvmFx.Bindings.Data;

    /// <summary>
    /// Proxy agent for <see cref="ToolStrip"/> and binder agent for <see cref="ToolStripItemProxy"/>.
    /// </summary>
    /// <seealso cref="ToolStripItemProxy" />
    public static class ToolStripHandler
    {
        #region GetChildItems

        /// <summary>
        /// Return the <see cref="ToolStrip" /> child items as <see cref="ToolStripItemProxy"/>.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetChildItems = (control) =>
        {
            if (!(control is ToolStrip))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(ToolStrip).FullName),
                    @"control");

            return GetNamedElements((ToolStrip) control);
        };

        private static IEnumerable<Control> GetNamedElements(ToolStrip control)
        {
            foreach (ToolStripItem item in control.Items)
            {
                yield return new ToolStripItemProxy(item, control.Parent, true);

                foreach (var toolStripItems in RecursiveGetItems(item, control))
                    yield return toolStripItems;
            }
        }

        private static IEnumerable<Control> RecursiveGetItems(ToolStripItem component, Control control)
        {
            if (component is ToolStripDropDownItem)
            {
                foreach (ToolStripItem item in ((ToolStripDropDownItem) component).DropDownItems)
                {
                    yield return new ToolStripItemProxy(item, control.Parent, true);

                    foreach (var subItem in RecursiveGetItems(item, control))
                        yield return subItem;
                }
            }
        }

        #endregion

        #region BindVisualProperties

        /// <summary>
        /// Binds the visible and enabled properties of a <see cref="ToolStripItemProxy"/> to 
        /// ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (control, viewModel, bindingManager) =>
            {
                if (!(control is ToolStripItemProxy))
                    throw new ArgumentException(
                        string.Format("Expecting type {0}", typeof(ToolStripItemProxy).FullName),
                        @"control");

                BindComponentProperties((ToolStripItemProxy) control, viewModel, bindingManager);
            };

        private static void BindComponentProperties(ToolStripItemProxy control, object viewModel,
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
                    WinFormExtensionMethods.DoBind(control, "Enabled", viewModel, property.Name, bindingManager);
                }
            }
        }

        #endregion
    }
}