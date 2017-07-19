namespace EventBinding.WisejWeb
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

        #region WisejWeb Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FullNameLabel = new Wisej.Web.Label();
            this.FullName = new Wisej.Web.TextBox();
            this.Save = new Wisej.Web.Button();
            this.CloseForm = new Wisej.Web.Button();
            this.toolStrip1 = new Wisej.Web.MenuBar();
            this.Tool = new Wisej.Web.MenuItem();
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
            //
            // CloseForm
            //
            this.CloseForm.Anchor = ((Wisej.Web.AnchorStyles)((Wisej.Web.AnchorStyles.Bottom | Wisej.Web.AnchorStyles.Right)));
            this.CloseForm.Location = new System.Drawing.Point(204, 111);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(75, 23);
            this.CloseForm.TabIndex = 3;
            this.CloseForm.Text = "Close";
            //
            // toolStrip1
            //
            this.toolStrip1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.Tool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            //
            // Tool
            //
            //this.Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tool.Name = "Tool";
            //this.Tool.Size = new System.Drawing.Size(31, 22);
            this.Tool.Text = "Tool";
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
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

        private Wisej.Web.Label FullNameLabel;
        private Wisej.Web.TextBox FullName;
        private Wisej.Web.Button Save;
        private Wisej.Web.Button CloseForm;
        private Wisej.Web.MenuBar toolStrip1;
        private Wisej.Web.MenuItem Tool;

    }
}

