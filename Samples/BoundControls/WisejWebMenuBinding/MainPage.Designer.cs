namespace WisejWeb.MenuBinding
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
            this.buttonHardBind = new Wisej.Web.Button();
            this.buttonBoundOnDemand = new Wisej.Web.Button();
            this.buttonAutoBind = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // buttonHardBind
            // 
            this.buttonHardBind.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonHardBind.Location = new System.Drawing.Point(50, 50);
            this.buttonHardBind.Name = "buttonHardBind";
            this.buttonHardBind.Size = new System.Drawing.Size(200, 40);
            this.buttonHardBind.TabIndex = 0;
            this.buttonHardBind.Text = "Hard Bind";
            this.buttonHardBind.Click += new System.EventHandler(this.buttonHardBind_Click);
            // 
            // buttonBoundOnDemand
            // 
            this.buttonBoundOnDemand.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonBoundOnDemand.Location = new System.Drawing.Point(50, 150);
            this.buttonBoundOnDemand.Name = "buttonBoundOnDemand";
            this.buttonBoundOnDemand.Size = new System.Drawing.Size(200, 40);
            this.buttonBoundOnDemand.TabIndex = 1;
            this.buttonBoundOnDemand.Text = "Bound On Demand";
            this.buttonBoundOnDemand.Click += new System.EventHandler(this.buttonBoundOnDemand_Click);
            // 
            // buttonAutoBind
            // 
            this.buttonAutoBind.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAutoBind.Location = new System.Drawing.Point(50, 250);
            this.buttonAutoBind.Name = "buttonAutoBind";
            this.buttonAutoBind.Size = new System.Drawing.Size(200, 40);
            this.buttonAutoBind.TabIndex = 1;
            this.buttonAutoBind.Text = "Auto Bind";
            this.buttonAutoBind.Click += new System.EventHandler(this.buttonAutoBind_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAutoBind);
            this.Controls.Add(this.buttonBoundOnDemand);
            this.Controls.Add(this.buttonHardBind);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Size = new System.Drawing.Size(999, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button buttonHardBind;
        private Wisej.Web.Button buttonBoundOnDemand;
        private Wisej.Web.Button buttonAutoBind;
    }
}
