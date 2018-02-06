using System;
#if WINFORMS
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro.ComponentHandlers;

namespace SimpleParameters.UI.ViewModels
{
    public class ToolStripViewModel : MenuStripViewModel
    {
        public ToolStripViewModel()
        {
            DisplayName = "ToolStrip Test Screen";
        }

        public new void ShowThis(object obj)
        {
            var helper = "$this is null";

#if WINFORMS
            var proxy = obj as ToolStripItemProxy;
            if (proxy != null)
            {
                helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
                var btn = proxy.Item as ToolStripButton;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
            }
#else
            if (obj is MenuItemProxy)
            {
                var proxy = (MenuItemProxy) obj;
                helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
                var btn = proxy.Item;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
            }
            if (obj is ToolBarButtonProxy)
            {
                var proxy = (ToolBarButtonProxy) obj;
                helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
                var btn = proxy.Item;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
            }

#endif

            ActionDetail = helper;
            ActionDescription = "$this";
        }
    }
}