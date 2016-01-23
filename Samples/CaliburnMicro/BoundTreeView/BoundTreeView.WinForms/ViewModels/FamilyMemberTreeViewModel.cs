using System.ComponentModel;
using FamilyBusiness;
using MvvmFx.CaliburnMicro;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace BoundTreeView.ViewModels
{
    public class FamilyMemberTreeViewModel : Conductor<Screen>, IHaveModel
    {
        #region Fields and properties

        private FamilyMemberInfoList _model;

        public object Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = (FamilyMemberInfoList) value;
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        private int _treeItemId;

        public int TreeItemId
        {
            get { return _treeItemId; }
            set
            {
                if (_treeItemId != value)
                {
                    _treeItemId = value;
                    ActivateItem(new FamilyMemberEditViewModel(_treeItemId));
                    NotifyOfPropertyChange("TreeItemId");
                }
            }
        }

        #endregion

        #region Initializers

        public FamilyMemberTreeViewModel()
        {
            DisplayName = "FamilyMemberTree";
            Model = FamilyMemberInfo.GetFamilyMemberInfoList();
        }

        #endregion
    }
}