namespace InvoicesUI
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
            this.stringBindingsINPC = new System.Windows.Forms.Button();
            this.lambdaBindingsINPC = new System.Windows.Forms.Button();
            this.stringBindingsValidation = new System.Windows.Forms.Button();
            this.lambdaBindingsValidation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stringBindingsINPC
            // 
            this.stringBindingsINPC.Location = new System.Drawing.Point(46, 50);
            this.stringBindingsINPC.Name = "stringBindingsINPC";
            this.stringBindingsINPC.Size = new System.Drawing.Size(200, 23);
            this.stringBindingsINPC.TabIndex = 0;
            this.stringBindingsINPC.Text = "String Bindings - PropertyChanged";
            this.stringBindingsINPC.UseVisualStyleBackColor = true;
            this.stringBindingsINPC.Click += new System.EventHandler(this.stringBindingsINPC_Click);
            // 
            // lambdaBindingsINPC
            // 
            this.lambdaBindingsINPC.Location = new System.Drawing.Point(46, 100);
            this.lambdaBindingsINPC.Name = "lambdaBindingsINPC";
            this.lambdaBindingsINPC.Size = new System.Drawing.Size(200, 23);
            this.lambdaBindingsINPC.TabIndex = 1;
            this.lambdaBindingsINPC.Text = "Lambda Bindings - PropertyChanged";
            this.lambdaBindingsINPC.UseVisualStyleBackColor = true;
            this.lambdaBindingsINPC.Click += new System.EventHandler(this.lambdaBindingsINPC_Click);
            // 
            // stringBindingsValidation
            // 
            this.stringBindingsValidation.Location = new System.Drawing.Point(46, 150);
            this.stringBindingsValidation.Name = "stringBindingsValidation";
            this.stringBindingsValidation.Size = new System.Drawing.Size(200, 23);
            this.stringBindingsValidation.TabIndex = 2;
            this.stringBindingsValidation.Text = "String Bindings - Validation";
            this.stringBindingsValidation.UseVisualStyleBackColor = true;
            this.stringBindingsValidation.Click += new System.EventHandler(this.stringBindingsValidation_Click);
            // 
            // lambdaBindingsValidation
            // 
            this.lambdaBindingsValidation.Location = new System.Drawing.Point(46, 200);
            this.lambdaBindingsValidation.Name = "lambdaBindingsValidation";
            this.lambdaBindingsValidation.Size = new System.Drawing.Size(200, 23);
            this.lambdaBindingsValidation.TabIndex = 3;
            this.lambdaBindingsValidation.Text = "Lambda Bindings - Validation";
            this.lambdaBindingsValidation.UseVisualStyleBackColor = true;
            this.lambdaBindingsValidation.Click += new System.EventHandler(this.lambdaBindingsValidation_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.lambdaBindingsValidation);
            this.Controls.Add(this.stringBindingsValidation);
            this.Controls.Add(this.lambdaBindingsINPC);
            this.Controls.Add(this.stringBindingsINPC);
            this.Name = "MainForm";
            this.Text = "InvoicesUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stringBindingsINPC;
        private System.Windows.Forms.Button lambdaBindingsINPC;
        private System.Windows.Forms.Button stringBindingsValidation;
        private System.Windows.Forms.Button lambdaBindingsValidation;
    }
}