using System;
using BoundControls.Business;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace WinForms.TestBoundTreeView
{
    public partial class ManualTreeView : UserControl
    {
        #region Members

        private DocTypeEditColl _docTypes;

        public DocTypeEditColl DocTypes
        {
            get { return _docTypes; }
        }

        #endregion

        #region Initializers

        public ManualTreeView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _docTypes = DocTypeEditColl.GetDocTypeEditColl();
            BindUI();
        }

        #endregion

        #region Data binding helpers

        private void BindUI()
        {
            foreach (var docType in _docTypes)
            {
                if (docType.DocTypeParentID == null)
                    treeView1.Nodes.Add(CreateNodeForDocType(docType));
            }
        }

        private TreeNode CreateNodeForDocType(DocTypeEdit docType)
        {
            var node = new TreeNode();
            node.Name = docType.DocTypeName;
            node.Text = node.Name;
            node.ToolTipText = docType.DocTypeDescription;
            SetNodeImages(node, docType.DocTypeIsReadOnly);

            PopulateTreeNode(node, docType.DocTypeID);

            return node;
        }

        private void SetNodeImages(TreeNode node, bool isReadOnly)
        {

            if (isReadOnly)
            {
                node.ImageIndex = 2;
                node.ImageIndex = 3;
            }
            else
            {
                node.ImageIndex = 0;
                node.ImageIndex = 1;
            }
            node.SelectedImageIndex = node.ImageIndex;
        }

        private void PopulateTreeNode(TreeNode node, int docTypeId)
        {
            foreach (var docType in _docTypes)
            {
                if (docType.DocTypeParentID == docTypeId)
                    node.Nodes.Add(CreateNodeForDocType(docType));
            }
        }

        #endregion

        #region Manage form state

        private void SortTreeView()
        {
            treeView1.Sort();
        }

        #endregion

        #region BoundTreeView

        private void tvButtonModel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Object ID: " + treeView1.SelectedNode.Tag);

            if (string.IsNullOrEmpty(textboxModel.Text))
                return;

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) treeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = textboxModel.Text;

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        private void tvButtonView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxView.Text))
                return;

            MessageBox.Show("This control doesn't support view setting. Model setting will be used.");

            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) treeView1.SelectedNode.Tag);
            docTypeEdit.DocTypeName = textboxView.Text;

            docTypeName.Text = docTypeEdit.DocTypeName;
        }

        #endregion

        #region BoundTreeView Drag&Drop events

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var tv = (TreeView)sender;
            tv.DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            var tv = (TreeView)sender;
            //var destinationNode = e.DropTarget as TreeNode;
            //tv.SelectedNode = destinationNode; //Highlight the node in relations to the mouse position

            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            dragDropStatusLabel.Text = "DragDrop";

            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                //Continue only if the item being dragged is a TreeNode object

                var tv = (TreeView)sender;
                /*var dropNode = e.DropTarget as TreeNode;
                var dragNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (dragNode != null)
                {
                    // now you can drag

                    if (dropNode != null)
                    {
                        // dropNode is a TreeNode
                        //tv.SelectedNode = dropNode;
                        dropNode.EnsureVisible();

                        ChangeParent(dragNode, dropNode);
                        dropNode.Expand();
                    }
                    else if (e.Data.GetData(typeof(TreeNode)) != null)
                    {
                        // dropNode is the TreeView's root
                        //tv.SelectedNode = dragNode;
                        dragNode.EnsureVisible();

                        ChangeParentToRoot(tv, dragNode);
                        tv.ExpandAll();
                    }
                }*/
            }
        }


        private void ChangeParent(TreeNode childNode, TreeNode parentNode)
        {
            var oldParent = childNode.Parent;
            var oldParentCount1 = oldParent.Nodes.Count;

            childNode.Remove();

            var tempParent = childNode.Parent;
            if (tempParent != null)
                Console.WriteLine("Shoudl be null");

            var oldParentCount2 = oldParent.Nodes.Count;

            parentNode.Nodes.Add(childNode);

            var newParent = childNode.Parent;
            if (newParent != parentNode)
                Console.WriteLine("Shoudl be the same");

            var parent2Count = newParent.Nodes.Count;
        }

        private void ChangeParentToRoot(TreeView tv, TreeNode childNode)
        {
            childNode.Remove();
            tv.Nodes.Add(childNode);
        }
        #endregion

        #region UI Events

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
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
            treeView1.ExpandAll();
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void boundTreeView1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) treeView1.SelectedNode.Tag);

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