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

        #region Visual WebGui UserControl Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEditView));
            this.toolStrip1 = new Gizmox.WebGUI.Forms.ToolStrip();
            this.createNew = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.save = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.delete = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.close = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.model_StudentId = new Gizmox.WebGUI.Forms.Label();
            this.model_FullName = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.model_FirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.model_FamilyName = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.model_StreetAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.model_TownAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.model_CountryAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip();
            //this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.createNew,
            this.save,
            this.delete,
            this.close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createNew
            // 
            this.createNew.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Image;
            this.createNew.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("createNew.Image"));
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(23, 22);
            this.createNew.Text = "Create New";
            // 
            // save
            // 
            this.save.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("save.Image"));
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save";
            // 
            // delete
            // 
            this.delete.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("delete.Image"));
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "Delete";
            // 
            // close
            // 
            this.close.Alignment = Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right;
            this.close.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Image;
            this.close.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("close.Image"));
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 22);
            this.close.Text = "Close form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // model_StudentId
            // 
            this.model_StudentId.AutoSize = true;
            this.model_StudentId.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_StudentId.Location = new System.Drawing.Point(74, 60);
            this.model_StudentId.Name = "model_StudentId";
            this.model_StudentId.Size = new System.Drawing.Size(0, 13);
            this.model_StudentId.TabIndex = 2;
            // 
            // model_FullName
            // 
            this.model_FullName.Font = new System.Drawing.Font("Tahoma", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model_FullName.Location = new System.Drawing.Point(250, 60);
            this.model_FullName.Name = "model_FullName";
            this.model_FullName.Size = new System.Drawing.Size(200, 14);
            this.model_FullName.TabIndex = 13;
            this.model_FullName.Text = "model_FullName";
            this.model_FullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // model_FirstName
            // 
            this.model_FirstName.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_FirstName.Location = new System.Drawing.Point(116, 98);
            this.model_FirstName.Name = "model_FirstName";
            this.model_FirstName.Size = new System.Drawing.Size(334, 20);
            this.model_FirstName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.model_FirstName, "Can\'t be empty.");
            // 
            // model_FamilyName
            // 
            this.model_FamilyName.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_FamilyName.Location = new System.Drawing.Point(116, 148);
            this.model_FamilyName.Name = "model_FamilyName";
            this.model_FamilyName.Size = new System.Drawing.Size(334, 20);
            this.model_FamilyName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.model_FamilyName, "Can\'t be empty.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Family Name";
            // 
            // model_StreetAddress
            // 
            this.model_StreetAddress.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_StreetAddress.Location = new System.Drawing.Point(116, 198);
            this.model_StreetAddress.Name = "model_StreetAddress";
            this.model_StreetAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StreetAddress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Street Address";
            // 
            // model_TownAddress
            // 
            this.model_TownAddress.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_TownAddress.Location = new System.Drawing.Point(116, 248);
            this.model_TownAddress.Name = "model_TownAddress";
            this.model_TownAddress.Size = new System.Drawing.Size(334, 20);
            this.model_TownAddress.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label5.Location = new System.Drawing.Point(15, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Town Address";
            // 
            // model_CountryAddress
            // 
            this.model_CountryAddress.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.model_CountryAddress.Location = new System.Drawing.Point(116, 298);
            this.model_CountryAddress.Name = "model_CountryAddress";
            this.model_CountryAddress.Size = new System.Drawing.Size(334, 20);
            this.model_CountryAddress.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.label6.Location = new System.Drawing.Point(15, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Country Address";
            // 
            // StudentEditView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
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
            //this.Name = "StudentEditView";
            this.Size = new System.Drawing.Size(994, 625);
            //this.toolStrip1.ResumeLayout(false);
            //this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            //this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolStrip toolStrip1;
        private Gizmox.WebGUI.Forms.ToolStripButton createNew;
        private Gizmox.WebGUI.Forms.ToolStripButton save;
        private Gizmox.WebGUI.Forms.ToolStripButton delete;
        private Gizmox.WebGUI.Forms.ToolStripButton close;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label model_StudentId;
        private Gizmox.WebGUI.Forms.Label model_FullName;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.TextBox model_FirstName;
        private Gizmox.WebGUI.Forms.TextBox model_FamilyName;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.TextBox model_StreetAddress;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.TextBox model_TownAddress;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.TextBox model_CountryAddress;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.ToolTip toolTip1;
    }
}
