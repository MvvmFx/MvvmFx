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
            var menu = MenuCollection.GetMenu("statusItem3");
            menu.Visible = false;
            menu.Text = "Hidden";
            menu.ToolTipText = "Hidden status bar entry";
            this.SetBindings();
        }

        private void showItem_Click(object sender, System.EventArgs e)
        {
            var menu = MenuCollection.GetMenu("statusItem3");
            menu.Visible = true;
        }

        private void changeItem_Click(object sender, System.EventArgs e)
        {
            var menu = MenuCollection.GetMenu("statusItem3");
            menu.Text = "Using \"master\" branch";
            menu.ToolTipText = "Branch in use.";
        }
    }
}