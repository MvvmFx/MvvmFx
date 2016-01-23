namespace TestPlainTreeView
{
    partial class Form1
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gizmox.WebGUI.Forms.TreeView));
            this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.docTypeName = new Gizmox.WebGUI.Forms.Label();
            this.dragDropStatusLabel = new Gizmox.WebGUI.Forms.Label();
            this.docTypeID = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.docTypeParentID = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrag = false;
            this.treeView1.AllowDrop = true;
            this.treeView1.DragTargets = new Gizmox.WebGUI.Forms.Component[] {
            ((Gizmox.WebGUI.Forms.Component)(this.treeView1))};
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(16, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(212, 394);
            this.treeView1.Sorted = false;
            this.treeView1.TabIndex = 15;
            this.treeView1.AfterLabelEdit += new Gizmox.WebGUI.Forms.NodeLabelEditEventHandler(this.boundTreeView1_AfterLabelEdit);
            this.treeView1.DragDrop += new Gizmox.WebGUI.Forms.DragEventHandler(this.boundTreeView1_DragDrop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "DocTypeName:";
            // 
            // docTypeName
            // 
            this.docTypeName.Location = new System.Drawing.Point(661, 66);
            this.docTypeName.Name = "docTypeName";
            this.docTypeName.Size = new System.Drawing.Size(100, 13);
            this.docTypeName.TabIndex = 21;
            this.docTypeName.Text = "DocTypeName";
            // 
            // dragDropStatusLabel
            // 
            this.dragDropStatusLabel.Location = new System.Drawing.Point(543, 216);
            this.dragDropStatusLabel.Name = "dragDropStatusLabel";
            this.dragDropStatusLabel.Size = new System.Drawing.Size(200, 13);
            this.dragDropStatusLabel.TabIndex = 28;
            this.dragDropStatusLabel.Text = "Current Drag&&Drop Status";
            // 
            // docTypeID
            // 
            this.docTypeID.Location = new System.Drawing.Point(664, 104);
            this.docTypeID.Name = "docTypeID";
            this.docTypeID.Size = new System.Drawing.Size(100, 13);
            this.docTypeID.TabIndex = 30;
            this.docTypeID.Text = "DocTypeID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "DocTypeID:";
            // 
            // docTypeParentID
            // 
            this.docTypeParentID.Location = new System.Drawing.Point(666, 143);
            this.docTypeParentID.Name = "docTypeParentID";
            this.docTypeParentID.Size = new System.Drawing.Size(100, 13);
            this.docTypeParentID.TabIndex = 32;
            this.docTypeParentID.Text = "DocTypeParentID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DocTypeParentID:";
            // 
            // TreeView
            // 
            this.Controls.Add(this.docTypeParentID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.docTypeID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dragDropStatusLabel);
            this.Controls.Add(this.docTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.MaximumSize = new System.Drawing.Size(931, 425);
            this.MinimumSize = new System.Drawing.Size(931, 425);
            this.Size = new System.Drawing.Size(931, 425);
            this.Text = "TreeView";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView treeView1;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label docTypeName;
        private Gizmox.WebGUI.Forms.Label dragDropStatusLabel;
        private Gizmox.WebGUI.Forms.Label docTypeID;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label docTypeParentID;
        private Gizmox.WebGUI.Forms.Label label5;
    }
}