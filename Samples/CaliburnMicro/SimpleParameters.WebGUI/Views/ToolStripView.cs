using System;
using Gizmox.WebGUI.Forms;
using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.ViewModels;

namespace SimpleParameters.UI.Views
{
    public partial class ToolStripView : UserControl, IHaveDataContext
    {
        public ToolStripView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private ToolStripViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as ToolStripViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}