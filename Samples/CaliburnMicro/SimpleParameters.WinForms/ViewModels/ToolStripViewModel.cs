using System;
#if WINFORMS
using System.Windows.Forms;
#else
using Gizmox.WebGUI.Forms;
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
                var btn = proxy.Item as ToolStripButton;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
            }

            ActionDetail = helper;
            ActionDescription = "$this";
        }
    }
}