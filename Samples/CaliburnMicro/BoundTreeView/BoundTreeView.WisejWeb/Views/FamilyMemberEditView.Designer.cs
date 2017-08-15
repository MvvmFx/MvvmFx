using Wisej.Web;

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
            this.toolStrip1 = new Wisej.Web.ToolBar();
            this.createNew = new Wisej.Web.ToolBarButton();
            this.save = new Wisej.Web.ToolBarButton();
            this.delete = new Wisej.Web.ToolBarButton();
            this.close = new Wisej.Web.ToolBarButton();
            this.toolStripSeparator1 = new Wisej.Web.ToolBarButton();
            this.deleteModeLabel = new Wisej.Web.ToolBarButton();
            this.modelDeleteMode = new Wisej.Web.ToolBarButton();
            this.label1 = new Wisej.Web.Label();
            this.model_FamilyMemberId = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.model_Name = new Wisej.Web.TextBox();
            this.label3 = new Wisej.Web.Label();
            this.modelGender = new Wisej.Web.ComboBox();
            this.label4 = new Wisej.Web.Label();
            this.modelDateOfBirth = new Wisej.Web.TextBox();
            this.label5 = new Wisej.Web.Label();
            this.modelParentId = new Wisej.Web.TextBox();
            this.model_ParentName = new Wisej.Web.TextBox();
            this.toolTip1 = new Wisej.Web.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.createNew,
            this.save,
            this.delete,
            this.close,
            this.toolStripSeparator1,
            this.deleteModeLabel,
            this.modelDeleteMode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(476, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = false;
            this.toolTip1.SetToolTip(this.toolStrip1, null);
            // 
            // createNew
            // 
            this.createNew.Image = global::BoundTreeView.Properties.Resources.AddNew16;
            this.createNew.Name = "createNew";
            this.createNew.ToolTipText = "Create New";
            // 
            // save
            // 
            this.save.Image = global::BoundTreeView.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.ToolTipText = "Save";
            // 
            // delete
            // 
            this.delete.Image = global::BoundTreeView.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.ToolTipText = "Delete";
            // 
            // close
            // 
            this.close.Image = global::BoundTreeView.Properties.Resources.Close16;
            this.close.Name = "close";
            this.close.ToolTipText = "Close form";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Style = Wisej.Web.ToolBarButtonStyle.Separator;
            // 
            // deleteModeLabel
            // 
            this.deleteModeLabel.Name = "deleteModeLabel";
            this.deleteModeLabel.Text = "Delete Mode";
            // 
            // modelDeleteMode
            // 
            this.modelDeleteMode.Name = "modelDeleteMode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member ID";
            this.toolTip1.SetToolTip(this.label1, null);
            // 
            // model_FamilyMemberId
            // 
            this.model_FamilyMemberId.AutoSize = true;
            this.model_FamilyMemberId.Location = new System.Drawing.Point(116, 60);
            this.model_FamilyMemberId.Name = "model_FamilyMemberId";
            this.model_FamilyMemberId.Size = new System.Drawing.Size(4, 15);
            this.model_FamilyMemberId.TabIndex = 2;
            this.toolTip1.SetToolTip(this.model_FamilyMemberId, null);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            this.toolTip1.SetToolTip(this.label2, null);
            // 
            // model_Name
            // 
            this.model_Name.Location = new System.Drawing.Point(116, 98);
            this.model_Name.Name = "model_Name";
            this.model_Name.Size = new System.Drawing.Size(334, 20);
            this.model_Name.TabIndex = 4;
            this.toolTip1.SetToolTip(this.model_Name, "Business rule:\r\nCan\'t be empty.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gender";
            this.toolTip1.SetToolTip(this.label3, null);
            // 
            // modelGender
            // 
            this.modelGender.Location = new System.Drawing.Point(116, 148);
            this.modelGender.Name = "modelGender";
            this.modelGender.Size = new System.Drawing.Size(75, 20);
            this.modelGender.TabIndex = 6;
            this.toolTip1.SetToolTip(this.modelGender, "Business rule:\r\nCan\'t be empty.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date of Birth";
            this.toolTip1.SetToolTip(this.label4, null);
            // 
            // modelDateOfBirth
            // 
            this.modelDateOfBirth.Location = new System.Drawing.Point(116, 198);
            this.modelDateOfBirth.Name = "modelDateOfBirth";
            this.modelDateOfBirth.Size = new System.Drawing.Size(75, 20);
            this.modelDateOfBirth.TabIndex = 8;
            this.toolTip1.SetToolTip(this.modelDateOfBirth, null);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parent";
            this.toolTip1.SetToolTip(this.label5, null);
            // 
            // modelParentId
            // 
            this.modelParentId.Location = new System.Drawing.Point(116, 248);
            this.modelParentId.Name = "modelParentId";
            this.modelParentId.Size = new System.Drawing.Size(30, 20);
            this.modelParentId.TabIndex = 10;
            this.toolTip1.SetToolTip(this.modelParentId, null);
            // 
            // model_ParentName
            // 
            this.model_ParentName.Location = new System.Drawing.Point(166, 248);
            this.model_ParentName.Name = "model_ParentName";
            this.model_ParentName.ReadOnly = true;
            this.model_ParentName.Size = new System.Drawing.Size(284, 20);
            this.model_ParentName.TabIndex = 12;
            this.toolTip1.SetToolTip(this.model_ParentName, null);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = Wisej.Web.ToolTipIcon.Warning;
            // 
            // FamilyMemberEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
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
            this.Size = new System.Drawing.Size(476, 393);
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
        private Wisej.Web.Label model_FamilyMemberId;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox model_Name;
        private Wisej.Web.Label label3;
        private Wisej.Web.ComboBox modelGender;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox modelDateOfBirth;
        private Wisej.Web.Label label5;
        private Wisej.Web.TextBox modelParentId;
        private Wisej.Web.TextBox model_ParentName;
        private Wisej.Web.ToolTip toolTip1;
        private Wisej.Web.ToolBarButton toolStripSeparator1;
        private Wisej.Web.ToolBarButton deleteModeLabel;
        private Wisej.Web.ToolBarButton modelDeleteMode;
    }
}
