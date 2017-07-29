namespace WisejWeb.TestTreeView
{
    partial class ManualTreeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualTreeView));
            Wisej.Web.ImageListEntry imageListEntry1 = new Wisej.Web.ImageListEntry(((System.Drawing.Image)(resources.GetObject("imageList.Images"))), "Node.png");
            Wisej.Web.ImageListEntry imageListEntry2 = new Wisej.Web.ImageListEntry(((System.Drawing.Image)(resources.GetObject("imageList.Images1"))), "NodeSelected.png");
            Wisej.Web.ImageListEntry imageListEntry3 = new Wisej.Web.ImageListEntry(((System.Drawing.Image)(resources.GetObject("imageList.Images2"))), "ReadOnlyNode.png");
            Wisej.Web.ImageListEntry imageListEntry4 = new Wisej.Web.ImageListEntry(((System.Drawing.Image)(resources.GetObject("imageList.Images3"))), "ReadOnlyNodeSelected.png");
            this.treeView1 = new Wisej.Web.TreeView();
            this.imageList = new Wisej.Web.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrag = true;
            this.treeView1.AllowDrop = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(16, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.OpenedImageIndex = 1;
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(212, 394);
            this.treeView1.TabIndex = 15;
            this.treeView1.ItemDrag += new Wisej.Web.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.DragDrop += new Wisej.Web.DragEventHandler(this.treeView1_DragDrop);
            // 
            // imageList
            // 
            this.imageList.Images.AddRange(new Wisej.Web.ImageListEntry[] {
            imageListEntry1,
            imageListEntry2,
            imageListEntry3,
            imageListEntry4});
            // 
            // ManualTreeView
            // 
            this.Controls.Add(this.treeView1);
            this.MaximumSize = new System.Drawing.Size(931, 438);
            this.MinimumSize = new System.Drawing.Size(931, 438);
            this.Name = "ManualTreeView";
            this.Size = new System.Drawing.Size(931, 438);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.TreeView treeView1;
        private Wisej.Web.ImageList imageList;
    }
}