namespace Test.FormScrollBar
{
    partial class FormScrollBar
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomRight = new Gizmox.WebGUI.Forms.Label();
            this.menuStrip1 = new Gizmox.WebGUI.Forms.MenuStrip();
            this.toolStripMenuItem1 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.statusStrip1 = new Gizmox.WebGUI.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new Gizmox.WebGUI.Forms.ToolStripStatusLabel();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomRight
            // 
            this.bottomRight.BackColor = System.Drawing.Color.Transparent;
            this.bottomRight.ForeColor = System.Drawing.Color.Transparent;
            this.bottomRight.Location = new System.Drawing.Point(1240, 609);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(10, 13);
            this.bottomRight.TabIndex = 0;
            this.bottomRight.Text = "_";
            // 
            // menuStrip1
            // 
            this.menuStrip1.DockPadding.Bottom = 2;
            this.menuStrip1.DockPadding.Left = 6;
            this.menuStrip1.DockPadding.Top = 2;
            this.menuStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1250, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(27, 17);
            this.toolStripMenuItem1.Text = "File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.statusStrip1.DockPadding.Left = 1;
            this.statusStrip1.DockPadding.Right = 14;
            this.statusStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 622);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1250, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new Gizmox.WebGUI.Forms.Padding(0, 1, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 13);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // listBox1
            // 
            this.listBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.listBox1.Location = new System.Drawing.Point(0, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 589);
            this.listBox1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 598);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel Top Left";
            // 
            // FormScrollBar
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.menuStrip1);
            this.Size = new System.Drawing.Size(1250, 623);
            this.Text = "FormScrollBar";
            this.Load += new System.EventHandler(this.FormScrollBar_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label bottomRight;
        private Gizmox.WebGUI.Forms.MenuStrip menuStrip1;
        private Gizmox.WebGUI.Forms.StatusStrip statusStrip1;
        private Gizmox.WebGUI.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItem1;
        private Gizmox.WebGUI.Forms.ListBox listBox1;
        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.Label label1;
    }
}