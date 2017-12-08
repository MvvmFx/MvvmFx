using BoundControls.Business;
using MvvmFx.CaliburnMicro;
using Wisej.Web;

namespace WisejWeb.MenuBinding
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