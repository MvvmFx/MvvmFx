using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;

#endif

namespace CslaSample.Framework
{
    class ComboValidation : Binding
    {
        private readonly Csla.NameValueListBase<int, String> _nameValueList;
        private int _keyProperty;
        private readonly ComboBox _comboBox;
        private readonly ErrorProvider _errorProvider;
        private readonly string _friendlyName;

        // TODO decide whether to add a basic constructor and create r/w properties for new fields

        public ComboValidation(string propertyName, BindingSource dataSource, string dataMember,
            int keyProperty, ComboBox comboBox, ErrorProvider errorProvider, string friendlyName) :
            base(propertyName, dataSource, dataMember)
        {
            _nameValueList = (Csla.NameValueListBase<int, string>) dataSource.List;
            _keyProperty = keyProperty;
            _comboBox = comboBox;
            _errorProvider = errorProvider;
            _friendlyName = friendlyName;

            FormattingEnabled = true;
            DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
            NullValue = 0;

            Format += OnFormat;
            Parse += OnParse;
        }

        void OnFormat(object sender, ConvertEventArgs e)
        {
            if (_keyProperty > 0)
            {
                _errorProvider.SetError(_comboBox, "");
                return;
            }

            if (string.IsNullOrEmpty(_comboBox.Text))
            {
                e.Value = "";
                _errorProvider.SetError(_comboBox, string.Format("{0} required.", _friendlyName));
            }
        }

        void OnParse(object sender, ConvertEventArgs e)
        {
            if (_nameValueList.Key(_comboBox.Text) > 0)
            {
                _errorProvider.SetError(_comboBox, "");
                return;
            }

            if (_nameValueList.Key(e.Value.ToString()) > 0)
            {
                _comboBox.Text = e.Value.ToString();
                _errorProvider.SetError(_comboBox, "");
                return;
            }

            _keyProperty = 0;
            if (string.IsNullOrEmpty(_comboBox.Text))
            {
                _errorProvider.SetError(_comboBox, string.Format("{0} required.", _friendlyName));
            }
            else
                _errorProvider.SetError(_comboBox, string.Format("{0} isn't a valid {1}.", e.Value, _friendlyName));
        }
    }
}