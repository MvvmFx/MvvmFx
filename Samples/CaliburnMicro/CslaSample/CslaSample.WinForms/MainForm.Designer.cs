namespace CslaSample
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.documentsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.folders = new System.Windows.Forms.ToolStripMenuItem();
            this.editFolderModal = new System.Windows.Forms.ToolStripMenuItem();
            this.editFolderModeless = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentsMenu,
            this.folders,
            this.exit});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1213, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // documentsMenu
            // 
            this.documentsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDocument,
            this.saveDocument,
            this.deleteDocument,
            this.closeDocument});
            this.documentsMenu.Name = "documentsMenu";
            this.documentsMenu.Size = new System.Drawing.Size(80, 20);
            this.documentsMenu.Text = "Documents";
            // 
            // createDocument
            // 
            this.createDocument.Name = "createDocument";
            this.createDocument.Size = new System.Drawing.Size(166, 22);
            this.createDocument.Text = "New Document";
            // 
            // saveDocument
            // 
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Size = new System.Drawing.Size(166, 22);
            this.saveDocument.Text = "Save Document";
            // 
            // deleteDocument
            // 
            this.deleteDocument.Name = "deleteDocument";
            this.deleteDocument.Size = new System.Drawing.Size(166, 22);
            this.deleteDocument.Text = "Delete Document";
            // 
            // closeDocument
            // 
            this.closeDocument.Name = "closeDocument";
            this.closeDocument.Size = new System.Drawing.Size(166, 22);
            this.closeDocument.Text = "Close Document";
            // 
            // folders
            // 
            this.folders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFolderModal,
            this.editFolderModeless});
            this.folders.Name = "folders";
            this.folders.Size = new System.Drawing.Size(57, 20);
            this.folders.Text = "Folders";
            // 
            // editFolderModal
            // 
            this.editFolderModal.Name = "editFolderModal";
            this.editFolderModal.Size = new System.Drawing.Size(183, 22);
            this.editFolderModal.Text = "Edit Folder Modal";
            // 
            // editFolderModeless
            // 
            this.editFolderModeless.Name = "editFolderModeless";
            this.editFolderModeless.Size = new System.Drawing.Size(183, 22);
            this.editFolderModeless.Text = "Edit Folder Modeless";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(37, 20);
            this.exit.Text = "Exit";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 678);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1213, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1213, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1213, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem documentsMenu;
        private System.Windows.Forms.ToolStripMenuItem createDocument;
        private System.Windows.Forms.ToolStripMenuItem saveDocument;
        private System.Windows.Forms.ToolStripMenuItem deleteDocument;
        private System.Windows.Forms.ToolStripMenuItem closeDocument;
        private System.Windows.Forms.ToolStripMenuItem folders;
        private System.Windows.Forms.ToolStripMenuItem editFolderModal;
        private System.Windows.Forms.ToolStripMenuItem editFolderModeless;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

