using System;
#if WINFORMS
using System.Windows.Forms;
using LogManager = MvvmFx.Windows.Forms.LogManager;
#else
using Wisej.Web;
using LogManager = MvvmFx.WisejWeb.LogManager;
#endif

namespace WisejWeb.TestBoundControls
{
    public partial class MainForm : Page
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            LogManager.GetLog = type => new MvvmFx.Logging.DebugLogger(type);
#else
            LogManager.GetLog = type => new MvvmFx.NLogLogger.NLogLogger(type);
#endif
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

        private void treeListViewButton_Click(object sender, EventArgs e)
        {
            foreach (IDisposable control in workPanel.Controls)
                control.Dispose();

            workPanel.Controls.Clear();

            var docBrowser = new TreeListView();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);
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

        private void stripWindowButton_Click(object sender, EventArgs e)
        {
            new StripWindow().ShowDialog();
        }
    }
}