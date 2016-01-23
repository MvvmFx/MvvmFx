namespace TreeListView
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvMain = new Gizmox.WebGUI.Forms.ListView();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // lvMain
            // 
            this.lvMain.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.lvMain.AutoGenerateColumns = true;
            this.lvMain.DataMember = null;
            this.lvMain.GridLines = false;
            this.lvMain.ItemsPerPage = 100;
            this.lvMain.Location = new System.Drawing.Point(11, 74);
            this.lvMain.Name = "lvMain";
            this.lvMain.ShowItemToolTips = false;
            this.lvMain.Size = new System.Drawing.Size(957, 388);
            this.lvMain.TabIndex = 0;
            this.lvMain.UseInternalPaging = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hierarchal ListView";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(446, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "NorthWind Customers - Orders - Order lines";
            // 
            // TreeListView
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvMain);
            this.Size = new System.Drawing.Size(981, 475);
            this.Text = "TreeListView";
            this.Load += new System.EventHandler(this.ListView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListView lvMain;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label2;
    }
}