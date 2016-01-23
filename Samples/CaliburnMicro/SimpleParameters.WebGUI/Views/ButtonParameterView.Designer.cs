namespace SimpleParameters.UI.Views
{
    partial class ButtonParameterView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.button3 = new Gizmox.WebGUI.Forms.Button();
            this.button4 = new Gizmox.WebGUI.Forms.Button();
            this.button5 = new Gizmox.WebGUI.Forms.Button();
            this.button6 = new Gizmox.WebGUI.Forms.Button();
            this.button7 = new Gizmox.WebGUI.Forms.Button();
            this.button8 = new Gizmox.WebGUI.Forms.Button();
            this.boundlabel = new Gizmox.WebGUI.Forms.Label();
            this.parameter = new Gizmox.WebGUI.Forms.TextBox();
            this.actionDescription = new Gizmox.WebGUI.Forms.Label();
            this.actionDetail = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "message.attach=ShowBindingContext($bindingcontext)";
            this.button1.Text = "BindingContext";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button2.Location = new System.Drawing.Point(114, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 1;
            this.button2.Tag = "message.attach=ShowDataContext($datacontext)";
            this.button2.Text = "DataContext";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button3.Location = new System.Drawing.Point(224, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 2;
            this.button3.Tag = "message.attach=ShowEventArgs($eventargs)";
            this.button3.Text = "EventArgs";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button4.Location = new System.Drawing.Point(334, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 3;
            this.button4.Tag = "message.attach=ShowSource($source)";
            this.button4.Text = "Source";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button5.Location = new System.Drawing.Point(444, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 4;
            this.button5.Tag = "message.attach=ShowExecutionContext($executioncontext)";
            this.button5.Text = "ExecutionContext";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button6.Location = new System.Drawing.Point(554, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 5;
            this.button6.Tag = "message.attach=ShowView($view)";
            this.button6.Text = "View";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button7.Location = new System.Drawing.Point(664, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 23);
            this.button7.TabIndex = 6;
            this.button7.Tag = "message.attach=ShowThis($this.Text)";
            this.button7.Text = "This.Text";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.button8.Location = new System.Drawing.Point(774, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 23);
            this.button8.TabIndex = 7;
            this.button8.Tag = "message.attach=ShowBound(parameter.Text)";
            this.button8.Text = "Bound";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // boundlabel
            // 
            this.boundlabel.AutoSize = true;
            this.boundlabel.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.boundlabel.Location = new System.Drawing.Point(6, 53);
            this.boundlabel.Name = "boundlabel";
            this.boundlabel.Size = new System.Drawing.Size(200, 13);
            this.boundlabel.TabIndex = 10;
            // 
            // parameter
            // 
            this.parameter.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.parameter.Location = new System.Drawing.Point(224, 50);
            this.parameter.Name = "parameter";
            this.parameter.Size = new System.Drawing.Size(100, 20);
            this.parameter.TabIndex = 7;
            // 
            // actionDescription
            // 
            this.actionDescription.AutoSize = true;
            this.actionDescription.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.actionDescription.Location = new System.Drawing.Point(6, 80);
            this.actionDescription.Name = "actionDescription";
            this.actionDescription.Size = new System.Drawing.Size(0, 13);
            this.actionDescription.TabIndex = 8;
            // 
            // actionDetail
            // 
            this.actionDetail.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.actionDetail.Location = new System.Drawing.Point(6, 100);
            this.actionDetail.Multiline = true;
            this.actionDetail.Name = "actionDetail";
            this.actionDetail.ReadOnly = true;
            this.actionDetail.BackColor = System.Drawing.Color.White;
            this.actionDetail.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.actionDetail.Size = new System.Drawing.Size(922, 300);
            this.actionDetail.TabIndex = 9;
            // 
            // ButtonParameterView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionDetail);
            this.Controls.Add(this.actionDescription);
            this.Controls.Add(this.boundlabel);
            this.Controls.Add(this.parameter);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(1003, 438);
            this.MinimumSize = new System.Drawing.Size(1003, 438);
            this.Name = "ButtonParameterView";
            this.Size = new System.Drawing.Size(1003, 438);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.Button button3;
        private Gizmox.WebGUI.Forms.Button button4;
        private Gizmox.WebGUI.Forms.Button button5;
        private Gizmox.WebGUI.Forms.Button button6;
        internal Gizmox.WebGUI.Forms.Button button7;
        private Gizmox.WebGUI.Forms.Button button8;
        private Gizmox.WebGUI.Forms.Label boundlabel;
        private Gizmox.WebGUI.Forms.TextBox parameter;
        private Gizmox.WebGUI.Forms.Label actionDescription;
        private Gizmox.WebGUI.Forms.TextBox actionDetail;
    }
}
