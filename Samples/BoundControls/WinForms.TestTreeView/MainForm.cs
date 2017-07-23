using System;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace WinForms.TestTreeView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var docBrowser = new ManualTreeView();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);
        }
    }
}