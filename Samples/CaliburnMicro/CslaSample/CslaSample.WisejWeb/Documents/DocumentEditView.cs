using System;
using Wisej.Web;
using MvvmFx.CaliburnMicro;

namespace CslaSample.Documents
{
    public partial class DocumentEditView : UserControl, IHaveDataContext
    {
        public DocumentEditView()
        {
            InitializeComponent();
            model_DocumentReference.Focus();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private DocumentEditViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as DocumentEditViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;
                        model_DocumentDate.DataBindings.Add(new Binding("Text", _viewModel.Model, "DocumentDate", false, DataSourceUpdateMode.OnValidation));
                        DataContextChanged(this, new DataContextChangedEventArgs());
                    }
                }
            }
        }

        #endregion
    }
}