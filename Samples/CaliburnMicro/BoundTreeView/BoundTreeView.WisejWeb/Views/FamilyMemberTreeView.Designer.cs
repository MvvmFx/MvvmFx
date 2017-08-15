namespace BoundTreeView.Views
{
    partial class FamilyMemberTreeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boundTreeView1 = new MvvmFx.WisejWeb.BoundTreeView();
            this.displayName = new Wisej.Web.Label();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.SuspendLayout();
            // 
            // boundTreeView1
            // 
            this.boundTreeView1.AllowDrop = true;
            this.boundTreeView1.AllowDropOnDescendents = false;
            this.boundTreeView1.AllowDropOnRoot = false;
            this.boundTreeView1.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.boundTreeView1.DuplicatedCaption = "Duplicated Identifier Error";
            this.boundTreeView1.DuplicatedMessage = "Node \"{0}\" duplicates identifier \"{1}\"";
            this.boundTreeView1.GeneralNodeError = "Error at node.";
            this.boundTreeView1.InexistentParent = "Parent of node does not exist.";
            this.boundTreeView1.Location = new System.Drawing.Point(0, 26);
            this.boundTreeView1.Name = "boundTreeView1";
            this.boundTreeView1.ReadOnlyImageKey = null;
            this.boundTreeView1.ReadOnlyOpenedImageKey = null;
            this.boundTreeView1.ReadOnlySelectedImageKey = null;
            this.boundTreeView1.SelfParent = "Parent of node cannot be the node itself.";
            this.boundTreeView1.Size = new System.Drawing.Size(348, 396);
            this.boundTreeView1.Sorted = false;
            this.boundTreeView1.TabIndex = 0;
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Location = new System.Drawing.Point(4, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(4, 15);
            this.displayName.TabIndex = 1;
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.activeItem.AutoScroll = true;
            this.activeItem.AutoScrollMinSize = new System.Drawing.Size(470, 350);
            this.activeItem.Location = new System.Drawing.Point(354, 26);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(476, 393);
            this.activeItem.TabIndex = 2;
            // 
            // FamilyMemberTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.boundTreeView1);
            this.Name = "FamilyMemberTreeView";
            this.Size = new System.Drawing.Size(830, 422);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.WisejWeb.BoundTreeView boundTreeView1;
        private Wisej.Web.Label displayName;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
