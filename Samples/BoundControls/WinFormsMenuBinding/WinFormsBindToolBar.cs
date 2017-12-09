using System;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;

namespace WinForms.MenuBinding
{
    public partial class WinFormsBindToolBar : Form
    {
        public WinFormsBindToolBar()
        {
            InitializeComponent();
        }

        private void WinFormsBindToolBar_Load(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("statusItem3");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden status bar entry";

            item = ItemCollection.GetItem("toolItem7");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden tool bar entry";

            this.SetBindings();
        }

        private void showItem_Click(object sender, EventArgs e)
        {
            var getItem = ItemCollection.GetItem("statusItem3");
            getItem.Visible = true;

            getItem = ItemCollection.GetItem("toolItem7");
            getItem.Visible = true;
        }

        private void changeItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("statusItem3");
            item.Text = "Using \"master\" branch";
            item.ToolTipText = "Branch in use.";

            item = ItemCollection.GetItem("toolItem7");
            item.Text = "Save Styles";
            item.ToolTipText = "Save the full set of Style Sheets.";
        }
    }
}