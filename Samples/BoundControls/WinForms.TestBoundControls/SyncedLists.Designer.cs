namespace WinForms.TestBoundControls
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
            LeafList.ListChanged -= LeafList_ListChanged;
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.leafIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leafNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leafListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvButtonModel = new System.Windows.Forms.Button();
            this.dgvTextboxModel = new System.Windows.Forms.TextBox();
            this.dgvTextboxView = new System.Windows.Forms.TextBox();
            this.dgvButtonView = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbButtonView = new System.Windows.Forms.Button();
            this.lbTextboxView = new System.Windows.Forms.TextBox();
            this.lbTextboxModel = new System.Windows.Forms.TextBox();
            this.lbButtonModel = new System.Windows.Forms.Button();
            this.lvButtonView = new System.Windows.Forms.Button();
            this.lvTextboxView = new System.Windows.Forms.TextBox();
            this.lvTextboxModel = new System.Windows.Forms.TextBox();
            this.lvButtonModel = new System.Windows.Forms.Button();
            this.boundListView1 = new MvvmFx.Windows.Forms.BoundListView();
            this.tvButtonView = new System.Windows.Forms.Button();
            this.tvTextboxView = new System.Windows.Forms.TextBox();
            this.tvTextboxModel = new System.Windows.Forms.TextBox();
            this.tvButtonModel = new System.Windows.Forms.Button();
            this.boundTreeView1 = new MvvmFx.Windows.Forms.BoundTreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.leafName = new System.Windows.Forms.Label();
            this.queryObjectButton = new System.Windows.Forms.Button();
            this.dragDropStatusLabel = new System.Windows.Forms.Label();
            this.leafId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.leafParentId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sortButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leafListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leafIdDataGridViewTextBoxColumn,
            this.leafNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.leafListBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(208, 204);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.BindingContextChanged += new System.EventHandler(this.dataGridView1_BindingContextChanged);
            // 
            // leafIdDataGridViewTextBoxColumn
            // 
            this.leafIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.leafIdDataGridViewTextBoxColumn.DataPropertyName = "LeafId";
            this.leafIdDataGridViewTextBoxColumn.HeaderText = "LeafId";
            this.leafIdDataGridViewTextBoxColumn.MinimumWidth = 30;
            this.leafIdDataGridViewTextBoxColumn.Name = "leafIdDataGridViewTextBoxColumn";
            this.leafIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.leafIdDataGridViewTextBoxColumn.Width = 87;
            // 
            // leafNameDataGridViewTextBoxColumn
            // 
            this.leafNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.leafNameDataGridViewTextBoxColumn.DataPropertyName = "LeafName";
            this.leafNameDataGridViewTextBoxColumn.HeaderText = "LeafName";
            this.leafNameDataGridViewTextBoxColumn.Name = "leafNameDataGridViewTextBoxColumn";
            // 
            // leafListBindingSource
            // 
            this.leafListBindingSource.DataSource = typeof(BoundControls.Business.LeafList);
            this.bindingSourceRefresh.SetReadValuesOnChange(this.leafListBindingSource, true);
            // 
            // dgvButtonModel
            // 
            this.dgvButtonModel.Location = new System.Drawing.Point(134, 244);
            this.dgvButtonModel.Name = "dgvButtonModel";
            this.dgvButtonModel.Size = new System.Drawing.Size(86, 23);
            this.dgvButtonModel.TabIndex = 1;
            this.dgvButtonModel.Text = "Set Model";
            this.dgvButtonModel.UseVisualStyleBackColor = true;
            this.dgvButtonModel.Click += new System.EventHandler(this.dgvButtonModel_Click);
            // 
            // dgvTextboxModel
            // 
            this.dgvTextboxModel.Location = new System.Drawing.Point(13, 246);
            this.dgvTextboxModel.Name = "dgvTextboxModel";
            this.dgvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.dgvTextboxModel.TabIndex = 2;
            // 
            // dgvTextboxView
            // 
            this.dgvTextboxView.Location = new System.Drawing.Point(13, 275);
            this.dgvTextboxView.Name = "dgvTextboxView";
            this.dgvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.dgvTextboxView.TabIndex = 3;
            // 
            // dgvButtonView
            // 
            this.dgvButtonView.Location = new System.Drawing.Point(134, 273);
            this.dgvButtonView.Name = "dgvButtonView";
            this.dgvButtonView.Size = new System.Drawing.Size(86, 23);
            this.dgvButtonView.TabIndex = 4;
            this.dgvButtonView.Text = "Set View";
            this.dgvButtonView.UseVisualStyleBackColor = true;
            this.dgvButtonView.Click += new System.EventHandler(this.dgvButtonView_Click);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.leafListBindingSource;
            this.listBox1.DisplayMember = "LeafName";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(241, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(212, 199);
            this.listBox1.TabIndex = 5;
            this.listBox1.ValueMember = "LeafId";
            this.listBox1.BindingContextChanged += new System.EventHandler(this.listBox1_BindingContextChanged);
            // 
            // lbButtonView
            // 
            this.lbButtonView.Location = new System.Drawing.Point(364, 273);
            this.lbButtonView.Name = "lbButtonView";
            this.lbButtonView.Size = new System.Drawing.Size(84, 23);
            this.lbButtonView.TabIndex = 9;
            this.lbButtonView.Text = "Set View";
            this.lbButtonView.UseVisualStyleBackColor = true;
            this.lbButtonView.Click += new System.EventHandler(this.lbButtonView_Click);
            // 
            // lbTextboxView
            // 
            this.lbTextboxView.Location = new System.Drawing.Point(241, 275);
            this.lbTextboxView.Name = "lbTextboxView";
            this.lbTextboxView.Size = new System.Drawing.Size(100, 20);
            this.lbTextboxView.TabIndex = 8;
            // 
            // lbTextboxModel
            // 
            this.lbTextboxModel.Location = new System.Drawing.Point(241, 246);
            this.lbTextboxModel.Name = "lbTextboxModel";
            this.lbTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.lbTextboxModel.TabIndex = 7;
            // 
            // lbButtonModel
            // 
            this.lbButtonModel.Location = new System.Drawing.Point(364, 244);
            this.lbButtonModel.Name = "lbButtonModel";
            this.lbButtonModel.Size = new System.Drawing.Size(84, 23);
            this.lbButtonModel.TabIndex = 6;
            this.lbButtonModel.Text = "Set Model";
            this.lbButtonModel.UseVisualStyleBackColor = true;
            this.lbButtonModel.Click += new System.EventHandler(this.lbButtonModel_Click);
            // 
            // lvButtonView
            // 
            this.lvButtonView.Location = new System.Drawing.Point(596, 273);
            this.lvButtonView.Name = "lvButtonView";
            this.lvButtonView.Size = new System.Drawing.Size(84, 23);
            this.lvButtonView.TabIndex = 14;
            this.lvButtonView.Text = "Set View";
            this.lvButtonView.UseVisualStyleBackColor = true;
            this.lvButtonView.Click += new System.EventHandler(this.lvButtonView_Click);
            // 
            // lvTextboxView
            // 
            this.lvTextboxView.Location = new System.Drawing.Point(473, 275);
            this.lvTextboxView.Name = "lvTextboxView";
            this.lvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.lvTextboxView.TabIndex = 13;
            // 
            // lvTextboxModel
            // 
            this.lvTextboxModel.Location = new System.Drawing.Point(473, 246);
            this.lvTextboxModel.Name = "lvTextboxModel";
            this.lvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.lvTextboxModel.TabIndex = 12;
            // 
            // lvButtonModel
            // 
            this.lvButtonModel.Location = new System.Drawing.Point(596, 244);
            this.lvButtonModel.Name = "lvButtonModel";
            this.lvButtonModel.Size = new System.Drawing.Size(84, 23);
            this.lvButtonModel.TabIndex = 11;
            this.lvButtonModel.Text = "Set Model";
            this.lvButtonModel.UseVisualStyleBackColor = true;
            this.lvButtonModel.Click += new System.EventHandler(this.lvButtonModel_Click);
            // 
            // boundListView1
            // 
            this.boundListView1.DataSource = this.leafListBindingSource;
            this.boundListView1.FullRowSelect = true;
            this.boundListView1.HideSelection = false;
            this.boundListView1.LabelEdit = true;
            this.boundListView1.Location = new System.Drawing.Point(473, 33);
            this.boundListView1.MultiSelect = false;
            this.boundListView1.Name = "boundListView1";
            this.boundListView1.Size = new System.Drawing.Size(212, 199);
            this.boundListView1.TabIndex = 10;
            this.boundListView1.UseCompatibleStateImageBehavior = false;
            this.boundListView1.View = System.Windows.Forms.View.Details;
            this.boundListView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.boundListView1_AfterLabelEdit);
            this.boundListView1.BindingContextChanged += new System.EventHandler(this.boundListView1_BindingContextChanged);
            // 
            // tvButtonView
            // 
            this.tvButtonView.Location = new System.Drawing.Point(828, 273);
            this.tvButtonView.Name = "tvButtonView";
            this.tvButtonView.Size = new System.Drawing.Size(84, 23);
            this.tvButtonView.TabIndex = 19;
            this.tvButtonView.Text = "Set View";
            this.tvButtonView.UseVisualStyleBackColor = true;
            this.tvButtonView.Click += new System.EventHandler(this.tvButtonView_Click);
            // 
            // tvTextboxView
            // 
            this.tvTextboxView.Location = new System.Drawing.Point(705, 275);
            this.tvTextboxView.Name = "tvTextboxView";
            this.tvTextboxView.Size = new System.Drawing.Size(100, 20);
            this.tvTextboxView.TabIndex = 18;
            // 
            // tvTextboxModel
            // 
            this.tvTextboxModel.Location = new System.Drawing.Point(705, 246);
            this.tvTextboxModel.Name = "tvTextboxModel";
            this.tvTextboxModel.Size = new System.Drawing.Size(100, 20);
            this.tvTextboxModel.TabIndex = 17;
            // 
            // tvButtonModel
            // 
            this.tvButtonModel.Location = new System.Drawing.Point(828, 244);
            this.tvButtonModel.Name = "tvButtonModel";
            this.tvButtonModel.Size = new System.Drawing.Size(84, 23);
            this.tvButtonModel.TabIndex = 16;
            this.tvButtonModel.Text = "Set Model";
            this.tvButtonModel.UseVisualStyleBackColor = true;
            this.tvButtonModel.Click += new System.EventHandler(this.tvButtonModel_Click);
            // 
            // boundTreeView1
            // 
            this.boundTreeView1.AllowDrop = true;
            this.boundTreeView1.DataSource = this.leafListBindingSource;
            this.boundTreeView1.DisplayMember = "LeafName";
            this.boundTreeView1.DuplicatedCaption = "Duplicated Identifier Error";
            this.boundTreeView1.DuplicatedMessage = "Node \"{0}\" duplicates identifier \"{1}\"";
            this.boundTreeView1.GeneralNodeError = "Error at node.";
            this.boundTreeView1.HideSelection = false;
            this.boundTreeView1.HotTracking = true;
            this.boundTreeView1.IdentifierMember = "LeafId";
            this.boundTreeView1.InexistentParent = "Parent of node does not exist.";
            this.boundTreeView1.LabelEdit = true;
            this.boundTreeView1.Location = new System.Drawing.Point(705, 33);
            this.boundTreeView1.Name = "boundTreeView1";
            this.boundTreeView1.ParentIdentifierMember = "LeafParentId";
            this.boundTreeView1.ReadOnlyImageKey = null;
            this.boundTreeView1.ReadOnlySelectedImageKey = null;
            this.boundTreeView1.SelfParent = "Parent of node cannot be the node itself.";
            this.boundTreeView1.Size = new System.Drawing.Size(212, 199);
            this.boundTreeView1.Sorted = false;
            this.boundTreeView1.TabIndex = 15;
            this.boundTreeView1.ValueMember = "LeafId";
            this.boundTreeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.boundTreeView1_AfterLabelEdit);
            this.boundTreeView1.BindingContextChanged += new System.EventHandler(this.boundTreeView1_BindingContextChanged);
            this.boundTreeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.boundTreeView1_DragDrop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "LeafName:";
            // 
            // leafName
            // 
            this.leafName.Location = new System.Drawing.Point(131, 311);
            this.leafName.Name = "leafName";
            this.leafName.Size = new System.Drawing.Size(100, 13);
            this.leafName.TabIndex = 21;
            this.leafName.Text = "LeafName";
            // 
            // queryObjectButton
            // 
            this.queryObjectButton.Location = new System.Drawing.Point(16, 339);
            this.queryObjectButton.Name = "queryObjectButton";
            this.queryObjectButton.Size = new System.Drawing.Size(75, 23);
            this.queryObjectButton.TabIndex = 22;
            this.queryObjectButton.Text = "Query object";
            this.queryObjectButton.UseVisualStyleBackColor = true;
            this.queryObjectButton.Click += new System.EventHandler(this.queryObjectButton_Click);
            // 
            // dragDropStatusLabel
            // 
            this.dragDropStatusLabel.Location = new System.Drawing.Point(13, 384);
            this.dragDropStatusLabel.Name = "dragDropStatusLabel";
            this.dragDropStatusLabel.Size = new System.Drawing.Size(200, 13);
            this.dragDropStatusLabel.TabIndex = 28;
            this.dragDropStatusLabel.Text = "Current Drag&&Drop Status";
            // 
            // leafId
            // 
            this.leafId.Location = new System.Drawing.Point(361, 311);
            this.leafId.Name = "leafId";
            this.leafId.Size = new System.Drawing.Size(100, 13);
            this.leafId.TabIndex = 30;
            this.leafId.Text = "LeafId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "LeafId:";
            // 
            // leafParentId
            // 
            this.leafParentId.Location = new System.Drawing.Point(593, 311);
            this.leafParentId.Name = "leafParentId";
            this.leafParentId.Size = new System.Drawing.Size(100, 13);
            this.leafParentId.TabIndex = 32;
            this.leafParentId.Text = "LeafParentId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "LeafParentId:";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(828, 302);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(84, 23);
            this.sortButton.TabIndex = 33;
            this.sortButton.Text = "UI Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "DataGridView";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "ListBox";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "BoundListView";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(705, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "BoundTreeView";
            // 
            // SyncedLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.leafParentId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.leafId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dragDropStatusLabel);
            this.Controls.Add(this.queryObjectButton);
            this.Controls.Add(this.leafName);
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
            this.MaximumSize = new System.Drawing.Size(931, 438);
            this.MinimumSize = new System.Drawing.Size(931, 438);
            this.Name = "SyncedLists";
            this.Size = new System.Drawing.Size(931, 438);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leafListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dgvButtonModel;
        private System.Windows.Forms.TextBox dgvTextboxModel;
        private System.Windows.Forms.TextBox dgvTextboxView;
        private System.Windows.Forms.Button dgvButtonView;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button lbButtonView;
        private System.Windows.Forms.TextBox lbTextboxView;
        private System.Windows.Forms.TextBox lbTextboxModel;
        private System.Windows.Forms.Button lbButtonModel;
        private System.Windows.Forms.BindingSource leafListBindingSource;
        private System.Windows.Forms.Button lvButtonView;
        private System.Windows.Forms.TextBox lvTextboxView;
        private System.Windows.Forms.TextBox lvTextboxModel;
        private System.Windows.Forms.Button lvButtonModel;
        private MvvmFx.Windows.Forms.BoundListView boundListView1;
        private System.Windows.Forms.Button tvButtonView;
        private System.Windows.Forms.TextBox tvTextboxView;
        private System.Windows.Forms.TextBox tvTextboxModel;
        private System.Windows.Forms.Button tvButtonModel;
        private MvvmFx.Windows.Forms.BoundTreeView boundTreeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label leafName;
        private System.Windows.Forms.Button queryObjectButton;
        private System.Windows.Forms.Label dragDropStatusLabel;
        private System.Windows.Forms.Label leafId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label leafParentId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn leafIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leafNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}