using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// DocumentList (read only list).<br/>
    /// This is a generated base class of <see cref="DocumentList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DocumentInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class DocumentList : ReadOnlyBindingListBase<DocumentList, DocumentInfo>
    {

        #region Event handler properties

        [NotUndoable]
        private static bool _singleInstanceSavedHandler = true;

        /// <summary>
        /// Gets or sets a value indicating whether only a single instance should handle the Saved event.
        /// </summary>
        /// <value>
        /// <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        /// </value>
        public static bool SingleInstanceSavedHandler
        {
            get { return _singleInstanceSavedHandler; }
            set { _singleInstanceSavedHandler = value; }
        }

        #endregion

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DocumentInfo"/> item is in the collection.
        /// </summary>
        /// <param name="documentId">The DocumentId of the item to search for.</param>
        /// <returns><c>true</c> if the DocumentInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int documentId)
        {
            foreach (var documentInfo in this)
            {
                if (documentInfo.DocumentId == documentId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="DocumentInfo"/> item of the <see cref="DocumentList"/> collection, based on a given DocumentId.
        /// </summary>
        /// <param name="documentId">The DocumentId.</param>
        /// <returns>A <see cref="DocumentInfo"/> object.</returns>
        public DocumentInfo FindDocumentInfoByDocumentId(int documentId)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].DocumentId.Equals(documentId))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocumentList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="folderId">The FolderId parameter of the DocumentList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocumentList"/> collection.</returns>
        public static DocumentList GetDocumentList(int folderId)
        {
            return DataPortal.Fetch<DocumentList>(folderId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocumentList()
        {
            // Use factory methods and do not use direct creation.
            DocumentEditSaved.Register(this);

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Saved Event Handler

        /// <summary>
        /// Handle Saved events of <see cref="DocumentEdit"/> to update the list of <see cref="DocumentInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void DocumentEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (DocumentEdit)e.NewObject;
            if (((DocumentEdit)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(DocumentInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((DocumentEdit)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.DocumentId == obj.DocumentId)
                    {
                        IsReadOnly = false;
                        var rlce = RaiseListChangedEvents;
                        RaiseListChangedEvents = true;
                        this.RemoveItem(index);
                        RaiseListChangedEvents = rlce;
                        IsReadOnly = true;
                        break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.DocumentId == obj.DocumentId)
                    {
                        child.UpdatePropertiesOnSaved(obj);
                        var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index);
                        OnListChanged(listChangedEventArgs);
                        break;
                    }
                }
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocumentList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="folderId">The Folder Id.</param>
        protected void DataPortal_Fetch(int folderId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaSampleConnection, false))
            {
                using (var cmd = new SqlCommand("GetDocumentList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FolderId", folderId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, folderId);
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
        /// Loads all <see cref="DocumentList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DocumentInfo.GetDocumentInfo(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

        #region DocumentEditSaved nested class

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="DocumentEdit"/>
        /// to update the list of <see cref="DocumentInfo"/> objects.
        /// </summary>
        private static class DocumentEditSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a DocumentList instance to handle Saved events.
            /// to update the list of <see cref="DocumentInfo"/> objects.
            /// </summary>
            /// <param name="obj">The DocumentList instance.</param>
            public static void Register(DocumentList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (DocumentList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    DocumentEdit.DocumentEditSaved += DocumentEditSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="DocumentEdit"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void DocumentEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((DocumentList) reference.Target).DocumentEditSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered DocumentList instances.
            /// </summary>
            public static void Unregister()
            {
                DocumentEdit.DocumentEditSaved -= DocumentEditSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
