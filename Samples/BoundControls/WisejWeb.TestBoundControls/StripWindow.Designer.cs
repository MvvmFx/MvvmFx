namespace WisejWeb.TestBoundTreeView
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

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusBar1 = new Wisej.Web.StatusBar();
            this.statusLabel1 = new MvvmFx.WisejWeb.StatusBarPanel();
            this.toolBar1 = new Wisej.Web.ToolBar();
            this.toolBarButton1 = new MvvmFx.WisejWeb.ToolBarButton();
            this.toolBarButton2 = new MvvmFx.WisejWeb.ToolBarButton();
            this.toolBarButton3 = new MvvmFx.WisejWeb.ToolBarButton();
            this.toolBarButton4 = new MvvmFx.WisejWeb.ToolBarButton();
            this.menuBar1 = new Wisej.Web.MenuBar();
            this.menuItem1 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem2 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem3 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem4 = new MvvmFx.WisejWeb.MenuItem();
            this.bindMenu = new Wisej.Web.Button();
            this.bindToolBar = new Wisej.Web.Button();
            this.bindStatus = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 458);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new Wisej.Web.StatusBarPanel[] {
            this.statusLabel1});
            this.statusBar1.Size = new System.Drawing.Size(612, 22);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Text = "statusLabel1";
            this.statusLabel1.ToolTipText = "statusLabel1";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Text = "toolBarButton1";
            this.toolBarButton1.ToolTipText = "toolBarButton1";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = Wisej.Web.ToolBarButtonStyle.ToggleButton;
            this.toolBarButton2.Text = "toolBarButton2";
            this.toolBarButton2.ToolTipText = "toolBarButton2";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = Wisej.Web.ToolBarButtonStyle.Separator;
            this.toolBarButton3.ToolTipText = "toolBarButton3";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = Wisej.Web.ToolBarButtonStyle.DropDownButton;
            this.toolBarButton4.Text = "toolBarButton4";
            this.toolBarButton4.ToolTipText = "toolBarButton4";
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3,
            this.toolBarButton4});
            this.toolBar1.Location = new System.Drawing.Point(0, 22);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(612, 26);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.TabStop = false;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Text = "menuItem1";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem3,
            this.menuItem4});
            this.menuItem2.Text = "menuItem2";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Text = "menuItem3";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Text = "menuItem4";

            // 
            // menuBar1
            // 
            this.menuBar1.Dock = Wisej.Web.DockStyle.Top;
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(612, 22);
            this.menuBar1.TabIndex = 2;
            this.menuBar1.TabStop = false;
            // 
            // bindMenu
            // 
            this.bindMenu.Enabled = false;
            this.bindMenu.Location = new System.Drawing.Point(200, 100);
            this.bindMenu.Name = "bindMenu";
            this.bindMenu.Size = new System.Drawing.Size(120, 23);
            this.bindMenu.TabIndex = 3;
            this.bindMenu.Text = "bindMenu";
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
            this.bindStatus.Click += new System.EventHandler(this.bindStatus_Click);
            // 
            // StripWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.bindStatus);
            this.Controls.Add(this.bindToolBar);
            this.Controls.Add(this.bindMenu);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuBar1);
            this.Name = "StripWindow";
            this.Text = "Strip Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.StatusBar statusBar1;
        private MvvmFx.WisejWeb.StatusBarPanel statusLabel1;
        private Wisej.Web.ToolBar toolBar1;
        private MvvmFx.WisejWeb.ToolBarButton toolBarButton1;
        private MvvmFx.WisejWeb.ToolBarButton toolBarButton2;
        private MvvmFx.WisejWeb.ToolBarButton toolBarButton3;
        private MvvmFx.WisejWeb.ToolBarButton toolBarButton4;
        private MvvmFx.WisejWeb.MenuItem menuItem1;
        private MvvmFx.WisejWeb.MenuItem menuItem2;
        private MvvmFx.WisejWeb.MenuItem menuItem3;
        private MvvmFx.WisejWeb.MenuItem menuItem4;
        private Wisej.Web.MenuBar menuBar1;
        private Wisej.Web.Button bindMenu;
        private Wisej.Web.Button bindToolBar;
        private Wisej.Web.Button bindStatus;
    }
}