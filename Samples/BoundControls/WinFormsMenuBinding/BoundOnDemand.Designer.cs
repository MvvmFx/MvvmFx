namespace WinForms.MenuBinding
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBar1 = new System.Windows.Forms.MenuStrip();
            this.menuItem1 = new MvvmFx.Windows.Forms.ToolStripButton();
            this.menuItem2 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.bindMenu = new System.Windows.Forms.Button();
            this.menuBar1.SuspendLayout();
            this.SuspendLayout();
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
            this.bindMenu.Enabled = true;
            this.bindMenu.Location = new System.Drawing.Point(200, 100);
            this.bindMenu.Name = "bindMenu";
            this.bindMenu.Size = new System.Drawing.Size(120, 23);
            this.bindMenu.TabIndex = 3;
            this.bindMenu.Text = "Bind Menu";
            this.bindMenu.UseVisualStyleBackColor = true;
            this.bindMenu.Click += new System.EventHandler(this.bindMenu_Click);
            //
            // BoundOnDemand
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 441);
            this.Controls.Add(this.bindMenu);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "BoundOnDemand";
            this.Text = "Bind On Demand";
            this.menuBar1.ResumeLayout(false);
            this.menuBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MvvmFx.Windows.Forms.ToolStripButton menuItem1;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem2;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem3;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem4;
        private System.Windows.Forms.MenuStrip menuBar1;
        private System.Windows.Forms.Button bindMenu;
    }
}
