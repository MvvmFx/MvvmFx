using BoundControls.Business;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;
using Menu = BoundControls.Business.Menu;
#if WISEJ
using MvvmFx.WisejWeb;
using Wisej.Web;
using ToolStrip = Wisej.Web.MenuBar;
using ToolStripDropDownItem = Wisej.Web.MenuItem;
using ToolStripItem = Wisej.Web.MenuItem;

#else
using MvvmFx.Windows.Forms;
using System.Windows.Forms;

#endif

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
                    var toolStrip = control as ToolStrip;

                    ParseComponents(toolStrip);
                }
            }
        }

        private void ParseComponents(ToolStrip toolStrip)
        {
#if WISEJ
            foreach (ToolStripItem toolStripItem in toolStrip.MenuItems)
#else
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
#endif
            {
                if (toolStripItem is IBindableComponent && toolStripItem is IHaveName)
                {
                    var menu = MenuCollection.GetMenu(toolStripItem as IHaveName);
                    Bind(toolStripItem, menu);
                }
                RecurseToolStripItem(toolStripItem);
            }
        }

        private void RecurseToolStripItem(ToolStripItem toolStripItem)
        {
            if (toolStripItem is ToolStripDropDownItem)
            {
#if WISEJ
                foreach (ToolStripItem item in ((ToolStripDropDownItem) toolStripItem).MenuItems)
#else
                foreach (ToolStripItem item in ((ToolStripDropDownItem) toolStripItem).DropDownItems)
#endif
                {
                    var menu = MenuCollection.GetMenu(item as IHaveName);
                    Bind(item, menu);
                    RecurseToolStripItem(item);
                }
            }
        }

        private void Bind(ToolStripItem toolStripItem, Menu menu)
        {
            _bindingManager.Bindings.Add(new Binding(toolStripItem, "Text", menu, "Text")
            {
                Mode = BindingMode.OneWayToTarget
            });
#if !WISEJ
            _bindingManager.Bindings.Add(new Binding(toolStripItem, "ToolTipText", menu, "ToolTipText")
            {
                Mode = BindingMode.OneWayToTarget
            });
#endif
            _bindingManager.Bindings.Add(new Binding(toolStripItem, "Enabled", menu, "Enabled")
            {
                Mode = BindingMode.OneWayToTarget
            });
            _bindingManager.Bindings.Add(new Binding(toolStripItem, "Visible", menu, "Visible")
            {
                Mode = BindingMode.OneWayToTarget
            });
        }
    }
}