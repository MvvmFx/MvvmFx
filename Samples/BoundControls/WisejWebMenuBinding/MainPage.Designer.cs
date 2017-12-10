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
            this.button1 = new Wisej.Web.Button();
            this.button2 = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.Location = new System.Drawing.Point(50, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "WinForms Bindings";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button2.Location = new System.Drawing.Point(50, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "MvvmFx Bindings";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(999, 548);
            this.Text = "Component Binding";
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button button1;
        private Wisej.Web.Button button2;
    }
}
