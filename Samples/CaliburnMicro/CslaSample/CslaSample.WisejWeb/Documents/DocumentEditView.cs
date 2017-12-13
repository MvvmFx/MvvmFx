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
                        model_DocumentReference.DataBindings.Add(new Binding("Text", _viewModel.Model, "DocumentReference", false, DataSourceUpdateMode.OnValidation));
                        model_DocumentDate.DataBindings.Add(new Binding("Text", _viewModel.Model, "DocumentDate", false, DataSourceUpdateMode.OnValidation));
                        model_Subject.DataBindings.Add(new Binding("Text", _viewModel.Model, "Subject", false, DataSourceUpdateMode.OnValidation));
                        model_Sender.DataBindings.Add(new Binding("Text", _viewModel.Model, "Sender", false, DataSourceUpdateMode.OnValidation));
                        model_Receiver.DataBindings.Add(new Binding("Text", _viewModel.Model, "Receiver", false, DataSourceUpdateMode.OnValidation));
                        model_TextContent.DataBindings.Add(new Binding("Text", _viewModel.Model, "TextContent", false, DataSourceUpdateMode.OnValidation));
                        errorProvider.DataSource = _viewModel.Model;
                        DataContextChanged(this, new DataContextChangedEventArgs());
                    }

                }
            }
        }

        #endregion
    }
}