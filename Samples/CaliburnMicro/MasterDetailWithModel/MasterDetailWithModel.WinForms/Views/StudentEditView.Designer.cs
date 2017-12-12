namespace MasterDetailWithModel.Views
{
    partial class StudentEditView
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.create = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.close = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.model_StudentId = new System.Windows.Forms.Label();
            this.model_FullName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.model_FirstName = new System.Windows.Forms.TextBox();
            this.model_FamilyName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.model_StreetAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.model_TownAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.model_CountryAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.create,
            this.save,
            this.delete,
            this.close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // create
            // 
            this.create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.create.Image = global::MasterDetailWithModel.Properties.Resources.AddNew16;
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(23, 22);
            this.create.Text = "New Student";
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::MasterDetailWithModel.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save";
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = global::MasterDetailWithModel.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "Delete";
            // 
            // close
            // 
            this.close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.close.Image = global::MasterDetailWithModel.Properties.Resources.Close16;
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 22);
            this.close.Text = "Close form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // model_StudentId
            // 
            this.model_StudentId.AutoSize = true;
            this.model_StudentId.Location = new System.Drawing.Point(74, 60);
            this.model_StudentId.Name = "model_StudentId";
            this.model_StudentId.Size = new System.Drawing.Size(0, 13);
            this.model_StudentId.TabIndex = 2;
            // 
            // model_FullName
            // 
            this.model_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model_FullName.Location = new System.Drawing.Point(250, 60);
            this.model_FullName.Name = "model_FullName";
            this.model_FullName.Size = new System.Drawing.Size(200, 13);
            this.model_FullName.TabIndex = 13;
            this.model_FullName.Text = "model_FullName";
            this.model_FullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // model_FirstName
            // 
            this.model_FirstName.Location = new System.Drawing.Point(116, 98);
            this.model_FirstName.Name = "model_FirstName";
            this.model_FirstName.Size = new System.Drawing.Size(334, 20);
            this.model_FirstName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.model_FirstName, "Can\'t be empty.");
            // 
            // model_FamilyName
            // 
            this.model_FamilyName.Location = new System.Drawing.Point(116, 148);
            this.model_FamilyName.Name = "model_FamilyName";
            this.model_FamilyName.Size = new System.Drawing.Size(334, 20);
            this.model_FamilyName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.model_FamilyName, "Can\'t be empty.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Family Name";
            // 
            // model_StreetAddress
            // 
            this.model_StreetAddress.Location = new System.Drawing.Point(116, 198);
            this.model_StreetAddress.Name = "model_StreetAddress";
            this.model_StreetAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StreetAddress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Street Address";
            // 
            // model_TownAddress
            // 
            this.model_TownAddress.Location = new System.Drawing.Point(116, 248);
            this.model_TownAddress.Name = "model_TownAddress";
            this.model_TownAddress.Size = new System.Drawing.Size(334, 20);
            this.model_TownAddress.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Town Address";
            // 
            // model_CountryAddress
            // 
            this.model_CountryAddress.Location = new System.Drawing.Point(116, 298);
            this.model_CountryAddress.Name = "model_CountryAddress";
            this.model_CountryAddress.Size = new System.Drawing.Size(334, 20);
            this.model_CountryAddress.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Country Address";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip1.ToolTipTitle = "Business Rule";
            // 
            // StudentEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.model_CountryAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.model_TownAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.model_StreetAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.model_FamilyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.model_FirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.model_FullName);
            this.Controls.Add(this.model_StudentId);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "StudentEditView";
            this.Size = new System.Drawing.Size(994, 625);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton create;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label model_StudentId;
        private System.Windows.Forms.Label model_FullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox model_FirstName;
        private System.Windows.Forms.TextBox model_FamilyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox model_StreetAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox model_TownAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox model_CountryAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
