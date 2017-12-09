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
            using (var winFormsBindMenu = new WinFormsBindMenu())
            {
                winFormsBindMenu.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var mvvmFxBindMenu = new MvvmFxBindMenu())
            {
                mvvmFxBindMenu.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var winFormsBindToolBar = new WinFormsBindToolBar())
            {
                winFormsBindToolBar.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var mvvmFxBindToolbar = new MvvmFxBindToolbar())
            {
                mvvmFxBindToolbar.ShowDialog();
            }
        }
    }
}