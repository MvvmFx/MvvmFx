using System;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;
using Wisej.Web;

namespace WisejWeb.MenuBinding
{
    public partial class WinFormsBindings : Form
    {
        private bool _menuItemIsVisible = true;
        private bool _toolItemIsVisible = true;
        private bool _statusItemIsVisible = true;

        public WinFormsBindings()
        {
            InitializeComponent();
        }

        private bool MenuItemIsVisible
        {
            set
            {
                if (_menuItemIsVisible != value)
                {
                    _menuItemIsVisible = value;
                    changeMenuItem.Enabled = _menuItemIsVisible;
                }
            }
        }

        private bool ToolItemIsVisible
        {
            set
            {
                if (_toolItemIsVisible != value)
                {
                    _toolItemIsVisible = value;
                    changeToolItem.Enabled = _toolItemIsVisible;
                }
            }
        }

        private bool StatusItemIsVisible
        {
            set
            {
                if (_statusItemIsVisible != value)
                {
                    _statusItemIsVisible = value;
                    changeStatusItem.Enabled = _statusItemIsVisible;
                }
            }
        }

        private void WinFormsBindings_Load(object sender, EventArgs e)
        {
            MenuItemIsVisible = false;
            ToolItemIsVisible = false;
            StatusItemIsVisible = false;

            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden menu entry";

            item = ItemCollection.GetItem("statusItem3");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden status bar entry";

            item = ItemCollection.GetItem("toolItem7");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden tool bar entry";

            this.SetBindings();
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = true;

            MenuItemIsVisible = true;
        }

        private void showToolItem_Click(object sender, EventArgs e)
        {
            var getItem = ItemCollection.GetItem("toolItem7");
            getItem.Visible = true;

            ToolItemIsVisible = true;
        }

        private void showStatusItem_Click(object sender, EventArgs e)
        {
            var getItem = ItemCollection.GetItem("statusItem3");
            getItem.Visible = true;

            StatusItemIsVisible = true;
        }

        private void changeMenuItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Text = "Help";
            item.ToolTipText = "Get help about an application topic.";
        }

        private void changeToolItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("toolItem7");
            item.Text = "Save Styles";
            item.ToolTipText = "Save the full set of Style Sheets.";
        }

        private void changeStatusItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("statusItem3");
            item.Text = "Using \"master\" branch";
            item.ToolTipText = "Branch in use.";
        }
    }
}