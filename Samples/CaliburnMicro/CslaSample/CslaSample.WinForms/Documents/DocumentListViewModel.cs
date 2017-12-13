using System.ComponentModel;
using CslaSample.Business;
using MvvmFx.CaliburnMicro;

namespace CslaSample.Documents
{
    public class DocumentListViewModel : ConductorWithModel<DocumentEditViewModel, DocumentList>
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


                /*if (_listItemId != value)
                {
                    _listItemId = value;
                    var documentEditViewModel = new DocumentEditViewModel(_listItemId);
                    if (documentEditViewModel.Model.IsLoaded)
                        ActivateItem(documentEditViewModel);
                    NotifyOfPropertyChange("ListItemId");
                }*/
            }
        }

        private readonly int _folderId;

        #endregion

        #region Initializers

        public DocumentListViewModel(int folderId)
        {
            ManageObjectLifetime = false;
            _folderId = folderId;
            RefreshDocuments();
            PropertyChanged += OnDocumentListViewModelPropertyChanged;
        }

        private void OnDocumentListViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                PropertyChanged -= OnDocumentListViewModelPropertyChanged;

                var parent = Parent as FolderListViewModel;
                if (parent != null)
                {
                    DisplayName = string.Format("{0} documents",
                        parent.Model.FindFolderInfoByFolderId(_folderId).FolderName);
                }
            }
        }

        #endregion

        #region Refresh list

        public void RefreshDocuments()
        {
            DoRefresh(() => DocumentList.GetDocumentList(_folderId));

            var haveDataContext = GetView() as IHaveDataContext;
            if (haveDataContext != null)
                haveDataContext.DataContext = this;
        }

        #endregion

        #region Activate New Document

        public bool ActivateItem(int listItemId)
        {
            if (CloseChildren())
            {
                var documentEditViewModel = new DocumentEditViewModel(listItemId);
                if (documentEditViewModel.Model.IsLoaded)
                    ActivateItem(documentEditViewModel);
                return true;
            }
            return false;
        }

        public void Create()
        {
            if (CloseChildren())
            {
                ListItemId = 0;
                ActivateItem(new DocumentEditViewModel(true, _folderId));
            }
        }

        public bool CloseChildren()
        {
            foreach (var child in GetChildren())
            {
                child.TryClose();
                if (child.IsActive)
                    return false;
                child.Close();
            }
            return true;
        }

        #endregion
    }
}