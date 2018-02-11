namespace CslaSample.Documents
{
    partial class DocumentEditView
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
            this.documentPanel = new Wisej.Web.Panel();
            this.label1 = new Wisej.Web.Label();
            this.model_DocumentId = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.model_DocumentReference = new Wisej.Web.TextBox();
            this.label3 = new Wisej.Web.Label();
            this.model_DocumentDate = new Wisej.Web.TextBox();
            this.label4 = new Wisej.Web.Label();
            this.model_Subject = new Wisej.Web.TextBox();
            this.label5 = new Wisej.Web.Label();
            this.model_Sender = new Wisej.Web.TextBox();
            this.label6 = new Wisej.Web.Label();
            this.model_Receiver = new Wisej.Web.TextBox();
            this.label7 = new Wisej.Web.Label();
            this.model_TextContent = new Wisej.Web.TextBox();
            this.label8 = new Wisej.Web.Label();
            this.model_CreateDate = new Wisej.Web.Label();
            this.label9 = new Wisej.Web.Label();
            this.model_ChangeDate = new Wisej.Web.Label();
            this.toolStrip1 = new Wisej.Web.ToolBar();
            this.create = new Wisej.Web.ToolBarButton();
            this.save = new Wisej.Web.ToolBarButton();
            this.delete = new Wisej.Web.ToolBarButton();
            this.close = new Wisej.Web.ToolBarButton();
            this.errorProvider = new Wisej.Web.ErrorProvider(this.components);
            this.documentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // documentPanel
            // 
            this.documentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.documentPanel.BorderStyle = Wisej.Web.BorderStyle.Solid;
            this.documentPanel.Controls.Add(this.label1);
            this.documentPanel.Controls.Add(this.model_DocumentId);
            this.documentPanel.Controls.Add(this.label2);
            this.documentPanel.Controls.Add(this.model_DocumentReference);
            this.documentPanel.Controls.Add(this.label3);
            this.documentPanel.Controls.Add(this.model_DocumentDate);
            this.documentPanel.Controls.Add(this.label4);
            this.documentPanel.Controls.Add(this.model_Subject);
            this.documentPanel.Controls.Add(this.label5);
            this.documentPanel.Controls.Add(this.model_Sender);
            this.documentPanel.Controls.Add(this.label6);
            this.documentPanel.Controls.Add(this.model_Receiver);
            this.documentPanel.Controls.Add(this.label7);
            this.documentPanel.Controls.Add(this.model_TextContent);
            this.documentPanel.Controls.Add(this.label8);
            this.documentPanel.Controls.Add(this.model_CreateDate);
            this.documentPanel.Controls.Add(this.label9);
            this.documentPanel.Controls.Add(this.model_ChangeDate);
            this.documentPanel.Dock = Wisej.Web.DockStyle.Fill;
            this.documentPanel.Location = new System.Drawing.Point(0, 26);
            this.documentPanel.Name = "documentPanel";
            this.documentPanel.Size = new System.Drawing.Size(727, 497);
            this.documentPanel.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Document Id";
            // 
            // model_DocumentId
            // 
            this.model_DocumentId.AutoSize = true;
            this.model_DocumentId.Location = new System.Drawing.Point(119, 25);
            this.model_DocumentId.Name = "model_DocumentId";
            this.model_DocumentId.Size = new System.Drawing.Size(4, 13);
            this.model_DocumentId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reference";
            // 
            // model_DocumentReference
            // 
            this.model_DocumentReference.Location = new System.Drawing.Point(116, 52);
            this.model_DocumentReference.Name = "model_DocumentReference";
            this.model_DocumentReference.Size = new System.Drawing.Size(234, 20);
            this.model_DocumentReference.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // model_DocumentDate
            // 
            this.model_DocumentDate.Location = new System.Drawing.Point(615, 52);
            this.model_DocumentDate.Name = "model_DocumentDate";
            this.model_DocumentDate.Size = new System.Drawing.Size(92, 20);
            this.model_DocumentDate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Subject";
            // 
            // model_Subject
            // 
            this.model_Subject.Location = new System.Drawing.Point(116, 82);
            this.model_Subject.Name = "model_Subject";
            this.model_Subject.Size = new System.Drawing.Size(591, 20);
            this.model_Subject.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sender";
            // 
            // model_Sender
            // 
            this.model_Sender.Location = new System.Drawing.Point(116, 112);
            this.model_Sender.Name = "model_Sender";
            this.model_Sender.Size = new System.Drawing.Size(334, 20);
            this.model_Sender.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Receiver";
            // 
            // model_Receiver
            // 
            this.model_Receiver.Location = new System.Drawing.Point(116, 142);
            this.model_Receiver.Name = "model_Receiver";
            this.model_Receiver.Size = new System.Drawing.Size(334, 20);
            this.model_Receiver.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Text Content";
            // 
            // model_TextContent
            // 
            this.model_TextContent.Location = new System.Drawing.Point(116, 172);
            this.model_TextContent.Multiline = true;
            this.model_TextContent.Name = "model_TextContent";
            this.model_TextContent.Size = new System.Drawing.Size(591, 243);
            this.model_TextContent.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "Created Date";
            // 
            // model_CreateDate
            // 
            this.model_CreateDate.AutoSize = true;
            this.model_CreateDate.Location = new System.Drawing.Point(119, 435);
            this.model_CreateDate.Name = "model_CreateDate";
            this.model_CreateDate.Size = new System.Drawing.Size(4, 13);
            this.model_CreateDate.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "Changed Date";
            // 
            // model_ChangeDate
            // 
            this.model_ChangeDate.AutoSize = true;
            this.model_ChangeDate.Location = new System.Drawing.Point(119, 465);
            this.model_ChangeDate.Name = "model_ChangeDate";
            this.model_ChangeDate.Size = new System.Drawing.Size(4, 13);
            this.model_ChangeDate.TabIndex = 18;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.create,
            this.save,
            this.delete,
            this.close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(727, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = false;
            this.toolStrip1.TextAlign = Wisej.Web.ToolBarTextAlign.Right;
            // 
            // create
            // 
            this.create.Image = global::CslaSample.Properties.Resources.AddNew16;
            this.create.Name = "create";
            this.create.ToolTipText = "New Document";
            // 
            // save
            // 
            this.save.Image = global::CslaSample.Properties.Resources.Save16;
            this.save.Name = "save";
            this.save.ToolTipText = "Save";
            // 
            // delete
            // 
            this.delete.Image = global::CslaSample.Properties.Resources.Delete16;
            this.delete.Name = "delete";
            this.delete.ToolTipText = "Delete";
            // 
            // close
            // 
            this.close.Image = global::CslaSample.Properties.Resources.Close16;
            this.close.Name = "close";
            this.close.ToolTipText = "Close form";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DocumentEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(727, 523);
            this.Controls.Add(this.documentPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DocumentEditView";
            this.Size = new System.Drawing.Size(727, 523);
            this.documentPanel.ResumeLayout(false);
            this.documentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Panel documentPanel;
        private Wisej.Web.ToolBar toolStrip1;
        private Wisej.Web.ToolBarButton create;
        private Wisej.Web.ToolBarButton save;
        private Wisej.Web.ToolBarButton delete;
        private Wisej.Web.ToolBarButton close;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label model_DocumentId;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox model_DocumentReference;
        private Wisej.Web.Label label3;
        private Wisej.Web.TextBox model_DocumentDate;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox model_Subject;
        private Wisej.Web.Label label5;
        private Wisej.Web.TextBox model_Sender;
        private Wisej.Web.Label label6;
        private Wisej.Web.TextBox model_Receiver;
        private Wisej.Web.Label label7;
        private Wisej.Web.TextBox model_TextContent;
        private Wisej.Web.Label label8;
        private Wisej.Web.Label model_CreateDate;
        private Wisej.Web.Label label9;
        private Wisej.Web.Label model_ChangeDate;
        private Wisej.Web.ErrorProvider errorProvider;
    }
}
