namespace MasterDetailWithModel.Views
{
    partial class StudentListView
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
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.displayName = new Gizmox.WebGUI.Forms.Label();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.listBox1.FormattingEnabled = true;
            //this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(0, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 628);
            this.listBox1.TabIndex = 0;
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.displayName.Location = new System.Drawing.Point(4, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(0, 13);
            this.displayName.TabIndex = 1;
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.activeItem.AutoScroll = true;
            //this.activeItem.AutoScrollMinSize = new System.Drawing.Size(470, 350);
            this.activeItem.Location = new System.Drawing.Point(354, 26);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(994, 625);
            this.activeItem.TabIndex = 2;
            // 
            // StudentListView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.listBox1);
            //this.Name = "StudentListView";
            this.Size = new System.Drawing.Size(1348, 654);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox listBox1;
        private Gizmox.WebGUI.Forms.Label displayName;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}
