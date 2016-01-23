using System;
using Gizmox.WebGUI.Forms;
using MvvmFx.CaliburnMicro;

namespace SimpleParameters.UI
{
    public partial class ShellView : Form, IHaveDataContext
    {
        public ShellView()
        {
            InitializeComponent();
            new AppBootstrapper(this).Run();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private ShellViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as ShellViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}