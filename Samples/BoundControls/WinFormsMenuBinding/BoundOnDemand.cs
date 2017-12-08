using System;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.Windows.Forms;
using ToolStripMenuItem = MvvmFx.Windows.Forms.ToolStripMenuItem;

namespace WinForms.MenuBinding
{
    public partial class BoundOnDemand : Form
    {
        public BoundOnDemand()
        {
            InitializeComponent();
        }


        private void bindMenu_Click(object sender, EventArgs e)
        {
            bindMenu.Enabled = false;
            var collection = MenuCollection.GetMenuCollection();
            var mainControl = (MenuStrip) GetMainControlByName("menuBar1");

            foreach (var item in collection)
            {
                var isMatch = false;
                foreach (object component in mainControl.Items)
                {
                    if (isMatch)
                        break;

                    if (((IHaveName) component).Name == item.Name)
                    {
                        ((IBindableComponent) component).DataBindings.Add(new Binding("Text", item, "Text"));
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