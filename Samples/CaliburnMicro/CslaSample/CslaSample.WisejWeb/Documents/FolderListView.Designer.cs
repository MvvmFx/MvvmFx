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
            this.folderListPanel = new Wisej.Web.Panel();
            this.folderListBox = new Wisej.Web.ListBox();
            this.listTitle = new Wisej.Web.ToolBar();
            this.displayName = new Wisej.Web.ToolBarButton();
            this.refreshFolders = new Wisej.Web.ToolBarButton();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.folderListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderListPanel
            // 
            this.folderListPanel.AutoScroll = true;
            this.folderListPanel.Controls.Add(this.folderListBox);
            this.folderListPanel.Controls.Add(this.listTitle);
            this.folderListPanel.Dock = Wisej.Web.DockStyle.Left;
            this.folderListPanel.Location = new System.Drawing.Point(0, 0);
            this.folderListPanel.MinimumSize = new System.Drawing.Size(120, 0);
            this.folderListPanel.Name = "folderListPanel";
            this.folderListPanel.Size = new System.Drawing.Size(240, 654);
            this.folderListPanel.TabIndex = 3;
            // 
            // folderListBox
            // 
            this.folderListBox.Dock = Wisej.Web.DockStyle.Fill;
            this.folderListBox.FormattingEnabled = true;
            this.folderListBox.Location = new System.Drawing.Point(0, 26);
            this.folderListBox.Name = "folderListBox";
            this.folderListBox.Size = new System.Drawing.Size(240, 628);
            this.folderListBox.TabIndex = 0;
            // 
            // listTitle
            // 
            this.listTitle.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.displayName,
            this.refreshFolders});
            this.listTitle.Location = new System.Drawing.Point(0, 0);
            this.listTitle.Name = "listTitle";
            this.listTitle.Size = new System.Drawing.Size(240, 26);
            this.listTitle.TabIndex = 0;
            this.listTitle.TabStop = false;
            // 
            // displayName
            // 
            this.displayName.Name = "displayName";
            this.displayName.Text = "DisplayName";
            // 
            // refreshFolders
            // 
            this.refreshFolders.Image = global::CslaSample.Properties.Resources.Refresh16;
            this.refreshFolders.Name = "refreshFolders";
            this.refreshFolders.ToolTipText = "Refresh folder list";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(240, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(973, 654);
            this.activeItem.TabIndex = 2;
            // 
            // FolderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.folderListPanel);
            this.Name = "FolderListView";
            this.Size = new System.Drawing.Size(1213, 654);
            this.folderListPanel.ResumeLayout(false);
            this.folderListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel folderListPanel;
        private Wisej.Web.ToolBar listTitle;
        private Wisej.Web.ToolBarButton displayName;
        private Wisej.Web.ToolBarButton refreshFolders;
        private Wisej.Web.ListBox folderListBox;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
