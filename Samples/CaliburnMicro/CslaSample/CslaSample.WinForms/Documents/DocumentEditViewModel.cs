using System;
using System.ComponentModel;
using CslaSample.Business;
using CslaSample.Framework;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;
#if WINFORMS
using DialogResult = System.Windows.Forms.DialogResult;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using MessageBoxDefaultButton = System.Windows.Forms.MessageBoxDefaultButton;
using MessageBoxIcon = System.Windows.Forms.MessageBoxIcon;
#else
using DialogResult = Wisej.Web.DialogResult;
using MessageBox = Wisej.Web.MessageBox;
using MessageBoxButtons = Wisej.Web.MessageBoxButtons;
using MessageBoxDefaultButton = Wisej.Web.MessageBoxDefaultButton;
using MessageBoxIcon = Wisej.Web.MessageBoxIcon;

#endif

namespace CslaSample.Documents
{
    public class DocumentEditViewModel : ScreenWithModel<DocumentEdit>, IHaveShutdownTask
    {
        #region Fields and properties

        // Close checks

        private bool _isShutdown;
        private bool _isCancelling;
        private bool _isSaving;


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
            _isSaving = true;

            base.Save();

            if (Error != null)
            {
                MessageBox.Show(Error.Message, @"Error on Save operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TryClose();

            if (_parent != null)
                _parent.ListItemId = Model.DocumentId;

            _isSaving = false;
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
            _isCancelling = true;

            base.Close();
            TryClose();

            if (_parent != null)
                _parent.ListItemId = -1;

            CanCreate = true;

            BindingManager.Bindings.Clear();

            _isCancelling = false;
        }

        #endregion

        #region Close check

        public override void CanClose(Action<bool> callback)
        {
            //if (Model.IsReadOnly || !IsDirty || _isCancelling || _isSaving)
            if (!IsDirty || _isCancelling || _isSaving)
            {
                callback(true);
            }
            else
            {
                _isShutdown = false;
                DoCloseCheck(callback);
            }
        }

        public IResult GetShutdownTask()
        {
            //if (Model.IsReadOnly || !IsDirty)
            if (!IsDirty)
                return null;

            _isShutdown = true;
            return new ApplicationCloseCheck(this, DoCloseCheck);
        }

        protected void DoCloseCheck(Action<bool> callback)
        {
            var result = MessageBox.Show("Document is not saved and you will loose all changes.\r\n\r\nDo you want to close?",
                @"Document is not saved.",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            var close = result == DialogResult.Yes;

            callback(close);

            if (!close)
            {
                CloseCheckHelper(close);
            }
        }

        private void CloseCheckHelper(bool doClose)
        {
            if (!_isShutdown)
            {
                (_parent.GetView() as DocumentListView)?.CancelClose(Model.DocumentId);

                var grandParent = _parent.Parent as FolderListViewModel;

                if (grandParent != null)
                    (grandParent.GetView() as FolderListView)?.CancelClose(Model.FolderId);
            }
        }

        #endregion
    }
}