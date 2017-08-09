using System;
using MvvmFx.Logging;
using MvvmFx.NLogLogger;
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
#if !DEBUG
            LogManager.GetLog = type => new DebugLogger(type);
#else
            LogManager.GetLog = type => new NLogLogger(type);
#endif

            autoTreeViewButton_Click(this, EventArgs.Empty);
        }

        private void syncedListsButton_Click(object sender, EventArgs e)
        {
            foreach (IDisposable control in workPanel.Controls)
                control.Dispose();

            workPanel.Controls.Clear();

            var docBrowser = new SyncedLists();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);

            var message = "BindingContextChanged events counted\r\n\r\n";
            message += string.Format("\tDataGridView: {0}\r\n", docBrowser.DataGridViewContextCounter);
            message += string.Format("\tListBox: {0}\r\n", docBrowser.ListBoxContextCounter);
            message += string.Format("\tListView: {0}\r\n", docBrowser.ListViewContextCounter);
            message += string.Format("\tTreeView: {0}\r\n", docBrowser.TreeViewContextCounter);

            MessageBox.Show(message, "Binding context changed");
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