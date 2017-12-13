using System.ComponentModel;
using CslaSample.Business;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;

namespace CslaSample.Documents
{
    public class DocumentEditViewModel : ScreenWithModel<DocumentEdit>
    {
        #region Fields and properties

        private DocumentListViewModel _parent;

        private static readonly BindingManager BindingManager = new BindingManager();

        private object _view;

        private MainFormViewModel _menuObject;

        private FolderNVL _folders;

        public FolderNVL Folders
        {
            get { return _folders; }
            set
            {
                if (_folders != value)
                {
                    _folders = value;
                    NotifyOfPropertyChange("Folders");
                }
            }
        }

        #endregion

        #region Initializers

        private DocumentEditViewModel()
        {
            // force to use parametrized constructor
        }

        public DocumentEditViewModel(bool createDocument, int folderId)
        {
            if (!createDocument)
                return;

            var documentGetter = DocumentEditGetter.NewDocumentEditGetter();
            Model = documentGetter.Document;
            Folders = documentGetter.Folders;
            Model.FolderId = folderId;

            SetUpEvents();
        }

        public DocumentEditViewModel(int documentEditId)
        {
            var documentGetter = DocumentEditGetter.GetDocumentEditGetter(documentEditId);
            Model = documentGetter.Document;
            Folders = documentGetter.Folders;

            SetUpEvents();
        }

        private void SetUpEvents()
        {
            PropertyChanged += OnDocumentEditViewModelPropertyChanged;
            ViewAttached += DocumentEditViewModel_ViewAttached;
        }

        private void OnDocumentEditViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                PropertyChanged -= OnDocumentEditViewModelPropertyChanged;
                _parent = Parent as DocumentListViewModel;
                if (_parent != null)
                {
                    var grandParent = _parent.Parent as FolderListViewModel;
                    if (grandParent != null)
                        _menuObject = grandParent.Parent as MainFormViewModel;
                }
                DisplayName = "Edit Document #" + Model.DocumentId;
                Bind();
            }
        }

        private void DocumentEditViewModel_ViewAttached(object sender, ViewAttachedEventArgs e)
        {
            ViewAttached -= DocumentEditViewModel_ViewAttached;
            _view = e.View;
        }

        #endregion

        #region Binders

        private void Bind()
        {
            // clear old bindings
            BindingManager.Bindings.Clear();

            // bind to main form properties
            BindMenuItem("CanSaveDocument", "CanSave");
            BindMenuItem("CanCreateDocument", "CanCreate");
            BindMenuItem("CanDeleteDocument", "CanDelete");
        }

        private void BindMenuItem(string target, string source)
        {
            BindingManager.Bindings.Add(new Binding(_menuObject, target, this, source)
            {
                Mode = BindingMode.OneWayToTarget
            });
        }

        #endregion

        #region Actions methods

        public void Create()
        {
            if (_parent != null)
                _parent.Create();
        }

        public override void Save()
        {
            base.Save();
            TryClose();

            if (_parent != null)
                _parent.ListItemId = Model.DocumentId;
        }

        public override void Delete()
        {
            var itemId = ItemToShowAfterDelete();

            DeleteImmediate();
            TryClose();

            if (_parent != null)
                _parent.ListItemId = itemId;
        }

        private int ItemToShowAfterDelete()
        {
            var result = -1;

            if (_parent != null)
            {
                DocumentList parentModel = _parent.Model;
                for (var index = 0; index < parentModel.Count; index++)
                {
                    var info = parentModel[index];
                    if (info.DocumentId == Model.DocumentId)
                    {
                        if (parentModel.Count > index + 1)
                            result = parentModel[index + 1].DocumentId;
                        else if (parentModel.Count > 1)
                            result = parentModel[index - 1].DocumentId;

                        break;
                    }
                }
            }

            return result;
        }

        public override void Close()
        {
            base.Close();
            TryClose();

            if (_parent != null)
                _parent.ListItemId = -1;

            CanCreate = true;

            BindingManager.Bindings.Clear();
        }

        public void CloseChildren()
        {
            Close();
        }

        #endregion
    }
}