using System;
using BoundControls.Business;
#if !WEBGUI
using System.Windows.Forms;
using MvvmFx.Windows.Forms;
#else
using Gizmox.WebGUI.Forms;
using MvvmFx.WebGUI.Forms;
#endif

namespace WinForms.TestBoundTreeView
{
    public partial class SyncedLists : BoundUserControl
    {
        #region Members

        private DocTypeEditColl _docTypes;

        public DocTypeEditColl DocTypes
        {
            get { return _docTypes; }
        }

        #endregion

        #region Initializers

        public SyncedLists()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ColumnsDataGridView();
            ColumnsListView();

            _docTypes = DocTypeEditColl.GetDocTypeEditColl();
            BindUI();

            GroupsListView();
            SortListView();

            _docTypes.ListChanged += _docTypes_ListChanged;
        }

        void _docTypes_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            MessageBox.Show("Business object ListChanged event.", "Event triggered", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion        

        #region Data binding helpers

        private void BindUI()
        {
            _docTypes.BeginEdit();
            docTypeListBindingSource.DataSource = _docTypes;
        }

        /*private void RebindUI(bool saveObject, bool rebind)
        {
            // disable events
            docTypeListBindingSource.RaiseListChangedEvents = false;
            try
            {
                // unbind the UI
                UnbindBindingSource(docTypeListBindingSource, saveObject, true);

                // save or cancel changes
                if (saveObject)
                {
                    _docTypes.ApplyEdit();
                    try
                    {
                        _docTypes = _docTypes.Save();
                    }
                    catch (Csla.DataPortalException ex)
                    {
                        MessageBox.Show(ex.BusinessException.ToString(), "Error saving", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    _docTypes.CancelEdit();
            }
            finally
            {
                // rebind UI if requested
                if (rebind)
                    BindUI();

                // restore events
                docTypeListBindingSource.RaiseListChangedEvents = true;

                if (rebind)
                {
                    // refresh the UI if rebinding
                    docTypeListBindingSource.ResetBindings(false);
                }
            }
        }*/

        /*private void UnbindBindingSource(BindingSource source, bool apply, bool isRoot)
        {
            var current = source.Current as System.ComponentModel.IEditableObject;
            if (isRoot)
                source.DataSource = null;
            if (current != null)
                if (apply)
                    current.EndEdit();
                else
                    current.CancelEdit();
        }*/

        #endregion

        #region Inactive CRUD operations

        /*private void OKButton_Click(object sender, EventArgs e)
        {
            RebindUI(true, false);
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            RebindUI(true, true);
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            RebindUI(false, true);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            RebindUI(false, false);
            Close();
        }*/

        #endregion

        #region Manage form state

        private void RedrawForm()
        {
            /*_docTypes.ResetBindings();// force update all data bound objects
            GroupsListView();
            SortListView();
            boundTreeView1.ExpandAll();*/
        }

        private void ColumnsDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "DocType Name";
            dataGridView1.Columns[1].Width = 120;
        }

        private void ColumnsListView()
        {
            boundListView1.Columns.RemoveAt(3);
            boundListView1.Columns.RemoveAt(1);
            boundListView1.Columns[0].Text = "ID";
            boundListView1.Columns[0].Width = 50;
            boundListView1.Columns[1].Text = "DocType Name";
            boundListView1.Columns[1].Width = 120;
        }

        private void GroupsListView()
        {
            boundListView1.Groups.Clear();

            boundListView1.Groups.Add(new ListViewGroup("Root", HorizontalAlignment.Left));
            boundListView1.Groups.Add(new ListViewGroup("One", HorizontalAlignment.Left));
            boundListView1.Groups.Add(new ListViewGroup("Two", HorizontalAlignment.Left));
            boundListView1.Groups.Add(new ListViewGroup("Others", HorizontalAlignment.Left));

            foreach (ListViewItem item in boundListView1.Items)
            {
                var parentID = ((DocTypeEdit)item.Tag).DocTypeParentID;
                if (parentID == null)
                {
                    item.Group = boundListView1.Groups[0];
                }
                else if (parentID == 1)
                    boundListView1.Groups[1].Items.Add(item);
                else if (parentID == 2)
                    boundListView1.Groups[2].Items.Add(item);
                else
                    boundListView1.Groups[3].Items.Add(item);
            }
        }

