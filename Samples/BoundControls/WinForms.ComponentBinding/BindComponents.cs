using System.ComponentModel;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.Controls.WinForms;

namespace MvvmFx.CaliburnMicro
{
    public static class BindComponents
    {
        public static void SetBindings(this Control masterControl)
        {
            foreach (Control control in masterControl.Controls)
            {
                if (control is ToolStrip)
                {
                    ParseComponents(control as ToolStrip);
                }
            }
        }

        private static void ParseComponents(ToolStrip toolStrip)
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                TryBind(item);
                RecurseToolStripItem(item);
            }
        }

        private static void RecurseToolStripItem(ToolStripItem toolStripItem)
        {
            if (toolStripItem is ToolStripDropDownItem)
            {
                foreach (ToolStripItem item in ((ToolStripDropDownItem) toolStripItem).DropDownItems)
                {
                    TryBind(item);
                    RecurseToolStripItem(item);
                }
            }
        }

        private static void TryBind(Component component)
        {
            if (component is INamedBindable)
            {
                var namedBindable = component as INamedBindable;
                var item = ItemCollection.GetItem(namedBindable);
                Bind(namedBindable, item);
            }
        }

        private static void Bind(IBindableComponent bindable, Item item)
        {
            bindable.DataBindings.Add("Text", item, "Text");
            bindable.DataBindings.Add("ToolTipText", item, "ToolTipText");
            bindable.DataBindings.Add("Enabled", item, "Enabled");
            bindable.DataBindings.Add("Visible", item, "Visible");
        }
    }
}