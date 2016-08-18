using System;
using BoundControls.Business;
#if WINFORMS
using System.Windows.Forms;
using MvvmFx.Windows.Forms;
#elif WISEJ
using Wisej.Web;
using MvvmFx.WisejForms;
using BoundUserControl = Wisej.Web.UserControl;
#else
using Gizmox.WebGUI.Forms;
using MvvmFx.WebGUI.Forms;
#endif

namespace WebGUI.TestBoundTreeView
{
    public partial class TreeView : BoundUserControl
    {
        #region Members

        private DocTypeEditColl _docTypes;

        public DocTypeEditColl DocTypes
        {
            get { return _docTypes; }
        }

        #endregion

        #region Initializers

        public TreeView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _docTypes = DocTypeEditColl.GetDocTypeEditColl();
            BindUI();

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
            docTypeListBindingSource.DataSource = _docTypes;
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
            MessageBox.Show("Object ID: " + boundTreeView1.SelectedNode.Tag);

            if (string.IsNullOrEmpty(textboxModel.Text))
                return;

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) boundTreeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = textboxModel.Text;

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void tvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) boundTreeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = textboxView.Text;

            docTypeName.Text = docTypeEdit.DocTypeName;
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
            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) e.Node.Tag);
            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            _docTypes.ResetBindings();
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
                var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) boundTreeView1.SelectedNode.Tag);

                if (docTypeEdit != null)
                {
                    docTypeName.Text = docTypeEdit.DocTypeName;
                    docTypeID.Text = docTypeEdit.DocTypeID.ToString();
                    docTypeParentID.Text = docTypeEdit.DocTypeParentID.ToString();
                }
            }
            else
            {
                docTypeName.Text = "null";
                docTypeID.Text = "null";
                docTypeParentID.Text = "null";
            }
        }

        #endregion
    }
}