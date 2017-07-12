using System;
#if WINFORMS
using Wisej.Web;
using LogManager = MvvmFx.Wisej.LogManager;
#elif WISEJ
using Wisej.Web;
using LogManager = MvvmFx.Wisej.LogManager;
#else
using Gizmox.WebGUI.Forms;
using LogManager = MvvmFx.WebGUI.Forms.LogManager;
#endif

namespace WisejTestBoundTreeView
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

        private void treeViewButton_Click(object sender, EventArgs e)
        {
            foreach (IDisposable control in workPanel.Controls)
                control.Dispose();

            workPanel.Controls.Clear();

            var docBrowser = new TreeView();
            docBrowser.TabIndex = 0;
            docBrowser.Dock = DockStyle.Fill;
            workPanel.Controls.Add(docBrowser);
        }
    }
}