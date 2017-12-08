namespace WinForms.MenuBinding
{
    partial class HardBind
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
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.itemMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(596, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.closeFile,
            this.fileMenuSeparator,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(210, 22);
            this.openFile.Text = "Open family member tree";
            // 
            // closeFile
            // 
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(210, 22);
            this.closeFile.Text = "Close family member tree";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(207, 6);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(210, 22);
            this.exit.Text = "Exit";
            // 
            // itemMenu
            // 
            this.itemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createItem,
            this.saveItem,
            this.deleteItem,
            this.closeItem});
            this.itemMenu.Name = "itemMenu";
            this.itemMenu.Size = new System.Drawing.Size(64, 20);
            this.itemMenu.Text = "File Item";
            // 
            // createItem
            // 
            this.createItem.Name = "createItem";
            this.createItem.Size = new System.Drawing.Size(155, 22);
            this.createItem.Text = "New File Item";
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(155, 22);
            this.saveItem.Text = "Save File Item";
            // 
            // deleteItem
            // 
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(155, 22);
            this.deleteItem.Text = "Delete File Item";
            // 
            // closeItem
            // 
            this.closeItem.Name = "closeItem";
            this.closeItem.Size = new System.Drawing.Size(155, 22);
            this.closeItem.Text = "Close File Item";
            // 
            // HardBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 441);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "HardBind";
            this.Text = "Hard Bind";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip mainMenu;
        internal System.Windows.Forms.ToolStripMenuItem fileMenu;
        internal System.Windows.Forms.ToolStripMenuItem openFile;
        internal System.Windows.Forms.ToolStripMenuItem closeFile;
        internal System.Windows.Forms.ToolStripSeparator fileMenuSeparator;
        internal System.Windows.Forms.ToolStripMenuItem exit;
        internal System.Windows.Forms.ToolStripMenuItem itemMenu;
        internal System.Windows.Forms.ToolStripMenuItem createItem;
        internal System.Windows.Forms.ToolStripMenuItem saveItem;
        internal System.Windows.Forms.ToolStripMenuItem deleteItem;
        internal System.Windows.Forms.ToolStripMenuItem closeItem;
    }
}
