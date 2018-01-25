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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFamilyMemberTree = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFamilyMemberTree = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.familyMemberMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createFamilyMember = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFamilyMember = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFamilyMember = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFamilyMember = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFamilyMemberTree,
            this.closeFamilyMemberTree,
            this.fileMenuSeparator,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openFamilyMemberTree
            // 
            this.openFamilyMemberTree.Name = "openFamilyMemberTree";
            this.openFamilyMemberTree.Size = new System.Drawing.Size(226, 22);
            this.openFamilyMemberTree.Text = "Open family member tree";
            // 
            // closeFamilyMemberTree
            // 
            this.closeFamilyMemberTree.Name = "closeFamilyMemberTree";
            this.closeFamilyMemberTree.Size = new System.Drawing.Size(226, 22);
            this.closeFamilyMemberTree.Text = "Close family member tree";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(226, 22);
            this.exit.Text = "Exit";
            // 
            // familyMemberMenu
            // 
            this.familyMemberMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFamilyMember,
            this.saveFamilyMember,
            this.deleteFamilyMember,
            this.closeFamilyMember});
            this.familyMemberMenu.Name = "familyMemberMenu";
            this.familyMemberMenu.Size = new System.Drawing.Size(60, 20);
            this.familyMemberMenu.Text = "Family member";
            // 
            // createFamilyMember
            // 
            this.createFamilyMember.Name = "createFamilyMember";
            this.createFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.createFamilyMember.Text = "New family member";
            // 
            // saveFamilyMember
            // 
            this.saveFamilyMember.Name = "saveFamilyMember";
            this.saveFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.saveFamilyMember.Text = "Save family member";
            // 
            // deleteFamilyMember
            // 
            this.deleteFamilyMember.Name = "deleteFamilyMember";
            this.deleteFamilyMember.Size = new System.Drawing.Size(175, 22);
            this.deleteFamilyMember.Text = "Delete family member";
            // 
            // closeFamilyMember
            // 
            this.closeFamilyMember.Name = "closeFamilyMember";
            this.closeFamilyMember.Size = new System.Drawing.Size(175, 22);
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
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openFamilyMemberTree;
        private System.Windows.Forms.ToolStripMenuItem closeFamilyMemberTree;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem familyMemberMenu;
        private System.Windows.Forms.ToolStripMenuItem createFamilyMember;
        private System.Windows.Forms.ToolStripMenuItem saveFamilyMember;
        private System.Windows.Forms.ToolStripMenuItem deleteFamilyMember;
        private System.Windows.Forms.ToolStripMenuItem closeFamilyMember;
        private System.Windows.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

