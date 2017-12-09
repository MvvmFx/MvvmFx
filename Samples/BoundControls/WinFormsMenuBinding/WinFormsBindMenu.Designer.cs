namespace WinForms.MenuBinding
{
    partial class WinFormsBindMenu
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
            this.menuItem5 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem7 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new MvvmFx.Windows.Forms.ToolStripMenuItem();
            this.showItem = new System.Windows.Forms.Button();
            this.changeItem = new System.Windows.Forms.Button();
            this.menuBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar1
            // 
            this.menuBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem6});
            this.menuBar1.Location = new System.Drawing.Point(0, 0);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(596, 26);
            this.menuBar1.TabIndex = 2;
            this.menuBar1.Text = "menuBar1";
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
            this.menuItem4,
            this.menuItem5});
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
            // menuItem5
            // 
            this.menuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem7});
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Size = new System.Drawing.Size(135, 22);
            this.menuItem5.Text = "menuItem5";
            // 
            // menuItem7
            // 
            this.menuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem8});
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Size = new System.Drawing.Size(135, 22);
            this.menuItem7.Text = "menuItem7";
            // 
            // menuItem8
            // 
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(135, 22);
            this.menuItem8.Text = "menuItem8";
            // 
            // menuItem6
            // 
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(80, 22);
            this.menuItem6.Text = "menuItem6";
            // 
            // showItem
            // 
            this.showItem.Location = new System.Drawing.Point(200, 100);
            this.showItem.Name = "showItem";
            this.showItem.Size = new System.Drawing.Size(120, 23);
            this.showItem.TabIndex = 4;
            this.showItem.Text = "Show Item";
            this.showItem.UseVisualStyleBackColor = true;
            this.showItem.Click += new System.EventHandler(this.showItem_Click);
            // 
            // changeItem
            // 
            this.changeItem.Location = new System.Drawing.Point(200, 200);
            this.changeItem.Name = "changeItem";
            this.changeItem.Size = new System.Drawing.Size(120, 23);
            this.changeItem.TabIndex = 5;
            this.changeItem.Text = "Change Item";
            this.changeItem.UseVisualStyleBackColor = true;
            this.changeItem.Click += new System.EventHandler(this.changeItem_Click);
            // 
            // WinFormsBindMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 441);
            this.Controls.Add(this.changeItem);
            this.Controls.Add(this.showItem);
            this.Controls.Add(this.menuBar1);
            this.MainMenuStrip = this.menuBar1;
            this.Name = "WinFormsBindMenu";
            this.Text = "WinForms Bind Menu";
            this.Load += new System.EventHandler(this.WinFormsBindMenu_Load);
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
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem5;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem6;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem7;
        private MvvmFx.Windows.Forms.ToolStripMenuItem menuItem8;
        private System.Windows.Forms.Button showItem;
        private System.Windows.Forms.Button changeItem;
    }
}
