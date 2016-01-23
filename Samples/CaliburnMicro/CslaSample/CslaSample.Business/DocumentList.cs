using System;
using Csla;

namespace CslaSample.Business
{
    public partial class DocumentList
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            DocumentEdit.DocumentEditSaved += DocumentEditSavedHandler;
            // add your custom OnDeserialized actions here.
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
