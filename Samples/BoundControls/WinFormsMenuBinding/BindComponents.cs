using BoundControls.Business;
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
    public static class BindComponents
    {
        public static void SetBindings(this Control masterControl)
        {
            foreach (Control control in masterControl.Controls)
            {
                if (control is ToolStrip)
                {
                    var toolStrip = control as ToolStrip;

                    ParseComponents(toolStrip);
                }
            }
        }

        private static void ParseComponents(ToolStrip toolStrip)
        {
#if WISEJ
            foreach (ToolStripItem toolStripItem in toolStrip.MenuItems)
#else
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
#endif
            {
                if (toolStripItem is INamedBindable)
                {
                    var namedBindable = toolStripItem as INamedBindable;
                    var menu = MenuCollection.GetMenu(namedBindable);
                    Bind(namedBindable, menu);
                }
                RecurseToolStripItem(toolStripItem);
            }
        }

        private static void RecurseToolStripItem(ToolStripItem toolStripItem)
        {
            if (toolStripItem is ToolStripDropDownItem)
            {
#if WISEJ
                foreach (ToolStripItem item in ((ToolStripDropDownItem) toolStripItem).MenuItems)
#else
                foreach (ToolStripItem item in ((ToolStripDropDownItem) toolStripItem).DropDownItems)
#endif
                {
                    if (toolStripItem is INamedBindable)
                    {
                        var namedBindable = item as INamedBindable;
                        var menu = MenuCollection.GetMenu(namedBindable);
                        Bind(namedBindable, menu);
                    }
                    RecurseToolStripItem(item);
                }
            }
        }

        private static void Bind(IBindableComponent bindable, Menu menu)
        {
            bindable.DataBindings.Add("Text", menu, "Text");
#if !WISEJ
            bindable.DataBindings.Add("ToolTipText", menu, "ToolTipText");
#endif
            bindable.DataBindings.Add("Enabled", menu, "Enabled");
            bindable.DataBindings.Add("Visible", menu, "Visible");
        }
    }
}