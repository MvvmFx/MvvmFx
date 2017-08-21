namespace WisejTreeSelectedNode
{
    partial class MainForm
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
            this.treeNode11 = new Wisej.Web.TreeNode();
            this.treeNode1 = new Wisej.Web.TreeNode();
            this.treeView1 = new Wisej.Web.TreeView();
            this.button1 = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // treeNode1
            // 
            this.treeNode1.Name = "Node1";
            this.treeNode1.Nodes.AddRange(new Wisej.Web.TreeNode[] {
            treeNode11});
            this.treeNode1.Text = "Node 1";
            // 
            // treeNode11
            // 
            this.treeNode11.Name = "Node11";
            this.treeNode11.Text = "Node 1.1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = Wisej.Web.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new Wisej.Web.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(288, 400);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new Wisej.Web.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.BeforeSelect += new Wisej.Web.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            // 
            // button1
            // 
            this.button1.Dock = Wisej.Web.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("default", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.Location = new System.Drawing.Point(0, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Step 1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WisejWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 456);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.TreeNode treeNode1;
        private Wisej.Web.TreeNode treeNode11;
        private Wisej.Web.TreeView treeView1;
        private Wisej.Web.Button button1;
    }
}

