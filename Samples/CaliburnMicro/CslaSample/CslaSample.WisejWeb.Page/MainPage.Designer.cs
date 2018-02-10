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
            this.displayName = new Wisej.Web.Label();
            this.displayNamePanel = new Wisej.Web.Panel();
            this.mainMenu = new Wisej.Web.MenuBar();
            this.documentsMenu = new Wisej.Web.MenuItem();
            this.createDocument = new Wisej.Web.MenuItem();
            this.saveDocument = new Wisej.Web.MenuItem();
            this.deleteDocument = new Wisej.Web.MenuItem();
            this.closeDocument = new Wisej.Web.MenuItem();
            this.folders = new Wisej.Web.MenuItem();
            this.editFolderModal = new Wisej.Web.MenuItem();
            this.editFolderModeless = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.statusBar = new Wisej.Web.StatusBar();
            this.placeHolder = new Wisej.Web.StatusBarPanel();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.displayNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayName
            // 
            this.displayName.Location = new System.Drawing.Point(12, 8);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(100, 14);
            this.displayName.TabIndex = 0;
            this.displayName.Text = "Application Title";
            // 
            // displayNamePanel
            // 
            this.displayNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(185)))));
            this.displayNamePanel.Controls.Add(this.displayName);
            this.displayNamePanel.Dock = Wisej.Web.DockStyle.Top;
            this.displayNamePanel.ForeColor = System.Drawing.Color.FromName("@activeCaption");
            this.displayNamePanel.Location = new System.Drawing.Point(0, 0);
            this.displayNamePanel.Name = "displayNamePanel";
            this.displayNamePanel.ShowCloseButton = false;
            this.displayNamePanel.Size = new System.Drawing.Size(969, 30);
            this.displayNamePanel.TabIndex = 1;
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = Wisej.Web.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 30);
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.documentsMenu,
            this.folders,
            this.exit});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(969, 22);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.TabStop = false;
            // 
            // documentsMenu
            // 
            this.documentsMenu.Index = 0;
            this.documentsMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createDocument,
            this.saveDocument,
            this.deleteDocument,
            this.closeDocument});
            this.documentsMenu.Name = "documentsMenu";
            this.documentsMenu.Text = "Documents";
            // 
            // createDocument
            // 
            this.createDocument.Index = 0;
            this.createDocument.Name = "createDocument";
            this.createDocument.Text = "New Document";
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
            // closeDocument
            // 
            this.closeDocument.Index = 3;
            this.closeDocument.Name = "closeDocument";
            this.closeDocument.Text = "Close Document";
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
            this.statusBar.Location = new System.Drawing.Point(0, 782);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new Wisej.Web.StatusBarPanel[] {
            this.placeHolder});
            this.statusBar.Size = new System.Drawing.Size(969, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // placeHolder
            // 
            this.placeHolder.AutoSize = Wisej.Web.StatusBarPanelAutoSize.Spring;
            this.placeHolder.Name = "placeHolder";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 52);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(969, 730);
            this.activeItem.TabIndex = 2;
            this.activeItem.Text = "activeItem";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.displayNamePanel);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(969, 804);
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.displayNamePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label displayName;
        private Wisej.Web.Panel displayNamePanel;
        private Wisej.Web.MenuBar mainMenu;
        private Wisej.Web.MenuItem documentsMenu;
        private Wisej.Web.MenuItem createDocument;
        private Wisej.Web.MenuItem saveDocument;
        private Wisej.Web.MenuItem deleteDocument;
        private Wisej.Web.MenuItem closeDocument;
        private Wisej.Web.MenuItem folders;
        private Wisej.Web.MenuItem editFolderModal;
        private Wisej.Web.MenuItem editFolderModeless;
        private Wisej.Web.MenuItem exit;
        private Wisej.Web.StatusBar statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
        private Wisej.Web.StatusBarPanel placeHolder;
    }
}

