using System.ComponentModel;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.Bindings.Data;
using MvvmFx.Controls.WinForms;
using Binding = MvvmFx.Bindings.Data.Binding;

namespace MvvmFx.CaliburnMicro
{
    public class MvvmFxBindComponents
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public void SetMvvmFxBindings(Control masterControl)
        {
            _bindingManager.Bindings.Clear();

            foreach (Control control in masterControl.Controls)
            {
                if (control is ToolStrip)
                {
                    ParseComponents(control as ToolStrip);
                }
            }
        }

        private void ParseComponents(ToolStrip toolStrip)
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                TryBind(item);
                RecurseToolStripItem(item);
            }
        }

        private void RecurseToolStripItem(ToolStripItem toolStripItem)
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

        private void TryBind(Component component)
        {
            if (component is INamedBindable)
            {
                var namedBindable = component as INamedBindable;
                var item = ItemCollection.GetItem(namedBindable);
                Bind(namedBindable, item);
            }
        }

        private void Bind(IBindableComponent bindable, Item item)
        {
            _bindingManager.Bindings.Add(new Binding(bindable, "Text", item, "Text")
            {
                Mode = BindingMode.OneWayToTarget
            });

            _bindingManager.Bindings.Add(new Binding(bindable, "ToolTipText", item, "ToolTipText")
            {
                Mode = BindingMode.OneWayToTarget
            });

            _bindingManager.Bindings.Add(new Binding(bindable, "Enabled", item, "Enabled")
            {
                Mode = BindingMode.OneWayToTarget
            });

            _bindingManager.Bindings.Add(new Binding(bindable, "Visible", item, "Visible")
            {
                Mode = BindingMode.OneWayToTarget
            });
        }
    }
}