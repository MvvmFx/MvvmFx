using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private DocumentList()
        {
            // Prevent direct creation
            DocumentEdit.DocumentEditSaved += DocumentEditSavedHandler;

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
        private void DocumentEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
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
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("CslaSample"))
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
