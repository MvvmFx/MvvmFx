namespace WisejWeb.MenuBinding
{
    partial class WinFormsBindToolBar
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
            this.toolBar1 = new Wisej.Web.ToolBar();
            this.toolItem1 = new MvvmFx.WisejWeb.ToolBarButton();
            this.toolItem2 = new MvvmFx.WisejWeb.ToolBarButton();
            this.toolItem3 = new MvvmFx.WisejWeb.ToolBarButton();
            this.tooltem3Menu = new Wisej.Web.ContextMenu();
            this.tooltem4 = new MvvmFx.WisejWeb.MenuItem();
            this.tooltem5 = new MvvmFx.WisejWeb.MenuItem();
            this.tooltem6 = new MvvmFx.WisejWeb.MenuItem();
            this.toolItem7 = new MvvmFx.WisejWeb.ToolBarButton();
            this.statusBar1 = new Wisej.Web.StatusBar();
            this.statusItem1 = new MvvmFx.WisejWeb.StatusBarPanel();
            this.statusItem2 = new MvvmFx.WisejWeb.StatusBarPanel();
            this.statusItem3 = new MvvmFx.WisejWeb.StatusBarPanel();
            this.changeItem = new Wisej.Web.Button();
            this.showItem = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.toolItem1,
            this.toolItem2,
            this.toolItem3,
            this.toolItem7});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(612, 0);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.TabStop = false;
            // 
            // toolItem1
            // 
            this.toolItem1.Name = "toolItem1";
            this.toolItem1.Text = "toolItem1";
            // 
            // toolItem2
            // 
            this.toolItem2.Name = "toolItem2";
            this.toolItem2.Text = "toolItem2";
            // 
            // toolItem3
            // 
            this.toolItem3.DropDownMenu = this.tooltem3Menu;
            this.toolItem3.Name = "toolItem3";
            this.toolItem3.Style = Wisej.Web.ToolBarButtonStyle.DropDownButton;
            this.toolItem3.Text = "toolItem3";
            // 
            // tooltem3Menu
            // 
            this.tooltem3Menu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.tooltem4,
            this.tooltem5});
            this.tooltem3Menu.Name = "tooltem3Menu";
            // 
            // tooltem4
            // 
            this.tooltem4.Index = 0;
            this.tooltem4.Name = "tooltem4";
            this.tooltem4.Text = "tooltem4";
            // 
            // tooltem5
            // 
            this.tooltem5.Index = 1;
            this.tooltem5.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.tooltem6});
            this.tooltem5.Name = "tooltem5";
            this.tooltem5.Text = "tooltem5";
            // 
            // tooltem6
            // 
            this.tooltem6.Index = 0;
            this.tooltem6.Name = "tooltem6";
            this.tooltem6.Text = "tooltem6";
            // 
            // toolItem7
            // 
            this.toolItem7.Name = "toolItem7";
            this.toolItem7.Text = "toolItem7";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 458);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new Wisej.Web.StatusBarPanel[] {
            this.statusItem1,
            this.statusItem2,
            this.statusItem3});
            this.statusBar1.Size = new System.Drawing.Size(612, 22);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusItem1
            // 
            this.statusItem1.Name = "statusItem1";
            this.statusItem1.Text = "statusItem1";
            // 
            // statusItem2
            // 
            this.statusItem2.Name = "statusItem2";
            this.statusItem2.Text = "statusItem2";
            // 
            // statusItem3
            // 
            this.statusItem3.Name = "statusItem3";
            this.statusItem3.Text = "statusItem3";
            // 
            // changeItem
            // 
            this.changeItem.Location = new System.Drawing.Point(246, 277);
            this.changeItem.Name = "changeItem";
            this.changeItem.Size = new System.Drawing.Size(120, 27);
            this.changeItem.TabIndex = 7;
            this.changeItem.Text = "Change Item";
            this.changeItem.Click += new System.EventHandler(this.changeItem_Click);
            // 
            // showItem
            // 
            this.showItem.Location = new System.Drawing.Point(246, 177);
            this.showItem.Name = "showItem";
            this.showItem.Size = new System.Drawing.Size(120, 27);
            this.showItem.TabIndex = 6;
            this.showItem.Text = "Show Item";
            this.showItem.Click += new System.EventHandler(this.showItem_Click);
            // 
            // WinFormsBindToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.changeItem);
            this.Controls.Add(this.showItem);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Name = "WinFormsBindToolBar";
            this.Text = "WinForms Bind ToolBar";
            this.Load += new System.EventHandler(this.WinFormsBindToolBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.ToolBar toolBar1;
        private Wisej.Web.StatusBar statusBar1;
        private MvvmFx.WisejWeb.ToolBarButton toolItem1;
        private MvvmFx.WisejWeb.ToolBarButton toolItem2;
        private MvvmFx.WisejWeb.ToolBarButton toolItem3;
        private MvvmFx.WisejWeb.StatusBarPanel statusItem1;
        private MvvmFx.WisejWeb.StatusBarPanel statusItem2;
        private MvvmFx.WisejWeb.StatusBarPanel statusItem3;
        private Wisej.Web.ContextMenu tooltem3Menu;
        private MvvmFx.WisejWeb.MenuItem tooltem4;
        private MvvmFx.WisejWeb.MenuItem tooltem5;
        private MvvmFx.WisejWeb.MenuItem tooltem6;
        private MvvmFx.WisejWeb.ToolBarButton toolItem7;
        private Wisej.Web.Button changeItem;
        private Wisej.Web.Button showItem;
    }
}