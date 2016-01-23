using System.ComponentModel;
using CslaSample.Business;
using CslaSample.Framework;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;

namespace CslaSample.Documents
{
    public class DocumentEditViewModel : ScreenWithModel<DocumentEdit>
    {
        //todo: last thing - recheck this class, namely the bindings

        #region Fields and properties

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
                var parent = Parent as DocumentListViewModel;
                if (parent != null)
                {
                    var grandParent = parent.Parent as FolderListViewModel;
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
            BindMenuItem("CanCreateNewDocument", "CanCreate");
            BindMenuItem("CanDeleteDocument", "CanDelete");
            BindMenuItem("CanCloseDocument", "CanClose");

            CanCreate = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

            if (Model != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreate", Model, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
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
            var documentListViewModel = Parent as DocumentListViewModel;
            if (documentListViewModel != null)
                documentListViewModel.CreateNew();
        }

        public override void Save()
        {
            base.Save();
            TryClose();
            (Parent as DocumentListViewModel).ListItemId = Model.DocumentId;
        }

        public override void Delete()
        {
            DeleteImmediate();
            TryClose();
        }

        public override void Close()
        {
            base.Close();
            TryClose();
            (Parent as DocumentListViewModel).ListItemId = -1;

            CanCreate = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

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