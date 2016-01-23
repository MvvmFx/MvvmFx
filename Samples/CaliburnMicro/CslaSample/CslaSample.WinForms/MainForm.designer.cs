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
            this.documentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.folders = new System.Windows.Forms.ToolStripMenuItem();
            this.editFoldersModal = new System.Windows.Forms.ToolStripMenuItem();
            this.editFoldersModeless = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentMenu,
            this.folders,
            this.exit});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1348, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // documentMenu
            // 
            this.documentMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewDocument,
            this.saveDocument,
            this.deleteDocument});
            this.documentMenu.Name = "documentMenu";
            this.documentMenu.Size = new System.Drawing.Size(75, 20);
            this.documentMenu.Text = "Document";
            // 
            // createNewDocument
            // 
            this.createNewDocument.Name = "createNewDocument";
            this.createNewDocument.Size = new System.Drawing.Size(165, 22);
            this.createNewDocument.Text = "New document";
            // 
            // saveDocument
            // 
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Size = new System.Drawing.Size(165, 22);
            this.saveDocument.Text = "Save document";
            // 
            // deleteDocument
            // 
            this.deleteDocument.Name = "deleteDocument";
            this.deleteDocument.Size = new System.Drawing.Size(165, 22);
            this.deleteDocument.Text = "Delete document";
            // 
            // folders
            // 
            this.folders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFoldersModal,
            this.editFoldersModeless});
            this.folders.Name = "folders";
            this.folders.Size = new System.Drawing.Size(57, 20);
            this.folders.Text = "Folders";
            // 
            // editFoldersModal
            // 
            this.editFoldersModal.Name = "editFoldersModal";
            this.editFoldersModal.Size = new System.Drawing.Size(188, 22);
            this.editFoldersModal.Text = "Edit Folders Modal";
            // 
            // editFoldersModeless
            // 
            this.editFoldersModeless.Name = "editFoldersModeless";
            this.editFoldersModeless.Size = new System.Drawing.Size(188, 22);
            this.editFoldersModeless.Text = "Edit Folders Modeless";
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
            this.statusBar.Size = new System.Drawing.Size(1348, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1255, 560);
            this.ClientSize = new System.Drawing.Size(1348, 700);
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
        private System.Windows.Forms.ToolStripMenuItem documentMenu;
        private System.Windows.Forms.ToolStripMenuItem createNewDocument;
        private System.Windows.Forms.ToolStripMenuItem saveDocument;
        private System.Windows.Forms.ToolStripMenuItem deleteDocument;
        private System.Windows.Forms.ToolStripMenuItem folders;
        private System.Windows.Forms.ToolStripMenuItem editFoldersModal;
        private System.Windows.Forms.ToolStripMenuItem editFoldersModeless;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

