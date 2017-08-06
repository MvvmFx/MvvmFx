using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;

namespace SimpleParameters.UI
{
    public partial class ShellView : Form, IHaveDataContext
    {
        public ShellView()
        {
            InitializeComponent();
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