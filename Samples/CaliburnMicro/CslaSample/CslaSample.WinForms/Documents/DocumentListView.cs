using System;
using System.Windows.Forms;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;

namespace CslaSample.Documents
{
    public partial class DocumentListView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public DocumentListView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private DocumentListViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                var viewModel = value as DocumentListViewModel;
                if (viewModel != null)
                {
                    _bindingManager.Bindings.Clear();
                    _viewModel = viewModel;

                    var displayNameBinding = new Binding();
                    displayNameBinding.SourceObject = _viewModel;
                    displayNameBinding.SourcePath = "DisplayName";
                    displayNameBinding.TargetObject = displayName;
                    displayNameBinding.TargetPath = "Text";
                    displayNameBinding.Mode = BindingMode.OneWayToTarget;
                    _bindingManager.Bindings.Add(displayNameBinding);

                    // as it is, it will select the first item of the list

                    // comment to start with no item selected
                    var binding = new Binding();
                    binding.SourceObject = _viewModel;
                    binding.SourcePath = "ListItemId";
                    binding.TargetObject = documentListBox;
                    binding.TargetPath = "SelectedValue";
                    binding.Mode = BindingMode.TwoWay;
                    _bindingManager.Bindings.Add(binding);

                    documentListBox.DataSource = _viewModel.Model;
                    documentListBox.DisplayMember = "Subject";
                    documentListBox.ValueMember = "DocumentId";

                    // _viewModel.PropertyChanged += ViewModelPropertyChanged;

                    // uncomment to start with no item selected
                    /*documentListBox.ClearSelected();

                    var binding = new Binding();
                    binding.SourceObject = _viewModel;
                    binding.SourcePath = "ListItemId";
                    binding.TargetObject = documentListBox;
                    binding.TargetPath = "SelectedValue";
                    binding.Mode = BindingMode.TwoWay;
                    _bindingManager.Bindings.Add(binding);*/
                }
                DataContextChanged(this, new DataContextChangedEventArgs());
            }
        }

        public void CancelClose(int selectedValue)
        {
            documentListBox.SelectedValue = selectedValue;
        }

        /*private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Model")
            {
                documentListBox.DataSource = _viewModel.Model;
            }
        }*/

        #endregion
    }
}