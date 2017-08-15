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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentListView));
            this.listBox1 = new Wisej.Web.ListBox();
            this.displayName = new Wisej.Web.Label();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.toolTip1 = new Wisej.Web.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 396);
            this.listBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listBox1, resources.GetString("listBox1.ToolTip"));
            // 
            // displayName
            // 
            this.displayName.AutoSize = true;
            this.displayName.Location = new System.Drawing.Point(4, 4);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(4, 15);
            this.displayName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.displayName, null);
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.activeItem.AutoScroll = true;
            this.activeItem.AutoScrollMinSize = new System.Drawing.Size(470, 350);
            this.activeItem.Location = new System.Drawing.Point(354, 26);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(476, 393);
            this.activeItem.TabIndex = 2;
            this.toolTip1.SetToolTip(this.activeItem, null);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.ToolTipIcon = Wisej.Web.ToolTipIcon.Info;
            // 
            // StudentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.listBox1);
            this.Name = "StudentListView";
            this.Size = new System.Drawing.Size(830, 422);
            this.toolTip1.SetToolTip(this, "Why this method doesn\'t work correctly\r\nunder Windows Forms?");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.ListBox listBox1;
        private Wisej.Web.Label displayName;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
        private Wisej.Web.ToolTip toolTip1;
    }
}
