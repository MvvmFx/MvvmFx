using System;
using Csla;

namespace CslaSample.Business
{
    public partial class FolderEditCollection
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            Saved += OnFolderEditCollectionSaved;
            // add your custom OnDeserialized actions here.
        }

        #endregion

        #region Inlines queries

        private string GetFolderEditCollectionInlineQuery()
        {
            var query = "SELECT [Folders].[FolderId], [Folders].[FolderName],";
            query += "(SELECT COUNT(*) FROM [Documents] WHERE [Documents].[FolderId] = [Folders].[FolderId]) AS [DocumentCount],";
            query += "[Folders].[CreateDate], [Folders].[ChangeDate] FROM [Folders]";
            return query;
        }

        #endregion

        #region Pseudo Event Handlers

        //partial void OnFetchPre(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new System.Exception("The method or operation is not implemented.");
        //}

        #endregion

    }
}
