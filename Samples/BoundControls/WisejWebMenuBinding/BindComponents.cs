using BoundControls.Business;
using MvvmFx.WisejWeb;
using Wisej.Web;
using Control = Wisej.Web.Control;
using IBindableComponent = Wisej.Web.IBindableComponent;
using Menu = BoundControls.Business.Menu;
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
                    var menuBar = control as MenuBar;
                    ParseComponents(menuBar);
                }
                else if (control is ToolBar)
                {
                    var toolBar = control as ToolBar;
                    ParseComponents(toolBar);
                }
                else if (control is StatusBar)
                {
                    var statusBar = control as StatusBar;
                    ParseComponents(statusBar);
                }
            }
        }

        private static void ParseComponents(MenuBar menubar)
        {
            foreach (MenuItem menuItem in menubar.MenuItems)
            {
                if (menuItem is INamedBindable)
                {
                    var bindable = menuItem as INamedBindable;
                    var menu = MenuCollection.GetMenu(menuItem as INamedBindable);
                    Bind(bindable, menu);
                }
                RecurseItem(menuItem);
            }
        }

        private static void ParseComponents(ToolBar toolBar)
        {
            foreach (ToolBarButton toolBarButton in toolBar.Buttons)
            {
                if (toolBarButton is INamedBindable)
                {
                    var bindable = toolBarButton as INamedBindable;
                    var menu = MenuCollection.GetMenu(toolBarButton as INamedBindable);
                    Bind(bindable, menu);
                }
                RecurseItem(toolBarButton);
            }
        }

        private static void ParseComponents(StatusBar statusBar)
        {
            foreach (StatusBarPanel statusBarPanel in statusBar.Panels)
            {
                if (statusBarPanel is INamedBindable)
                {
                    var bindable = statusBarPanel as INamedBindable;
                    var menu = MenuCollection.GetMenu(statusBarPanel as INamedBindable);
                    Bind(bindable, menu);
                }
                RecurseItem(statusBarPanel);
            }
        }

        private static void RecurseItem(Component component)
        {
            if (component is MenuItem)
            {
                foreach (MenuItem item in ((MenuItem) component).MenuItems)
                {
                    var bindable = item as INamedBindable;
                    var menu = MenuCollection.GetMenu(item as INamedBindable);
                    Bind(bindable, menu);
                    RecurseItem(item);
                }
            }
            else if ((component as ToolBarButton)?.DropDownMenu != null)
            {
                foreach (MenuItem item in ((ToolBarButton) component).DropDownMenu.MenuItems)
                {
                    var bindable = item as INamedBindable;
                    var menu = MenuCollection.GetMenu(item as INamedBindable);
                    Bind(bindable, menu);
                    RecurseItem(item);
                }
            }
            /*else if (component is StatusBarPanel)
            {
                foreach (MenuItem item in ((StatusBarPanel) component).Panels)
                {
                    var bindable = item as INamedBindable;
                    var menu = MenuCollection.GetMenu(item as INamedBindable);
                    Bind(bindable, menu);
                    RecurseItem(item);
                }
            }*/
        }

        private static void Bind(IBindableComponent bindable, Menu menu)
        {
            bindable.DataBindings.Add("Text", menu, "Text");

            if (!(bindable is MenuItem || bindable is ToolBarButton))
                bindable.DataBindings.Add("ToolTipText", menu, "ToolTipText");

            if (!(bindable is StatusBarPanel))
            {
                bindable.DataBindings.Add("Enabled", menu, "Enabled");
                bindable.DataBindings.Add("Visible", menu, "Visible");
            }
        }
    }
}