using System;
using System.Globalization;
using System.Windows.Forms;
using InvoicesBusiness;
using MvvmFx.Bindings.Data;

namespace InvoicesUI
{
    public partial class TestFormLambdaValidation : Form
    {
        private BindingManager _bindingManager;
        private Customer _customer;

        public TestFormLambdaValidation()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            AddBindings();
            AddButtonGestures();
        }

        private void AddBindings()
        {
            _customer = new Customer();
            _bindingManager = new BindingManager();
            _bindingManager.BindOnValidation = true;
            _bindingManager.Bindings.Add(
                new TypedBinding<TextBox, Customer>(CustomerNameUI, t => t.Text, _customer, s => s.Name));
            _bindingManager.Bindings.Add(
                new TypedBinding<Label, Customer>(CustomerNameBO, t => t.Text, _customer, s => s.Name));

            var address = _customer.Address;
            _bindingManager.Bindings.Add(
                new TypedBinding<TextBox, Address>(CustomerAddressCountryUI, t => t.Text, address, s => s.Country));
            _bindingManager.Bindings.Add(
                new TypedBinding<Label, Address>(CustomerAddressCountryBO, t => t.Text, address, s => s.Country));
            _bindingManager.Bindings.Add(
                new TypedBinding<TextBox, Customer>(CustomerAddressZipCodeUI, t => t.Text, _customer, s => s.Address.ZipCode));
            _bindingManager.Bindings.Add(
                new TypedBinding<Label, Customer>(CustomerAddressZipCodeBO, t => t.Text, _customer, s => s.Address.ZipCode));

            var invoice = _customer.Invoice;
            _bindingManager.Bindings.Add(
                new TypedBinding<TextBox, Invoice>(CustomerInvoiceInvoiceNumberUI, t => t.Text, invoice, s => s.InvoiceNumber));
            _bindingManager.Bindings.Add(
                new TypedBinding<Label, Invoice>(CustomerInvoiceInvoiceNumberBO, t => t.Text, invoice, s => s.InvoiceNumber));
            var invoicedateBinding = new TypedBinding<TextBox, Customer>(CustomerInvoiceInvoiceDateUI, t => t.Text, _customer, s => s.Invoice.InvoiceDate);
            invoicedateBinding.Converter = new DateTimeToDateConverter();
            invoicedateBinding.ConverterCulture = CultureInfo.CurrentCulture;
            _bindingManager.Bindings.Add(invoicedateBinding);
            _bindingManager.Bindings.Add(new TypedBinding<Label, Customer>
            {
                TargetObject = CustomerInvoiceInvoiceDateBO,
                TargetExpression = t => t.Text,
                SourceObject = _customer,
                SourceExpression = s => s.Invoice.InvoiceDate,
                Converter = new DateTimeToDateConverter(),
                ConverterCulture = CultureInfo.CurrentCulture
            });
        }

        private void AddButtonGestures()
        {
            CustomerNameChangeBO.Click += CustomerNameChangeBO_Click;
            CustomerNameChangeUI.Click += CustomerNameChangeUI_Click;
            CustomerAddressCountryChangeBO.Click += CustomerAddressCountryChangeBO_Click;
            CustomerAddressCountryChangeUI.Click += CustomerAddressCountryChangeUI_Click;
            CustomerAddressZipCodeChangeBO.Click += CustomerAddressZipCodeChangeBO_Click;
            CustomerAddressZipCodeChangeUI.Click += CustomerAddressZipCodeChangeUI_Click;
            CustomerInvoiceInvoiceNumberChangeBO.Click += CustomerInvoiceInvoiceNumberChangeBO_Click;
            CustomerInvoiceInvoiceNumberChangeUI.Click += CustomerInvoiceInvoiceNumberChangeUI_Click;
            CustomerInvoiceInvoiceDateChangeBO.Click += CustomerInvoiceInvoiceDateChangeBO_Click;
            CustomerInvoiceInvoiceDateChangeUI.Click += CustomerInvoiceInvoiceDateChangeUI_Click;
        }

        private void CustomerNameChangeBO_Click(object sender, EventArgs e)
        {
            _customer.Name = "Lone Ranger (BO)";
        }

        private void CustomerNameChangeUI_Click(object sender, EventArgs e)
        {
            CustomerNameUI.Text = "Silver (UI)";
        }

        private void CustomerAddressCountryChangeBO_Click(object sender, EventArgs eventArgs)
        {
            _customer.Address.Country = "Borozukisthan (BO)";
        }

        private void CustomerAddressCountryChangeUI_Click(object sender, EventArgs eventArgs)
        {
            CustomerAddressCountryUI.Text = "Protogea (UI)";
        }

        private void CustomerAddressZipCodeChangeBO_Click(object sender, EventArgs e)
        {
            _customer.Address.ZipCode = "90210 (BO)";
        }

        private void CustomerAddressZipCodeChangeUI_Click(object sender, EventArgs e)
        {
            CustomerAddressZipCodeUI.Text = "21090 (UI)";
        }

        private void CustomerInvoiceInvoiceNumberChangeBO_Click(object sender, EventArgs e)
        {
            _customer.Invoice.InvoiceNumber = 1;
        }

        private void CustomerInvoiceInvoiceNumberChangeUI_Click(object sender, EventArgs e)
        {
            CustomerInvoiceInvoiceNumberUI.Text = "22";
        }

        private void CustomerInvoiceInvoiceDateChangeBO_Click(object sender, EventArgs e)
        {
            _customer.Invoice.InvoiceDate = new DateTime(2011, 12, 31);
        }

        private void CustomerInvoiceInvoiceDateChangeUI_Click(object sender, EventArgs e)
        {
            CustomerInvoiceInvoiceDateUI.Text = DateTime.Today.ToString("d", CultureInfo.CurrentCulture);
        }
    }
}
