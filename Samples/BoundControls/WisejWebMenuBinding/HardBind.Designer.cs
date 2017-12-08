namespace WisejWeb.MenuBinding
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

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new Wisej.Web.MenuBar();
            this.fileMenu = new Wisej.Web.MenuItem();
            this.openFile = new Wisej.Web.MenuItem();
            this.closeFile = new Wisej.Web.MenuItem();
            this.fileMenuSeparator = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.itemMenu = new Wisej.Web.MenuItem();
            this.createItem = new Wisej.Web.MenuItem();
            this.saveItem = new Wisej.Web.MenuItem();
            this.deleteItem = new Wisej.Web.MenuItem();
            this.closeItem = new Wisej.Web.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Dock = Wisej.Web.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.fileMenu,
            this.itemMenu});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(612, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.TabStop = false;
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.openFile,
            this.closeFile,
            this.fileMenuSeparator,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "File";
            // 
            // openFile
            // 
            this.openFile.Index = 0;
            this.openFile.Name = "openFile";
            this.openFile.Text = "Open family member tree";
            // 
            // closeFile
            // 
            this.closeFile.Index = 1;
            this.closeFile.Name = "closeFile";
            this.closeFile.Text = "Close family member tree";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Index = 2;
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Text = "";
            // 
            // exit
            // 
            this.exit.Index = 3;
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            // 
            // itemMenu
            // 
            this.itemMenu.Index = 1;
            this.itemMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createItem,
            this.saveItem,
            this.deleteItem,
            this.closeItem});
            this.itemMenu.Name = "itemMenu";
            this.itemMenu.Text = "File Item";
            // 
            // createItem
            // 
            this.createItem.Index = 0;
            this.createItem.Name = "createItem";
            this.createItem.Text = "New File Item";
            // 
            // saveItem
            // 
            this.saveItem.Index = 1;
            this.saveItem.Name = "saveItem";
            this.saveItem.Text = "Save File Item";
            // 
            // deleteItem
            // 
            this.deleteItem.Index = 2;
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Text = "Delete File Item";
            // 
            // closeItem
            // 
            this.closeItem.Index = 3;
            this.closeItem.Name = "closeItem";
            this.closeItem.Text = "Close File Item";
            // 
            // HardBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.mainMenu);
            this.Name = "HardBind";
            this.Text = "Hard Bind";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Wisej.Web.MenuBar mainMenu;
        internal Wisej.Web.MenuItem fileMenu;
        internal Wisej.Web.MenuItem openFile;
        internal Wisej.Web.MenuItem closeFile;
        internal Wisej.Web.MenuItem fileMenuSeparator;
        internal Wisej.Web.MenuItem exit;
        internal Wisej.Web.MenuItem itemMenu;
        internal Wisej.Web.MenuItem createItem;
        internal Wisej.Web.MenuItem saveItem;
        internal Wisej.Web.MenuItem deleteItem;
        internal Wisej.Web.MenuItem closeItem;
    }
}

