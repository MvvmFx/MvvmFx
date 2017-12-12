using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// FolderInfo (read only object).<br/>
    /// This is a generated base class of <see cref="FolderInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="FolderList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class FolderInfo : ReadOnlyBase<FolderInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="FolderId"/> property.
        /// </summary>
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
        /// Gets the Folder Name.
        /// </summary>
        /// <value>The Folder Name.</value>
        public string FolderName
        {
            get { return GetProperty(FolderNameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="FolderInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="FolderInfo"/> object.</returns>
        internal static FolderInfo GetFolderInfo(SafeDataReader dr)
        {
            FolderInfo obj = new FolderInfo();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FolderInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="FolderInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(FolderIdProperty, dr.GetInt32("FolderId"));
            LoadProperty(FolderNameProperty, dr.GetString("FolderName"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
