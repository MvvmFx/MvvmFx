using System;
using System.Collections.Generic;
using BoundControls.Business;
using Gizmox.WebGUI.Forms;

namespace TestPlainTreeView
{
    public partial class Form1 : Form
    {
        #region Members

        private DocTypeEditColl _docTypes;

        #endregion

        #region Initializers

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _docTypes = DocTypeEditColl.GetDocTypeEditColl();
            BindUI();

            _docTypes.ListChanged += _docTypes_ListChanged;
        }

        private void _docTypes_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            MessageBox.Show("Business object ListChanged event: " + e.ListChangedType, "Event triggered",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Data binding helpers

        private void BindUI()
        {
            var docTypes = GetSortedDocTypes();

            foreach (var docType in docTypes)
            {
                TreeNode node = null;
                if (docType.DocTypeParentID.HasValue)
                    node = GetTreeNode(docType.DocTypeParentID.Value);
                if (node == null)
                {
                    treeView1.Nodes.Add(new TreeNode()
                    {
                        Text = docType.DocTypeName,
                        ToolTipText = docType.DocTypeDescription,
                        Tag = docType.DocTypeID
                    });
                }
                else
                {
                    node.Nodes.Add(new TreeNode()
                    {
                        Text = docType.DocTypeName,
                        ToolTipText = docType.DocTypeDescription,
                        Tag = docType.DocTypeID
                    });
                }
            }
        }

        private DocTypeEditColl GetSortedDocTypes()
        {
            var docTypes = DocTypeEditColl.NewDocTypeEditColl();
            var childDocTypes = DocTypeEditColl.NewDocTypeEditColl();
            var insertedValues = new List<int>();
            var pendingValues = new List<int>();

            foreach (var docType in _docTypes)
            {
                if (insertedValues.IndexOf(docType.DocTypeID) > -1 ||
                    pendingValues.IndexOf(docType.DocTypeID) > -1 ||
                    docType.DocTypeID == docType.DocTypeParentID)
                    continue;
                if (docType.DocTypeParentID == null)
                {
                    docTypes.Add(docType);
                    insertedValues.Add(docType.DocTypeID);
                }
                else
                {
                    childDocTypes.Add(docType);
                    pendingValues.Add(docType.DocTypeID);
                }
            }

            while (true)
            {
                foreach (var docType in childDocTypes)
                {
                    if (pendingValues.IndexOf(docType.DocTypeID) > -1)
                    {
                        if (insertedValues.IndexOf(docType.DocTypeParentID.Value) > -1)
                        {
                            docTypes.Add(docType);
                            insertedValues.Add(docType.DocTypeID);
                            pendingValues.Remove(docType.DocTypeID);
                        }
                    }
                }
                if (pendingValues.Count == 1)
                    break;
            }

            return docTypes;
        }

        private TreeNode GetTreeNode(int treeNodeId)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Tag.ToString() == treeNodeId.ToString())
                    return node;

                var childNode = GetTreeNode(treeNodeId, node);
                if (childNode != null)
                    return childNode;
            }

            return null;
        }

        private TreeNode GetTreeNode(int treeNodeId, TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Tag.ToString() == treeNodeId.ToString())
                    return node;

                return GetTreeNode(treeNodeId, node);
            }

            return null;
        }

        #endregion

        private void boundTreeView1_DragDrop(object sender, DragEventArgs e)
        {
            dragDropStatusLabel.Text = "DragDrop";
        }

        private void boundTreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var docTypeEdit = _docTypes.FindDocTypeEditByDocTypeID((int) e.Node.Tag);
            docTypeName.Text = docTypeEdit.DocTypeName;
        }
    }
}