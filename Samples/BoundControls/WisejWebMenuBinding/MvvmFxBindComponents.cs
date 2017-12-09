using BoundControls.Business;
using MvvmFx.Windows.Data;
using MvvmFx.WisejWeb;
using Wisej.Web;
using Binding = MvvmFx.Windows.Data.Binding;
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
    public class MvvmFxBindComponents
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public void SetMvvmFxBindings(Control masterControl)
        {
            _bindingManager.Bindings.Clear();

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

        private void ParseComponents(MenuBar menubar)
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

        private void ParseComponents(ToolBar toolBar)
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

        private void ParseComponents(StatusBar statusBar)
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

        private void RecurseItem(Component component)
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

        private void Bind(IBindableComponent bindable, Menu menu)
        {
            _bindingManager.Bindings.Add(new Binding(bindable, "Text", menu, "Text")
            {
                Mode = BindingMode.OneWayToTarget
            });

            if (!(bindable is MenuItem || bindable is ToolBarButton))
            {
                _bindingManager.Bindings.Add(new Binding(bindable, "ToolTipText", menu, "ToolTipText")
                {
                    Mode = BindingMode.OneWayToTarget
                });
            }

            if (!(bindable is StatusBarPanel))
            {
                _bindingManager.Bindings.Add(new Binding(bindable, "Enabled", menu, "Enabled")
                {
                    Mode = BindingMode.OneWayToTarget
                });
                _bindingManager.Bindings.Add(new Binding(bindable, "Visible", menu, "Visible")
                {
                    Mode = BindingMode.OneWayToTarget
                });
            }
        }
    }
}