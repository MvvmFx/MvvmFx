using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlSpy
{
    public partial class ControlSpy : Form
    {
        public ControlSpy()
        {
            InitializeComponent();
        }

        private void spyButton_Click(object sender, EventArgs e)
        {
            var control = new TreeView();
            var attributes = TypeDescriptor.GetProperties(control)[propertyTextBox.Text].Attributes;
            spyTextBox.Text = string.Empty;
            foreach (Attribute attr in attributes)
            {
                if (attr.GetType() == typeof (EditorAttribute))
                {
                    var abc = ((EditorAttribute) attr).ToString();
                    spyTextBox.Text += attr.GetType() + " " + ((EditorAttribute)attr).EditorTypeName + Environment.NewLine;
                }
                else
                    spyTextBox.Text += attr.GetType() + Environment.NewLine;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
