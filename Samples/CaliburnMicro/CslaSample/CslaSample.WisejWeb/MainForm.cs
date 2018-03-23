using System;
using System.Collections.Generic;
using Wisej.Web;
using MvvmFx.CaliburnMicro;
using MvvmFx.Bindings.Data;

namespace CslaSample
{
    public partial class MainForm : Form, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        private bool _isBindingSet;

        private List<Control> _namedElements;

        public MainForm()
        {
            InitializeComponent();

            Closed += MainFormClosed;
        }

        private void MainFormClosed(object sender, EventArgs e)
        {
            Close();
        }

        public new void Close()
        {
            Application.Exit();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private MainFormViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as MainFormViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion

        #region Bind menu items

        public void BindMenuItems(List<Control> namedElements)
        {
            if (_isBindingSet)
                return;

            // Prepare to bind the control visible and enabled properties.
            _namedElements = namedElements;

            //_isBindingSet = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_isBindingSet || _namedElements == null)
                return;

            // Binds the control visible and enabled properties.
            WinFormExtensionMethods.BindComponentProxyProperties(_namedElements, _viewModel, _bindingManager);

            _isBindingSet = true;
        }

        #endregion
    }
}