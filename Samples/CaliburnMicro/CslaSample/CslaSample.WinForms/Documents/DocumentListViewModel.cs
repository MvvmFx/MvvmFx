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
                _listItemId = value;
                var documentEditViewModel = new DocumentEditViewModel(_listItemId);
                if (documentEditViewModel.Model.IsLoaded)
                    ActivateItem(documentEditViewModel);
                NotifyOfPropertyChange("ListItemId");
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
                DisplayName = string.Format("{0} documents", parent.Model.FindFolderInfoByFolderId(_folderId).FolderName);
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

        public void CreateNew()
        {
            foreach (var child in GetChildren())
            {
                child.TryClose();
            }

            ListItemId = 0;
            ActivateItem(new DocumentEditViewModel(true, _folderId));
        }

        #endregion
    }
}