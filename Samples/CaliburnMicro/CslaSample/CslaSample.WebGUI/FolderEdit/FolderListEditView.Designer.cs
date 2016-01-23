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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyleMiddleCenter = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
            this.foldersDataGridView = new Gizmox.WebGUI.Forms.DataGridView();
            this.buttonPanel = new Gizmox.WebGUI.Forms.Panel();
            this.close = new Gizmox.WebGUI.Forms.Button();
            this.save = new Gizmox.WebGUI.Forms.Button();
            this.validate = new Gizmox.WebGUI.Forms.Button();
            this.cancel = new Gizmox.WebGUI.Forms.Button();
            this.FolderId = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.FolderName = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.DocumentCount = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.ChangeDate = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // foldersDataGridView
            // 
            this.foldersDataGridView.AutoGenerateColumns = false;
            this.foldersDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foldersDataGridView.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.FolderId,
            this.FolderName,
            this.DocumentCount,
            this.CreateDate,
            this.ChangeDate});
            this.foldersDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.foldersDataGridView.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.foldersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.foldersDataGridView.Name = "foldersDataGridView";
            this.foldersDataGridView.Size = new System.Drawing.Size(738, 337);
            this.foldersDataGridView.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.close);
            this.buttonPanel.Controls.Add(this.save);
            this.buttonPanel.Controls.Add(this.validate);
            this.buttonPanel.Controls.Add(this.cancel);
            this.buttonPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 337);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(738, 43);
            this.buttonPanel.TabIndex = 2;
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.close.Location = new System.Drawing.Point(592, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.save.Location = new System.Drawing.Point(481, 13);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // validate
            // 
            this.validate.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.validate.Location = new System.Drawing.Point(137, 14);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(75, 23);
            this.validate.TabIndex = 2;
            this.validate.Text = "Validate";
            this.validate.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.cancel.Location = new System.Drawing.Point(26, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Undo";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // FolderId
            // 
            this.FolderId.DataPropertyName = "FolderId";
            this.FolderId.HeaderText = "Id";
            this.FolderId.Name = "FolderId";
            this.FolderId.Visible = false;
            // 
            // FolderName
            // 
            this.FolderName.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FolderName.DataPropertyName = "FolderName";
            this.FolderName.HeaderText = "Name";
            this.FolderName.Name = "FolderName";
            // 
            // DocumentCount
            // 
            this.DocumentCount.DataPropertyName = "DocumentCount";
            dataGridViewCellStyleMiddleCenter.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DocumentCount.DefaultCellStyle = dataGridViewCellStyleMiddleCenter;
            this.DocumentCount.HeaderText = "Documents";
            this.DocumentCount.Name = "DocumentCount";
            this.DocumentCount.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            dataGridViewCellStyleMiddleCenter.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyleMiddleCenter;
            this.CreateDate.HeaderText = "Created Date";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // ChangeDate
            // 
            this.ChangeDate.DataPropertyName = "ChangeDate";
            dataGridViewCellStyleMiddleCenter.Alignment = Gizmox.WebGUI.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ChangeDate.DefaultCellStyle = dataGridViewCellStyleMiddleCenter;
            this.ChangeDate.HeaderText = "Changed Date";
            this.ChangeDate.Name = "ChangeDate";
            this.ChangeDate.Width = 80;
            // 
            // FolderListEditView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 380);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.foldersDataGridView);
            this.Name = "FolderListEditView";
            //this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView foldersDataGridView;
        private Gizmox.WebGUI.Forms.Panel buttonPanel;
        private Gizmox.WebGUI.Forms.Button close;
        private Gizmox.WebGUI.Forms.Button save;
        private Gizmox.WebGUI.Forms.Button cancel;
        private Gizmox.WebGUI.Forms.Button validate;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn FolderId;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn FolderName;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn DocumentCount;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn CreateDate;
        private Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn ChangeDate;
    }
}