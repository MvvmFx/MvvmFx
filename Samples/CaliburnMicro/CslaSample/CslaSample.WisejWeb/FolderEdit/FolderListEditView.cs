using System;
using Wisej.Web;
using MvvmFx.CaliburnMicro;

namespace CslaSample.FolderEdit
{
    public partial class FolderListEditView : Form, IHaveDataContext
    {
        public FolderListEditView()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private FolderListEditViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as FolderListEditViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;

                        foldersDataGridView.DataSource = _viewModel.Model;
                        errorProvider.DataSource = _viewModel.Model;
                        _viewModel.PropertyChanged += ViewModelPropertyChanged;
                    }
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Model")
            {
                foldersDataGridView.DataSource = _viewModel.Model;
            }
        }

        #endregion

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= OnClosing;
            close.PerformClick();
        }
    }
}