namespace BoundTreeView.Views
{
    partial class FamilyMemberEditView
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
            this.createNew = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.close = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteModeLabel = new System.Windows.Forms.ToolStripLabel();
            this.modelDeleteMode = new System.Windows.Forms.ToolStripComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.model_FamilyMemberId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.model_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modelGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.modelDateOfBirth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modelParentId = new System.Windows.Forms.TextBox();
            this.model_ParentName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNew,
            this.save,
            this.delete,
            this.close,
            this.toolStripSeparator1,
            this.deleteModeLabel,
            this.modelDeleteMode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createNew
            // 
            this.createNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createNew.Image = global::BoundTreeView.Properties.Resources.AddNew16;
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(23, 22);
            this.createNew.Text = "Create New";
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::BoundTreeView.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "Save";
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = global::BoundTreeView.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "Delete";
            // 
            // close
            // 
            this.close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.close.Image = global::BoundTreeView.Properties.Resources.Close16;
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 22);
            this.close.Text = "Close form";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteModeLabel
            // 
            this.deleteModeLabel.Name = "deleteModeLabel";
            this.deleteModeLabel.Size = new System.Drawing.Size(87, 22);
            this.deleteModeLabel.Text = "Delete Mode";
            // 
            // modelDeleteMode
            // 
            this.modelDeleteMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.modelDeleteMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.modelDeleteMode.Name = "modelDeleteMode";
            this.modelDeleteMode.Size = new System.Drawing.Size(150, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID";
            // 
            // model_FamilyMemberId
            // 
            this.model_FamilyMemberId.AutoSize = true;
            this.model_FamilyMemberId.Location = new System.Drawing.Point(116, 60);
            this.model_FamilyMemberId.Name = "model_FamilyMemberId";
            this.model_FamilyMemberId.Size = new System.Drawing.Size(0, 13);
            this.model_FamilyMemberId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // model_Name
            // 
            this.model_Name.Location = new System.Drawing.Point(116, 98);
            this.model_Name.Name = "model_Name";
            this.model_Name.Size = new System.Drawing.Size(334, 20);
            this.model_Name.TabIndex = 4;
            this.toolTip1.SetToolTip(this.model_Name, "Can\'t be empty.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gender";
            // 
            // modelGender
            // 
            this.modelGender.Location = new System.Drawing.Point(116, 148);
            this.modelGender.Name = "modelGender";
            this.modelGender.Size = new System.Drawing.Size(75, 20);
            this.modelGender.TabIndex = 6;
            this.toolTip1.SetToolTip(this.modelGender, "Can\'t be empty.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date of Birth";
            // 
            // modelDateOfBirth
            // 
            this.modelDateOfBirth.Location = new System.Drawing.Point(116, 198);
            this.modelDateOfBirth.Name = "modelDateOfBirth";
            this.modelDateOfBirth.Size = new System.Drawing.Size(75, 20);
            this.modelDateOfBirth.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parent";
            // 
            // modelParentId
            // 
            this.modelParentId.Location = new System.Drawing.Point(116, 248);
            this.modelParentId.Name = "modelParentId";
            this.modelParentId.Size = new System.Drawing.Size(30, 20);
            this.modelParentId.TabIndex = 10;
            // 
            // model_ParentName
            // 
            this.model_ParentName.Location = new System.Drawing.Point(166, 248);
            this.model_ParentName.Name = "model_ParentName";
            this.model_ParentName.ReadOnly = true;
            this.model_ParentName.Size = new System.Drawing.Size(284, 20);
            this.model_ParentName.TabIndex = 12;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip1.ToolTipTitle = "Business Rule";
            // 
            // FamilyMemberEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.model_ParentName);
            this.Controls.Add(this.modelParentId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modelDateOfBirth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modelGender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.model_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.model_FamilyMemberId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FamilyMemberEditView";
            this.Size = new System.Drawing.Size(994, 625);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton createNew;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label model_FamilyMemberId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox model_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox modelGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox modelDateOfBirth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modelParentId;
        private System.Windows.Forms.TextBox model_ParentName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel deleteModeLabel;
        private System.Windows.Forms.ToolStripComboBox modelDeleteMode;
    }
}
