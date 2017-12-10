using System;
#if WISEJ
using Wisej.Web;
using ToolStripMenuItem = MvvmFx.WisejWeb.MenuItem;
using ToolStripItemProxy = MvvmFx.CaliburnMicro.MenuItemProxy;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;

namespace SimpleParameters.UI.ViewModels
{
    public class MenuStripViewModel : ButtonViewModel
    {
        public MenuStripViewModel()
        {
            DisplayName = "MenuStrip Test Screen";
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
                var btn = proxy.Item as ToolStripMenuItem;
                if (btn == null)
                    helper = "$this is null";
                else
                    helper += "Type: " + btn.GetType() + Environment.NewLine + "Name: " + btn.Name;
            }

            ActionDetail = helper;
            ActionDescription = "$this";
        }

        #region Show Level 2

        public void ShowLevel2BindingContext(object obj)
        {
            ShowBindingContext(obj);
            ActionDescription = "Level 2 - BindingContext";
        }

        public void ShowLevel2DataContext(object obj)
        {
            ShowDataContext(obj);
            ActionDescription = "Level 2 - DataContext";
        }

        public void ShowLevel2EventArgs(object obj)
        {
            ShowEventArgs(obj);
            ActionDescription = "Level 2 - eventArgs";
        }

        public void ShowLevel2Source(object obj)
        {
            ShowSource(obj);
            ActionDescription = "Level 2 - Source";
        }

        public void ShowLevel2ExecutionContext(object obj)
        {
            ShowExecutionContext(obj);
            ActionDescription = "Level 2 - ActionExecutionContext";
        }

        public void ShowLevel2View(object obj)
        {
            ShowView(obj);
            ActionDescription = "Level 2 - View";
        }

        public void ShowLevel2This(object obj)
        {
            ShowThis(obj);
            ActionDescription = "Level 2 - $this";
        }

        public bool CanShowLevel2Bound(string parameter)
        {
            return CanShowBound(parameter);
        }

        public void ShowLevel2Bound(string parameter)
        {
            ShowBound(parameter);
            ActionDescription = "Level 2 - Bound (to the value in the TextBox above)";
        }

        public void ShowLevel2Value1(int nr)
        {
            ShowValue1(nr);
            ActionDescription = "Level 2 - fixed value 1";
        }

        #endregion

        #region Show Level 3

        public void ShowLevel3BindingContext(object obj)
        {
            ShowBindingContext(obj);
            ActionDescription = "Level 3 - BindingContext";
        }

        public void ShowLevel3DataContext(object obj)
        {
            ShowDataContext(obj);
            ActionDescription = "Level 3 - DataContext";
        }

        public void ShowLevel3EventArgs(object obj)
        {
            ShowEventArgs(obj);
            ActionDescription = "Level 3 - eventArgs";
        }

        public void ShowLevel3Source(object obj)
        {
            ShowSource(obj);
            ActionDescription = "Level 3 - Source";
        }

        public void ShowLevel3ExecutionContext(object obj)
        {
            ShowExecutionContext(obj);
            ActionDescription = "Level 3 - ActionExecutionContext";
        }

        public void ShowLevel3View(object obj)
        {
            ShowView(obj);
            ActionDescription = "Level 3 - View";
        }

        public void ShowLevel3This(object obj)
        {
            ShowThis(obj);
            ActionDescription = "Level 3 - $this";
        }

        public bool CanShowLevel3Bound(string parameter)
        {
            return CanShowBound(parameter);
        }

        public void ShowLevel3Bound(string parameter)
        {
            ShowBound(parameter);
            ActionDescription = "Level 3 - Bound (to the value in the TextBox above)";
        }

        public void ShowLevel3Value1(int nr)
        {
            ShowValue1(nr);
            ActionDescription = "Level 3 - fixed value 1";
        }

        #endregion
    }
}