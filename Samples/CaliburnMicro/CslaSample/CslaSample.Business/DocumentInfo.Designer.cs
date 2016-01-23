using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaSample.Business
{

    /// <summary>
    /// DocumentInfo (read only object).<br/>
    /// This is a generated base class of <see cref="DocumentInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocumentList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DocumentInfo : ReadOnlyBase<DocumentInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocumentId"/> property.
        /// </summary>
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
        public static readonly PropertyInfo<string> DocumentReferenceProperty = RegisterProperty<string>(p => p.DocumentReference, "Document Reference", null);
        /// <summary>
        /// Gets the Document Reference.
        /// </summary>
        /// <value>The Document Reference.</value>
        public string DocumentReference
        {
            get { return GetProperty(DocumentReferenceProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocumentDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocumentDateProperty = RegisterProperty<SmartDate>(p => p.DocumentDate, "Document Date", null);
        /// <summary>
        /// Gets the Document Date.
        /// </summary>
        /// <value>The Document Date.</value>
        public string DocumentDate
        {
            get { return GetPropertyConvert<SmartDate, String>(DocumentDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Subject");
        /// <summary>
        /// Gets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Sender"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SenderProperty = RegisterProperty<string>(p => p.Sender, "Sender");
        /// <summary>
        /// Gets the Sender.
        /// </summary>
        /// <value>The Sender.</value>
        public string Sender
        {
            get { return GetProperty(SenderProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Receiver"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ReceiverProperty = RegisterProperty<string>(p => p.Receiver, "Receiver");
        /// <summary>
        /// Gets the Receiver.
        /// </summary>
        /// <value>The Receiver.</value>
        public string Receiver
        {
            get { return GetProperty(ReceiverProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="DocumentInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocumentInfo"/> object.</returns>
        internal static DocumentInfo GetDocumentInfo(SafeDataReader dr)
        {
            DocumentInfo obj = new DocumentInfo();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private DocumentInfo()
        {
            // Prevent direct creation
        }

        #endregion

        #region Update properties on saved object

        /// <summary>
        /// Existing <see cref="DocumentInfo"/> object is updated by <see cref="DocumentEdit"/> Saved event.
        /// </summary>
        internal static DocumentInfo LoadInfo(DocumentEdit documentEdit)
        {
            var info = new DocumentInfo();
            info.UpdatePropertiesOnSaved(documentEdit);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="DocumentInfo"/> object are updated by <see cref="DocumentEdit"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(DocumentEdit documentEdit)
        {
            LoadProperty(DocumentIdProperty, documentEdit.DocumentId);
            LoadProperty(DocumentReferenceProperty, documentEdit.DocumentReference);
            LoadProperty(DocumentDateProperty, (SmartDate)documentEdit.DocumentDate);
            LoadProperty(SubjectProperty, documentEdit.Subject);
            LoadProperty(SenderProperty, documentEdit.Sender);
            LoadProperty(ReceiverProperty, documentEdit.Receiver);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocumentInfo"/> object from the given SafeDataReader.
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
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
