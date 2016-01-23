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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new Gizmox.WebGUI.Forms.MenuStrip();
            this.fileMenu = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.openFamilyMemberTree = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.closeFamilyMemberTree = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.exit = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.familyMemberMenu = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.createNewFamilyMember = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.saveFamilyMember = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.deleteFamilyMember = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.closeFamilyMember = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.statusBar = new Gizmox.WebGUI.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            //this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.DockPadding.Bottom = 2;
            this.mainMenu.DockPadding.Left = 6;
            this.mainMenu.DockPadding.Top = 2;
            this.mainMenu.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.mainMenu.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
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
            this.fileMenu.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.openFamilyMemberTree,
            this.closeFamilyMemberTree,
            this.fileMenuSeparator,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openFamilyMemberTree
            // 
            this.openFamilyMemberTree.Name = "openFamilyMemberTree";
            this.openFamilyMemberTree.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.openFamilyMemberTree.Size = new System.Drawing.Size(226, 22);
            this.openFamilyMemberTree.Text = "Open family member tree";
            // 
            // closeFamilyMemberTree
            // 
            this.closeFamilyMemberTree.Name = "closeFamilyMemberTree";
            this.closeFamilyMemberTree.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.closeFamilyMemberTree.Size = new System.Drawing.Size(226, 22);
            this.closeFamilyMemberTree.Text = "Close family member tree";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(226, 22);
            this.exit.Text = "Exit";
            // 
            // familyMemberMenu
            // 
            this.familyMemberMenu.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.createNewFamilyMember,
            this.saveFamilyMember,
            this.deleteFamilyMember,
            this.closeFamilyMember});
            this.familyMemberMenu.Name = "familyMemberMenu";
            this.familyMemberMenu.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.familyMemberMenu.Size = new System.Drawing.Size(60, 20);
            this.familyMemberMenu.Text = "Family member";
            // 
            // createNewFamilyMember
            // 
            this.createNewFamilyMember.Name = "createNewFamilyMember";
            this.createNewFamilyMember.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.createNewFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.createNewFamilyMember.Text = "New family member";
            // 
            // saveFamilyMember
            // 
            this.saveFamilyMember.Name = "saveFamilyMember";
            this.saveFamilyMember.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.saveFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.saveFamilyMember.Text = "Save family member";
            // 
            // deleteFamilyMember
            // 
            this.deleteFamilyMember.Name = "deleteFamilyMember";
            this.deleteFamilyMember.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.deleteFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.deleteFamilyMember.Text = "Delete family member";
            // 
            // closeFamilyMember
            // 
            this.closeFamilyMember.Name = "closeFamilyMember";
            this.closeFamilyMember.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.closeFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.closeFamilyMember.Text = "Close family member form";
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
            //this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            //this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1348, 700);
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.MenuStrip mainMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem fileMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem openFamilyMemberTree;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem closeFamilyMemberTree;
        private Gizmox.WebGUI.Forms.ToolStripSeparator fileMenuSeparator;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem exit;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem familyMemberMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem createNewFamilyMember;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem saveFamilyMember;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem deleteFamilyMember;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem closeFamilyMember;
        private Gizmox.WebGUI.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

