namespace EventBinding
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FullNameLabel = new Gizmox.WebGUI.Forms.Label();
            this.FullName = new Gizmox.WebGUI.Forms.TextBox();
            this.Save = new Gizmox.WebGUI.Forms.Button();
            this.CloseForm = new Gizmox.WebGUI.Forms.Button();
            this.toolStrip1 = new Gizmox.WebGUI.Forms.ToolStrip();
            this.Tool = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // FullNameLabel
            //
            this.FullNameLabel.Location = new System.Drawing.Point(12, 48);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(59, 13);
            this.FullNameLabel.TabIndex = 0;
            this.FullNameLabel.Text = "Full name";
            //
            // FullName
            //
            this.FullName.Location = new System.Drawing.Point(77, 45);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(100, 20);
            this.FullName.TabIndex = 1;
            //
            // Save
            //
            this.Save.Location = new System.Drawing.Point(205, 43);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            //
            // CloseForm
            //
            this.CloseForm.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.CloseForm.Location = new System.Drawing.Point(204, 111);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 3;
            this.CloseForm.Text = "Close";
            this.CloseForm.UseVisualStyleBackColor = true;
            //
            // toolStrip1
            //
            this.toolStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.Tool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            //
            // Tool
            //
            this.Tool.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Text;
            this.Tool.Image = ((System.Drawing.Image)(resources.GetObject("Tool.Image")));
            //this.Tool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(31, 22);
            this.Tool.Text = "Tool";
            //
            // MainForm
            //
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 146);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FullName);
            this.Controls.Add(this.FullNameLabel);
            this.Name = "MainForm";
            this.Text = "Event Binding";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label FullNameLabel;
        private Gizmox.WebGUI.Forms.TextBox FullName;
        private Gizmox.WebGUI.Forms.Button Save;
        private Gizmox.WebGUI.Forms.Button CloseForm;
        private Gizmox.WebGUI.Forms.ToolStrip toolStrip1;
        private Gizmox.WebGUI.Forms.ToolStripButton Tool;

    }
}

