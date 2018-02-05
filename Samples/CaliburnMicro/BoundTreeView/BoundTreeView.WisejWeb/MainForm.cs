using System;
using System.Collections.Generic;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
#if WISEJ
using Wisej.Web;
using LogManager = MvvmFx.WisejWeb.LogManager;
#else
using System.Windows.Forms;
using LogManager = MvvmFx.Windows.Forms.LogManager;
#endif

namespace BoundTreeView
{
    public partial class MainForm : Page, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        private bool _isBindingSet;

        private List<Control> _namedElements;

        public MainForm()
        {
            InitializeComponent();
            LogManager.GetLog = type => new MvvmFx.Logging.DebugLogger(type);
        }

        public void Close()
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