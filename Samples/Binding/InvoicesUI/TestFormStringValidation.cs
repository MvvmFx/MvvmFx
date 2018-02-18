using System;
using System.Globalization;
using System.Windows.Forms;
using InvoicesBusiness;
using MvvmFx.Bindings.Data;
using Binding = MvvmFx.Bindings.Data.Binding;

namespace InvoicesUI
{
    public partial class TestFormStringValidation : Form
    {
        private BindingManager _bindingManager;
        private Customer _customer;

        public TestFormStringValidation()
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
            _bindingManager.Bindings.Add(new Binding(CustomerNameUI, "Text", _customer, "Name"));
            _bindingManager.Bindings.Add(new Binding(CustomerNameBO, "Text", _customer, "Name"));

            var address = _customer.Address;
            _bindingManager.Bindings.Add(new Binding(CustomerAddressCountryUI, "Text", address, "Country"));
            _bindingManager.Bindings.Add(new Binding(CustomerAddressCountryBO, "Text", address, "Country"));
            _bindingManager.Bindings.Add(new Binding(CustomerAddressZipCodeUI, "Text", _customer, "Address.ZipCode"));
            _bindingManager.Bindings.Add(new Binding(CustomerAddressZipCodeBO, "Text", _customer, "Address.ZipCode"));

            var invoice = _customer.Invoice;
            _bindingManager.Bindings.Add(new Binding(CustomerInvoiceInvoiceNumberUI, "Text", invoice, "InvoiceNumber"));
            _bindingManager.Bindings.Add(new Binding(CustomerInvoiceInvoiceNumberBO, "Text", invoice, "InvoiceNumber"));
            var invoicedateBinding = new Binding(CustomerInvoiceInvoiceDateUI, "Text", _customer, "Invoice.InvoiceDate");
            invoicedateBinding.Converter = new DateTimeToDateConverter();
            invoicedateBinding.ConverterCulture = CultureInfo.CurrentCulture;
            _bindingManager.Bindings.Add(invoicedateBinding);
            _bindingManager.Bindings.Add(new Binding
            {
                TargetObject = CustomerInvoiceInvoiceDateBO,
                TargetPath = "Text",
                SourceObject = _customer,
                SourcePath = "Invoice.InvoiceDate",
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
