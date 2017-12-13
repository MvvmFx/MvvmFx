using System;
using Wisej.Web;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;

namespace CslaSample.Documents
{
    public partial class FolderListView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public FolderListView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private FolderListViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                var viewModel = value as FolderListViewModel;
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
                    binding.TargetObject = folderListBox;
                    binding.TargetPath = "SelectedValue";
                    binding.Mode = BindingMode.TwoWay;
                    _bindingManager.Bindings.Add(binding);

                    folderListBox.DataSource = _viewModel.Model;
                    folderListBox.DisplayMember = "FolderName";
                    folderListBox.ValueMember = "FolderId";

                    // _viewModel.PropertyChanged += ViewModelPropertyChanged;

                    // uncomment to start with no item selected
                    /*folderListBox.ClearSelected();

                    var binding = new Binding();
                    binding.SourceObject = _viewModel;
                    binding.SourcePath = "ListItemId";
                    binding.TargetObject = folderListBox;
                    binding.TargetPath = "SelectedValue";
                    binding.Mode = BindingMode.TwoWay;
                    _bindingManager.Bindings.Add(binding);*/
                }
                DataContextChanged(this, new DataContextChangedEventArgs());
            }
        }

        public void CancelClose(int selectedValue)
        {
            folderListBox.SelectedValue = selectedValue;
        }

        /*private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Model")
            {
                folderListBox.DataSource = _viewModel.Model;
            }
        }*/

        #endregion
    }
}