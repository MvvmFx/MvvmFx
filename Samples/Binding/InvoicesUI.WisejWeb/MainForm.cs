using System;
using Wisej.Web;

namespace InvoicesUI.WisejWeb
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void stringBindingsINPC_Click(object sender, EventArgs e)
        {
            var testForm = new TestFormStringINPC();
            testForm.ShowDialog();
        }

        private void lambdaBindingsINPC_Click(object sender, EventArgs e)
        {
            var testForm = new TestFormLambdaINPC();
            testForm.ShowDialog();
        }

        private void stringBindingsValidation_Click(object sender, EventArgs e)
        {
            var testForm = new TestFormStringValidation();
            testForm.ShowDialog();
        }

        private void lambdaBindingsValidation_Click(object sender, EventArgs e)
        {
            var testForm = new TestFormLambdaValidation();
            testForm.ShowDialog();
        }
    }
}
