using System;
using Gizmox.WebGUI.Forms;

namespace Test.FormScrollBar
{
    public partial class FormScrollBar : Form
    {
        public FormScrollBar()
        {
            InitializeComponent();
        }

        private void FormScrollBar_Load(object sender, EventArgs e)
        {
            for (var item = 0; item < 30; item++)
            {
                var line = "Item " + item;
                listBox1.Items.Add(line);
            }
        }
    }
}