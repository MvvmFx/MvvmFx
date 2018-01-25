using System.ComponentModel;
using BoundTreeView.Framework;
using BoundTreeView.Properties;
using FamilyBusiness;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace BoundTreeView.ViewModels
{
    public class FamilyMemberEditViewModel : Screen
    {
        #region Fields and properties

        private static readonly BindingManager BindingManager = new BindingManager();

        private MainFormViewModel _menuObject;

        private FamilyMemberTreeViewModel _treeView;

        private FamilyMember _model;

        public object Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = (FamilyMember) value;
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        #endregion

        #region Initializers

        internal FamilyMemberEditViewModel()
        {
            DisplayName = "Edit FamilyMember #";
        }

        public FamilyMemberEditViewModel(int memberId) : this()
        {
            DisplayName += memberId;
            PropertyChanged += OnFamilyMemberEditViewModelPropertyChanged;
            Model = FamilyMember.GetFamilyMemberById(memberId);
        }

        private void OnFamilyMemberEditViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                PropertyChanged -= OnFamilyMemberEditViewModelPropertyChanged;
                _treeView = Parent as FamilyMemberTreeViewModel;
                if (_treeView != null)
                    _menuObject = _treeView.Parent as MainFormViewModel;
                Bind();
            }
        }

        #endregion

        #region Binders

        private void Bind()
        {
            // clear old bindings
            BindingManager.Bindings.Clear();

            // bind to main form properties
            BindMenuItem("CanSaveFamilyMember", "CanSave");
            BindMenuItem("CanCreateFamilyMember", "CanCreate");
            BindMenuItem("CanDeleteFamilyMember", "CanDelete");

            CanCreate = true;
            CanSave = false;
            CanDelete = false;

            if (Model != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreate", Model as FamilyMember, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
                    Mode = BindingMode.OneWayToTarget
                });

                BindingManager.Bindings.Add(new Binding(this, "CanSave", Model as FamilyMember, "IsSavable")
                {
                    Mode = BindingMode.OneWayToTarget
                });

                CanDelete = true;
            }
        }

        private void BindMenuItem(string target, string source)
        {
            BindingManager.Bindings.Add(new Binding(_menuObject, target, this, source)
            {
                Mode = BindingMode.OneWayToTarget
            });
        }

        #endregion

        #region Actions methods and guard properties

        public void Create()
        {
            int? treeItemId = null;
            if (_treeView != null)
                treeItemId = _treeView.TreeItemId;

            var familyMember = FamilyMember.AddNewFamilyMember(treeItemId, Resources.New_Node_Name);
            if (_treeView != null)
                _treeView.TreeItemId = familyMember.FamilyMemberId;

            TryClose();
        }

        private bool _canCreate;

        public bool CanCreate
        {
            get { return _canCreate; }
            set
            {
                if (_canCreate != value)
                {
                    _canCreate = value;
                    NotifyOfPropertyChange("CanCreate");
                }
            }
        }

        public void Save()
        {
            _model.Save();
        }

        private bool _canSave;

        public bool CanSave
        {
            get { return _canSave; }
            set
            {
                if (_canSave != value)
                {
                    _canSave = value;
                    NotifyOfPropertyChange("CanSave");
                }
            }
        }

        public void Delete()
        {
            _model.Delete();

            CanCreate = true;
            CanSave = false;
            CanDelete = false;

            TryClose();
        }

        private bool _canDelete = true;

        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    NotifyOfPropertyChange("CanDelete");
                }
            }
        }

        public void Close()
        {
            TryClose();
            ((FamilyMemberTreeViewModel) Parent).TreeItemId = -1;
            BindingManager.Bindings.Clear();
        }

        #endregion
    }
}