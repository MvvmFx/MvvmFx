namespace MasterDetailWithModel.Views
{
    partial class StudentMasterDetailView
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
            this.displayName = new Wisej.Web.Label();
            this.listBox1 = new Wisej.Web.ListBox();
            this.studentEditPanel = new Wisej.Web.Panel();
            this.toolStrip1 = new Wisej.Web.ToolBar();
            this.createNew = new Wisej.Web.ToolBarButton();
            this.save = new Wisej.Web.ToolBarButton();
            this.delete = new Wisej.Web.ToolBarButton();
            this.close = new Wisej.Web.ToolBarButton();
            this.label1 = new Wisej.Web.Label();
            this.model_StudentEdit_StudentId = new Wisej.Web.Label();
            this.model_StudentEdit_FullName = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.model_StudentEdit_FirstName = new Wisej.Web.TextBox();
            this.label3 = new Wisej.Web.Label();
            this.model_StudentEdit_FamilyName = new Wisej.Web.TextBox();
            this.label4 = new Wisej.Web.Label();
            this.model_StudentEdit_StreetAddress = new Wisej.Web.TextBox();
            this.label5 = new Wisej.Web.Label();
            this.model_StudentEdit_TownAddress = new Wisej.Web.TextBox();
            this.label6 = new Wisej.Web.Label();
            this.model_StudentEdit_CountryAddress = new Wisej.Web.TextBox();
            this.toolTip1 = new Wisej.Web.ToolTip(this.components);
            this.studentEditPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Location = new System.Drawing.Point(4, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(0, 13);
            this.displayName.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom)
           | Wisej.Web.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 628);
            this.listBox1.TabIndex = 0;
            // 
            // studentEditPanel
            // 
            this.studentEditPanel.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.studentEditPanel.AutoScroll = true;
            this.studentEditPanel.AutoScrollMinSize = new System.Drawing.Size(470, 350);
            this.studentEditPanel.Controls.Add(this.toolStrip1);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_CountryAddress);
            this.studentEditPanel.Controls.Add(this.label6);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_TownAddress);
            this.studentEditPanel.Controls.Add(this.label5);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_StreetAddress);
            this.studentEditPanel.Controls.Add(this.label4);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_FamilyName);
            this.studentEditPanel.Controls.Add(this.label3);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_FirstName);
            this.studentEditPanel.Controls.Add(this.label2);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_FullName);
            this.studentEditPanel.Controls.Add(this.model_StudentEdit_StudentId);
            this.studentEditPanel.Controls.Add(this.label1);
            this.studentEditPanel.Location = new System.Drawing.Point(354, 26);
            this.studentEditPanel.Name = "studentEditPanel";
            this.studentEditPanel.Size = new System.Drawing.Size(994, 625);
            this.studentEditPanel.TabIndex = 2;
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
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createNew
            // 
            this.createNew.Image = global::MasterDetailWithModel.Properties.Resources.AddNew16;
            this.createNew.Name = "createNew";
            this.createNew.Text = "Create New";
            // 
            // save
            // 
            this.save.Image = global::MasterDetailWithModel.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.Text = "Save";
            // 
            // delete
            // 
            this.delete.Image = global::MasterDetailWithModel.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.Text = "Delete";
            // 
            // close
            // 
            this.close.Image = global::MasterDetailWithModel.Properties.Resources.Close16;
            this.close.Name = "close";
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
            // model_StudentEdit_StudentId
            // 
            this.model_StudentEdit_StudentId.AutoSize = true;
            this.model_StudentEdit_StudentId.Location = new System.Drawing.Point(74, 60);
            this.model_StudentEdit_StudentId.Name = "model_StudentEdit_StudentId";
            this.model_StudentEdit_StudentId.Size = new System.Drawing.Size(0, 13);
            this.model_StudentEdit_StudentId.TabIndex = 2;
            // 
            // model_StudentEdit_FullName
            // 
            this.model_StudentEdit_FullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.model_StudentEdit_FullName.Location = new System.Drawing.Point(250, 60);
            this.model_StudentEdit_FullName.Name = "model_StudentEdit_FullName";
            this.model_StudentEdit_FullName.Size = new System.Drawing.Size(200, 13);
            this.model_StudentEdit_FullName.TabIndex = 13;
            this.model_StudentEdit_FullName.Text = "";
            this.model_StudentEdit_FullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // model_StudentEdit_FirstName
            // 
            this.model_StudentEdit_FirstName.Location = new System.Drawing.Point(116, 98);
            this.model_StudentEdit_FirstName.Name = "model_StudentEdit_FirstName";
            this.model_StudentEdit_FirstName.Size = new System.Drawing.Size(334, 20);
            this.model_StudentEdit_FirstName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.model_StudentEdit_FirstName, "Can\'t be empty.");
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
            // model_StudentEdit_FamilyName
            // 
            this.model_StudentEdit_FamilyName.Location = new System.Drawing.Point(116, 148);
            this.model_StudentEdit_FamilyName.Name = "model_StudentEdit_FamilyName";
            this.model_StudentEdit_FamilyName.Size = new System.Drawing.Size(334, 20);
            this.model_StudentEdit_FamilyName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.model_StudentEdit_FamilyName, "Can\'t be empty.");
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
            // model_StudentEdit_StreetAddress
            // 
            this.model_StudentEdit_StreetAddress.Location = new System.Drawing.Point(116, 198);
            this.model_StudentEdit_StreetAddress.Name = "model_StudentEdit_StreetAddress";
            this.model_StudentEdit_StreetAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StudentEdit_StreetAddress.TabIndex = 8;
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
            // model_StudentEdit_TownAddress
            // 
            this.model_StudentEdit_TownAddress.Location = new System.Drawing.Point(116, 248);
            this.model_StudentEdit_TownAddress.Name = "model_StudentEdit_TownAddress";
            this.model_StudentEdit_TownAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StudentEdit_TownAddress.TabIndex = 10;
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
            // model_StudentEdit_CountryAddress
            // 
            this.model_StudentEdit_CountryAddress.Location = new System.Drawing.Point(116, 298);
            this.model_StudentEdit_CountryAddress.Name = "model_StudentEdit_CountryAddress";
            this.model_StudentEdit_CountryAddress.Size = new System.Drawing.Size(334, 20);
            this.model_StudentEdit_CountryAddress.TabIndex = 12;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = Wisej.Web.ToolTipIcon.Warning;
            this.toolTip1.SetToolTip(this, "Business Rule");
            // 
            // StudentMasterDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.studentEditPanel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.displayName);
            this.Name = "StudentMasterDetailView";
            this.Size = new System.Drawing.Size(1348, 654);
            this.studentEditPanel.ResumeLayout(false);
            this.studentEditPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label displayName;
        private Wisej.Web.ListBox listBox1;
        private Wisej.Web.Panel studentEditPanel;
        private Wisej.Web.ToolBar toolStrip1;
        private Wisej.Web.ToolBarButton createNew;
        private Wisej.Web.ToolBarButton save;
        private Wisej.Web.ToolBarButton delete;
        private Wisej.Web.ToolBarButton close;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label model_StudentEdit_StudentId;
        private Wisej.Web.Label model_StudentEdit_FullName;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox model_StudentEdit_FirstName;
        private Wisej.Web.Label label3;
        private Wisej.Web.TextBox model_StudentEdit_FamilyName;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox model_StudentEdit_StreetAddress;
        private Wisej.Web.Label label5;
        private Wisej.Web.TextBox model_StudentEdit_TownAddress;
        private Wisej.Web.Label label6;
        private Wisej.Web.TextBox model_StudentEdit_CountryAddress;
        private Wisej.Web.ToolTip toolTip1;
    }
}
