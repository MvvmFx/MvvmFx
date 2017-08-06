using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.ViewModels;

namespace SimpleParameters.UI.Views
{
    public partial class ButtonView : UserControl, IHaveDataContext
    {
        public ButtonView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private ButtonViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as ButtonViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}