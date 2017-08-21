using System;
using System.Windows.Forms;

namespace WinFormsTreeSelectedNode
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            MessageBox.Show(string.Format("BeforeSelect - node: {0}", e.Node == null ? "NULL" : e.Node.Text),
                "Trace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(string.Format("AfterSelect - node: {0}", e.Node == null ? "NULL" : e.Node.Text),
                "Trace", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == treeNode11)
            {
                MessageBox.Show("Select null node", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                treeView1.SelectedNode = null;
                MessageBox.Show("End Step 2\r\nNote no Select event will be raised.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Text = "Step 1";
            }
            else
            {
                MessageBox.Show("Select Node 1.1", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                treeView1.SelectedNode = treeNode11;
                treeView1.Focus();
                MessageBox.Show("End Step 1", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Text = "Step 2";
            }
        }
    }
}
