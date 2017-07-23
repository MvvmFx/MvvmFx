namespace WisejWeb.TestTreeView
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
            this.workPanel = new Wisej.Web.Panel();
            this.SuspendLayout();
            // 
            // workPanel
            // 
            this.workPanel.Dock = Wisej.Web.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(0, 0);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(1035, 547);
            this.workPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.workPanel);
            this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1035, 547);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel workPanel;
    }
}
