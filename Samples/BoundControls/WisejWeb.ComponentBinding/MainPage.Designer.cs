namespace WisejWeb.ComponentBinding
{
    partial class MainPage
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
            this.menuBar1 = new Wisej.Web.MenuBar();
            this.menuItem1 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem2 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem3 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem4 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem5 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem7 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem8 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.menuItem6 = new MvvmFx.Controls.WisejWeb.MenuItem();
            this.showMenuItem = new Wisej.Web.Button();
            this.changeMenuItem = new Wisej.Web.Button();
            this.winFormsBindings = new Wisej.Web.Button();
            this.mvvmfxBindings = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.Dock = Wisej.Web.DockStyle.Top;
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem6});
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(957, 28);
            this.menuBar1.TabIndex = 2;
            this.menuBar1.TabStop = false;
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
            this.menuItem2.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.menuItem2.Name = "menuItem2";
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
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem7});
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Text = "menuItem5";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem8});
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Text = "menuItem7";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Text = "menuItem8";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Text = "menuItem6";
            // 
            // showMenuItem
            // 
            this.showMenuItem.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.showMenuItem.Location = new System.Drawing.Point(50, 150);
            this.showMenuItem.Name = "showMenuItem";
            this.showMenuItem.Size = new System.Drawing.Size(250, 40);
            this.showMenuItem.TabIndex = 4;
            this.showMenuItem.Text = "Show Menu Item";
            this.showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);
            // 
            // changeMenuItem
            // 
            this.changeMenuItem.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.changeMenuItem.Location = new System.Drawing.Point(50, 250);
            this.changeMenuItem.Name = "changeMenuItem";
            this.changeMenuItem.Size = new System.Drawing.Size(250, 40);
            this.changeMenuItem.TabIndex = 5;
            this.changeMenuItem.Text = "Change Menu Item";
            this.changeMenuItem.Click += new System.EventHandler(this.changeMenuItem_Click);
            // 
            // winFormsBindings
            // 
            this.winFormsBindings.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.winFormsBindings.Location = new System.Drawing.Point(500, 150);
            this.winFormsBindings.Name = "winFormsBindings";
            this.winFormsBindings.Size = new System.Drawing.Size(250, 40);
            this.winFormsBindings.TabIndex = 0;
            this.winFormsBindings.Text = "WinForms Bindings";
            this.winFormsBindings.Click += new System.EventHandler(this.winFormsBindings_Click);
            // 
            // mvvmfxBindings
            // 
            this.mvvmfxBindings.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mvvmfxBindings.Location = new System.Drawing.Point(500, 250);
            this.mvvmfxBindings.Name = "mvvmfxBindings";
            this.mvvmfxBindings.Size = new System.Drawing.Size(250, 40);
            this.mvvmfxBindings.TabIndex = 1;
            this.mvvmfxBindings.Text = "MvvmFx Bindings";
            this.mvvmfxBindings.Click += new System.EventHandler(this.mvvmfxBindings_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.mvvmfxBindings);
            this.Controls.Add(this.winFormsBindings);
            this.Controls.Add(this.changeMenuItem);
            this.Controls.Add(this.showMenuItem);
            this.Controls.Add(this.menuBar1);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(957, 803);
            this.Text = "Component Binding";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.Controls.WisejWeb.MenuItem menuItem1;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem2;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem3;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem4;
        private Wisej.Web.MenuBar menuBar1;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem5;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem6;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem7;
        private MvvmFx.Controls.WisejWeb.MenuItem menuItem8;
        private Wisej.Web.Button showMenuItem;
        private Wisej.Web.Button changeMenuItem;
        private Wisej.Web.Button winFormsBindings;
        private Wisej.Web.Button mvvmfxBindings;
    }
}
