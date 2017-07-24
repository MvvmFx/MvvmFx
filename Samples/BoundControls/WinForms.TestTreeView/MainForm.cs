using System;
using MvvmFx.Logging;
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
            LogManager.GetLog = type => new DebugLogger(type);

            autoTreeViewButton_Click(this, EventArgs.Empty);
        }

        private void autoTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach (IDisposable control in workPanel.Controls)
                control.Dispose();

            workPanel.Controls.Clear();

            var docBrowser = new AutoTreeView();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);
        }

        private void manualTreeViewButton_Click(object sender, EventArgs e)
        {
            foreach (IDisposable control in workPanel.Controls)
                control.Dispose();

            workPanel.Controls.Clear();

            var docBrowser = new ManualTreeView();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);
        }
    }
}