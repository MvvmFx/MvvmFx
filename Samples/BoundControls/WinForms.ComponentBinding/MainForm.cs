using System;
using System.Windows.Forms;

namespace WinForms.ComponentBinding
{
    public partial class MainForm : Form
    {
        public MainForm()
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