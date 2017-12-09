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

        private void ParseComponents(MenuBar menubar)
        {
            foreach (MenuItem item in menubar.MenuItems)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void ParseComponents(ToolBar toolBar)
        {
            foreach (ToolBarButton item in toolBar.Buttons)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void ParseComponents(StatusBar statusBar)
        {
            foreach (StatusBarPanel item in statusBar.Panels)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void RecurseItem(Component component)
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

        private void TryBind(Component component)
        {
            if (component is INamedBindable)
            {
                var namedBindable = component as INamedBindable;
                var menu = MenuCollection.GetMenu(namedBindable);
                Bind(namedBindable, menu);
            }
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