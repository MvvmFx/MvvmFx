using System;
using Csla;

namespace CslaSample.Business
{
    public partial class DocumentEdit
    {

        #region OnDeserialized actions

        /// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        /// <param name="context">Serialization context object.</param>
        protected override void OnDeserialized(System.Runtime.Serialization.StreamingContext context)
        {
            base.OnDeserialized(context);
            Saved += OnDocumentEditSaved;
            // add your custom OnDeserialized actions here.
        }

        #endregion

        #region Custom Business Rules and Property Authorization

        //partial void AddBusinessRulesExtend()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Implementation of DataPortal Hooks

        partial void OnCreate(DataPortalHookArgs args)
        {
            BusinessRules.CheckRules();
        }

        //partial void OnDeletePre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnDeletePost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchPre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnFetchRead(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnUpdatePre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnUpdatePost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnInsertPre(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        //partial void OnInsertPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
