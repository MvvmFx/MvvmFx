namespace WisejTestBoundTreeView
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

        #region WisejWeb Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.syncedListsButton = new Wisej.Web.Button();
            this.treeListViewButton = new Wisej.Web.Button();
            this.treeViewButton = new Wisej.Web.Button();
            this.workPanel = new Wisej.Web.Panel();
            this.menuBar1 = new Wisej.Web.MenuBar();
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
            this.workPanel.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.workPanel.Location = new System.Drawing.Point(0, 50);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1020, 546);
            this.workPanel.TabIndex = 3;
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(1003, 49);
            this.menuBar1.TabIndex = 4;
            this.menuBar1.TabStop = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewButton);
            this.Controls.Add(this.treeListViewButton);
            this.Controls.Add(this.syncedListsButton);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuBar1);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1020, 546);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Button syncedListsButton;
        private Wisej.Web.Button treeListViewButton;
        private Wisej.Web.Button treeViewButton;
        private Wisej.Web.Panel workPanel;
        private Wisej.Web.MenuBar menuBar1;
    }
}
