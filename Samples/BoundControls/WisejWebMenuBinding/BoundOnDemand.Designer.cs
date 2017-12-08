namespace WisejWeb.MenuBinding
{
    partial class BoundOnDemand
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
            this.bindMenu = new Wisej.Web.Button();
            this.SuspendLayout();
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
            this.bindMenu.Enabled = true;
            this.bindMenu.Location = new System.Drawing.Point(200, 100);
            this.bindMenu.Name = "bindMenu";
            this.bindMenu.Size = new System.Drawing.Size(120, 27);
            this.bindMenu.TabIndex = 3;
            this.bindMenu.Text = "Bind Menu";
            this.bindMenu.Click += new System.EventHandler(this.bindMenu_Click);
            //
            // BoundOnDemand
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 480);
            this.Controls.Add(this.bindMenu);
            this.Controls.Add(this.menuBar1);
            this.Name = "BoundOnDemand";
            this.Text = "Bound On Demand";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.WisejWeb.MenuItem menuItem1;
        private MvvmFx.WisejWeb.MenuItem menuItem2;
        private MvvmFx.WisejWeb.MenuItem menuItem3;
        private MvvmFx.WisejWeb.MenuItem menuItem4;
        private Wisej.Web.MenuBar menuBar1;
        private Wisej.Web.Button bindMenu;
    }
}