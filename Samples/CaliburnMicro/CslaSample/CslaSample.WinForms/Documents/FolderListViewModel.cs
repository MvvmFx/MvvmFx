using CslaSample.Business;
using CslaSample.Framework;
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
                    if (ActivateItem(value))
                    {
                        _listItemId = value;
                        NotifyOfPropertyChange("ListItemId");
                    }
                }
            }
        }

        #endregion

        #region Initializers

        public FolderListViewModel()
        {
            CloseStrategy = new ApplicationCloseStrategy();

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

        #endregion

        #region Activate New Document List

        public bool ActivateItem(int listItemId)
        {
            if (CloseChildren())
            {
                ActivateItem(new DocumentListViewModel(listItemId));
                return true;
            }

            return false;
        }

        public bool CloseChildren()
        {
            foreach (var child in GetChildren())
            {
                if (!child.CloseChildren())
                    return false;
            }

            return true;
        }

        #endregion
    }
}