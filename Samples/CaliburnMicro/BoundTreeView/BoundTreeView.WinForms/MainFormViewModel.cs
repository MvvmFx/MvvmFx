using System.Collections.Generic;
using BoundTreeView.ViewModels;
using FamilyBusiness;
using MvvmFx.CaliburnMicro;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace BoundTreeView
{
    public interface IMainFormViewModel : IScreen, IHaveViewNamedElements
    {
    }

    public class MainFormViewModel : Conductor<Screen>, IMainFormViewModel
    {
        #region Fields and properties

        public List<Control> ViewNamedElements { get; set; }

        #endregion

        #region Initializers

        protected override void OnInitialize()
        {
            DisplayName = "Bound TreeView";
            BindMenuItems();
        }

        #endregion

        #region File menu guard visibility properties

        private bool _openFamilyMemberTreeVisible = true;

        public bool OpenFamilyMemberTreeVisible
        {
            get { return _openFamilyMemberTreeVisible; }
            set
            {
                if (_openFamilyMemberTreeVisible != value)
                {
                    _openFamilyMemberTreeVisible = value;
                    NotifyOfPropertyChange("OpenFamilyMemberTreeVisible");
                }
            }
        }

        private bool _closeFamilyMemberTreeVisible;

        public bool CloseFamilyMemberTreeVisible
        {
            get { return _closeFamilyMemberTreeVisible; }
            set
            {
                if (_closeFamilyMemberTreeVisible != value)
                {
                    _closeFamilyMemberTreeVisible = value;
                    NotifyOfPropertyChange("CloseFamilyMemberTreeVisible");
                }
            }
        }

        #endregion

        #region File menu action methods

        public void OpenFamilyMemberTree()
        {
            OpenFamilyMemberTreeVisible = false;
            CloseFamilyMemberTreeVisible = true;
            FamilyMemberMenuVisible = true;

            if (ActiveItem != null)
            {
                if (ActiveItem.GetType() != typeof(FamilyMemberTreeViewModel))
                    ActiveItem.TryClose();
            }
            ActivateItem(new FamilyMemberTreeViewModel());
        }

        public void CloseFamilyMemberTree()
        {
            OpenFamilyMemberTreeVisible = true;
            CloseFamilyMemberTreeVisible = false;
            FamilyMemberMenuVisible = false;

            ActiveItem.TryClose();
            ActivateItem(null);
        }

        public void Exit()
        {
            TryClose();
        }

        private void BindMenuItems()
        {
            var mainForm = GetView() as MainForm;
            if (mainForm != null)
                mainForm.BindMenuItems(ViewNamedElements);
        }

        #endregion

        #region FamilyMember menu guard visibility properties

        private bool _familyMemberMenuVisible;

        public bool FamilyMemberMenuVisible
        {
            get { return _familyMemberMenuVisible; }
            set
            {
                if (_familyMemberMenuVisible != value)
                {
                    _familyMemberMenuVisible = value;
                    NotifyOfPropertyChange("FamilyMemberMenuVisible");
                }
            }
        }

        #endregion

        #region FamilyMember menu action methods and guard properties

        public void CreateFamilyMember()
        {
            if (_canCreateFamilyMember)
            {
                GetFamilyMemberEdit().Create();
                ActivateIfSingleNode();
            }
        }

        private void ActivateIfSingleNode()
        {
            var treeView = (FamilyMemberTreeViewModel) ActiveItem;
            var model = (FamilyMemberInfoList) treeView.Model;

            if (model.Count == 1)
                treeView.TreeItemId = model[0].FamilyMemberId;
        }

        private bool _canCreateFamilyMember;

        public bool CanCreateFamilyMember
        {
            get { return _canCreateFamilyMember; }
            set
            {
                if (_canCreateFamilyMember != value)
                {
                    _canCreateFamilyMember = value;
                    NotifyOfPropertyChange("CanCreateFamilyMember");
                }
            }
        }

        public void SaveFamilyMember()
        {
            GetFamilyMemberEdit().Save();
        }

        private bool _canSaveFamilyMember;

        public bool CanSaveFamilyMember
        {
            get { return _canSaveFamilyMember; }
            set
            {
                if (_canSaveFamilyMember != value)
                {
                    _canSaveFamilyMember = value;
                    NotifyOfPropertyChange("CanSaveFamilyMember");
                }
            }
        }

        public void DeleteFamilyMember()
        {
            GetFamilyMemberEdit().Delete();
        }

        private bool _canDeleteFamilyMember;

        public bool CanDeleteFamilyMember
        {
            get { return _canDeleteFamilyMember; }
            set
            {
                if (_canDeleteFamilyMember != value)
                {
                    _canDeleteFamilyMember = value;
                    NotifyOfPropertyChange("CanDeleteFamilyMember");
                }
            }
        }

        public void CloseFamilyMember()
        {
            GetFamilyMemberEdit().Close();
        }

        private FamilyMemberEditViewModel GetFamilyMemberEdit()
        {
            foreach (var child in GetChildren())
            {
                if (child is IParent)
                {
                    var parent = child as IParent;
                    foreach (var grandChild in parent.GetChildren())
                    {
                        if (grandChild == null)
                            return new FamilyMemberEditViewModel();

                        if (grandChild is FamilyMemberEditViewModel)
                        {
                            return grandChild as FamilyMemberEditViewModel;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }
}