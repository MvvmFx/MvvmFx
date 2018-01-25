using System;
using System.Collections.Generic;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;

namespace MasterDetailWithModel
{
    public partial class MainForm : Form, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        private bool _isBindingSet;

        public MainForm()
        {
            InitializeComponent();
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

            // Binds the control visible and enabled properties.
            WinFormExtensionMethods.BindToolStripItemProxyProperties(namedElements, _viewModel, _bindingManager);

            _isBindingSet = true;
        }

        #endregion
    }
}