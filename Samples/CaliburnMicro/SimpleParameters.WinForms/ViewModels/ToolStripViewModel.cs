using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;

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
            string helper = string.Empty;

#if WINFORMS
            var proxy = obj as ToolStripItemProxy;
            if (proxy == null)
                helper = "$this is null";
            else
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
                var proxy = obj as MenuItemProxy;
                {
                    helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
                    var btn = proxy.Item;
                    if (btn == null)
                        helper = "$this is null";
                    else
                        helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
                }
            }
            if (obj is ToolBarButtonProxy)
            {
                var proxy = obj as ToolBarButtonProxy;
                {
                    helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
                    var btn = proxy.Item;
                    if (btn == null)
                        helper = "$this is null";
                    else
                        helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
                }
            }

#endif

            ActionDetail = helper;
            ActionDescription = "$this";
        }
    }
}