namespace CslaSample.Documents
{
    partial class FolderListView
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
            this.folderListPanel = new System.Windows.Forms.Panel();
            this.folderListBox = new System.Windows.Forms.ListBox();
            this.listTitle = new System.Windows.Forms.ToolStrip();
            this.displayName = new System.Windows.Forms.ToolStripLabel();
            this.refreshFolders = new System.Windows.Forms.ToolStripButton();
            this.splitter = new System.Windows.Forms.Splitter();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.folderListPanel.SuspendLayout();
            this.listTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderListPanel
            // 
            this.folderListPanel.AutoScroll = true;
            this.folderListPanel.Controls.Add(this.folderListBox);
            this.folderListPanel.Controls.Add(this.listTitle);
            this.folderListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.folderListPanel.Location = new System.Drawing.Point(0, 0);
            this.folderListPanel.MinimumSize = new System.Drawing.Size(120, 0);
            this.folderListPanel.Name = "folderListPanel";
            this.folderListPanel.Size = new System.Drawing.Size(240, 654);
            this.folderListPanel.TabIndex = 3;
            // 
            // folderListBox
            // 
            this.folderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderListBox.FormattingEnabled = true;
            this.folderListBox.IntegralHeight = false;
            this.folderListBox.Location = new System.Drawing.Point(0, 25);
            this.folderListBox.Name = "folderListBox";
            this.folderListBox.Size = new System.Drawing.Size(240, 629);
            this.folderListBox.TabIndex = 0;
            // 
            // listTitle
            // 
            this.listTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayName,
            this.refreshFolders});
            this.listTitle.Location = new System.Drawing.Point(0, 0);
            this.listTitle.Name = "listTitle";
            this.listTitle.Size = new System.Drawing.Size(240, 25);
            this.listTitle.TabIndex = 0;
            this.listTitle.Text = "listTitle";
            // 
            // displayName
            // 
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(77, 22);
            this.displayName.Text = "DisplayName";
            // 
            // refreshFolders
            // 
            this.refreshFolders.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshFolders.Image = global::CslaSample.Properties.Resources.Refresh16;
            this.refreshFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshFolders.Name = "refreshFolders";
            this.refreshFolders.Size = new System.Drawing.Size(23, 22);
            this.refreshFolders.Text = "Refresh folder list";
            this.refreshFolders.ToolTipText = "Refresh folder list";
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(240, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 654);
            this.splitter.TabIndex = 4;
            this.splitter.TabStop = false;
            // 
            // activeItem
            // 
            this.activeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(243, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(970, 654);
            this.activeItem.TabIndex = 2;
            // 
            // FolderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.folderListPanel);
            this.Name = "FolderListView";
            this.Size = new System.Drawing.Size(1213, 654);
            this.folderListPanel.ResumeLayout(false);
            this.folderListPanel.PerformLayout();
            this.listTitle.ResumeLayout(false);
            this.listTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel folderListPanel;
        private System.Windows.Forms.ToolStrip listTitle;
        private System.Windows.Forms.ToolStripLabel displayName;
        private System.Windows.Forms.ToolStripButton refreshFolders;
        private System.Windows.Forms.ListBox folderListBox;
        private System.Windows.Forms.Splitter splitter;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
