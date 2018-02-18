using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MasterDetailWithModel.ViewModels;
using MvvmFx.CaliburnMicro;
using MvvmFx.Bindings.Data;
using Binding = MvvmFx.Bindings.Data.Binding;

namespace MasterDetailWithModel.Views
{
    public partial class StudentListView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public StudentListView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private StudentListViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as StudentListViewModel;
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

                        listBox1.DataSource = _viewModel.Model;
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
                    }
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}