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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderListView));
            this.folderListBox = new Wisej.Web.ListBox();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.toolTip1 = new Wisej.Web.ToolTip(this.components);
            this.panel1 = new Wisej.Web.Panel();
            this.toolStrip1 = new Wisej.Web.ToolBar();
            this.displayName = new Wisej.Web.ToolBarButton();
            this.refreshFolders = new Wisej.Web.ToolBarButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderListBox
            // 
            this.folderListBox.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.folderListBox.FormattingEnabled = true;
            this.folderListBox.Location = new System.Drawing.Point(0, 26);
            this.folderListBox.Name = "folderListBox";
            this.folderListBox.Size = new System.Drawing.Size(248, 628);
            this.folderListBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.folderListBox, resources.GetString("folderListBox.ToolTip"));
            // 
            // activeItem
            // 
            this.activeItem.Anchor = ((Wisej.Web.AnchorStyles)((((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.activeItem.Location = new System.Drawing.Point(254, 0);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1094, 654);
            this.activeItem.TabIndex = 2;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ToolTipIcon = Wisej.Web.ToolTipIcon.Info;
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
            this.toolStrip1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
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
            // 
            // refreshFolders
            // 
            this.refreshFolders.Image = global::CslaSample.Properties.Resources.Refresh16;
            this.refreshFolders.Name = "refreshFolders";
            this.refreshFolders.Text = "Refresh folder list";
            this.refreshFolders.ToolTipText = "Refresh folder list";
            // 
            // FolderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
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

        private Wisej.Web.ListBox folderListBox;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
        private Wisej.Web.ToolTip toolTip1;
        private Wisej.Web.Panel panel1;
        private Wisej.Web.ToolBar toolStrip1;
        private Wisej.Web.ToolBarButton displayName;
        private Wisej.Web.ToolBarButton refreshFolders;
    }
}
