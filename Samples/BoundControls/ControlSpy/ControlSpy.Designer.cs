namespace ControlSpy
{
    partial class ControlSpy
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
            this.controlName = new System.Windows.Forms.Label();
            this.controlTextBox = new System.Windows.Forms.TextBox();
            this.propertyTextBox = new System.Windows.Forms.TextBox();
            this.propertyName = new System.Windows.Forms.Label();
            this.spyTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.libraryComboBox = new System.Windows.Forms.ComboBox();
            this.spyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // controlName
            // 
            this.controlName.AutoSize = true;
            this.controlName.Location = new System.Drawing.Point(13, 13);
            this.controlName.Name = "controlName";
            this.controlName.Size = new System.Drawing.Size(69, 13);
            this.controlName.TabIndex = 0;
            this.controlName.Text = "Control name";
            // 
            // controlTextBox
            // 
            this.controlTextBox.Location = new System.Drawing.Point(107, 13);
            this.controlTextBox.Name = "controlTextBox";
            this.controlTextBox.Size = new System.Drawing.Size(100, 20);
            this.controlTextBox.TabIndex = 1;
            // 
            // propertyTextBox
            // 
            this.propertyTextBox.Location = new System.Drawing.Point(107, 39);
            this.propertyTextBox.Name = "propertyTextBox";
            this.propertyTextBox.Size = new System.Drawing.Size(100, 20);
            this.propertyTextBox.TabIndex = 3;
            // 
            // propertyName
            // 
            this.propertyName.AutoSize = true;
            this.propertyName.Location = new System.Drawing.Point(13, 39);
            this.propertyName.Name = "propertyName";
            this.propertyName.Size = new System.Drawing.Size(75, 13);
            this.propertyName.TabIndex = 2;
            this.propertyName.Text = "Property name";
            // 
            // spyTextBox
            // 
            this.spyTextBox.Location = new System.Drawing.Point(16, 73);
            this.spyTextBox.Multiline = true;
            this.spyTextBox.Name = "spyTextBox";
            this.spyTextBox.Size = new System.Drawing.Size(608, 328);
            this.spyTextBox.TabIndex = 4;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(548, 44);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // libraryComboBox
            // 
            this.libraryComboBox.AllowDrop = true;
            this.libraryComboBox.FormattingEnabled = true;
            this.libraryComboBox.Items.AddRange(new object[] {
            "Windows",
            "WebGUI"});
            this.libraryComboBox.Location = new System.Drawing.Point(231, 11);
            this.libraryComboBox.Name = "libraryComboBox";
            this.libraryComboBox.Size = new System.Drawing.Size(121, 21);
            this.libraryComboBox.TabIndex = 6;
            // 
            // spyButton
            // 
            this.spyButton.Location = new System.Drawing.Point(231, 39);
            this.spyButton.Name = "spyButton";
            this.spyButton.Size = new System.Drawing.Size(121, 23);
            this.spyButton.TabIndex = 7;
            this.spyButton.Text = "Spy";
            this.spyButton.UseVisualStyleBackColor = true;
            this.spyButton.Click += new System.EventHandler(this.spyButton_Click);
            // 
            // ControlSpy
            // 
            this.AcceptButton = this.spyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(636, 413);
            this.Controls.Add(this.spyButton);
            this.Controls.Add(this.libraryComboBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.spyTextBox);
            this.Controls.Add(this.propertyTextBox);
            this.Controls.Add(this.propertyName);
            this.Controls.Add(this.controlTextBox);
            this.Controls.Add(this.controlName);
            this.Name = "ControlSpy";
            this.Text = "Control Spy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label controlName;
        private System.Windows.Forms.TextBox controlTextBox;
        private System.Windows.Forms.TextBox propertyTextBox;
        private System.Windows.Forms.Label propertyName;
        private System.Windows.Forms.TextBox spyTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ComboBox libraryComboBox;
        private System.Windows.Forms.Button spyButton;
    }
}

