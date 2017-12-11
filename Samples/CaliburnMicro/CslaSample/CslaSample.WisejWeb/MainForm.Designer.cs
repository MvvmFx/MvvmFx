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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new Wisej.Web.MenuBar();
            this.documentMenu = new Wisej.Web.MenuItem();
            this.createNewDocument = new Wisej.Web.MenuItem();
            this.saveDocument = new Wisej.Web.MenuItem();
            this.deleteDocument = new Wisej.Web.MenuItem();
            this.folders = new Wisej.Web.MenuItem();
            this.editFoldersModal = new Wisej.Web.MenuItem();
            this.editFoldersModeless = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.statusBar = new Wisej.Web.StatusBar();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.documentMenu,
            this.folders,
            this.exit});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1348, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.TabStop = false;
            // 
            // documentMenu
            // 
            this.documentMenu.Index = 0;
            this.documentMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createNewDocument,
            this.saveDocument,
            this.deleteDocument});
            this.documentMenu.Name = "documentMenu";
            this.documentMenu.Text = "Document";
            // 
            // createNewDocument
            // 
            this.createNewDocument.Index = 0;
            this.createNewDocument.Name = "createNewDocument";
            this.createNewDocument.Text = "New document";
            // 
            // saveDocument
            // 
            this.saveDocument.Index = 1;
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Text = "Save document";
            // 
            // deleteDocument
            // 
            this.deleteDocument.Index = 2;
            this.deleteDocument.Name = "deleteDocument";
            this.deleteDocument.Text = "Delete document";
            // 
            // folders
            // 
            this.folders.Index = 1;
            this.folders.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.editFoldersModal,
            this.editFoldersModeless});
            this.folders.Name = "folders";
            this.folders.Text = "Folders";
            // 
            // editFoldersModal
            // 
            this.editFoldersModal.Index = 0;
            this.editFoldersModal.Name = "editFoldersModal";
            this.editFoldersModal.Text = "Edit Folders Modal";
            // 
            // editFoldersModeless
            // 
            this.editFoldersModeless.Index = 1;
            this.editFoldersModeless.Name = "editFoldersModeless";
            this.editFoldersModeless.Text = "Edit Folders Modeless";
            // 
            // exit
            // 
            this.exit.Index = 2;
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 538);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1255, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1255, 538);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1255, 560);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1007, 531);
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.MenuBar mainMenu;
        private Wisej.Web.MenuItem documentMenu;
        private Wisej.Web.MenuItem createNewDocument;
        private Wisej.Web.MenuItem saveDocument;
        private Wisej.Web.MenuItem deleteDocument;
        private Wisej.Web.MenuItem folders;
        private Wisej.Web.MenuItem editFoldersModal;
        private Wisej.Web.MenuItem editFoldersModeless;
        private Wisej.Web.MenuItem exit;
        private Wisej.Web.StatusBar statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

