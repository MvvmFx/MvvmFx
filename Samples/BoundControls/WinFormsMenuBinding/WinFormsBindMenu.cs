using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;

namespace WinForms.MenuBinding
{
    public partial class WinFormsBindMenu : Form
    {
        public WinFormsBindMenu()
        {
            InitializeComponent();
        }

        private void AutoBind_Load(object sender, System.EventArgs e)
        {
            var menu = MenuCollection.GetMenu("menuItem6");
            menu.Visible = false;
            menu.Text = "Hidden";
            menu.ToolTipText = "Hidden menu entry";
            this.SetBindings();
        }

        private void showItem_Click(object sender, System.EventArgs e)
        {
            var menu = MenuCollection.GetMenu("menuItem6");
            menu.Visible = true;
        }

        private void changeItem_Click(object sender, System.EventArgs e)
        {
            var menu = MenuCollection.GetMenu("menuItem6");
            menu.Text = "Help";
            menu.ToolTipText = "Help menu entry";
        }
    }
}