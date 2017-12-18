namespace CslaSample.FolderEdit
{
    partial class FolderListEditView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.foldersDataGridView = new System.Windows.Forms.DataGridView();
            this.FolderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.validate = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldersDataGridView
            // 
            this.foldersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foldersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolderId,
            this.FolderName,
            this.DocumentCount,
            this.CreateDate,
            this.ChangeDate});
            this.foldersDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.foldersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.foldersDataGridView.Name = "foldersDataGridView";
            this.foldersDataGridView.Size = new System.Drawing.Size(738, 337);
            this.foldersDataGridView.TabIndex = 0;
            // 
            // FolderId
            // 
            this.FolderId.DataPropertyName = "FolderId";
            this.FolderId.HeaderText = "Id";
            this.FolderId.Name = "FolderId";
            this.FolderId.Visible = false;
            this.FolderId.Width = 80;
            // 
            // FolderName
            // 
            this.FolderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FolderName.DataPropertyName = "FolderName";
            this.FolderName.HeaderText = "Name";
            this.FolderName.Name = "FolderName";
            // 
            // DocumentCount
            // 
            this.DocumentCount.DataPropertyName = "DocumentCount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DocumentCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.DocumentCount.HeaderText = "Documents";
            this.DocumentCount.Name = "DocumentCount";
            this.DocumentCount.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreateDate.HeaderText = "Created Date";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // ChangeDate
            // 
            this.ChangeDate.DataPropertyName = "ChangeDate";
            this.ChangeDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChangeDate.HeaderText = "Changed Date";
            this.ChangeDate.Name = "ChangeDate";
            this.ChangeDate.Width = 80;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.close);
            this.buttonPanel.Controls.Add(this.save);
            this.buttonPanel.Controls.Add(this.validate);
            this.buttonPanel.Controls.Add(this.cancel);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 337);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(738, 43);
            this.buttonPanel.TabIndex = 2;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(592, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(481, 13);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(137, 14);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(75, 23);
            this.validate.TabIndex = 2;
            this.validate.Text = "Validate";
            this.validate.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(26, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Undo";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // FolderListEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 380);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.foldersDataGridView);
            this.Name = "FolderListEditView";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView foldersDataGridView;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button validate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeDate;
    }
}