using System;
using BoundControls.Business;
#if WINFORMS
using System.Drawing;
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace WisejWeb.TestTreeView
{
    public partial class ManualTreeView : UserControl
    {
        #region Members

        public LeafList LeafList { get; private set; }

        #endregion

        #region Initializers

        public ManualTreeView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeafList = LeafList.GetLeafList();
            Populate();
        }

        #endregion

        #region Populate helpers

        private void Populate()
        {
            foreach (var leaf in LeafList)
                if (leaf.LeafParentId == null)
                    treeView1.Nodes.Add(CreateNodeForLeaf(leaf));
            treeView1.ExpandAll();
        }

        private TreeNode CreateNodeForLeaf(Leaf leaf)
        {
            var node = new TreeNode();
            node.Name = leaf.LeafName;
            node.Text = node.Name;
            node.ToolTipText = leaf.LeafDescription;
            SetNodeImages(node, leaf.LeafIsReadOnly);

            PopulateTreeNode(node, leaf.LeafId);

            return node;
        }

        private void SetNodeImages(TreeNode node, bool isReadOnly)
        {
            if (isReadOnly)
            {
                node.ImageIndex = 2;
                node.OpenedImageIndex = 3;
            }
            else
            {
                node.ImageIndex = 0;
                node.OpenedImageIndex = 1;
            }
            node.SelectedImageIndex = node.OpenedImageIndex;
        }

        private void PopulateTreeNode(TreeNode node, int leafId)
        {
            foreach (var leaf in LeafList)
                if (leaf.LeafParentId == leafId)
                    node.Nodes.Add(CreateNodeForLeaf(leaf));
        }

        #endregion

        #region TreeView Drag&Drop events

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var tv = (TreeView) sender;
            tv.DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }

        /*private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            var tv = (TreeView)sender;
            var destinationNode = e.DropTarget as TreeNode;
            tv.SelectedNode = destinationNode; //Highlight the node in relations to the mouse position
            e.Effect = DragDropEffects.Move;
        }*/

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                // Continue only if the item being dragged is a TreeNode object

                var tv = (TreeView) sender;
                var dropNode = e.DropTarget as TreeNode;
                var dragNode = (TreeNode) e.Data.GetData(typeof(TreeNode));

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
                }
            }
        }


        private void ChangeParent(TreeNode childNode, TreeNode parentNode)
        {
            if (TargetIsSourceAncestor(childNode, parentNode))
            {
                var oldParent = childNode.Parent;

                var nodeCounter = childNode.Nodes.Count;
                for (var index = 0; index < nodeCounter; index++)
                {
                    var node = childNode.Nodes[0];
                    node.Remove();
                    oldParent.Nodes.Add(node);
                }
            }

            childNode.Remove();
            parentNode.Nodes.Add(childNode);
        }

        private void ChangeParentToRoot(TreeView tv, TreeNode childNode)
        {
            childNode.Remove();
            tv.Nodes.Add(childNode);
        }

        private bool TargetIsSourceAncestor(TreeNode source, TreeNode dropNode)
        {
            if (dropNode.Parent == null)
                return false;

            if (source == dropNode.Parent)
                return true;

            return TargetIsSourceAncestor(source, dropNode.Parent);
        }

        #endregion
    }
}