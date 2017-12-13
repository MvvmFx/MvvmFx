using CslaSample.Business;
using MvvmFx.CaliburnMicro;

namespace CslaSample.Documents
{
    public class FolderListViewModel : ConductorWithModel<DocumentListViewModel, FolderList>
    {
        #region Fields and properties

        private int _listItemId;

        public int ListItemId
        {
            get { return _listItemId; }
            set
            {
                if (_listItemId != value)
                {
                    _listItemId = value;
                    ActivateItem(new DocumentListViewModel(_listItemId));
                    NotifyOfPropertyChange("ListItemId");
                }
            }
        }

        #endregion

        #region Initializers

        public FolderListViewModel()
        {
            ManageObjectLifetime = false;
            DisplayName = "Folder list";
            RefreshFolders();
        }

        #endregion

        #region Refresh list

        public void RefreshFolders()
        {
            DoRefresh(FolderList.GetFolderList);
            var haveDataContext = GetView() as IHaveDataContext;
            if (haveDataContext != null)
                haveDataContext.DataContext = this;
        }

        public void CloseChildren()
        {
            foreach (var documentListViewModel in GetChildren())
            {
                documentListViewModel.CloseChildren();
            }
        }

        #endregion
    }
}