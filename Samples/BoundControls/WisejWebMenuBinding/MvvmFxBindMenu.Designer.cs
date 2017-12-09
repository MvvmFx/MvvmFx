namespace WisejWeb.MenuBinding
{
    partial class MvvmFxBindMenu
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
            this.menuItem1 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem2 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem3 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem4 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem5 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem7 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem8 = new MvvmFx.WisejWeb.MenuItem();
            this.menuItem6 = new MvvmFx.WisejWeb.MenuItem();
            this.showItem = new Wisej.Web.Button();
            this.changeItem = new Wisej.Web.Button();
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
            this.menuBar1.Size = new System.Drawing.Size(612, 28);
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
            // showItem
            // 
            this.showItem.Location = new System.Drawing.Point(200, 100);
            this.showItem.Name = "showItem";
            this.showItem.Size = new System.Drawing.Size(120, 27);
            this.showItem.TabIndex = 4;
            this.showItem.Text = "Show Item";
            this.showItem.Click += new System.EventHandler(this.showItem_Click);
            // 
            // changeItem
            // 
            this.changeItem.Location = new System.Drawing.Point(200, 200);
            this.changeItem.Name = "changeItem";
            this.changeItem.Size = new System.Drawing.Size(120, 27);
            this.changeItem.TabIndex = 5;
            this.changeItem.Text = "Change Item";
            this.changeItem.Click += new System.EventHandler(this.changeItem_Click);
            // 
            // MvvmFxBindMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.changeItem);
            this.Controls.Add(this.showItem);
            this.Controls.Add(this.menuBar1);
            this.Name = "MvvmFxBindMenu";
            this.Text = "MvvmFx Bind Menu";
            this.Load += new System.EventHandler(this.MvvmFxBindMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.WisejWeb.MenuItem menuItem1;
        private MvvmFx.WisejWeb.MenuItem menuItem2;
        private MvvmFx.WisejWeb.MenuItem menuItem3;
        private MvvmFx.WisejWeb.MenuItem menuItem4;
        private Wisej.Web.MenuBar menuBar1;
        private MvvmFx.WisejWeb.MenuItem menuItem5;
        private MvvmFx.WisejWeb.MenuItem menuItem6;
        private MvvmFx.WisejWeb.MenuItem menuItem7;
        private MvvmFx.WisejWeb.MenuItem menuItem8;
        private Wisej.Web.Button showItem;
        private Wisej.Web.Button changeItem;
    }
}