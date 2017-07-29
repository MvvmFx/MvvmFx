namespace WisejWeb.TestTreeView
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
            this.autoTreeViewButton = new Wisej.Web.Button();
            this.manualTreeViewButton = new Wisej.Web.Button();
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
            // autoTreeViewButton
            // 
            this.autoTreeViewButton.Location = new System.Drawing.Point(265, 13);
            this.autoTreeViewButton.Name = "autoTreeViewButton";
            this.autoTreeViewButton.Size = new System.Drawing.Size(100, 23);
            this.autoTreeViewButton.TabIndex = 0;
            this.autoTreeViewButton.Text = "Auto TreeView";
            this.autoTreeViewButton.Click += new System.EventHandler(this.autoTreeViewButton_Click);
            // 
            // manualTreeViewButton
            // 
            this.manualTreeViewButton.Location = new System.Drawing.Point(139, 13);
            this.manualTreeViewButton.Name = "manualTreeViewButton";
            this.manualTreeViewButton.Size = new System.Drawing.Size(100, 23);
            this.manualTreeViewButton.TabIndex = 1;
            this.manualTreeViewButton.Text = "Manual TreeView";
            this.manualTreeViewButton.Click += new System.EventHandler(this.manualTreeViewButton_Click);
            // 
            // workPanel
            // 
            this.workPanel.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            //this.workPanel.Dock = Wisej.Web.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(0, 49);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1003, 438);
            this.workPanel.TabIndex = 4;
            // 
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(1003, 22);
            this.menuBar1.TabIndex = 5;
            this.menuBar1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1003, 522);
            this.Controls.Add(this.manualTreeViewButton);
            this.Controls.Add(this.autoTreeViewButton);
            this.Controls.Add(this.syncedListsButton);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.menuBar1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button syncedListsButton;
        private Wisej.Web.Button autoTreeViewButton;
        private Wisej.Web.Button manualTreeViewButton;
        private Wisej.Web.Panel workPanel;
        private Wisej.Web.MenuBar menuBar1;
    }
}