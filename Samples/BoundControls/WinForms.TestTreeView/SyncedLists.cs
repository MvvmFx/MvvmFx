using System;
using BoundControls.Business;
#if WINFORMS
using System.Windows.Forms;
using MvvmFx.WinForms;
#else
using Wisej.Web;
using MvvmFx.WisejWeb;
using BoundUserControl = Wisej.Web.UserControl;
#endif

namespace WinForms.TestTreeView
{
    public partial class SyncedLists : BoundUserControl
    {
        #region Public Members

        public LeafList LeafList { get; set; }

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

            BindUI();

            GroupsListView();

            LeafList.ListChanged += LeafList_ListChanged;

            boundTreeView1.ExpandAll();
        }

        private void LeafList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            MessageBox.Show("Business object ListChanged event.", "Event triggered", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        #region Data binding helpers

        private void BindUI()
        {
            LeafList = LeafList.GetLeafList();
            leafListBindingSource.DataSource = LeafList;
        }

        #endregion

        #region Manage form state

        private void RedrawForm()
        {
            LeafList.ResetBindings(); // force update all data bound objects
            GroupsListView();
            boundTreeView1.ExpandAll();
        }

        private void ColumnsDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Leaf Name";
            dataGridView1.Columns[1].Width = 120;
        }

        private void ColumnsListView()
        {
            boundListView1.Columns.RemoveAt(4);
            boundListView1.Columns.RemoveAt(3);
            boundListView1.Columns.RemoveAt(1);
            boundListView1.Columns[0].Text = "Id";
            boundListView1.Columns[0].Width = 50;
            boundListView1.Columns[1].Text = "Leaf Name";
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
                var parentId = ((Leaf) item.Tag).LeafParentId;
                if (parentId == null)
                {
                    item.Group = boundListView1.Groups[0];
                }
                else if (parentId == 1)
                    boundListView1.Groups[1].Items.Add(item);
                else if (parentId == 2)
                    boundListView1.Groups[2].Items.Add(item);
                else
                    boundListView1.Groups[3].Items.Add(item);
            }
        }

        private void SortListView()
        {
            boundListView1.Sorting = SortOrder.Ascending;
        }

        private void SortTreeView()
        {
            boundTreeView1.Sort();
        }

        #endregion

        #region DataGridView

        private void dgvButtonModel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || string.IsNullOrEmpty(dgvTextboxModel.Text))
                return;

            var leaf = LeafList.FindLeafByLeafId((int) dataGridView1.CurrentRow.Cells[0].Value);
            leaf.LeafName = dgvTextboxModel.Text;
            RedrawForm();

            leafName.Text = leaf.LeafName;
        }

        private void dgvButtonView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || string.IsNullOrEmpty(dgvTextboxView.Text))
                return;

            dataGridView1.CurrentRow.Cells[1].Value = dgvTextboxView.Text;
            RedrawForm();

            var leaf = LeafList.FindLeafByLeafId((int) dataGridView1.CurrentRow.Cells[0].Value);
            leafName.Text = leaf.LeafName;
        }

        #endregion

        #region ListBox

        private void lbButtonModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbTextboxModel.Text))
                return;

            ((Leaf) listBox1.Items[listBox1.SelectedIndex]).LeafName = lbTextboxModel.Text;
            RedrawForm();

            leafName.Text = ((Leaf) listBox1.Items[listBox1.SelectedIndex]).LeafName;
        }

        private void lbButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            ((Leaf) listBox1.Items[listBox1.SelectedIndex]).LeafName = lbTextboxView.Text;
            RedrawForm();

            leafName.Text = ((Leaf) listBox1.Items[listBox1.SelectedIndex]).LeafName;
        }

        #endregion

        #region ListView

        private void lvButtonModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lvTextboxModel.Text))
                return;

            var leaf = (Leaf) boundListView1.SelectedItems[0].Tag;
            leaf.LeafName = lvTextboxModel.Text;
            RedrawForm();

            leafName.Text = leaf.LeafName;
        }

        private void lvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lvTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var leaf = (Leaf) boundListView1.SelectedItems[0].Tag;
            leaf.LeafName = lvTextboxView.Text;
            RedrawForm();

            leafName.Text = leaf.LeafName;
        }

        #endregion

        #region BoundTreeView

        private void tvButtonModel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Object Id: " + boundTreeView1.SelectedNode.Tag);

            if (string.IsNullOrEmpty(tvTextboxModel.Text))
                return;

            var leaf = LeafList.FindLeafByLeafId((int) boundTreeView1.SelectedNode.Tag);
            leaf.LeafName = tvTextboxModel.Text;
            RedrawForm();

            leafName.Text = leaf.LeafName;
        }

        private void tvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tvTextboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var leaf = LeafList.FindLeafByLeafId((int) boundTreeView1.SelectedNode.Tag);
            leaf.LeafName = tvTextboxView.Text;
            RedrawForm();

            leafName.Text = leaf.LeafName;
        }

        #endregion

        private void queryObjectButton_Click(object sender, EventArgs e)
        {
            boundTreeView1.Select();
            if (boundTreeView1.SelectedNode == null)
                MessageBox.Show("Select one node");
            else
            {
                leafName.Text = ((Leaf) boundListView1.SelectedItems[0].Tag).LeafName;
                leafId.Text = ((Leaf) boundListView1.SelectedItems[0].Tag).LeafId.ToString();
                leafParentId.Text = ((Leaf) boundListView1.SelectedItems[0].Tag).LeafParentId.ToString();
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
            var leaf = LeafList.FindLeafByLeafId((int) dataGridView1.CurrentRow.Cells[0].Value);
            leafName.Text = leaf.LeafName;
            RedrawForm();
        }

        private void boundListView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            leafName.Text = ((Leaf) boundListView1.SelectedItems[0].Tag).LeafName;
            RedrawForm();
        }

        private void boundTreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var leaf = LeafList.FindLeafByLeafId((int) e.Node.Tag);
            leafName.Text = leaf.LeafName;
            RedrawForm();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LeafList.ResetBindings();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            SortListView();
            GroupsListView();
            SortTreeView();
        }

        #region BindingContext handling

        public int DataGridViewContextCounter { get; private set; }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            DataGridViewContextCounter++;
        }

        public int ListBoxContextCounter { get; private set; }

        private void listBox1_BindingContextChanged(object sender, EventArgs e)
        {
            ListBoxContextCounter++;
        }

        public int ListViewContextCounter { get; private set; }

        private void boundListView1_BindingContextChanged(object sender, EventArgs e)
        {
            ListViewContextCounter++;
        }

        public int TreeViewContextCounter { get; private set; }

        private void boundTreeView1_BindingContextChanged(object sender, EventArgs e)
        {
            TreeViewContextCounter++;
        }

        #endregion
    }
}