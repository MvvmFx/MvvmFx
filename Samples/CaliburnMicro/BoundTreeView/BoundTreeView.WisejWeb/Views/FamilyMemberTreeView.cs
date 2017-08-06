using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using BoundTreeView.ViewModels;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;

namespace BoundTreeView.Views
{
    public partial class FamilyMemberTreeView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public FamilyMemberTreeView()
        {
            InitializeComponent();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private FamilyMemberTreeViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as FamilyMemberTreeViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;

                        boundTreeView1.DataSource = _viewModel.Model;
                        boundTreeView1.DisplayMember = "Name";
                        boundTreeView1.IdentifierMember = "FamilyMemberId";
                        boundTreeView1.ParentIdentifierMember = "ParentId";
                        boundTreeView1.ValueMember = "FamilyMemberId";

                        var binding = new Binding();
                        binding.SourceObject = _viewModel;
                        binding.SourcePath = "TreeItemId";
                        binding.TargetObject = boundTreeView1;
                        binding.TargetPath = "SelectedValue";
                        binding.Mode = BindingMode.TwoWay;
                        _bindingManager.Bindings.Add(binding);
                    }
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}