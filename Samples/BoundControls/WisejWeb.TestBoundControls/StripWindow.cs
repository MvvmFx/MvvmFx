using System;
using BoundControls.Business;
using MvvmFx.WisejWeb;
using Wisej.Web;
using MenuItem = MvvmFx.WisejWeb.MenuItem;
using ToolBarButton = MvvmFx.WisejWeb.ToolBarButton;

namespace WisejWeb.TestBoundControls
{
    public partial class StripWindow : Form
    {
        public StripWindow()
        {
            InitializeComponent();
            BindButtons();
        }

        private void BindButtons()
        {
            var collection = ButtonModelCollection.GetButtonModelCollection();

            foreach (var item in collection)
            {
                var button = (Button) GetMainControlByName(item.Name);
                if (button.Name == item.Name)
                {
                    Binding binding = new Binding("Text", item, "Text");
                    button.DataBindings.Add(binding);
                    button.DataBindings.Add("Enabled", item, "Enabled");
                    button.DataBindings.Add("Visible", item, "Visible");
                }
            }
        }

        private void bindMenu_Click(object sender, EventArgs e)
        {
            var collection = MenuCollection.GetMenuCollection();
            var mainControl = (MenuBar) GetMainControlByName("menuBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.MenuItems)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add("Text", item, "Text");
                        //((IBindableComponent) component).DataBindings.Add("ToolTipText", item, "ToolTipText");
                        ((IBindableComponent) component).DataBindings.Add("Enabled", item, "Enabled");
                        ((IBindableComponent) component).DataBindings.Add("Visible", item, "Visible");
                        isMatch = true;
                    }
                    else if (component.GetType() == typeof(MenuItem))
                    {
                        foreach (MenuItem subControl in ((MenuItem) component).MenuItems)
                        {
                            if (subControl.Name == item.Name)
                            {
                                subControl.DataBindings.Add("Text", item, "Text");
                                //subControl.DataBindings.Add("ToolTipText", item, "ToolTipText");
                                subControl.DataBindings.Add("Enabled", item, "Enabled");
                                subControl.DataBindings.Add("Visible", item, "Visible");
                                isMatch = true;
                            }
                        }
                    }
                }
            }
        }

        private void bindToolBar_Click(object sender, EventArgs e)
        {
            var collection = ToolCollection.GetToolCollection();
            var mainControl = (ToolBar) GetMainControlByName("toolBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (ToolBarButton component in mainControl.Buttons)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        Binding binding = new Binding("Text", item, "Text");
                        ((IBindableComponent) component).DataBindings.Add(binding);
                        ((IBindableComponent) component).DataBindings.Add("ToolTipText", item, "ToolTipText");
                        ((IBindableComponent) component).DataBindings.Add("Enabled", item, "Enabled");
                        ((IBindableComponent) component).DataBindings.Add("Visible", item, "Visible");
                        isMatch = true;
                    }
                }
            }
        }

        private void bindStatus_Click(object sender, EventArgs e)
        {
            var collection = StatusCollection.GetStatusCollection();
            var mainControl = (StatusBar) GetMainControlByName("statusBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.Panels)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add("Text", item, "Text");
                        ((IBindableComponent) component).DataBindings.Add("ToolTipText", item, "ToolTipText");
                        //((IBindableComponent) component).DataBindings.Add("Enabled", item, "Enabled");
                        //((IBindableComponent) component).DataBindings.Add("Visible", item, "Visible");
                        isMatch = true;
                    }
                }
            }
        }

        private Control GetMainControlByName(string name)
        {
            foreach (Control control in Controls)
            {
                if (control.Name == name)
                {
                    return control;
                }
            }

            return null;
        }
    }
}