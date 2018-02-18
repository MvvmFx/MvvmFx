using System;
using System.Collections.Generic;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using BoundTreeView.Framework;
using BoundTreeView.Properties;
using BoundTreeView.ViewModels;
using FamilyBusiness;
using MvvmFx.CaliburnMicro;
using MvvmFx.Bindings.Data;
using Binding = MvvmFx.Bindings.Data.Binding;

namespace BoundTreeView.Views
{
    public partial class FamilyMemberEditView : UserControl, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        private bool _isBindingSet;

        public FamilyMemberEditView()
        {
            InitializeComponent();
            model_Name.Focus();
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private FamilyMemberEditViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    var viewModel = value as FamilyMemberEditViewModel;
                    if (viewModel != null)
                    {
                        _viewModel = viewModel;
                        Bind();
                        DataContextChanged(this, new DataContextChangedEventArgs());
                    }
                }
            }
        }

        #endregion

        #region Manage manual bindings and combo box data sources

        private void Bind()
        {
            if (_isBindingSet)
                return;

            if (modelDeleteMode.ComboBox != null)
                SetDeleteModeComboBoxDataSource();

            if (modelGender != null)
                SetGenderComboBoxDataSource();

            modelDateOfBirth.DataBindings.Add(new System.Windows.Forms.Binding("Text", _viewModel.Model, "DateOfBirth", false, DataSourceUpdateMode.OnValidation));

            _bindingManager.Bindings.Add(new Binding(modelDeleteMode.ComboBox, "Text", _viewModel.Model as FamilyMember, "DeleteMode")
            {
                Converter = new DeleteModeDescriptionConverter(),
                Mode = BindingMode.TwoWay
            });

            _bindingManager.Bindings.Add(new Binding(modelGender, "Text", _viewModel.Model as FamilyMember, "Gender")
            {
                Converter = new GenderConverter(),
                Mode = BindingMode.TwoWay
            });

            _bindingManager.Bindings.Add(new Binding(modelParentId, "Text", _viewModel.Model as FamilyMember, "ParentId")
            {
                Converter = new IntegerToStringConverter(),
                Mode = BindingMode.TwoWay
            });

            _isBindingSet = true;
        }

        private void SetDeleteModeComboBoxDataSource()
        {
            if (modelDeleteMode.ComboBox == null)
                return;

            var ds = new List<string>
            {
                Resources.Cascade_Delete,
                Resources.Bypass_Deleted_Node,
                Resources.Orphan_Child_Nodes
            };

            modelDeleteMode.ComboBox.DataSource = ds;
        }

        private void SetGenderComboBoxDataSource()
        {
            if (modelDeleteMode.ComboBox == null)
                return;

            var ds = new List<string>
            {
                string.Empty,
                Resources.Gender_Male,
                Resources.Gender_Female
            };

            modelGender.DataSource = ds;
        }

        #endregion
    }
}