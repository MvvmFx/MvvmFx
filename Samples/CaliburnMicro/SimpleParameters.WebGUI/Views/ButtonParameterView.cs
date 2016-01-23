using System;
using Gizmox.WebGUI.Forms;
using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.ViewModels;

namespace SimpleParameters.UI.Views
{
    public partial class ButtonParameterView : UserControl, IHaveDataContext
    {
        public ButtonParameterView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private ButtonParameterViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as ButtonParameterViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}