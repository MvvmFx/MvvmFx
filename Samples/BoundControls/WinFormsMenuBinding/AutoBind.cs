using System.Windows.Forms;
using BoundControls.Business;
using MvvmFx.CaliburnMicro;

namespace WinForms.MenuBinding
{
    public partial class AutoBind : Form
    {
        public AutoBind()
        {
            InitializeComponent();
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
            menu.Text = "Apply Style Sheet";
            menu.ToolTipText = "Apply Style Sheet menu entry";
        }
    }
}