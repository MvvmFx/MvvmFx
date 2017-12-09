using System;
using System.Windows.Forms;

namespace WinForms.MenuBinding
{
    public partial class MainForm : Form
    {
        public MainForm()
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