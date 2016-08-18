using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// DocumentEdit (editable root object).<br/>
    /// This is a generated base class of <see cref="DocumentEdit"/> business object.
    /// </summary>
    [Serializable]
    public partial class DocumentEdit : BusinessBase<DocumentEdit>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocumentId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocumentIdProperty = RegisterProperty<int>(p => p.DocumentId, "Document Id");
        /// <summary>
        /// Gets the Document Id.
        /// </summary>
        /// <value>The Document Id.</value>
        public int DocumentId
        {
            get { return GetProperty(DocumentIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentReference"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocumentReferenceProperty = RegisterProperty<string>(p => p.DocumentReference, "Document Reference");
        /// <summary>
        /// Gets or sets the Document Reference.
        /// </summary>
        /// <value>The Document Reference.</value>
        public string DocumentReference
        {
            get { return GetProperty(DocumentReferenceProperty); }
            set { SetProperty(DocumentReferenceProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocumentDateProperty = RegisterProperty<SmartDate>(p => p.DocumentDate, "Document Date");
        /// <summary>
        /// Gets or sets the Document Date.
        /// </summary>
        /// <value>The Document Date.</value>
        public string DocumentDate
        {
            get { return GetPropertyConvert<SmartDate, String>(DocumentDateProperty); }
            set { SetPropertyConvert<SmartDate, String>(DocumentDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Subject");
        /// <summary>
        /// Gets or sets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
            set { SetProperty(SubjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Sender"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SenderProperty = RegisterProperty<string>(p => p.Sender, "Sender");
        /// <summary>
        /// Gets or sets the Sender.
        /// </summary>
        /// <value>The Sender.</value>
        public string Sender
        {
            get { return GetProperty(SenderProperty); }
            set { SetProperty(SenderProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Receiver"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ReceiverProperty = RegisterProperty<string>(p => p.Receiver, "Receiver");
        /// <summary>
        /// Gets or sets the Receiver.
        /// </summary>
        /// <value>The Receiver.</value>
        public string Receiver
        {
            get { return GetProperty(ReceiverProperty); }
            set { SetProperty(ReceiverProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="TextContent"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> TextContentProperty = RegisterProperty<string>(p => p.TextContent, "Text Content");
        /// <summary>
        /// Gets or sets the Text Content.
        /// </summary>
        /// <value>The Text Content.</value>
        public string TextContent
        {
            get { return GetProperty(TextContentProperty); }
            set { SetProperty(TextContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> FolderIdProperty = RegisterProperty<int>(p => p.FolderId, "Folder Id");
        /// <summary>
        /// Gets or sets the Folder Id.
        /// </summary>
        /// <value>The Folder Id.</value>
        public int FolderId
        {
            get { return GetProperty(FolderIdProperty); }
            set
            {
                SetProperty(FolderIdProperty, value);
                OnPropertyChanged("FolderName");
            }
        }

        /// <summary>
        /// Gets or sets the Folder Name.
        /// </summary>
        /// <value>The Folder Name.</value>
        public string FolderName
        {
            get
            {
                var result = string.Empty;
                if (FolderNVL.GetFolderNVL().ContainsKey(FolderId))
                    result = FolderNVL.GetFolderNVL().GetItemByKey(FolderId).Value;
                return result;
            }
            set
            {
                if (FolderNVL.GetFolderNVL().ContainsValue(value))
                {
                    var result = FolderNVL.GetFolderNVL().GetItemByValue(value).Key;
                    if (result != FolderId)
                        FolderId = result;
                }
            }
        }

        #endregion

        #region State Property

        /// <summary>
        /// Maintains metadata about <see cref="IsLoaded"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<bool> IsLoadedProperty = RegisterProperty<bool>(p => p.IsLoaded, string.Empty, false);
        /// <summary>
        /// Gets the IsLoaded state.
        /// </summary>
        /// <value>The IsLoaded state.</value>
        public bool IsLoaded
        {
            get { return GetProperty(IsLoadedProperty); }
        }

        #endregion

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="DocumentEdit"/>
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return DocumentId.ToString() + ", " + DocumentReference.ToString();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocumentEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocumentEdit"/> object.</returns>
        public static DocumentEdit NewDocumentEdit()
        {
            return DataPortal.Create<DocumentEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocumentEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="documentId">The DocumentId parameter of the DocumentEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocumentEdit"/> object.</returns>
        public static DocumentEdit GetDocumentEdit(int documentId)
        {
            return DataPortal.Fetch<DocumentEdit>(documentId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="DocumentEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="documentId">The DocumentId of the DocumentEdit to delete.</param>
        public static void DeleteDocumentEdit(int documentId)
        {
            DataPortal.Delete<DocumentEdit>(documentId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        public DocumentEdit()
        {
            // Prevent direct creation
            Saved += OnDocumentEditSaved;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocumentEdit"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(DocumentIdProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(DocumentReferenceProperty, null);
            LoadProperty(DocumentDateProperty, null);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocumentEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="documentId">The Document Id.</param>
        protected void DataPortal_Fetch(int documentId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("GetDocumentEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentId", documentId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, documentId);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="DocumentEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocumentIdProperty, dr.GetInt32("DocumentId"));
            LoadProperty(DocumentReferenceProperty, dr.GetString("DocumentReference"));
            LoadProperty(DocumentDateProperty, dr.GetSmartDate("DocumentDate", true));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            LoadProperty(SenderProperty, dr.GetString("Sender"));
            LoadProperty(ReceiverProperty, dr.GetString("Receiver"));
            LoadProperty(TextContentProperty, dr.GetString("TextContent"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(FolderIdProperty, dr.GetInt32("FolderId"));
            // State property
            LoadProperty(IsLoadedProperty, true);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DocumentEdit"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("AddDocumentEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentId", ReadProperty(DocumentIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocumentReference", ReadProperty(DocumentReferenceProperty) == null ? (object)DBNull.Value : ReadProperty(DocumentReferenceProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", ReadProperty(DocumentDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Sender", ReadProperty(SenderProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Receiver", ReadProperty(ReceiverProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@TextContent", ReadProperty(TextContentProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@FolderId", ReadProperty(FolderIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocumentIdProperty, (int) cmd.Parameters["@DocumentId"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocumentEdit"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("UpdateDocumentEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentId", ReadProperty(DocumentIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocumentReference", ReadProperty(DocumentReferenceProperty) == null ? (object)DBNull.Value : ReadProperty(DocumentReferenceProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocumentDate", ReadProperty(DocumentDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Sender", ReadProperty(SenderProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Receiver", ReadProperty(ReceiverProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@TextContent", ReadProperty(TextContentProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@FolderId", ReadProperty(FolderIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocumentEdit"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(DocumentId);
        }

        /// <summary>
        /// Deletes the <see cref="DocumentEdit"/> object from database.
        /// </summary>
        /// <param name="documentId">The delete criteria.</param>
        protected void DataPortal_Delete(int documentId)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("DeleteDocumentEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocumentId", documentId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, documentId);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
            }
        }

        #endregion

        #region Saved Event

        private void OnDocumentEditSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (DocumentEditSaved != null)
                DocumentEditSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="DocumentEdit"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> DocumentEditSaved;

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
