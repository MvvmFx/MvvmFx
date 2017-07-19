namespace WisejTestBoundTreeView
{
    partial class SyncedLists
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new Wisej.Web.DataGridView();
            this.docTypeListBindingSource = new Wisej.Web.BindingSource(this.components);
            this.dgvButtonModel = new Wisej.Web.Button();
            this.dgvTextboxModel = new Wisej.Web.TextBox();
            this.dgvTextboxView = new Wisej.Web.TextBox();
            this.dgvButtonView = new Wisej.Web.Button();
            this.listBox1 = new Wisej.Web.ListBox();
            this.lbButtonView = new Wisej.Web.Button();
            this.lbTextboxView = new Wisej.Web.TextBox();
            this.lbTextboxModel = new Wisej.Web.TextBox();
            this.lbButtonModel = new Wisej.Web.Button();
            this.lvButtonView = new Wisej.Web.Button();
            this.lvTextboxView = new Wisej.Web.TextBox();
            this.lvTextboxModel = new Wisej.Web.TextBox();
            this.lvButtonModel = new Wisej.Web.Button();
            this.boundListView1 = new MvvmFx.WisejWeb.BoundListView();
            this.tvButtonView = new Wisej.Web.Button();
            this.tvTextboxView = new Wisej.Web.TextBox();
            this.tvTextboxModel = new Wisej.Web.TextBox();
            this.tvButtonModel = new Wisej.Web.Button();
            this.boundTreeView1 = new MvvmFx.WisejWeb.BoundTreeView();
            this.label1 = new Wisej.Web.Label();
            this.docTypeName = new Wisej.Web.Label();
            this.queryObjectButton = new Wisej.Web.Button();
            this.dragDropStatusLabel = new Wisej.Web.Label();
            this.docTypeID = new Wisej.Web.Label();
            this.label3 = new Wisej.Web.Label();
            this.docTypeParentID = new Wisej.Web.Label();
            this.label5 = new Wisej.Web.Label();
            this.docTypeIDDataGridViewTextBoxColumn = new Wisej.Web.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new Wisej.Web.DataGridViewTextBoxColumn();
            this.sortButton = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTypeListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = Wisej.Web.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new Wisej.Web.DataGridViewColumn[] {
            this.docTypeIDDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.docTypeListBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(208, 204);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new Wisej.Web.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // docTypeListBindingSource
            // 
            this.docTypeListBindingSource.DataSource = typeof(BoundControls.Business.DocTypeEditColl);
            // 
            // dgvButtonModel
            // 
            this.dgvButtonModel.Location = new System.Drawing.Point(134, 224);
            this.dgvButtonModel.Name = "dgvButtonModel";
            this.dgvButtonModel.Size = new System.Drawing.Size(86, 23);
            this.dgvButtonModel.TabIndex = 1;
            this.dgvButtonModel.Text = "Set Model";
            this.dgvButtonModel.Click += new System.EventHandler(this.dgvButtonModel_Click);
            // 
            // dgvTextboxModel
            // 
            this.dgvTextboxModel.Location = new System.Drawing.Point(13, 226);
            this.dgvTextboxModel.Name = "dgvTextboxModel";
            this.dgvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.dgvTextboxModel.TabIndex = 2;
            // 
            // dgvTextboxView
            // 
            this.dgvTextboxView.Location = new System.Drawing.Point(13, 255);
            this.dgvTextboxView.Name = "dgvTextboxView";
            this.dgvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.dgvTextboxView.TabIndex = 3;
            // 
            // dgvButtonView
            // 
            this.dgvButtonView.Location = new System.Drawing.Point(134, 253);
            this.dgvButtonView.Name = "dgvButtonView";
            this.dgvButtonView.Size = new System.Drawing.Size(86, 23);
            this.dgvButtonView.TabIndex = 4;
            this.dgvButtonView.Text = "Set View";
            this.dgvButtonView.Click += new System.EventHandler(this.dgvButtonView_Click);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.docTypeListBindingSource;
            this.listBox1.DisplayMember = "DocTypeName";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(241, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(212, 199);
            this.listBox1.TabIndex = 5;
            this.listBox1.ValueMember = "DocTypeID";
            // 
            // lbButtonView
            // 
            this.lbButtonView.Location = new System.Drawing.Point(364, 253);
            this.lbButtonView.Name = "lbButtonView";
            this.lbButtonView.Size = new System.Drawing.Size(84, 23);
            this.lbButtonView.TabIndex = 9;
            this.lbButtonView.Text = "Set View";
            this.lbButtonView.Click += new System.EventHandler(this.lbButtonView_Click);
            // 
            // lbTextboxView
            // 
            this.lbTextboxView.Location = new System.Drawing.Point(241, 255);
            this.lbTextboxView.Name = "lbTextboxView";
            this.lbTextboxView.Size = new System.Drawing.Size(100, 20);
            this.lbTextboxView.TabIndex = 8;
            // 
            // lbTextboxModel
            // 
            this.lbTextboxModel.Location = new System.Drawing.Point(241, 226);
            this.lbTextboxModel.Name = "lbTextboxModel";
            this.lbTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.lbTextboxModel.TabIndex = 7;
            // 
            // lbButtonModel
            // 
            this.lbButtonModel.Location = new System.Drawing.Point(364, 224);
            this.lbButtonModel.Name = "lbButtonModel";
            this.lbButtonModel.Size = new System.Drawing.Size(84, 23);
            this.lbButtonModel.TabIndex = 6;
            this.lbButtonModel.Text = "Set Model";
            this.lbButtonModel.Click += new System.EventHandler(this.lbButtonModel_Click);
            // 
            // lvButtonView
            // 
            this.lvButtonView.Location = new System.Drawing.Point(596, 253);
            this.lvButtonView.Name = "lvButtonView";
            this.lvButtonView.Size = new System.Drawing.Size(84, 23);
            this.lvButtonView.TabIndex = 14;
            this.lvButtonView.Text = "Set View";
            this.lvButtonView.Click += new System.EventHandler(this.lvButtonView_Click);
            // 
            // lvTextboxView
            // 
            this.lvTextboxView.Location = new System.Drawing.Point(473, 255);
            this.lvTextboxView.Name = "lvTextboxView";
            this.lvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.lvTextboxView.TabIndex = 13;
            // 
            // lvTextboxModel
            // 
            this.lvTextboxModel.Location = new System.Drawing.Point(473, 226);
            this.lvTextboxModel.Name = "lvTextboxModel";
            this.lvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.lvTextboxModel.TabIndex = 12;
            // 
            // lvButtonModel
            // 
            this.lvButtonModel.Location = new System.Drawing.Point(596, 224);
            this.lvButtonModel.Name = "lvButtonModel";
            this.lvButtonModel.Size = new System.Drawing.Size(84, 23);
            this.lvButtonModel.TabIndex = 11;
            this.lvButtonModel.Text = "Set Model";
            this.lvButtonModel.Click += new System.EventHandler(this.lvButtonModel_Click);
            // 
            // boundListView1
            // 
            this.boundListView1.DataSource = this.docTypeListBindingSource;
            //this.boundListView1.FullRowSelect = true;
            //this.boundListView1.HideSelection = false;
            this.boundListView1.LabelEdit = true;
            this.boundListView1.Location = new System.Drawing.Point(473, 13);
            this.boundListView1.MultiSelect = false;
            this.boundListView1.Name = "boundListView1";
            this.boundListView1.Size = new System.Drawing.Size(212, 199);
            this.boundListView1.TabIndex = 10;
            this.boundListView1.View = Wisej.Web.View.Details;
            //this.boundListView1.AfterLabelEdit += new Wisej.Web.LabelEditEventHandler(this.boundListView1_AfterLabelEdit);
            // 
            // tvButtonView
            // 
            this.tvButtonView.Location = new System.Drawing.Point(828, 253);
            this.tvButtonView.Name = "tvButtonView";
            this.tvButtonView.Size = new System.Drawing.Size(84, 23);
            this.tvButtonView.TabIndex = 19;
            this.tvButtonView.Text = "Set View";
            this.tvButtonView.Click += new System.EventHandler(this.tvButtonView_Click);
            // 
            // tvTextboxView
            // 
            this.tvTextboxView.Location = new System.Drawing.Point(705, 255);
            this.tvTextboxView.Name = "tvTextboxView";
            this.tvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.tvTextboxView.TabIndex = 18;
            // 
            // tvTextboxModel
            // 
            this.tvTextboxModel.Location = new System.Drawing.Point(705, 226);
            this.tvTextboxModel.Name = "tvTextboxModel";
            this.tvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.tvTextboxModel.TabIndex = 17;
            // 
            // tvButtonModel
            // 
            this.tvButtonModel.Location = new System.Drawing.Point(828, 224);
            this.tvButtonModel.Name = "tvButtonModel";
            this.tvButtonModel.Size = new System.Drawing.Size(84, 23);
            this.tvButtonModel.TabIndex = 16;
            this.tvButtonModel.Text = "Set Model";
            this.tvButtonModel.Click += new System.EventHandler(this.tvButtonModel_Click);
            // 
            // boundTreeView1
            // 
            this.boundTreeView1.AllowDrop = true;
            this.boundTreeView1.DataSource = this.docTypeListBindingSource;
            this.boundTreeView1.DisplayMember = "DocTypeName";
            this.boundTreeView1.IdentifierMember = "DocTypeID";
            this.boundTreeView1.LabelEdit = true;
            this.boundTreeView1.Location = new System.Drawing.Point(705, 13);
            this.boundTreeView1.Name = "boundTreeView1";
            this.boundTreeView1.ParentIdentifierMember = "DocTypeParentID";
            this.boundTreeView1.Size = new System.Drawing.Size(212, 199);
            this.boundTreeView1.Sorted = false;
            this.boundTreeView1.TabIndex = 15;
            this.boundTreeView1.ValueMember = "DocTypeID";
            this.boundTreeView1.AfterLabelEdit += new Wisej.Web.NodeLabelEditEventHandler(this.boundTreeView1_AfterLabelEdit);
            this.boundTreeView1.DragDrop += new Wisej.Web.DragEventHandler(this.boundTreeView1_DragDrop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "DocTypeName:";
            // 
            // docTypeName
            // 
            this.docTypeName.Location = new System.Drawing.Point(131, 291);
            this.docTypeName.Name = "docTypeName";
            this.docTypeName.Size = new System.Drawing.Size(100, 13);
            this.docTypeName.TabIndex = 21;
            this.docTypeName.Text = "DocTypeName";
            // 
            // queryObjectButton
            // 
            this.queryObjectButton.Location = new System.Drawing.Point(16, 319);
            this.queryObjectButton.Name = "queryObjectButton";
            this.queryObjectButton.Size = new System.Drawing.Size(75, 23);
            this.queryObjectButton.TabIndex = 22;
            this.queryObjectButton.Text = "Query object";
            this.queryObjectButton.Click += new System.EventHandler(this.queryObjectButton_Click);
            // 
            // dragDropStatusLabel
            // 
            this.dragDropStatusLabel.Location = new System.Drawing.Point(13, 364);
            this.dragDropStatusLabel.Name = "dragDropStatusLabel";
            this.dragDropStatusLabel.Size = new System.Drawing.Size(200, 13);
            this.dragDropStatusLabel.TabIndex = 28;
            this.dragDropStatusLabel.Text = "Current Drag&&Drop Status";
            // 
            // docTypeID
            // 
            this.docTypeID.Location = new System.Drawing.Point(361, 291);
            this.docTypeID.Name = "docTypeID";
            this.docTypeID.Size = new System.Drawing.Size(100, 13);
            this.docTypeID.TabIndex = 30;
            this.docTypeID.Text = "DocTypeID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "DocTypeID:";
            // 
            // docTypeParentID
            // 
            this.docTypeParentID.Location = new System.Drawing.Point(593, 291);
            this.docTypeParentID.Name = "docTypeParentID";
            this.docTypeParentID.Size = new System.Drawing.Size(100, 13);
            this.docTypeParentID.TabIndex = 32;
            this.docTypeParentID.Text = "DocTypeParentID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DocTypeParentID:";
            // 
            // docTypeIDDataGridViewTextBoxColumn
            // 
            this.docTypeIDDataGridViewTextBoxColumn.AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.docTypeIDDataGridViewTextBoxColumn.DataPropertyName = "DocTypeID";
            this.docTypeIDDataGridViewTextBoxColumn.HeaderText = "DocTypeID";
            this.docTypeIDDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.docTypeIDDataGridViewTextBoxColumn.Name = "docTypeIDDataGridViewTextBoxColumn";
            this.docTypeIDDataGridViewTextBoxColumn.Width = 87;
            this.docTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.Fill;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "DocTypeName";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "DocTypeName";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(828, 282);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(84, 23);
            this.sortButton.TabIndex = 33;
            this.sortButton.Text = "Sort";
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.docTypeParentID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.docTypeID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dragDropStatusLabel);
            this.Controls.Add(this.queryObjectButton);
            this.Controls.Add(this.docTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvButtonView);
            this.Controls.Add(this.tvTextboxView);
            this.Controls.Add(this.tvTextboxModel);
            this.Controls.Add(this.tvButtonModel);
            this.Controls.Add(this.boundTreeView1);
            this.Controls.Add(this.lvButtonView);
            this.Controls.Add(this.lvTextboxView);
            this.Controls.Add(this.lvTextboxModel);
            this.Controls.Add(this.lvButtonModel);
            this.Controls.Add(this.boundListView1);
            this.Controls.Add(this.lbButtonView);
            this.Controls.Add(this.lbTextboxView);
            this.Controls.Add(this.lbTextboxModel);
            this.Controls.Add(this.lbButtonModel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dgvButtonView);
            this.Controls.Add(this.dgvTextboxView);
            this.Controls.Add(this.dgvTextboxModel);
            this.Controls.Add(this.dgvButtonModel);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(931, 425);
            this.MinimumSize = new System.Drawing.Size(931, 425);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docTypeListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridView1;
        private Wisej.Web.Button dgvButtonModel;
        private Wisej.Web.TextBox dgvTextboxModel;
        private Wisej.Web.TextBox dgvTextboxView;
        private Wisej.Web.Button dgvButtonView;
        private Wisej.Web.ListBox listBox1;
        private Wisej.Web.Button lbButtonView;
        private Wisej.Web.TextBox lbTextboxView;
        private Wisej.Web.TextBox lbTextboxModel;
        private Wisej.Web.Button lbButtonModel;
        private Wisej.Web.BindingSource docTypeListBindingSource;
        private Wisej.Web.Button lvButtonView;
        private Wisej.Web.TextBox lvTextboxView;
        private Wisej.Web.TextBox lvTextboxModel;
        private Wisej.Web.Button lvButtonModel;
        private MvvmFx.WisejWeb.BoundListView boundListView1;
        private Wisej.Web.Button tvButtonView;
        private Wisej.Web.TextBox tvTextboxView;
        private Wisej.Web.TextBox tvTextboxModel;
        private Wisej.Web.Button tvButtonModel;
        private MvvmFx.WisejWeb.BoundTreeView boundTreeView1;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label docTypeName;
        private Wisej.Web.Button queryObjectButton;
        private Wisej.Web.Label dragDropStatusLabel;
        private Wisej.Web.Label docTypeID;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label docTypeParentID;
        private Wisej.Web.Label label5;
        private Wisej.Web.DataGridViewTextBoxColumn docTypeIDDataGridViewTextBoxColumn;
        private Wisej.Web.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private Wisej.Web.Button sortButton;
    }
}