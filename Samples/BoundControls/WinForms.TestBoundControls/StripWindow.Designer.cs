namespace WinForms.TestBoundControls
{
    partial class StripWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StripWindow));
            this.statusBar1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new MvvmFx.Windows.Forms.ToolStripStatusLabel();
            this.toolBar1 = new System.Windows.Forms.ToolStrip();
            this.toolBarButton1 = new MvvmFx.Windows.Forms.ToolStripLabel();
            this.toolBarButton2 = new MvvmFx.Windows.Forms.ToolStripLabel();
            this.toolBarButton3 = new MvvmFx.Windows.Forms.ToolStripSeparator();
            this.toolBarButton4 = new MvvmFx.Windows.Forms.ToolStripDropDownButton();
            this.menuBar1 = new System.Windows.Forms.MenuStrip();
            this.menuItem1 = new MvvmFx.Windows.Forms.ToolStripButton();
            this.menuItem2 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.bindMenu = new System.Windows.Forms.Button();
            this.bindToolBar = new System.Windows.Forms.Button();
            this.bindStatus = new System.Windows.Forms.Button();
            this.statusBar1.SuspendLayout();
            this.toolBar1.SuspendLayout();
            this.menuBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusBar1.Location = new System.Drawing.Point(0, 419);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(596, 22);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(72, 17);
            this.statusLabel1.Text = "statusLabel1";
            this.statusLabel1.ToolTipText = "statusLabel1";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBarButton1.DoubleClickEnabled = true;
            this.toolBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButton1.Image")));
            this.toolBarButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = new System.Drawing.Size(87, 22);
            this.toolBarButton1.Text = "toolBarButton1";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Size = new System.Drawing.Size(87, 22);
            this.toolBarButton2.Text = "toolBarButton2";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBarButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolBarButton4.Image")));
            this.toolBarButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Size = new System.Drawing.Size(100, 22);
            this.toolBarButton4.Text = "toolBarButton4";
            // 
            // toolBar1
            // 
            this.toolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3,
            this.toolBarButton4});
            this.toolBar1.Location = new System.Drawing.Point(0, 26);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(596, 25);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.Text = "toolBar1";
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(72, 19);
            this.menuItem1.Text = "menuItem1";
            // 
            // menuItem2
            // 
            this.menuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem3,
            this.menuItem4});
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(80, 22);
            this.menuItem2.Text = "menuItem2";
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(135, 22);
            this.menuItem3.Text = "menuItem3";
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(135, 22);
            this.menuItem4.Text = "menuItem4";
            // 
            // menuBar1
            // 
            this.menuBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem2});
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(596, 26);
            this.menuBar1.TabIndex = 2;
            this.menuBar1.Text = "menuBar1";
            // 
            // bindMenu
            // 
            this.bindMenu.Enabled = false;
            this.bindMenu.Location = new System.Drawing.Point(200, 100);
            this.bindMenu.Name = "bindMenu";
            this.bindMenu.Size = new System.Drawing.Size(120, 23);
            this.bindMenu.TabIndex = 3;
            this.bindMenu.Text = "bindMenu";
            this.bindMenu.UseVisualStyleBackColor = true;
            this.bindMenu.Click += new System.EventHandler(this.bindMenu_Click);
            // 
            // bindToolBar
            // 
            this.bindToolBar.Enabled = false;
            this.bindToolBar.Location = new System.Drawing.Point(200, 200);
            this.bindToolBar.Name = "bindToolBar";
            this.bindToolBar.Size = new System.Drawing.Size(120, 23);
            this.bindToolBar.TabIndex = 4;
            this.bindToolBar.Text = "bindToolBar";
            this.bindToolBar.UseVisualStyleBackColor = true;
            this.bindToolBar.Click += new System.EventHandler(this.bindToolBar_Click);
            // 
            // bindStatus
            // 
            this.bindStatus.Enabled = false;
            this.bindStatus.Location = new System.Drawing.Point(200, 300);
            this.bindStatus.Name = "bindStatus";
            this.bindStatus.Size = new System.Drawing.Size(120, 23);
            this.bindStatus.TabIndex = 5;
            this.bindStatus.Text = "bindStatus";
            this.bindStatus.UseVisualStyleBackColor = true;
            this.bindStatus.Click += new System.EventHandler(this.bindStatus_Click);
            // 
            // StripWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 441);
            this.Controls.Add(this.bindStatus);
            this.Controls.Add(this.bindToolBar);
            this.Controls.Add(this.bindMenu);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "StripWindow";
            this.Text = "Strip Window";
            this.statusBar1.ResumeLayout(false);
            this.statusBar1.PerformLayout();
            this.toolBar1.ResumeLayout(false);
            this.toolBar1.PerformLayout();
            this.menuBar1.ResumeLayout(false);
            this.menuBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar1;
        private MvvmFx.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ToolStrip toolBar1;
        private MvvmFx.Windows.Forms.ToolStripLabel toolBarButton1;
        private MvvmFx.Windows.Forms.ToolStripLabel toolBarButton2;
        private MvvmFx.Windows.Forms.ToolStripSeparator toolBarButton3;
        private MvvmFx.Windows.Forms.ToolStripDropDownButton toolBarButton4;
        private MvvmFx.Windows.Forms.ToolStripButton menuItem1;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem2;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem3;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem4;
        private System.Windows.Forms.MenuStrip menuBar1;
        private System.Windows.Forms.Button bindMenu;
        private System.Windows.Forms.Button bindToolBar;
        private System.Windows.Forms.Button bindStatus;
    }
}