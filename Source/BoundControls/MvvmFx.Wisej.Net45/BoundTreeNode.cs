/********************************************************************
    created:	2005/03/27
    created:	27:3:2005   7:05
    filename: 	BoundTreeNode.cs	
    author:		Mike Chaliy
    published:  http://www.codeproject.com/Articles/9949/Hierarchical-TreeView-control-with-data-binding-en

    purpose:	Data binding enabled hierarchical tree view control.

The MIT License (MIT)

Copyright (c) 2005 Mike Chaliy

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*********************************************************************/
/*

Improvements by Tiago Freitas Leal (MvvmFx project).

*/

using System;
#if WISEJ
using Wisej.Web;
#elif WEBGUI
using Gizmox.WebGUI.Forms;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.Wisej
{
    /// <summary>
    /// Tree node with additional data related information.
    /// </summary>
    public class BoundTreeNode : TreeNode
    {
        #region Private fields

        private bool _readOnly;
        private TreeNode _cachedFirstNode;
        private TreeNode _cachedLastNode;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor of the node.
        /// </summary>
        public BoundTreeNode(int position)
        {
            Position = position;
        }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets or sets the node identifier.
        /// </summary>
        /// <value>
        /// The node identifier.
        /// </value>
        internal object NodeId
        {
            get { return Tag; }
            set { Tag = value; }
        }

        /// <summary>
        /// Gets or sets the parent node identifier.
        /// </summary>
        /// <value>
        /// The parent node identifier.
        /// </value>
        internal object ParentNodeId { get; set; }

        /// <summary>
        /// Gets or sets the node position in the current currency manager.
        /// </summary>
        /// <value>
        /// The node position in the current currency manager.
        /// </value>
        internal int Position { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the node is read only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the node is read only; otherwise, <c>false</c>.
        /// </value>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (_readOnly != value)
                {
                    _readOnly = value;
                    SetNodeImages();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether there is a node error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if there is a node error; otherwise, <c>false</c>.
        /// </value>
        public bool NodeError { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether this node can be selectede.
        /// </summary>
        /// <value>
        /// <c>true</c> if this node can be selected; otherwise, <c>false</c>.
        /// </value>
        public bool CanSelectNode
        {
            get { return ((BoundTreeView) TreeView).ReadOnlyAllowSelect || ReadOnly == false; }
        }

        #endregion

        #region Internal Methods

        internal void SetNodeImages()
        {
            if (ReadOnly)
            {
                if (TreeView != null)
                {
                    if (TreeView.ImageIndex != -1)
                        ImageIndex = ((BoundTreeView) TreeView).ReadOnlyImageIndex;
                    else if (TreeView.ImageKey != string.Empty)
                        ImageKey = ((BoundTreeView) TreeView).ReadOnlyImageKey;

                    if (TreeView.SelectedImageIndex != -1)
                        SelectedImageIndex = ((BoundTreeView) TreeView).ReadOnlySelectedImageIndex;
                    else if (TreeView.SelectedImageKey != string.Empty)
                        SelectedImageKey = ((BoundTreeView) TreeView).ReadOnlySelectedImageKey;
                }
            }
            else
            {
                ImageIndex = -1;
                SelectedImageIndex = -1;
            }
        }

        #endregion

        #region Navigation methods

        /// <summary>
        /// Moves to first tree node.
        /// </summary>
        public void MoveToFirstTreeNode()
        {
            if (_cachedFirstNode == null)
                _cachedFirstNode = FirstTreeNode();

            TreeView.SelectedNode = _cachedFirstNode;
        }

        /// <summary>
        /// Moves to previous tree node.
        /// </summary>
        public void MoveToPreviousTreeNode()
        {
            TreeView.SelectedNode = PrevTreeNode(TreeView.SelectedNode);
        }

        /// <summary>
        /// Moves to next tree node.
        /// </summary>
        public void MoveToNextTreeNode()
        {
            TreeView.SelectedNode = NextTreeNode(TreeView.SelectedNode);
        }

        /// <summary>
        /// Moves to last tree node.
        /// </summary>
        public void MoveToLastTreeNode()
        {
            if (_cachedLastNode == null)
                _cachedLastNode = LastTreeNode();

            TreeView.SelectedNode = _cachedLastNode;
        }

        #endregion

        #region Public navigation helper methods

        /// <summary>
        /// Gets the first tree node of the tree view.
        /// </summary>
        /// <returns>The first TreeNode.</returns>
        public TreeNode FirstTreeNode()
        {
            // get the first top treeNode
            var node = TreeView.Nodes[0];

            // find a selectable treeNode
            while (node != null && !((BoundTreeNode) node).CanSelectNode)
            {
                node = NextTreeNode(node);
            }

            // cache the result
            _cachedFirstNode = node;
            return node;
        }

        /// <summary>
        /// Gets the last tree node of the tree view.
        /// </summary>
        /// <returns>The last TreeNode.</returns>
        public TreeNode LastTreeNode()
        {
            // get the last top treeNode
            var node = TreeView.Nodes[TreeView.Nodes.Count - 1];

            // get the last child of the very last branch
            while (node.LastNode != null)
            {
                node = node.LastNode;
            }

            // go back until we find a selectable treeNode
            while (node != null && !((BoundTreeNode) node).CanSelectNode)
            {
                node = PrevTreeNode(node);
            }

            // cache the result
            _cachedLastNode = node;
            return node;
        }

        /// <summary>
        /// Gets the tree node following the current tree node.
        /// </summary>
        /// <returns>The next TreeNode.</returns>
        public TreeNode NextTreeNode()
        {
            return NextTreeNode(this);
        }

        /// <summary>
        /// Gets the tree node following the specifies tree node.
        /// </summary>
        /// <returns>The next TreeNode.</returns>
        public TreeNode NextTreeNode(TreeNode treeNode)
        {
            if (treeNode == null)
                throw new ArgumentNullException("treeNode");

            var node = ScanNodesNextEverywhere(treeNode, true);

            // end of the line; return the last treeNode
            if (node == null)
                node = LastTreeNode();

            return node;
        }

        /// <summary>
        /// Gets the tree node before the current tree node.
        /// </summary>
        /// <returns>The previous TreeNode.</returns>
        public TreeNode PrevTreeNode()
        {
            return PrevTreeNode(this);
        }

        /// <summary>
        /// Gets the tree node before the specifies tree node.
        /// </summary>
        /// <returns>The previous TreeNode.</returns>
        public TreeNode PrevTreeNode(TreeNode treeNode)
        {
            if (treeNode == null)
                throw new ArgumentNullException("treeNode");

            var node = ScanNodesPrevEverywhere(treeNode, true);

            // end of the line; return the first treeNode
            if (node == null)
                node = FirstTreeNode();

            return node;
        }

        #endregion

        #region Private Navigation helper methods

        private TreeNode ScanNodesNextEverywhere(TreeNode treeNode, bool starting)
        {
            if (!starting && ((BoundTreeNode) treeNode).CanSelectNode)
                return treeNode;

            if (treeNode.FirstNode != null)
                return ScanNodesNextEverywhere(treeNode.FirstNode, false);

            if (treeNode.NextNode != null)
                return ScanNodesNextEverywhere(treeNode.NextNode, false);

            var node = treeNode;
            while (node.Parent != null)
            {
                node = node.Parent;
                while (node.NextNode != null)
                {
                    return ScanNodesNextEverywhere(node.NextNode, false);
                }
            }

            return null;
        }

        private TreeNode ScanNodesPrevEverywhere(TreeNode treeNode, bool starting)
        {
            if (!starting && ((BoundTreeNode) treeNode).CanSelectNode)
                return treeNode;

            var node = treeNode;
            while (node.PrevNode != null)
            {
                node = node.PrevNode;
                while (node.LastNode != null)
                {
                    node = node.LastNode;
                }
                return ScanNodesPrevEverywhere(node, false);
            }

            if (treeNode.Parent != null)
                return ScanNodesPrevEverywhere(treeNode.Parent, false);

            return null;
        }

        #endregion
    }
}