using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// FolderList (read only list).<br/>
    /// This is a generated base class of <see cref="FolderList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="FolderInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class FolderList : ReadOnlyBindingListBase<FolderList, FolderInfo>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="FolderInfo"/> item is in the collection.
        /// </summary>
        /// <param name="folderId">The FolderId of the item to search for.</param>
        /// <returns><c>true</c> if the FolderInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int folderId)
        {
            foreach (var folderInfo in this)
            {
                if (folderInfo.FolderId == folderId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="FolderInfo"/> item of the <see cref="FolderList"/> collection, based on a given FolderId.
        /// </summary>
        /// <param name="folderId">The FolderId.</param>
        /// <returns>A <see cref="FolderInfo"/> object.</returns>
        public FolderInfo FindFolderInfoByFolderId(int folderId)
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

        #region Private Fields

        private static FolderList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory FolderList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(FolderList list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="FolderList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="FolderList"/> collection.</returns>
        public static FolderList GetFolderList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<FolderList>();

            return _list;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private FolderList()
        {
            // Prevent direct creation

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="FolderList"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("CslaSample"))
            {
                using (var cmd = new SqlCommand("GetFolderList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="FolderList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(FolderInfo.GetFolderInfo(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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
