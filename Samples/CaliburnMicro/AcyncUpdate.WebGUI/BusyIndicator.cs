using System;
using Gizmox.WebGUI.Forms;

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
            Visible = false;
            SendToBack();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private System.ComponentModel.IContainer components;

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
                    StartBusy();
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

        private void StartBusy()
        {
            timer.Enabled = true;
            timer.Start();
            BringToFront();
            Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!_isBusy)
            {
                Visible = false;
                SendToBack();
                timer.Stop();
                timer.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusyIndicator));
            this.Message = new Gizmox.WebGUI.Forms.Label();
            this.pictureBox = new Gizmox.WebGUI.Forms.PictureBox();
            this.timer = new Gizmox.WebGUI.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.Message.Location = new System.Drawing.Point(10, 62);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(50, 13);
            this.Message.TabIndex = 1;
            this.Message.Text = "Message";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.pictureBox.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox.Image"));
            this.pictureBox.Location = new System.Drawing.Point(11, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(48, 48);
            this.pictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // BusyIndicator
            // 
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Message);
            this.Size = new System.Drawing.Size(71, 83);
            this.RegisteredTimers = new Gizmox.WebGUI.Forms.Timer[]
            {
                this.timer
            };
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        private Label Message;
        private PictureBox pictureBox;
        private Timer timer;
    }
}