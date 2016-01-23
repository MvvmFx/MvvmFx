using System;
using System.Windows.Forms;

namespace AcyncUpdate.UI
{
    public interface IBusyIndicator
    {
        bool IsBusy { get; set; }
        string BusyContent { get; set; }
    }

    public class BusyIndicator : UserControl, IBusyIndicator
    {
        public BusyIndicator()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                }

                if (_isBusy)
                    BringToFront();
                else
                    SendToBack();

                Visible = _isBusy;
            }
        }

        public string BusyContent
        {
            get { return Message.Text; }
            set
            {
                if (value != Message.Text)
                    Message.Text = value;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof (BusyIndicator));
            this.Message = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.Message.Location = new System.Drawing.Point(10, 62);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(50, 13);
            this.Message.TabIndex = 1;
            this.Message.Text = "Message";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BusyIndicator
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Message);
            this.Name = "BusyIndicator";
            this.Size = new System.Drawing.Size(71, 83);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label Message;
        private PictureBox pictureBox1;
    }
}