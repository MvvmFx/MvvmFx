using System;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;
using Wisej.Web;

namespace WisejWeb.MenuBinding
{
    public partial class MvvmFxBindToolbar : Form
    {
        private readonly MvvmFxBindComponents _binder = new MvvmFxBindComponents();

        public MvvmFxBindToolbar()
        {
            InitializeComponent();
        }

        private void MvvmFxBindToolbar_Load(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("statusItem3");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden status bar entry";

            item = ItemCollection.GetItem("toolItem7");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden tool bar entry";

            _binder.SetMvvmFxBindings(this);
        }

        private void showItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("statusItem3");
            item.Visible = true;

            item = ItemCollection.GetItem("toolItem7");
            item.Visible = true;
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