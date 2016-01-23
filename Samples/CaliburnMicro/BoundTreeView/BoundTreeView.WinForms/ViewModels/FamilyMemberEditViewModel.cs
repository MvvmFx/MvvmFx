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
            BindMenuItem("CanCreateNewFamilyMember", "CanCreateNew");
            BindMenuItem("CanDeleteFamilyMember", "CanDelete");
            BindMenuItem("CanCloseFamilyMember", "CanClose");

            CanCreateNew = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

            if (Model != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreateNew", Model as FamilyMember, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
                    Mode = BindingMode.OneWayToTarget
                });

                BindingManager.Bindings.Add(new Binding(this, "CanSave", Model as FamilyMember, "IsSavable")
                {
                    Mode = BindingMode.OneWayToTarget
                });

                CanDelete = true;
                CanClose = true;
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

        public void CreateNew()
        {
            int? treeItemId = null;
            if (_treeView != null)
                treeItemId = _treeView.TreeItemId;

            var familyMember = FamilyMember.AddNewFamilyMember(treeItemId, Resources.New_Node_Name);
            if (_treeView != null)
                _treeView.TreeItemId = familyMember.FamilyMemberId;

            TryClose();
        }

        private bool _canCreateNew;

        public bool CanCreateNew
        {
            get { return _canCreateNew; }
            set
            {
                if (_canCreateNew != value)
                {
                    _canCreateNew = value;
                    NotifyOfPropertyChange("CanCreateNew");
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

            var cnt = ((FamilyMemberInfoList) _treeView.Model).Count;

            CanCreateNew = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

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

        private bool _canClose = true;

        public new bool CanClose
        {
            get { return _canClose; }
            set
            {
                if (_canClose != value)
                {
                    _canClose = value;
                    NotifyOfPropertyChange("CanClose");
                }
            }
        }

        #endregion
    }
}