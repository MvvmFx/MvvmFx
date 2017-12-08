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

        private void buttonHardBind_Click(object sender, EventArgs e)
        {
            using (var manualMenu = new HardBind())
            {
                manualMenu.closeFile.Visible = false;
                manualMenu.ShowDialog();
            }
        }

        private void buttonBoundOnDemand_Click(object sender, EventArgs e)
        {
            using (var boundMenu = new BoundOnDemand())
            {
                boundMenu.ShowDialog();
            }
        }

        private void buttonAutoBind_Click(object sender, EventArgs e)
        {
            using (var autoBind = new AutoBind())
            {
                autoBind.ShowDialog();
            }
        }
    }
}