using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace WebGUI.TestBoundTreeView
{
    partial class TreeListView
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
            this.boundListView1 = new MvvmFx.WebGUI.Forms.BoundListView();
            this.SuspendLayout();
            // 
            // boundListView1
            // 
            this.boundListView1.FullRowSelect = true;
            this.boundListView1.LabelEdit = true;
            this.boundListView1.Location = new System.Drawing.Point(0, 0);
            this.boundListView1.MaximumSize = new System.Drawing.Size(500, 425);
            this.boundListView1.MinimumSize = new System.Drawing.Size(500, 425);
            this.boundListView1.MultiSelect = false;
            this.boundListView1.Name = "boundListView1";
            this.boundListView1.Size = new System.Drawing.Size(500, 425);
            this.boundListView1.TabIndex = 0;
            // 
            // TreeListView
            // 
            this.Controls.Add(this.boundListView1);
            this.MaximumSize = new System.Drawing.Size(931, 425);
            this.MinimumSize = new System.Drawing.Size(931, 425);
            this.Size = new System.Drawing.Size(931, 425);
            this.Text = "TreeListView";
            this.ResumeLayout(false);

        }

        #endregion

        private MvvmFx.WebGUI.Forms.BoundListView boundListView1;


    }
}