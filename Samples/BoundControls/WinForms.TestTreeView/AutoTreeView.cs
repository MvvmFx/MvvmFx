using System;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
using BoundUserControl = Wisej.Web.UserControl;
#endif

namespace WinForms.TestTreeView
{
    public partial class AutoTreeView : BoundUserControl
    {
        #region Members

        public LeafList LeafList { get; set; }

        #endregion

        #region Data binding helpers

        private void BindUI()
        {
            LeafList = LeafList.GetLeafListWithErrors();
            leafListBindingSource.DataSource = LeafList;
        }

        #endregion

        #region Manage form state

        private void SortTreeView()
        {
            boundTreeView1.Sort();
        }

        #endregion

        #region BoundTreeView Drag&Drop events

        private void boundTreeView1_DragDrop(object sender, DragEventArgs e)
        {
            dragDropStatusLabel.Text = "DragDrop";
        }

        #endregion

        #region Initializers

        public AutoTreeView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindUI();
            boundTreeView1.ExpandAll();
            MessageBox.Show("Tree expanded.");

            readOnlyAllowSelectCheckBox.Checked = boundTreeView1.ReadOnlyAllowSelect;
            readOnlyAllowDragCheckBox.Checked = boundTreeView1.ReadOnlyAllowDrag;
            readOnlyAllowDropCheckBox.Checked = boundTreeView1.ReadOnlyAllowDrop;
            allowDropOnDescendentsCheckBox.Checked = boundTreeView1.AllowDropOnDescendents;
            allowDropOnRootCheckBox.Checked = boundTreeView1.AllowDropOnRoot;
        }

        #endregion

        #region UI Events

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LeafList.ResetBindings();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            SortTreeView();
        }

        private void expandButton_Click(object sender, EventArgs e)
        {
            boundTreeView1.ExpandAll();
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            boundTreeView1.CollapseAll();
        }

        private void readOnlyAllowSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            boundTreeView1.ReadOnlyAllowSelect = readOnlyAllowSelectCheckBox.Checked;
        }

        private void readOnlyAllowDragCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            boundTreeView1.ReadOnlyAllowDrag = readOnlyAllowDragCheckBox.Checked;
        }

        private void readOnlyAllowDropCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            boundTreeView1.ReadOnlyAllowDrop = readOnlyAllowDropCheckBox.Checked;
        }

        private void allowDropOnDescendentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            boundTreeView1.AllowDropOnDescendents = allowDropOnDescendentsCheckBox.Checked;
        }

        private void allowDropOnRootCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            boundTreeView1.AllowDropOnRoot = allowDropOnRootCheckBox.Checked;
        }

        #endregion
    }
}