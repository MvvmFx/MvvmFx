namespace MvvmFx.WebGUI.Forms
{
    partial class BoundForm
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
            this.components = new System.ComponentModel.Container();
            this.bindingSourceRefresh = new MvvmFx.WebGUI.Forms.BindingSourceRefresh(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // BoundForm
            // 
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "BoundForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The binding source refresh component.
        /// </summary>
        protected BindingSourceRefresh bindingSourceRefresh;
    }
}