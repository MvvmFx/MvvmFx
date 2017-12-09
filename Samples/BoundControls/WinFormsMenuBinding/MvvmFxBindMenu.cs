using System;
using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;

namespace WinForms.MenuBinding
{
    public partial class MvvmFxBindMenu : Form
    {
        private readonly MvvmFxBindComponents _binder = new MvvmFxBindComponents();

        public MvvmFxBindMenu()
        {
            InitializeComponent();
        }

        private void MvvmFxBindMenu_Load(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = false;
            item.Text = "Hidden";
            item.ToolTipText = "Hidden menu entry";

            _binder.SetMvvmFxBindings(this);
        }

        private void showItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Visible = true;
        }

        private void changeItem_Click(object sender, EventArgs e)
        {
            var item = ItemCollection.GetItem("menuItem6");
            item.Text = "Help";
            item.ToolTipText = "Get help about an application topic.";
        }
    }
}