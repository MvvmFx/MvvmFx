using System;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.Controls.WinForms;
using ToolStripMenuItem = MvvmFx.Controls.WinForms.ToolStripMenuItem;

namespace WinForms.TestBoundControls
{
    public partial class StripWindow : BoundForm
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
            var mainControl = (MenuStrip) GetMainControlByName("menuBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.Items)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add("Text", item, "Text");
                        ((IBindableComponent) component).DataBindings.Add("ToolTipText", item, "ToolTipText");
                        ((IBindableComponent) component).DataBindings.Add("Enabled", item, "Enabled");
                        ((IBindableComponent) component).DataBindings.Add("Visible", item, "Visible");
                        isMatch = true;
                    }
                    else if (component.GetType() == typeof(ToolStripMenuItem))
                    {
                        foreach (ToolStripMenuItem subControl in ((ToolStripMenuItem) component).DropDownItems)
                        {
                            if (subControl.Name == item.Name)
                            {
                                subControl.DataBindings.Add("Text", item, "Text");
                                subControl.DataBindings.Add("ToolTipText", item, "ToolTipText");
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
            var mainControl = (ToolStrip) GetMainControlByName("toolBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.Items)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add("Text", item, "Text");
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
            var mainControl = (StatusStrip) GetMainControlByName("statusBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.Items)
                {
                    if (isMatch)
                        break;

                    if (((INamedBindable) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add("Text", item, "Text");
                        ((IBindableComponent) component).DataBindings.Add("ToolTipText", item, "ToolTipText");
                        ((IBindableComponent) component).DataBindings.Add("Enabled", item, "Enabled");
                        ((IBindableComponent) component).DataBindings.Add("Visible", item, "Visible");
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