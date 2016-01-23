using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace WebGUI.TestBoundTreeView
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
            this.syncedListsButton = new Gizmox.WebGUI.Forms.Button();
            this.treeListViewButton = new Gizmox.WebGUI.Forms.Button();
            this.treeViewButton = new Gizmox.WebGUI.Forms.Button();
            this.workPanel = new Gizmox.WebGUI.Forms.Panel();
            this.menuStrip1 = new Gizmox.WebGUI.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // syncedListsButton
            // 
            this.syncedListsButton.Location = new System.Drawing.Point(13, 13);
            this.syncedListsButton.Name = "syncedListsButton";
            this.syncedListsButton.Size = new System.Drawing.Size(100, 23);
            this.syncedListsButton.TabIndex = 0;
            this.syncedListsButton.Text = "Synced Lists";
            this.syncedListsButton.Click += new System.EventHandler(this.syncedListsButton_Click);
            // 
            // treeListViewButton
            // 
            this.treeListViewButton.Location = new System.Drawing.Point(139, 13);
            this.treeListViewButton.Name = "treeListViewButton";
            this.treeListViewButton.Size = new System.Drawing.Size(100, 23);
            this.treeListViewButton.TabIndex = 1;
            this.treeListViewButton.Text = "TreeListView";
            this.treeListViewButton.Click += new System.EventHandler(this.treeListViewButton_Click);
            // 
            // treeViewButton
            // 
            this.treeViewButton.Location = new System.Drawing.Point(265, 13);
            this.treeViewButton.Name = "treeViewButton";
            this.treeViewButton.Size = new System.Drawing.Size(100, 23);
            this.treeViewButton.TabIndex = 2;
            this.treeViewButton.Text = "TreeView";
            this.treeViewButton.Click += new System.EventHandler(this.treeViewButton_Click);
            // 
            // workPanel
            // 
            this.workPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(0, 50);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1012, 466);
            this.workPanel.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.DockPadding.Bottom = 2;
            this.menuStrip1.DockPadding.Left = 6;
            this.menuStrip1.DockPadding.Top = 2;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1012, 49);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.Controls.Add(this.treeViewButton);
            this.Controls.Add(this.treeListViewButton);
            this.Controls.Add(this.syncedListsButton);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormStyle = Gizmox.WebGUI.Forms.FormStyle.Application;
            this.Size = new System.Drawing.Size(1012, 516);
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button syncedListsButton;
        private Button treeListViewButton;
        private Button treeViewButton;
        private Panel workPanel;
        private MenuStrip menuStrip1;
    }
}