        private void SortListView()
        {
#if !WEBGUI
            boundListView1.Sorting = SortOrder.Ascending;
#else
            boundListView1.Columns[0].SortOrder = SortOrder.Descending;
            boundListView1.Columns[0].SortPosition = 2; // Supports multi-column sort
            boundListView1.Columns[1].SortOrder = SortOrder.Ascending;
            boundListView1.Columns[1].SortPosition = 1; // Supports multi-column sort
            /*boundListView1.ListViewItemSorter = <ICompares>;*/
#endif
        }

        private void SortTreeView()
        {
            boundTreeView1.Sort();
            //boundTreeView1.Sorted = true;
        }

        #endregion

        #region DataGridView

        private void dgvButtonModel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || string.IsNullOrEmpty(dgvTextboxModel.Text))
                return;

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)dataGridView1.CurrentRow.Cells[0].Value);
            docTypeEdit.DocTypeName = dgvTextboxModel.Text;
            RedrawForm();

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void dgvButtonView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || string.IsNullOrEmpty(dgvTextboxView.Text))
                return;

            dataGridView1.CurrentRow.Cells[1].Value = dgvTextboxView.Text;
            RedrawForm();

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)dataGridView1.CurrentRow.Cells[0].Value);
            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        #endregion

        #region ListBox

        private void lbButtonModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbTextboxModel.Text))
                return;

            ((DocTypeEdit)listBox1.Items[listBox1.SelectedIndex]).DocTypeName = lbTextboxModel.Text;
            RedrawForm();

            docTypeName.Text = ((DocTypeEdit)listBox1.Items[listBox1.SelectedIndex]).DocTypeName;
        }

        private void lbButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            ((DocTypeEdit)listBox1.Items[listBox1.SelectedIndex]).DocTypeName = lbTextboxView.Text;
            RedrawForm();

            docTypeName.Text = ((DocTypeEdit)listBox1.Items[listBox1.SelectedIndex]).DocTypeName;
        }

        #endregion

        #region ListView

        private void lvButtonModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lvTextboxModel.Text))
                return;

            var docTypeEdit = (DocTypeEdit)boundListView1.SelectedItems[0].Tag;
            docTypeEdit.DocTypeName = lvTextboxModel.Text;
            RedrawForm();

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void lvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lvTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var docTypeEdit = (DocTypeEdit)boundListView1.SelectedItems[0].Tag;
            docTypeEdit.DocTypeName = lvTextboxView.Text;
            RedrawForm();

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        #endregion

        #region BoundTreeView

        private void tvButtonModel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Object ID: " + boundTreeView1.SelectedNode.Tag);

            if (string.IsNullOrEmpty(tvTextboxModel.Text))
                return;

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)boundTreeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = tvTextboxModel.Text;
            RedrawForm();

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void tvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tvTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)boundTreeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = tvTextboxView.Text;
            RedrawForm();

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        #endregion

        private void queryObjectButton_Click(object sender, EventArgs e)
        {
            boundTreeView1.Select();
            if (boundTreeView1.SelectedNode == null)
                MessageBox.Show("Select one node");
            else
            {
                docTypeName.Text = ((DocTypeEdit)boundListView1.SelectedItems[0].Tag).DocTypeName;
                docTypeID.Text = ((DocTypeEdit)boundListView1.SelectedItems[0].Tag).DocTypeID.ToString();
                docTypeParentID.Text = ((DocTypeEdit)boundListView1.SelectedItems[0].Tag).DocTypeParentID.ToString();
            }
        }

        #region BoundTreeView Drag&Drop events

        private void boundTreeView1_DragDrop(object sender, DragEventArgs e)
        {
            dragDropStatusLabel.Text = "DragDrop";
            RedrawForm();
        }

        #endregion

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)dataGridView1.CurrentRow.Cells[0].Value);
            docTypeName.Text = docTypeEdit.DocTypeName;
            RedrawForm();
        }

        private void boundListView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            docTypeName.Text = ((DocTypeEdit)boundListView1.SelectedItems[0].Tag).DocTypeName;
            RedrawForm();
        }

        private void boundTreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int)e.Node.Tag);
            docTypeName.Text = docTypeEdit.DocTypeName;
            RedrawForm();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            SortTreeView();
        }

        private void boundListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boundTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
