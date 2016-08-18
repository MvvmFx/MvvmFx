using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// FolderEdit (editable child object).<br/>
    /// This is a generated base class of <see cref="FolderEdit"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="FolderEditCollection"/> collection.
    /// </remarks>
    [Serializable]
    public partial class FolderEdit : BusinessBase<FolderEdit>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> FolderIdProperty = RegisterProperty<int>(p => p.FolderId, "Folder Id");
        /// <summary>
        /// Gets the Folder Id.
        /// </summary>
        /// <value>The Folder Id.</value>
        public int FolderId
        {
            get { return GetProperty(FolderIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FolderNameProperty = RegisterProperty<string>(p => p.FolderName, "Folder Name");
        /// <summary>
        /// Gets or sets the Folder Name.
        /// </summary>
        /// <value>The Folder Name.</value>
        public string FolderName
        {
            get { return GetProperty(FolderNameProperty); }
            set { SetProperty(FolderNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentCount"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocumentCountProperty = RegisterProperty<int>(p => p.DocumentCount, "Document Count");
        /// <summary>
        /// Gets the Document Count.
        /// </summary>
        /// <value>The Document Count.</value>
        public int DocumentCount
        {
            get { return GetProperty(DocumentCountProperty); }
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

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="FolderEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="FolderEdit"/> object.</returns>
        internal static FolderEdit NewFolderEdit()
        {
            return DataPortal.CreateChild<FolderEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="FolderEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="FolderEdit"/> object.</returns>
        internal static FolderEdit GetFolderEdit(SafeDataReader dr)
        {
            FolderEdit obj = new FolderEdit();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(dr);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        public FolderEdit()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="FolderEdit"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(FolderIdProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(DocumentCountProperty, 0);
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="FolderEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderIdProperty, dr.GetInt32("FolderId"));
            LoadProperty(FolderNameProperty, dr.GetString("FolderName"));
            LoadProperty(DocumentCountProperty, dr.GetInt32("DocumentCount"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="FolderEdit"/> object in the database.
        /// </summary>
        private void Child_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("AddFolderEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderId", ReadProperty(FolderIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@FolderName", ReadProperty(FolderNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(FolderIdProperty, (int) cmd.Parameters["@FolderId"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="FolderEdit"/> object.
        /// </summary>
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("UpdateFolderEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderId", ReadProperty(FolderIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FolderName", ReadProperty(FolderNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
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
        /// Self deletes the <see cref="FolderEdit"/> object from database.
        /// </summary>
        private void Child_DeleteSelf()
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("DeleteFolderEdit", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderId", ReadProperty(FolderIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
        }

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
