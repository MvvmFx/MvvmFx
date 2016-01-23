namespace CslaSample.Documents
{
    partial class FolderListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderListView));
            this.folderListBox = new Gizmox.WebGUI.Forms.ListBox();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.toolTip1 = new Gizmox.WebGUI.Forms.ToolTip(this.components);
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.toolStrip1 = new Gizmox.WebGUI.Forms.ToolStrip();
            this.displayName = new Gizmox.WebGUI.Forms.ToolStripLabel();
            this.refreshFolders = new Gizmox.WebGUI.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderListBox
            // 
            this.folderListBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.folderListBox.FormattingEnabled = true;
            //this.folderListBox.IntegralHeight = false;
            this.folderListBox.Location = new System.Drawing.Point(0, 26);
            this.folderListBox.Name = "folderListBox";
            this.folderListBox.Size = new System.Drawing.Size(248, 628);
            this.folderListBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.folderListBox, resources.GetString("folderListBox.ToolTip"));
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.activeItem.Location = new System.Drawing.Point(254, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1094, 654);
            this.activeItem.TabIndex = 2;
            /*// 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = Gizmox.WebGUI.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Why this method doesn\'t work correctly\r\nunder Windows Forms?";*/
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 27);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.displayName,
            this.refreshFolders});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(248, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // displayName
            // 
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(0, 22);
            // 
            // refreshFolders
            // 
            this.refreshFolders.Alignment = Gizmox.WebGUI.Forms.ToolStripItemAlignment.Right;
            this.refreshFolders.DisplayStyle = Gizmox.WebGUI.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshFolders.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("refreshFolders.Image"));
            this.refreshFolders.Name = "refreshFolders";
            this.refreshFolders.Size = new System.Drawing.Size(23, 22);
            this.refreshFolders.Text = "Refresh folder list";
            this.refreshFolders.ToolTipText = "Refresh folder list";
            // 
            // FolderListView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.folderListBox);
            this.Name = "FolderListView";
            this.Size = new System.Drawing.Size(1348, 654);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ListBox folderListBox;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
        private Gizmox.WebGUI.Forms.ToolTip toolTip1;
        private Gizmox.WebGUI.Forms.Panel panel1;
        private Gizmox.WebGUI.Forms.ToolStrip toolStrip1;
        private Gizmox.WebGUI.Forms.ToolStripLabel displayName;
        private Gizmox.WebGUI.Forms.ToolStripButton refreshFolders;
    }
}
