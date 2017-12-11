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

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new Wisej.Web.MenuBar();
            this.documentsMenu = new Wisej.Web.MenuItem();
            this.createNewDocument = new Wisej.Web.MenuItem();
            this.saveDocument = new Wisej.Web.MenuItem();
            this.deleteDocument = new Wisej.Web.MenuItem();
            this.folders = new Wisej.Web.MenuItem();
            this.editFolderModal = new Wisej.Web.MenuItem();
            this.editFolderModeless = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.statusBar = new Wisej.Web.StatusBar();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = Wisej.Web.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.documentsMenu,
            this.folders,
            this.exit});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1255, 22);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.TabStop = false;
            // 
            // documentsMenu
            // 
            this.documentsMenu.Index = 0;
            this.documentsMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createNewDocument,
            this.saveDocument,
            this.deleteDocument});
            this.documentsMenu.Name = "documentsMenu";
            this.documentsMenu.Text = "Documents";
            // 
            // createNewDocument
            // 
            this.createNewDocument.Index = 0;
            this.createNewDocument.Name = "createNewDocument";
            this.createNewDocument.Text = "New Document";
            // 
            // saveDocument
            // 
            this.saveDocument.Index = 1;
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Text = "Save Document";
            // 
            // deleteDocument
            // 
            this.deleteDocument.Index = 2;
            this.deleteDocument.Name = "deleteDocument";
            this.deleteDocument.Text = "Delete Document";
            // 
            // folders
            // 
            this.folders.Index = 1;
            this.folders.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.editFolderModal,
            this.editFolderModeless});
            this.folders.Name = "folders";
            this.folders.Text = "Folders";
            // 
            // editFolderModal
            // 
            this.editFolderModal.Index = 0;
            this.editFolderModal.Name = "editFolderModal";
            this.editFolderModal.Text = "Edit Folder Modal";
            // 
            // editFolderModeless
            // 
            this.editFolderModeless.Index = 1;
            this.editFolderModeless.Name = "editFolderModeless";
            this.editFolderModeless.Text = "Edit Folder Modeless";
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
            this.activeItem.Location = new System.Drawing.Point(0, 22);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1255, 516);
            this.activeItem.TabIndex = 2;
            this.activeItem.Text = "activeItem";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1255, 560);
            this.ClientSize = new System.Drawing.Size(699, 446);
            this.CloseBox = false;
            this.ControlBox = false;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = Wisej.Web.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.MenuBar mainMenu;
        private Wisej.Web.MenuItem documentsMenu;
        private Wisej.Web.MenuItem createNewDocument;
        private Wisej.Web.MenuItem saveDocument;
        private Wisej.Web.MenuItem deleteDocument;
        private Wisej.Web.MenuItem folders;
        private Wisej.Web.MenuItem editFolderModal;
        private Wisej.Web.MenuItem editFolderModeless;
        private Wisej.Web.MenuItem exit;
        private Wisej.Web.StatusBar statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

