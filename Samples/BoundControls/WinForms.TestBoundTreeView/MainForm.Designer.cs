namespace WinForms.TestBoundTreeView
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
            this.syncedListsButton = new System.Windows.Forms.Button();
            this.treeListViewButton = new System.Windows.Forms.Button();
            this.autoTreeViewButton = new System.Windows.Forms.Button();
            this.stripWindowButton = new System.Windows.Forms.Button();
            this.workPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // syncedListsButton
            // 
            this.syncedListsButton.Location = new System.Drawing.Point(13, 13);
            this.syncedListsButton.Name = "syncedListsButton";
            this.syncedListsButton.Size = new System.Drawing.Size(100, 23);
            this.syncedListsButton.TabIndex = 0;
            this.syncedListsButton.Text = "Synced Lists";
            this.syncedListsButton.UseVisualStyleBackColor = true;
            this.syncedListsButton.Click += new System.EventHandler(this.syncedListsButton_Click);
            // 
            // treeListViewButton
            // 
            this.treeListViewButton.Location = new System.Drawing.Point(139, 13);
            this.treeListViewButton.Name = "treeListViewButton";
            this.treeListViewButton.Size = new System.Drawing.Size(100, 23);
            this.treeListViewButton.TabIndex = 1;
            this.treeListViewButton.Text = "TreeListView";
            this.treeListViewButton.UseVisualStyleBackColor = true;
            this.treeListViewButton.Click += new System.EventHandler(this.treeListViewButton_Click);
            // 
            // autoTreeViewButton
            // 
            this.autoTreeViewButton.Location = new System.Drawing.Point(265, 13);
            this.autoTreeViewButton.Name = "autoTreeViewButton";
            this.autoTreeViewButton.Size = new System.Drawing.Size(100, 23);
            this.autoTreeViewButton.TabIndex = 2;
            this.autoTreeViewButton.Text = "TreeView";
            this.autoTreeViewButton.UseVisualStyleBackColor = true;
            this.autoTreeViewButton.Click += new System.EventHandler(this.autoTreeViewButton_Click);
            // 
            // stripWindowButton
            // 
            this.stripWindowButton.Location = new System.Drawing.Point(391, 12);
            this.stripWindowButton.Name = "stripWindowButton";
            this.stripWindowButton.Size = new System.Drawing.Size(100, 23);
            this.stripWindowButton.TabIndex = 3;
            this.stripWindowButton.Text = "Strip Window";
            this.stripWindowButton.UseVisualStyleBackColor = true;
            this.stripWindowButton.Click += new System.EventHandler(this.stripWindowButton_Click);
            // 
            // workPanel
            // 
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(0, 49);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1003, 438);
            this.workPanel.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 49);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1003, 487);
            this.Controls.Add(this.stripWindowButton);
            this.Controls.Add(this.autoTreeViewButton);
            this.Controls.Add(this.treeListViewButton);
            this.Controls.Add(this.syncedListsButton);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button syncedListsButton;
        private System.Windows.Forms.Button treeListViewButton;
        private System.Windows.Forms.Button autoTreeViewButton;
        private System.Windows.Forms.Button stripWindowButton;
        private System.Windows.Forms.Panel workPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}