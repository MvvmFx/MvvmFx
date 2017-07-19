namespace InvoicesUI.WisejWeb
{
    partial class TestFormLambdaINPC
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
            if (disposing)
            {
                _bindingManager.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerNameChangeBO = new Wisej.Web.Button();
            this.CustomerNameUI = new Wisej.Web.TextBox();
            this.CustomerNameChangeUI = new Wisej.Web.Button();
            this.label2 = new Wisej.Web.Label();
            this.CustomerNameBO = new Wisej.Web.Label();
            this.CustomerNameGrp = new Wisej.Web.GroupBox();
            this.CustomerAddressCountryGrp = new Wisej.Web.GroupBox();
            this.CustomerAddressCountryUI = new Wisej.Web.TextBox();
            this.CustomerAddressCountryChangeBO = new Wisej.Web.Button();
            this.CustomerAddressCountryBO = new Wisej.Web.Label();
            this.label4 = new Wisej.Web.Label();
            this.CustomerAddressCountryChangeUI = new Wisej.Web.Button();
            this.CustomerAddressZipCodeGrp = new Wisej.Web.GroupBox();
            this.CustomerAddressZipCodeUI = new Wisej.Web.TextBox();
            this.CustomerAddressZipCodeChangeBO = new Wisej.Web.Button();
            this.CustomerAddressZipCodeBO = new Wisej.Web.Label();
            this.label6 = new Wisej.Web.Label();
            this.CustomerAddressZipCodeChangeUI = new Wisej.Web.Button();
            this.CustomerInvoiceInvoiceNumberGrp = new Wisej.Web.GroupBox();
            this.CustomerInvoiceInvoiceNumberUI = new Wisej.Web.TextBox();
            this.CustomerInvoiceInvoiceNumberChangeBO = new Wisej.Web.Button();
            this.CustomerInvoiceInvoiceNumberBO = new Wisej.Web.Label();
            this.label8 = new Wisej.Web.Label();
            this.CustomerInvoiceInvoiceNumberChangeUI = new Wisej.Web.Button();
            this.CustomerInvoiceInvoiceDateGrp = new Wisej.Web.GroupBox();
            this.CustomerInvoiceInvoiceDateUI = new Wisej.Web.TextBox();
            this.CustomerInvoiceInvoiceDateChangeBO = new Wisej.Web.Button();
            this.CustomerInvoiceInvoiceDateBO = new Wisej.Web.Label();
            this.label10 = new Wisej.Web.Label();
            this.CustomerInvoiceInvoiceDateChangeUI = new Wisej.Web.Button();
            this.CustomerNameGrp.SuspendLayout();
            this.CustomerAddressCountryGrp.SuspendLayout();
            this.CustomerAddressZipCodeGrp.SuspendLayout();
            this.CustomerInvoiceInvoiceNumberGrp.SuspendLayout();
            this.CustomerInvoiceInvoiceDateGrp.SuspendLayout();
            this.SuspendLayout();
            //
            // CustomerNameChangeBO
            //
            this.CustomerNameChangeBO.Location = new System.Drawing.Point(162, 19);
            this.CustomerNameChangeBO.Name = "CustomerNameChangeBO";
            this.CustomerNameChangeBO.Size = new System.Drawing.Size(100, 23);
            this.CustomerNameChangeBO.TabIndex = 1;
            this.CustomerNameChangeBO.Text = "Change BO";
            //
            // CustomerNameUI
            //
            this.CustomerNameUI.Location = new System.Drawing.Point(11, 21);
            this.CustomerNameUI.Name = "CustomerNameUI";
            this.CustomerNameUI.Size = new System.Drawing.Size(120, 20);
            this.CustomerNameUI.TabIndex = 2;
            //
            // CustomerNameChangeUI
            //
            this.CustomerNameChangeUI.Location = new System.Drawing.Point(162, 51);
            this.CustomerNameChangeUI.Name = "CustomerNameChangeUI";
            this.CustomerNameChangeUI.Size = new System.Drawing.Size(100, 23);
            this.CustomerNameChangeUI.TabIndex = 3;
            this.CustomerNameChangeUI.Text = "Change UI";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "BO";
            //
            // CustomerNameBO
            //
            this.CustomerNameBO.Location = new System.Drawing.Point(36, 56);
            this.CustomerNameBO.Name = "CustomerNameBO";
            this.CustomerNameBO.Size = new System.Drawing.Size(120, 16);
            this.CustomerNameBO.TabIndex = 5;
            this.CustomerNameBO.Text = "";
            //
            // CustomerNameGrp
            //
            this.CustomerNameGrp.Controls.Add(this.CustomerNameUI);
            this.CustomerNameGrp.Controls.Add(this.CustomerNameChangeBO);
            this.CustomerNameGrp.Controls.Add(this.CustomerNameBO);
            this.CustomerNameGrp.Controls.Add(this.label2);
            this.CustomerNameGrp.Controls.Add(this.CustomerNameChangeUI);
            this.CustomerNameGrp.Location = new System.Drawing.Point(12, 12);
            this.CustomerNameGrp.Name = "CustomerNameGrp";
            this.CustomerNameGrp.Size = new System.Drawing.Size(279, 88);
            this.CustomerNameGrp.TabIndex = 8;
            this.CustomerNameGrp.TabStop = false;
            this.CustomerNameGrp.Text = "<Customer>.Name";
            //
            // CustomerAddressCountryGrp
            //
            this.CustomerAddressCountryGrp.Controls.Add(this.CustomerAddressCountryUI);
            this.CustomerAddressCountryGrp.Controls.Add(this.CustomerAddressCountryChangeBO);
            this.CustomerAddressCountryGrp.Controls.Add(this.CustomerAddressCountryBO);
            this.CustomerAddressCountryGrp.Controls.Add(this.label4);
            this.CustomerAddressCountryGrp.Controls.Add(this.CustomerAddressCountryChangeUI);
            this.CustomerAddressCountryGrp.Location = new System.Drawing.Point(12, 106);
            this.CustomerAddressCountryGrp.Name = "CustomerAddressCountryGrp";
            this.CustomerAddressCountryGrp.Size = new System.Drawing.Size(279, 88);
            this.CustomerAddressCountryGrp.TabIndex = 9;
            this.CustomerAddressCountryGrp.TabStop = false;
            this.CustomerAddressCountryGrp.Text = "<Customer.Address>.Country";
            //
            // CustomerAddressCountryUI
            //
            this.CustomerAddressCountryUI.Location = new System.Drawing.Point(11, 21);
            this.CustomerAddressCountryUI.Name = "CustomerAddressCountryUI";
            this.CustomerAddressCountryUI.Size = new System.Drawing.Size(120, 20);
            this.CustomerAddressCountryUI.TabIndex = 2;
            //
            // CustomerAddressCountryChangeBO
            //
            this.CustomerAddressCountryChangeBO.Location = new System.Drawing.Point(162, 19);
            this.CustomerAddressCountryChangeBO.Name = "CustomerAddressCountryChangeBO";
            this.CustomerAddressCountryChangeBO.Size = new System.Drawing.Size(100, 23);
            this.CustomerAddressCountryChangeBO.TabIndex = 1;
            this.CustomerAddressCountryChangeBO.Text = "Change BO";
            //
            // CustomerAddressCountryBO
            //
            this.CustomerAddressCountryBO.Location = new System.Drawing.Point(36, 56);
            this.CustomerAddressCountryBO.Name = "CustomerAddressCountryBO";
            this.CustomerAddressCountryBO.Size = new System.Drawing.Size(120, 16);
            this.CustomerAddressCountryBO.TabIndex = 5;
            this.CustomerAddressCountryBO.Text = "";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "BO";
            //
            // CustomerAddressCountryChangeUI
            //
            this.CustomerAddressCountryChangeUI.Location = new System.Drawing.Point(162, 51);
            this.CustomerAddressCountryChangeUI.Name = "CustomerAddressCountryChangeUI";
            this.CustomerAddressCountryChangeUI.Size = new System.Drawing.Size(100, 23);
            this.CustomerAddressCountryChangeUI.TabIndex = 3;
            this.CustomerAddressCountryChangeUI.Text = "Change UI";
            //
            // CustomerAddressZipCodeGrp
            //
            this.CustomerAddressZipCodeGrp.Controls.Add(this.CustomerAddressZipCodeUI);
            this.CustomerAddressZipCodeGrp.Controls.Add(this.CustomerAddressZipCodeChangeBO);
            this.CustomerAddressZipCodeGrp.Controls.Add(this.CustomerAddressZipCodeBO);
            this.CustomerAddressZipCodeGrp.Controls.Add(this.label6);
            this.CustomerAddressZipCodeGrp.Controls.Add(this.CustomerAddressZipCodeChangeUI);
            this.CustomerAddressZipCodeGrp.Location = new System.Drawing.Point(12, 200);
            this.CustomerAddressZipCodeGrp.Name = "CustomerAddressZipCodeGrp";
            this.CustomerAddressZipCodeGrp.Size = new System.Drawing.Size(279, 88);
            this.CustomerAddressZipCodeGrp.TabIndex = 9;
            this.CustomerAddressZipCodeGrp.TabStop = false;
            this.CustomerAddressZipCodeGrp.Text = "<Customer>.Address.ZipCode";
            //
            // CustomerAddressZipCodeUI
            //
            this.CustomerAddressZipCodeUI.Location = new System.Drawing.Point(11, 21);
            this.CustomerAddressZipCodeUI.Name = "CustomerAddressZipCodeUI";
            this.CustomerAddressZipCodeUI.Size = new System.Drawing.Size(120, 20);
            this.CustomerAddressZipCodeUI.TabIndex = 2;
            //
            // CustomerAddressZipCodeChangeBO
            //
            this.CustomerAddressZipCodeChangeBO.Location = new System.Drawing.Point(162, 19);
            this.CustomerAddressZipCodeChangeBO.Name = "CustomerAddressZipCodeChangeBO";
            this.CustomerAddressZipCodeChangeBO.Size = new System.Drawing.Size(100, 23);
            this.CustomerAddressZipCodeChangeBO.TabIndex = 1;
            this.CustomerAddressZipCodeChangeBO.Text = "Change BO";
            //
            // CustomerAddressZipCodeBO
            //
            this.CustomerAddressZipCodeBO.Location = new System.Drawing.Point(36, 56);
            this.CustomerAddressZipCodeBO.Name = "CustomerAddressZipCodeBO";
            this.CustomerAddressZipCodeBO.Size = new System.Drawing.Size(120, 16);
            this.CustomerAddressZipCodeBO.TabIndex = 5;
            this.CustomerAddressZipCodeBO.Text = "";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "BO";
            //
            // CustomerAddressZipCodeChangeUI
            //
            this.CustomerAddressZipCodeChangeUI.Location = new System.Drawing.Point(162, 51);
            this.CustomerAddressZipCodeChangeUI.Name = "CustomerAddressZipCodeChangeUI";
            this.CustomerAddressZipCodeChangeUI.Size = new System.Drawing.Size(100, 23);
            this.CustomerAddressZipCodeChangeUI.TabIndex = 3;
            this.CustomerAddressZipCodeChangeUI.Text = "Change UI";
            //
            // CustomerInvoiceInvoiceNumberGrp
            //
            this.CustomerInvoiceInvoiceNumberGrp.Controls.Add(this.CustomerInvoiceInvoiceNumberUI);
            this.CustomerInvoiceInvoiceNumberGrp.Controls.Add(this.CustomerInvoiceInvoiceNumberChangeBO);
            this.CustomerInvoiceInvoiceNumberGrp.Controls.Add(this.CustomerInvoiceInvoiceNumberBO);
            this.CustomerInvoiceInvoiceNumberGrp.Controls.Add(this.label8);
            this.CustomerInvoiceInvoiceNumberGrp.Controls.Add(this.CustomerInvoiceInvoiceNumberChangeUI);
            this.CustomerInvoiceInvoiceNumberGrp.Location = new System.Drawing.Point(12, 294);
            this.CustomerInvoiceInvoiceNumberGrp.Name = "CustomerInvoiceInvoiceNumberGrp";
            this.CustomerInvoiceInvoiceNumberGrp.Size = new System.Drawing.Size(279, 88);
            this.CustomerInvoiceInvoiceNumberGrp.TabIndex = 9;
            this.CustomerInvoiceInvoiceNumberGrp.TabStop = false;
            this.CustomerInvoiceInvoiceNumberGrp.Text = "<Customer.Invoice>.InvoiceNumber";
            //
            // CustomerInvoiceInvoiceNumberUI
            //
            this.CustomerInvoiceInvoiceNumberUI.Location = new System.Drawing.Point(11, 21);
            this.CustomerInvoiceInvoiceNumberUI.Name = "CustomerInvoiceInvoiceNumberUI";
            this.CustomerInvoiceInvoiceNumberUI.Size = new System.Drawing.Size(120, 20);
            this.CustomerInvoiceInvoiceNumberUI.TabIndex = 2;
            //
            // CustomerInvoiceInvoiceNumberChangeBO
            //
            this.CustomerInvoiceInvoiceNumberChangeBO.Location = new System.Drawing.Point(162, 19);
            this.CustomerInvoiceInvoiceNumberChangeBO.Name = "CustomerInvoiceInvoiceNumberChangeBO";
            this.CustomerInvoiceInvoiceNumberChangeBO.Size = new System.Drawing.Size(100, 23);
            this.CustomerInvoiceInvoiceNumberChangeBO.TabIndex = 1;
            this.CustomerInvoiceInvoiceNumberChangeBO.Text = "Change BO";
            //
            // CustomerInvoiceInvoiceNumberBO
            //
            this.CustomerInvoiceInvoiceNumberBO.Location = new System.Drawing.Point(36, 56);
            this.CustomerInvoiceInvoiceNumberBO.Name = "CustomerInvoiceInvoiceNumberBO";
            this.CustomerInvoiceInvoiceNumberBO.Size = new System.Drawing.Size(120, 16);
            this.CustomerInvoiceInvoiceNumberBO.TabIndex = 5;
            this.CustomerInvoiceInvoiceNumberBO.Text = "";
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "BO";
            //
            // CustomerInvoiceInvoiceNumberChangeUI
            //
            this.CustomerInvoiceInvoiceNumberChangeUI.Location = new System.Drawing.Point(162, 51);
            this.CustomerInvoiceInvoiceNumberChangeUI.Name = "CustomerInvoiceInvoiceNumberChangeUI";
            this.CustomerInvoiceInvoiceNumberChangeUI.Size = new System.Drawing.Size(100, 23);
            this.CustomerInvoiceInvoiceNumberChangeUI.TabIndex = 3;
            this.CustomerInvoiceInvoiceNumberChangeUI.Text = "Change UI";
            //
            // CustomerInvoiceInvoiceDateGrp
            //
            this.CustomerInvoiceInvoiceDateGrp.Controls.Add(this.CustomerInvoiceInvoiceDateUI);
            this.CustomerInvoiceInvoiceDateGrp.Controls.Add(this.CustomerInvoiceInvoiceDateChangeBO);
            this.CustomerInvoiceInvoiceDateGrp.Controls.Add(this.CustomerInvoiceInvoiceDateBO);
            this.CustomerInvoiceInvoiceDateGrp.Controls.Add(this.label10);
            this.CustomerInvoiceInvoiceDateGrp.Controls.Add(this.CustomerInvoiceInvoiceDateChangeUI);
            this.CustomerInvoiceInvoiceDateGrp.Location = new System.Drawing.Point(12, 388);
            this.CustomerInvoiceInvoiceDateGrp.Name = "CustomerInvoiceInvoiceDateGrp";
            this.CustomerInvoiceInvoiceDateGrp.Size = new System.Drawing.Size(279, 88);
            this.CustomerInvoiceInvoiceDateGrp.TabIndex = 9;
            this.CustomerInvoiceInvoiceDateGrp.TabStop = false;
            this.CustomerInvoiceInvoiceDateGrp.Text = "<Customer>.Invoice.InvoiceDate";
            //
            // CustomerInvoiceInvoiceDateUI
            //
            this.CustomerInvoiceInvoiceDateUI.Location = new System.Drawing.Point(11, 21);
            this.CustomerInvoiceInvoiceDateUI.Name = "CustomerInvoiceInvoiceDateUI";
            this.CustomerInvoiceInvoiceDateUI.Size = new System.Drawing.Size(120, 20);
            this.CustomerInvoiceInvoiceDateUI.TabIndex = 2;
            //
            // CustomerInvoiceInvoiceDateChangeBO
            //
            this.CustomerInvoiceInvoiceDateChangeBO.Location = new System.Drawing.Point(162, 19);
            this.CustomerInvoiceInvoiceDateChangeBO.Name = "CustomerInvoiceInvoiceDateChangeBO";
            this.CustomerInvoiceInvoiceDateChangeBO.Size = new System.Drawing.Size(100, 23);
            this.CustomerInvoiceInvoiceDateChangeBO.TabIndex = 1;
            this.CustomerInvoiceInvoiceDateChangeBO.Text = "Change BO";
            //
            // CustomerInvoiceInvoiceDateBO
            //
            this.CustomerInvoiceInvoiceDateBO.Location = new System.Drawing.Point(36, 56);
            this.CustomerInvoiceInvoiceDateBO.Name = "CustomerInvoiceInvoiceDateBO";
            this.CustomerInvoiceInvoiceDateBO.Size = new System.Drawing.Size(120, 16);
            this.CustomerInvoiceInvoiceDateBO.TabIndex = 5;
            this.CustomerInvoiceInvoiceDateBO.Text = "";
            //
            // label10
            //
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "BO";
            //
            // CustomerInvoiceInvoiceDateChangeUI
            //
            this.CustomerInvoiceInvoiceDateChangeUI.Location = new System.Drawing.Point(162, 51);
            this.CustomerInvoiceInvoiceDateChangeUI.Name = "CustomerInvoiceInvoiceDateChangeUI";
            this.CustomerInvoiceInvoiceDateChangeUI.Size = new System.Drawing.Size(100, 23);
            this.CustomerInvoiceInvoiceDateChangeUI.TabIndex = 3;
            this.CustomerInvoiceInvoiceDateChangeUI.Text = "Change UI";
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 486);
            this.Controls.Add(this.CustomerInvoiceInvoiceDateGrp);
            this.Controls.Add(this.CustomerInvoiceInvoiceNumberGrp);
            this.Controls.Add(this.CustomerAddressZipCodeGrp);
            this.Controls.Add(this.CustomerAddressCountryGrp);
            this.Controls.Add(this.CustomerNameGrp);
            this.Name = "MainForm";
            this.Text = "Invoices sample (lambda bindings)";
            this.CustomerNameGrp.ResumeLayout(false);
            this.CustomerNameGrp.PerformLayout();
            this.CustomerAddressCountryGrp.ResumeLayout(false);
            this.CustomerAddressCountryGrp.PerformLayout();
            this.CustomerAddressZipCodeGrp.ResumeLayout(false);
            this.CustomerAddressZipCodeGrp.PerformLayout();
            this.CustomerInvoiceInvoiceNumberGrp.ResumeLayout(false);
            this.CustomerInvoiceInvoiceNumberGrp.PerformLayout();
            this.CustomerInvoiceInvoiceDateGrp.ResumeLayout(false);
            this.CustomerInvoiceInvoiceDateGrp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button CustomerNameChangeBO;
        private Wisej.Web.TextBox CustomerNameUI;
        private Wisej.Web.Button CustomerNameChangeUI;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label CustomerNameBO;
        private Wisej.Web.GroupBox CustomerNameGrp;
        private Wisej.Web.GroupBox CustomerAddressCountryGrp;
        private Wisej.Web.TextBox CustomerAddressCountryUI;
        private Wisej.Web.Button CustomerAddressCountryChangeBO;
        private Wisej.Web.Label CustomerAddressCountryBO;
        private Wisej.Web.Label label4;
        private Wisej.Web.Button CustomerAddressCountryChangeUI;
        private Wisej.Web.GroupBox CustomerAddressZipCodeGrp;
        private Wisej.Web.TextBox CustomerAddressZipCodeUI;
        private Wisej.Web.Button CustomerAddressZipCodeChangeBO;
        private Wisej.Web.Label CustomerAddressZipCodeBO;
        private Wisej.Web.Label label6;
        private Wisej.Web.Button CustomerAddressZipCodeChangeUI;
        private Wisej.Web.GroupBox CustomerInvoiceInvoiceNumberGrp;
        private Wisej.Web.TextBox CustomerInvoiceInvoiceNumberUI;
        private Wisej.Web.Button CustomerInvoiceInvoiceNumberChangeBO;
        private Wisej.Web.Label CustomerInvoiceInvoiceNumberBO;
        private Wisej.Web.Label label8;
        private Wisej.Web.Button CustomerInvoiceInvoiceNumberChangeUI;
        private Wisej.Web.GroupBox CustomerInvoiceInvoiceDateGrp;
        private Wisej.Web.TextBox CustomerInvoiceInvoiceDateUI;
        private Wisej.Web.Button CustomerInvoiceInvoiceDateChangeBO;
        private Wisej.Web.Label CustomerInvoiceInvoiceDateBO;
        private Wisej.Web.Label label10;
        private Wisej.Web.Button CustomerInvoiceInvoiceDateChangeUI;
    }
}

