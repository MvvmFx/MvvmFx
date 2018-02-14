using BoundControls.Business;
using MvvmFx.Controls.WisejWeb;
using Wisej.Web;
using Control = Wisej.Web.Control;
using IBindableComponent = Wisej.Web.IBindableComponent;
using MenuItem = Wisej.Web.MenuItem;
using StatusBar = Wisej.Web.StatusBar;
using StatusBarPanel = Wisej.Web.StatusBarPanel;
using ToolBar = Wisej.Web.ToolBar;
using ToolBarButton = Wisej.Web.ToolBarButton;

namespace MvvmFx.CaliburnMicro
{
    public static class BindComponents
    {
        public static void SetBindings(this Control masterControl)
        {
            foreach (Control control in masterControl.Controls)
            {
                if (control is MenuBar)
                {
                    ParseComponents(control as MenuBar);
                }
                else if (control is ToolBar)
                {
                    ParseComponents(control as ToolBar);
                }
                else if (control is StatusBar)
                {
                    ParseComponents(control as StatusBar);
                }
            }
        }

        private static void ParseComponents(MenuBar menuBar)
        {
            foreach (MenuItem item in menuBar.MenuItems)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private static void ParseComponents(ToolBar toolBar)
        {
            foreach (ToolBarButton item in toolBar.Buttons)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private static void ParseComponents(StatusBar statusBar)
        {
            foreach (StatusBarPanel item in statusBar.Panels)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private static void RecurseItem(Component component)
        {
            if (component is MenuItem)
            {
                foreach (MenuItem item in ((MenuItem) component).MenuItems)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }
            else if ((component as ToolBarButton)?.DropDownMenu != null)
            {
                foreach (MenuItem item in ((ToolBarButton) component).DropDownMenu.MenuItems)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }
            /*else if (component is StatusBarPanel)
            {
                foreach (MenuItem item in ((StatusBarPanel) component).Panels)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }*/
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

            if (!(bindable is MenuItem || bindable is ToolBarButton))
                bindable.DataBindings.Add("ToolTipText", item, "ToolTipText");

            if (!(bindable is StatusBarPanel))
            {
                bindable.DataBindings.Add("Enabled", item, "Enabled");
                bindable.DataBindings.Add("Visible", item, "Visible");
            }
        }
    }
}