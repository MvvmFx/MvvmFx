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
            this.toolStrip1 = new Wisej.Web.ToolBar();
            this.createNew = new Wisej.Web.ToolBarButton();
            this.save = new Wisej.Web.ToolBarButton();
            this.delete = new Wisej.Web.ToolBarButton();
            this.close = new Wisej.Web.ToolBarButton();
            this.label1 = new Wisej.Web.Label();
            this.model_StudentId = new Wisej.Web.Label();
            this.model_FullName = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.model_FirstName = new Wisej.Web.TextBox();
            this.model_FamilyName = new Wisej.Web.TextBox();
            this.label3 = new Wisej.Web.Label();
            this.model_StreetAddress = new Wisej.Web.TextBox();
            this.label4 = new Wisej.Web.Label();
            this.model_TownAddress = new Wisej.Web.TextBox();
            this.label5 = new Wisej.Web.Label();
            this.model_CountryAddress = new Wisej.Web.TextBox();
            this.label6 = new Wisej.Web.Label();
            this.toolTip1 = new Wisej.Web.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.createNew,
            this.save,
            this.delete,
            this.close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(476, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = false;
            this.toolStrip1.Text = "toolStrip1";
            this.toolTip1.SetToolTip(this.toolStrip1, null);
            // 
            // createNew
            // 
            //this.createNew.DisplayStyle = Wisej.Web.ToolBarItemDisplayStyle.Image;
            this.createNew.Image = global::MasterDetailWithModel.Properties.Resources.AddNew16;
            this.createNew.Name = "createNew";
            this.createNew.Text = "Create New";
            // 
            // save
            // 
            //this.save.DisplayStyle = Wisej.Web.ToolBarItemDisplayStyle.Image;
            this.save.Image = global::MasterDetailWithModel.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.Text = "Save";
            // 
            // delete
            // 
            //this.delete.DisplayStyle = Wisej.Web.ToolBarItemDisplayStyle.Image;
            this.delete.Image = global::MasterDetailWithModel.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.Text = "Delete";
            // 
            // close
            // 
            //this.close.Alignment = Wisej.Web.ToolBarItemAlignment.Right;
            //this.close.DisplayStyle = Wisej.Web.ToolBarItemDisplayStyle.Image;
            this.close.Image = global::MasterDetailWithModel.Properties.Resources.Close16;
            this.close.Name = "close";
            this.close.Text = "Close form";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            this.toolTip1.SetToolTip(this.label1, null);
            // 
            // model_StudentId
            // 
            this.model_StudentId.AutoSize = true;
            this.model_StudentId.Location = new System.Drawing.Point(74, 60);
            this.model_StudentId.Name = "model_StudentId";
            this.model_StudentId.Size = new System.Drawing.Size(4, 15);
            this.model_StudentId.TabIndex = 2;
            this.toolTip1.SetToolTip(this.model_StudentId, null);
            // 
            // model_FullName
            // 
            this.model_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.model_FullName.Location = new System.Drawing.Point(250, 60);
            this.model_FullName.Name = "model_FullName";
            this.model_FullName.Size = new System.Drawing.Size(200, 13);
            this.model_FullName.TabIndex = 13;
            this.model_FullName.Text = "model_FullName";
            this.model_FullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.model_FullName, null);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            this.toolTip1.SetToolTip(this.label2, null);
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
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Family Name";
            this.toolTip1.SetToolTip(this.label3, null);
            // 
            // model_StreetAddress
            // 
            this.model_StreetAddress.Location = new System.Drawing.Point(116, 198);
            this.model_StreetAddress.Name = "model_StreetAddress";
            this.model_StreetAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StreetAddress.TabIndex = 8;
            this.toolTip1.SetToolTip(this.model_StreetAddress, null);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Street Address";
            this.toolTip1.SetToolTip(this.label4, null);
            // 
            // model_TownAddress
            // 
            this.model_TownAddress.Location = new System.Drawing.Point(116, 248);
            this.model_TownAddress.Name = "model_TownAddress";
            this.model_TownAddress.Size = new System.Drawing.Size(334, 20);
            this.model_TownAddress.TabIndex = 10;
            this.toolTip1.SetToolTip(this.model_TownAddress, null);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Town Address";
            this.toolTip1.SetToolTip(this.label5, null);
            // 
            // model_CountryAddress
            // 
            this.model_CountryAddress.Location = new System.Drawing.Point(116, 298);
            this.model_CountryAddress.Name = "model_CountryAddress";
            this.model_CountryAddress.Size = new System.Drawing.Size(334, 20);
            this.model_CountryAddress.TabIndex = 12;
            this.toolTip1.SetToolTip(this.model_CountryAddress, null);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Country Address";
            this.toolTip1.SetToolTip(this.label6, null);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = Wisej.Web.ToolTipIcon.Warning;
            // 
            // StudentEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
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
            this.Size = new System.Drawing.Size(476, 422);
            this.toolTip1.SetToolTip(this, "Business Rule");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.ToolBar toolStrip1;
        private Wisej.Web.ToolBarButton createNew;
        private Wisej.Web.ToolBarButton save;
        private Wisej.Web.ToolBarButton delete;
        private Wisej.Web.ToolBarButton close;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label model_StudentId;
        private Wisej.Web.Label model_FullName;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox model_FirstName;
        private Wisej.Web.TextBox model_FamilyName;
        private Wisej.Web.Label label3;
        private Wisej.Web.TextBox model_StreetAddress;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox model_TownAddress;
        private Wisej.Web.Label label5;
        private Wisej.Web.TextBox model_CountryAddress;
        private Wisej.Web.Label label6;
        private Wisej.Web.ToolTip toolTip1;
    }
}
