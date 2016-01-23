using System;
using System.Windows.Forms;
using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.ViewModels;

namespace SimpleParameters.UI.Views
{
    public partial class MenuStripView : UserControl, IHaveDataContext
    {
        public MenuStripView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private MenuStripViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as MenuStripViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}