using System;
using BoundControls.Business;
#if WINFORMS
using System.Windows.Forms;
using MvvmFx.Controls.WinForms;
#else
using Wisej.Web;
using MvvmFx.Controls.WisejWeb;
using BoundUserControl = Wisej.Web.UserControl;
#endif

namespace WinForms.TestBoundControls
{
    public partial class AutoTreeView : BoundUserControl
    {
        #region Public Members

        public LeafList LeafList { get; set; }

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

            readOnlyAllowSelectCheckBox.Checked = boundTreeView1.ReadOnlyAllowSelect;
            readOnlyAllowDragCheckBox.Checked = boundTreeView1.ReadOnlyAllowDrag;
            readOnlyAllowDropCheckBox.Checked = boundTreeView1.ReadOnlyAllowDrop;
            allowDropOnDescendentsCheckBox.Checked = boundTreeView1.AllowDropOnDescendents;
            allowDropOnRootCheckBox.Checked = boundTreeView1.AllowDropOnRoot;
        }

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

        #region BoundTreeView

        private void tvButtonModel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Object Id: " + boundTreeView1.SelectedNode.Tag);

            if (string.IsNullOrEmpty(textboxModel.Text))
                return;

            var leaf = LeafList.FindLeafByLeafId((int) boundTreeView1.SelectedNode.Tag);
            leaf.LeafName = textboxModel.Text;

            leafName.Text = leaf.LeafName;
        }

        private void tvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var leaf = LeafList.FindLeafByLeafId((int) boundTreeView1.SelectedNode.Tag);
            leaf.LeafName = textboxView.Text;

            leafName.Text = leaf.LeafName;
        }

        #endregion

        #region BoundTreeView Drag&Drop events

        private void boundTreeView1_DragDrop(object sender, DragEventArgs e)
        {
            dragDropStatusLabel.Text = "DragDrop";
        }

        #endregion

        #region UI Events

        private void boundTreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var leaf = LeafList.FindLeafByLeafId((int) e.Node.Tag);
            leafName.Text = leaf.LeafName;
        }

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

        private void boundTreeView1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (boundTreeView1.SelectedNode != null)
            {
                var leaf = LeafList.FindLeafByLeafId((int) boundTreeView1.SelectedNode.Tag);

                if (leaf != null)
                {
                    leafName.Text = leaf.LeafName;
                    leafId.Text = leaf.LeafId.ToString();
                    leafParentId.Text = leaf.LeafParentId.ToString();
                }
            }
            else
            {
                leafName.Text = "null";
                leafId.Text = "null";
                leafParentId.Text = "null";
            }
        }

        private void selectValueButton_Click(object sender, EventArgs e)
        {
            readOnlyAllowSelectCheckBox.Checked = true;
            boundTreeView1.SelectedValue = Convert.ToInt32(textBoxSelectValue.Text);
        }

        #endregion
    }
}