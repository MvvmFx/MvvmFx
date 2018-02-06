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
            this.boundTreeView1 = new MvvmFx.WinForms.BoundTreeView();
            this.displayName = new System.Windows.Forms.Label();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.SuspendLayout();
            // 
            // boundTreeView1
            // 
            this.boundTreeView1.AllowDrop = true;
            this.boundTreeView1.AllowDropOnDescendents = false;
            this.boundTreeView1.AllowDropOnRoot = false;
            this.boundTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.boundTreeView1.HideSelection = false;
            this.boundTreeView1.HotTracking = true;
            this.boundTreeView1.Location = new System.Drawing.Point(0, 26);
            this.boundTreeView1.Name = "boundTreeView1";
            this.boundTreeView1.ReadOnlyImageKey = null;
            this.boundTreeView1.ReadOnlySelectedImageKey = null;
            this.boundTreeView1.Size = new System.Drawing.Size(348, 628);
            this.boundTreeView1.Sorted = false;
            this.boundTreeView1.TabIndex = 0;
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Location = new System.Drawing.Point(4, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(0, 13);
            this.displayName.TabIndex = 1;
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeItem.AutoScroll = true;
            this.activeItem.AutoScrollMinSize = new System.Drawing.Size(470, 350);
            this.activeItem.Location = new System.Drawing.Point(354, 26);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(994, 625);
            this.activeItem.TabIndex = 2;
            // 
            // FamilyMemberTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.boundTreeView1);
            this.Name = "FamilyMemberTreeView";
            this.Size = new System.Drawing.Size(1348, 654);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.WinForms.BoundTreeView boundTreeView1;
        private System.Windows.Forms.Label displayName;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
