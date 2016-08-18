using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// FolderEditCollection (editable root list).<br/>
    /// This is a generated base class of <see cref="FolderEditCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="FolderEdit"/> objects.
    /// </remarks>
    [Serializable]
    public partial class FolderEditCollection : BusinessBindingListBase<FolderEditCollection, FolderEdit>
    {

        #region Collection Business Methods

        /// <summary>
        /// Adds a new <see cref="FolderEdit"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        public new void Add(FolderEdit item)
        {
            if (Contains(item.FolderId))
                throw new ArgumentException("FolderEdit already exists.");

            base.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="FolderEdit"/> item to the collection.
        /// </summary>
        /// <returns>The new FolderEdit item added to the collection.</returns>
        public FolderEdit Add()
        {
            var item = FolderEdit.NewFolderEdit();
            Add(item);
            return item;
        }

        /// <summary>
        /// Removes a <see cref="FolderEdit"/> item from the collection.
        /// </summary>
        /// <param name="folderId">The FolderId of the item to be removed.</param>
        public void Remove(int folderId)
        {
            foreach (var folderEdit in this)
            {
                if (folderEdit.FolderId == folderId)
                {
                    Remove(folderEdit);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="FolderEdit"/> item is in the collection.
        /// </summary>
        /// <param name="folderId">The FolderId of the item to search for.</param>
        /// <returns><c>true</c> if the FolderEdit is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int folderId)
        {
            foreach (var folderEdit in this)
            {
                if (folderEdit.FolderId == folderId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="FolderEdit"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="folderId">The FolderId of the item to search for.</param>
        /// <returns><c>true</c> if the FolderEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int folderId)
        {
            foreach (var folderEdit in this.DeletedList)
            {
                if (folderEdit.FolderId == folderId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="FolderEdit"/> item of the <see cref="FolderEditCollection"/> collection, based on a given FolderId.
        /// </summary>
        /// <param name="folderId">The FolderId.</param>
        /// <returns>A <see cref="FolderEdit"/> object.</returns>
        public FolderEdit FindFolderEditByFolderId(int folderId)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].FolderId.Equals(folderId))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="FolderEditCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="FolderEditCollection"/> collection.</returns>
        public static FolderEditCollection NewFolderEditCollection()
        {
            return DataPortal.Create<FolderEditCollection>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="FolderEditCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="FolderEditCollection"/> collection.</returns>
        public static FolderEditCollection GetFolderEditCollection()
        {
            return DataPortal.Fetch<FolderEditCollection>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderEditCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        public FolderEditCollection()
        {
            // Prevent direct creation
            Saved += OnFolderEditCollectionSaved;

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Cache Invalidation

        private void OnFolderEditCollectionSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            FolderList.InvalidateCache();
            FolderNVL.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                FolderList.InvalidateCache();
                FolderNVL.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="FolderEditCollection"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand(GetFolderEditCollectionInlineQuery(), ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="FolderEditCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(FolderEdit.GetFolderEdit(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="FolderEditCollection"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager("CslaSample"))
            {
                base.Child_Update();
                ctx.Commit();
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
