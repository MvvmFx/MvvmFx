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
            this.documentListPanel = new System.Windows.Forms.Panel();
            this.documentListBox = new System.Windows.Forms.ListBox();
            this.listTitle = new System.Windows.Forms.ToolStrip();
            this.displayName = new System.Windows.Forms.ToolStripLabel();
            this.refreshDocuments = new System.Windows.Forms.ToolStripButton();
            this.splitter = new System.Windows.Forms.Splitter();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.documentListPanel.SuspendLayout();
            this.listTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentListPanel
            // 
            this.documentListPanel.Controls.Add(this.documentListBox);
            this.documentListPanel.Controls.Add(this.listTitle);
            this.documentListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.documentListPanel.Location = new System.Drawing.Point(0, 0);
            this.documentListPanel.MinimumSize = new System.Drawing.Size(160, 0);
            this.documentListPanel.Name = "documentListPanel";
            this.documentListPanel.Size = new System.Drawing.Size(240, 654);
            this.documentListPanel.TabIndex = 3;
            // 
            // documentListBox
            // 
            this.documentListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentListBox.FormattingEnabled = true;
            this.documentListBox.IntegralHeight = false;
            this.documentListBox.Location = new System.Drawing.Point(0, 25);
            this.documentListBox.Name = "documentListBox";
            this.documentListBox.Size = new System.Drawing.Size(240, 629);
            this.documentListBox.TabIndex = 0;
            // 
            // listTitle
            // 
            this.listTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayName,
            this.refreshDocuments});
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
            // refreshDocuments
            // 
            this.refreshDocuments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshDocuments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshDocuments.Image = global::CslaSample.Properties.Resources.Refresh16;
            this.refreshDocuments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshDocuments.Name = "refreshDocuments";
            this.refreshDocuments.Size = new System.Drawing.Size(23, 22);
            this.refreshDocuments.Text = "Refresh document list";
            this.refreshDocuments.ToolTipText = "Refresh document list";
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
            this.activeItem.Size = new System.Drawing.Size(727, 654);
            this.activeItem.TabIndex = 2;
            // 
            // DocumentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.documentListPanel);
            this.Name = "DocumentListView";
            this.Size = new System.Drawing.Size(970, 654);
            this.documentListPanel.ResumeLayout(false);
            this.documentListPanel.PerformLayout();
            this.listTitle.ResumeLayout(false);
            this.listTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel documentListPanel;
        private System.Windows.Forms.ToolStrip listTitle;
        private System.Windows.Forms.ToolStripLabel displayName;
        private System.Windows.Forms.ToolStripButton refreshDocuments;
        private System.Windows.Forms.ListBox documentListBox;
        private System.Windows.Forms.Splitter splitter;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
