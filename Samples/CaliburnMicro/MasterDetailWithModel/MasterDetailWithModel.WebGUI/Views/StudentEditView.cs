using System;
using Gizmox.WebGUI.Forms;
using MasterDetailWithModel.ViewModels;
using MvvmFx.CaliburnMicro;

namespace MasterDetailWithModel.Views
{
    public partial class StudentEditView : UserControl, IHaveDataContext
    {
        public StudentEditView()
        {
            InitializeComponent();
            model_FirstName.Focus();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private StudentEditViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as StudentEditViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;
                        DataContextChanged(this, new DataContextChangedEventArgs());
                    }
                }
            }
        }

        #endregion
    }
}