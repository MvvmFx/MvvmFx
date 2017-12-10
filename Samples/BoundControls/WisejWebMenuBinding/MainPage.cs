using System;
using Wisej.Web;

namespace WisejWeb.MenuBinding
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var winFormsBindMenu = new WinFormsBindings())
            {
                winFormsBindMenu.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var mvvmFxBindMenu = new MvvmFxBindings())
            {
                mvvmFxBindMenu.ShowDialog();
            }
        }
    }
}