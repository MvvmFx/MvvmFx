using System;
using Csla;

namespace CslaSample.Business
{

    /// <summary>
    /// DocumentEditGetter (creator and getter unit of work pattern).<br/>
    /// This is a generated base class of <see cref="DocumentEditGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class DocumentEditGetter : ReadOnlyBase<DocumentEditGetter>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Document"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocumentEdit> DocumentProperty = RegisterProperty<DocumentEdit>(p => p.Document, "Document");
        /// <summary>
        /// Gets the Document object (unit of work child property).
        /// </summary>
        /// <value>The Document.</value>
        public DocumentEdit Document
        {
            get { return GetProperty(DocumentProperty); }
            private set { LoadProperty(DocumentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Folders"/> property.
        /// </summary>
        public static readonly PropertyInfo<FolderNVL> FoldersProperty = RegisterProperty<FolderNVL>(p => p.Folders, "Folders");
        /// <summary>
        /// Gets the Folders object (unit of work child property).
        /// </summary>
        /// <value>The Folders.</value>
        public FolderNVL Folders
        {
            get { return GetProperty(FoldersProperty); }
            private set { LoadProperty(FoldersProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocumentEditGetter"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocumentEditGetter"/> unit of objects.</returns>
        public static DocumentEditGetter NewDocumentEditGetter()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<DocumentEditGetter>(new Criteria1(true, new int()));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocumentEditGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="documentId">The DocumentId parameter of the DocumentEditGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocumentEditGetter"/> unit of objects.</returns>
        public static DocumentEditGetter GetDocumentEditGetter(int documentId)
        {
            return DataPortal.Fetch<DocumentEditGetter>(new Criteria1(false, documentId));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentEditGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocumentEditGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Criteria

        /// <summary>
        /// Criteria1 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria1 : CriteriaBase<Criteria1>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateDocumentEdit"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateDocumentEditProperty = RegisterProperty<bool>(p => p.CreateDocumentEdit, "Create Document Edit");
            /// <summary>
            /// Gets or sets the Create Document Edit.
            /// </summary>
            /// <value><c>true</c> if Create Document Edit; otherwise, <c>false</c>.</value>
            public bool CreateDocumentEdit
            {
                get { return ReadProperty(CreateDocumentEditProperty); }
                set { LoadProperty(CreateDocumentEditProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocumentId"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> DocumentIdProperty = RegisterProperty<int>(p => p.DocumentId, "Document Id");
            /// <summary>
            /// Gets or sets the Document Id.
            /// </summary>
            /// <value>The Document Id.</value>
            public int DocumentId
            {
                get { return ReadProperty(DocumentIdProperty); }
                set { LoadProperty(DocumentIdProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <param name="createDocumentEdit">The CreateDocumentEdit.</param>
            /// <param name="documentId">The DocumentId.</param>
            public Criteria1(bool createDocumentEdit, int documentId)
            {
                CreateDocumentEdit = createDocumentEdit;
                DocumentId = documentId;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria1)
                {
                    var c = (Criteria1) obj;
                    if (!CreateDocumentEdit.Equals(c.CreateDocumentEdit))
                        return false;
                    if (!DocumentId.Equals(c.DocumentId))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria1", CreateDocumentEdit.ToString(), DocumentId.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates or loads a <see cref="DocumentEditGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria1 crit)
        {
            if (crit.CreateDocumentEdit)
                LoadProperty(DocumentProperty, DocumentEdit.NewDocumentEdit());
            else
                LoadProperty(DocumentProperty, DocumentEdit.GetDocumentEdit(crit.DocumentId));
            LoadProperty(FoldersProperty, FolderNVL.GetFolderNVL());
        }

        #endregion

    }
}
