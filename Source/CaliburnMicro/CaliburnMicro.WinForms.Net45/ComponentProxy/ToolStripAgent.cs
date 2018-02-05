namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using MvvmFx.Windows.Data;

    /// <summary>
    /// Proxy agent for <see cref="ToolStrip"/> control.
    /// </summary>
    /// <seealso cref="ToolStripItemProxy" />
    public static class ToolStripAgent
    {
        #region GetNamedItems

        /// <summary>
        /// Return the <see cref="ToolStrip" /> named items.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetNamedItems = (control) =>
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!(control is ToolStrip))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(ToolStrip).FullName),
                    nameof(control));

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
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            if (control == null)
                throw new ArgumentNullException(nameof(control));

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