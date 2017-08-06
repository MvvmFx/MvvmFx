using System;
#if WISEJ
using Wisej.Web;
using ToolStripButton = Wisej.Web.ToolBarButton;
using ToolStripItem = Wisej.Web.MenuItem;
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
            string helper;

            var proxy = obj as ToolStripItemProxy;
            if (proxy == null)
                helper = "$this is null";
            else
            {
                helper = "Proxy Type: " + proxy.GetType() + Environment.NewLine;
#if !WISEJ
                var btn = proxy.Item as ToolStripButton;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
#endif
            }

            ActionDetail = helper;
            ActionDescription = "$this";
        }
    }
}