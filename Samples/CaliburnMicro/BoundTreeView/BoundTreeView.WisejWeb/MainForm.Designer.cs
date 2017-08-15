namespace BoundTreeView
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
            this.mainMenu = new Wisej.Web.MenuBar();
            this.fileMenu = new Wisej.Web.MenuItem();
            this.openFamilyMemberTree = new Wisej.Web.MenuItem();
            this.closeFamilyMemberTree = new Wisej.Web.MenuItem();
            this.fileMenuSeparator = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.familyMemberMenu = new Wisej.Web.MenuItem();
            this.createNewFamilyMember = new Wisej.Web.MenuItem();
            this.saveFamilyMember = new Wisej.Web.MenuItem();
            this.deleteFamilyMember = new Wisej.Web.MenuItem();
            this.closeFamilyMember = new Wisej.Web.MenuItem();
            this.statusBar = new Wisej.Web.StatusBar();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.fileMenu,
            this.familyMemberMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1348, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.openFamilyMemberTree,
            this.closeFamilyMemberTree,
            this.fileMenuSeparator,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "File";
            // 
            // openFamilyMemberTree
            // 
            this.openFamilyMemberTree.Name = "openFamilyMemberTree";
            this.openFamilyMemberTree.Text = "Open family member tree";
            // 
            // closeFamilyMemberTree
            // 
            this.closeFamilyMemberTree.Name = "closeFamilyMemberTree";
            this.closeFamilyMemberTree.Text = "Close family member tree";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            // 
            // familyMemberMenu
            // 
            this.familyMemberMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createNewFamilyMember,
            this.saveFamilyMember,
            this.deleteFamilyMember,
            this.closeFamilyMember});
            this.familyMemberMenu.Name = "familyMemberMenu";
            this.familyMemberMenu.Text = "Family member";
            // 
            // createNewFamilyMember
            // 
            this.createNewFamilyMember.Name = "createNewFamilyMember";
            this.createNewFamilyMember.Text = "New family member";
            // 
            // saveFamilyMember
            // 
            this.saveFamilyMember.Name = "saveFamilyMember";
            this.saveFamilyMember.Text = "Save family member";
            // 
            // deleteFamilyMember
            // 
            this.deleteFamilyMember.Name = "deleteFamilyMember";
            this.deleteFamilyMember.Text = "Delete family member";
            // 
            // closeFamilyMember
            // 
            this.closeFamilyMember.Name = "closeFamilyMember";
            this.closeFamilyMember.Text = "Close family member form";
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
            this.activeItem.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom)
            | Wisej.Web.AnchorStyles.Left)
            | Wisej.Web.AnchorStyles.Right)));
            //this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.MenuBar mainMenu;
        private Wisej.Web.MenuItem fileMenu;
        private Wisej.Web.MenuItem openFamilyMemberTree;
        private Wisej.Web.MenuItem closeFamilyMemberTree;
        private Wisej.Web.MenuItem fileMenuSeparator;
        private Wisej.Web.MenuItem exit;
        private Wisej.Web.MenuItem familyMemberMenu;
        private Wisej.Web.MenuItem createNewFamilyMember;
        private Wisej.Web.MenuItem saveFamilyMember;
        private Wisej.Web.MenuItem deleteFamilyMember;
        private Wisej.Web.MenuItem closeFamilyMember;
        private Wisej.Web.StatusBar statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

