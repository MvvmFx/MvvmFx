using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MasterDetailWithModel.ViewModels;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using StudentsBusiness;
using Binding = MvvmFx.Windows.Data.Binding;

namespace MasterDetailWithModel.Views
{
    public partial class StudentMasterDetailView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public StudentMasterDetailView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private StudentMasterDetailViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as StudentMasterDetailViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;
                        // as it is, it will select the first item of the list

                        // comment to start with no item selected
                        var binding = new Binding();
                        binding.SourceObject = _viewModel;
                        binding.SourcePath = "ListItemId";
                        binding.TargetObject = listBox1;
                        binding.TargetPath = "SelectedValue";
                        binding.Mode = BindingMode.TwoWay;
                        _bindingManager.Bindings.Add(binding);

                        listBox1.DataSource = ((StudentEditMasterDetail) _viewModel.Model).Students;
                        listBox1.DisplayMember = "FullName";
                        listBox1.ValueMember = "StudentId";

                        // uncomment to start with no item selected
                        /*listBox1.ClearSelected();

                        var binding = new Binding();
                        binding.SourceObject = _viewModel;
                        binding.SourcePath = "ListItemId";
                        binding.TargetObject = listBox1;
                        binding.TargetPath = "SelectedValue";
                        binding.Mode = BindingMode.TwoWay;
                        _bindingManager.Bindings.Add(binding);*/

                        SetVisibilityBindings();
                    }
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        private void SetVisibilityBindings()
        {
            var binding = new Binding();
            binding.SourceObject = _viewModel;
            binding.SourcePath = "StudentOpen";
            binding.TargetObject = studentEditPanel;
            binding.TargetPath = "Visible";
            binding.Mode = BindingMode.OneWayToTarget;
            _bindingManager.Bindings.Add(binding);
        }

        #endregion
    }
}