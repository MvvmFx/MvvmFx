namespace AcyncUpdate.UI
{
    partial class AsyncUpdateView
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
            this.customerName = new Gizmox.WebGUI.Forms.TextBox();
            this.customerNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.customerId = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.getId = new Gizmox.WebGUI.Forms.Button();
            this.exit = new Gizmox.WebGUI.Forms.Button();
            this.dataEntry = new Gizmox.WebGUI.Forms.GroupBox();
            this.menuStrip1 = new Gizmox.WebGUI.Forms.MenuStrip();
            this.fileToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.busyIndicator = new AcyncUpdate.UI.BusyIndicator();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.dataEntry.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(105, 47);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(247, 20);
            this.customerName.TabIndex = 0;
            // 
            // customerNumber
            // 
            this.customerNumber.Location = new System.Drawing.Point(105, 76);
            this.customerNumber.Name = "customerNumber";
            this.customerNumber.Size = new System.Drawing.Size(247, 20);
            this.customerNumber.TabIndex = 1;
            // 
            // customerId
            // 
            this.customerId.Location = new System.Drawing.Point(105, 19);
            this.customerId.Name = "customerId";
            this.customerId.ReadOnly = true;
            this.customerId.Size = new System.Drawing.Size(247, 20);
            this.customerId.TabIndex = 2;
            this.customerId.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer Id";
            // 
            // getId
            // 
            this.getId.Location = new System.Drawing.Point(358, 17);
            this.getId.Name = "getId";
            this.getId.Size = new System.Drawing.Size(49, 22);
            this.getId.TabIndex = 6;
            this.getId.Text = "Get Id";
            this.getId.UseVisualStyleBackColor = true;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(366, 159);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(55, 22);
            this.exit.TabIndex = 7;
            this.exit.Tag = "message.attach=Exit(customerId.Text)";
            this.exit.Text = "Exit now";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // dataEntry
            // 
            this.dataEntry.Controls.Add(this.customerId);
            this.dataEntry.Controls.Add(this.customerName);
            this.dataEntry.Controls.Add(this.getId);
            this.dataEntry.Controls.Add(this.customerNumber);
            this.dataEntry.Controls.Add(this.label3);
            this.dataEntry.Controls.Add(this.label1);
            this.dataEntry.Controls.Add(this.label2);
            this.dataEntry.Location = new System.Drawing.Point(6, 43);
            this.dataEntry.Name = "dataEntry";
            this.dataEntry.Size = new System.Drawing.Size(415, 109);
            this.dataEntry.TabIndex = 9;
            this.dataEntry.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[]
            {
                this.fileToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(427, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[]
            {
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Tag = "message.attach=Quit(customerId.Text)";
            this.exitToolStripMenuItem.Text = "Get out!";
            // 
            // busyIndicator
            // 
            this.busyIndicator.BackColor = System.Drawing.SystemColors.Window;
            this.busyIndicator.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.busyIndicator.BusyContent = "Message";
            this.busyIndicator.IsBusy = false;
            this.busyIndicator.Location = new System.Drawing.Point(109, 7);
            this.busyIndicator.Name = "busyIndicator";
            this.busyIndicator.Size = new System.Drawing.Size(193, 114);
            this.busyIndicator.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "* The File menu items use the contol\'s Tag property to attach the action.";
            // 
            // AsyncUpdateView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 185);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataEntry);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.busyIndicator);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsyncUpdateView";
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "AsyncUpdateView";
            this.dataEntry.ResumeLayout(false);
            this.dataEntry.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox customerName;
        private Gizmox.WebGUI.Forms.TextBox customerNumber;
        private Gizmox.WebGUI.Forms.TextBox customerId;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Button getId;
        private Gizmox.WebGUI.Forms.Button exit;
        private AcyncUpdate.UI.BusyIndicator busyIndicator;
        private Gizmox.WebGUI.Forms.GroupBox dataEntry;
        private Gizmox.WebGUI.Forms.MenuStrip menuStrip1;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Gizmox.WebGUI.Forms.Label label4;
    }
}