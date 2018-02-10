namespace CslaSample.Documents
{
    partial class DocumentListView
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
            this.documentListPanel = new Wisej.Web.Panel();
            this.documentListBox = new Wisej.Web.ListBox();
            this.listTitle = new Wisej.Web.ToolBar();
            this.displayName = new Wisej.Web.ToolBarButton();
            this.refreshDocuments = new Wisej.Web.ToolBarButton();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.documentListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentListPanel
            // 
            this.documentListPanel.Controls.Add(this.documentListBox);
            this.documentListPanel.Controls.Add(this.listTitle);
            this.documentListPanel.Dock = Wisej.Web.DockStyle.Left;
            this.documentListPanel.Location = new System.Drawing.Point(0, 0);
            this.documentListPanel.MinimumSize = new System.Drawing.Size(160, 0);
            this.documentListPanel.Name = "documentListPanel";
            this.documentListPanel.Size = new System.Drawing.Size(240, 654);
            this.documentListPanel.TabIndex = 3;
            // 
            // documentListBox
            // 
            this.documentListBox.Dock = Wisej.Web.DockStyle.Fill;
            this.documentListBox.FormattingEnabled = true;
            this.documentListBox.Location = new System.Drawing.Point(0, 26);
            this.documentListBox.Name = "documentListBox";
            this.documentListBox.Size = new System.Drawing.Size(240, 628);
            this.documentListBox.TabIndex = 0;
            // 
            // listTitle
            // 
            this.listTitle.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.displayName,
            this.refreshDocuments});
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
            // refreshDocuments
            // 
            this.refreshDocuments.Image = global::CslaSample.Properties.Resources.Refresh16;
            this.refreshDocuments.Name = "refreshDocuments";
            this.refreshDocuments.ToolTipText = "Refresh document list";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(240, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(730, 654);
            this.activeItem.TabIndex = 2;
            // 
            // DocumentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.documentListPanel);
            this.Name = "DocumentListView";
            this.Size = new System.Drawing.Size(970, 654);
            this.documentListPanel.ResumeLayout(false);
            this.documentListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel documentListPanel;
        private Wisej.Web.ToolBar listTitle;
        private Wisej.Web.ToolBarButton displayName;
        private Wisej.Web.ToolBarButton refreshDocuments;
        private Wisej.Web.ListBox documentListBox;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
