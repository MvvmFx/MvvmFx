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

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Wisej.Web.DataGridViewCellStyle dataGridViewCellStyle = new Wisej.Web.DataGridViewCellStyle();
            this.foldersDataGridView = new Wisej.Web.DataGridView();
            this.FolderId = new Wisej.Web.DataGridViewTextBoxColumn();
            this.FolderName = new Wisej.Web.DataGridViewTextBoxColumn();
            this.DocumentCount = new Wisej.Web.DataGridViewTextBoxColumn();
            this.CreateDate = new Wisej.Web.DataGridViewTextBoxColumn();
            this.ChangeDate = new Wisej.Web.DataGridViewTextBoxColumn();
            this.buttonPanel = new Wisej.Web.Panel();
            this.close = new Wisej.Web.Button();
            this.save = new Wisej.Web.Button();
            this.validate = new Wisej.Web.Button();
            this.cancel = new Wisej.Web.Button();
            this.errorProvider = new Wisej.Web.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // foldersDataGridView
            // 
            this.foldersDataGridView.AllowUserToAddRows = true;
            this.foldersDataGridView.AllowUserToDeleteRows = true;
            this.foldersDataGridView.AllowUserToResizeRows = false;
            this.foldersDataGridView.ColumnHeadersHeightSizeMode = Wisej.Web.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foldersDataGridView.Columns.AddRange(new Wisej.Web.DataGridViewColumn[] {
            this.FolderId,
            this.FolderName,
            this.DocumentCount,
            this.CreateDate,
            this.ChangeDate});
            this.foldersDataGridView.Dock = Wisej.Web.DockStyle.Top;
            this.foldersDataGridView.KeepSameRowHeight = true;
            this.foldersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.foldersDataGridView.MultiSelect = false;
            this.foldersDataGridView.Name = "foldersDataGridView";
            this.foldersDataGridView.ReadOnly = false;
            this.foldersDataGridView.ShowColumnVisibilityMenu = false;
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
            this.FolderName.AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.Fill;
            this.FolderName.DataPropertyName = "FolderName";
            this.FolderName.HeaderText = "Name";
            this.FolderName.Name = "FolderName";
            // 
            // DocumentCount
            // 
            this.DocumentCount.DataPropertyName = "DocumentCount";
            dataGridViewCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;
            this.DocumentCount.DefaultCellStyle = dataGridViewCellStyle;
            this.DocumentCount.HeaderText = "Documents";
            this.DocumentCount.Name = "DocumentCount";
            this.DocumentCount.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle;
            this.CreateDate.HeaderText = "Created Date";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // ChangeDate
            // 
            this.ChangeDate.DataPropertyName = "ChangeDate";
            this.ChangeDate.DefaultCellStyle = dataGridViewCellStyle;
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
            this.buttonPanel.Dock = Wisej.Web.DockStyle.Fill;
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
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(481, 13);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(137, 14);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(75, 23);
            this.validate.TabIndex = 2;
            this.validate.Text = "Validate";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(26, 14);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Undo";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FolderListEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 380);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.foldersDataGridView);
            this.Name = "FolderListEditView";
            ((System.ComponentModel.ISupportInitialize)(this.foldersDataGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.DataGridView foldersDataGridView;
        private Wisej.Web.Panel buttonPanel;
        private Wisej.Web.Button close;
        private Wisej.Web.Button save;
        private Wisej.Web.Button cancel;
        private Wisej.Web.Button validate;
        private Wisej.Web.DataGridViewTextBoxColumn FolderId;
        private Wisej.Web.DataGridViewTextBoxColumn FolderName;
        private Wisej.Web.DataGridViewTextBoxColumn DocumentCount;
        private Wisej.Web.DataGridViewTextBoxColumn CreateDate;
        private Wisej.Web.DataGridViewTextBoxColumn ChangeDate;
        private Wisej.Web.ErrorProvider errorProvider;
    }
}