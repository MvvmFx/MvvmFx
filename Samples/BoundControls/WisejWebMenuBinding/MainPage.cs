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
            using (var boundMenu = new BoundOnDemand())
            {
                boundMenu.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var autoBind = new AutoBind())
            {
                autoBind.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var mvvmFxBind = new MvvmFxBind())
            {
                mvvmFxBind.ShowDialog();
            }
        }
    }
}