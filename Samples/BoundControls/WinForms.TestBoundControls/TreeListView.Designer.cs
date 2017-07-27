namespace WinForms.TestBoundTreeView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boundListView1 = new MvvmFx.Windows.Forms.BoundListView();
            this.SuspendLayout();
            // 
            // boundListView1
            // 
            this.boundListView1.FullRowSelect = true;
            this.boundListView1.HideSelection = false;
            this.boundListView1.LabelEdit = true;
            this.boundListView1.Location = new System.Drawing.Point(4, 4);
            this.boundListView1.MaximumSize = new System.Drawing.Size(500, 418);
            this.boundListView1.MinimumSize = new System.Drawing.Size(500, 418);
            this.boundListView1.MultiSelect = false;
            this.boundListView1.Name = "boundListView1";
            this.boundListView1.Size = new System.Drawing.Size(500, 418);
            this.boundListView1.TabIndex = 0;
            this.boundListView1.UseCompatibleStateImageBehavior = false;
            this.boundListView1.View = System.Windows.Forms.View.Details;
            // 
            // TreeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.boundListView1);
            this.MaximumSize = new System.Drawing.Size(931, 425);
            this.MinimumSize = new System.Drawing.Size(931, 425);
            this.Name = "TreeListView";
            this.Size = new System.Drawing.Size(931, 425);
            this.ResumeLayout(false);

        }

        #endregion

        private MvvmFx.Windows.Forms.BoundListView boundListView1;
    }
}
