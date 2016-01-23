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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomRight = new Gizmox.WebGUI.Forms.Label();
            this.mainMenu = new Gizmox.WebGUI.Forms.MenuStrip();
            this.documentMenu = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.createNewDocument = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.saveDocument = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.deleteDocument = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.folders = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.editFoldersModal = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.editFoldersModeless = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.exit = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.statusBar = new Gizmox.WebGUI.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            //this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomRight
            // 
            this.bottomRight.BackColor = System.Drawing.Color.Transparent;
            this.bottomRight.ForeColor = System.Drawing.Color.Transparent;
            this.bottomRight.Location = new System.Drawing.Point(1240, 565);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(10, 13);
            this.bottomRight.TabIndex = 0;
            this.bottomRight.Text = "_";
            // 
            // mainMenu
            // 
            this.mainMenu.DockPadding.Bottom = 2;
            this.mainMenu.DockPadding.Left = 6;
            this.mainMenu.DockPadding.Top = 2;
            this.mainMenu.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.mainMenu.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
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
            this.documentMenu.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.createNewDocument,
            this.saveDocument,
            this.deleteDocument});
            this.documentMenu.Name = "documentMenu";
            this.documentMenu.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.documentMenu.Size = new System.Drawing.Size(100, 20);
            this.documentMenu.Text = "Document";
            // 
            // createNewDocument
            // 
            this.createNewDocument.Name = "createNewDocument";
            this.createNewDocument.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.createNewDocument.Size = new System.Drawing.Size(165, 22);
            this.createNewDocument.Text = "New document";
            // 
            // saveDocument
            // 
            this.saveDocument.Name = "saveDocument";
            this.saveDocument.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.saveDocument.Size = new System.Drawing.Size(175, 22);
            this.saveDocument.Text = "Save document";
            // 
            // deleteDocument
            // 
            this.deleteDocument.Name = "deleteDocument";
            this.deleteDocument.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.deleteDocument.Size = new System.Drawing.Size(175, 22);
            this.deleteDocument.Text = "Delete document";
            // 
            // folders
            // 
            this.folders.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.editFoldersModal,
            this.editFoldersModeless});
            this.folders.Name = "folders";
            this.folders.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.folders.Size = new System.Drawing.Size(57, 20);
            this.folders.Text = "Folders";
            // 
            // editFoldersModal
            // 
            this.editFoldersModal.Name = "editFoldersModal";
            this.editFoldersModal.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.editFoldersModal.Size = new System.Drawing.Size(188, 22);
            this.editFoldersModal.Text = "Edit Folders Modal";
            // 
            // editFoldersModeless
            // 
            this.editFoldersModeless.Name = "editFoldersModeless";
            this.editFoldersModeless.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.editFoldersModeless.Size = new System.Drawing.Size(188, 22);
            this.editFoldersModeless.Text = "Edit Folders Modeless";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(37, 20);
            this.exit.Text = "Exit";
            // 
            // statusBar
            // 
            this.statusBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.statusBar.DockPadding.Left = 1;
            this.statusBar.DockPadding.Right = 14;
            this.statusBar.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.statusBar.Location = new System.Drawing.Point(0, 678);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1348, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            //this.AutoScrollMinSize = new System.Drawing.Size(1255, 560);
            this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            //this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1348, 700);
            this.Text = "MainForm";
            //this.mainMenu.ResumeLayout(false);
            //this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            //this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label bottomRight;
        private Gizmox.WebGUI.Forms.MenuStrip mainMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem documentMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem createNewDocument;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem saveDocument;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem deleteDocument;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem folders;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem editFoldersModal;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem editFoldersModeless;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem exit;
        private Gizmox.WebGUI.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

