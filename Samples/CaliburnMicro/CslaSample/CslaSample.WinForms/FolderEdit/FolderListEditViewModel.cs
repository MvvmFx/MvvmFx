using CslaSample.Business;
using MvvmFx.CaliburnMicro;

namespace CslaSample.FolderEdit
{
    public class FolderListEditViewModel : ScreenWithModel<FolderEditCollection>
    {
        private object _view;

        #region Initializers

        private FolderListEditViewModel()
        {
            DisplayName = "Edit folder list (Editable Root Collection)";
            ViewAttached += FolderListEditViewModel_ViewAttached;
        }

        private void FolderListEditViewModel_ViewAttached(object sender, ViewAttachedEventArgs e)
        {
            ViewAttached -= FolderListEditViewModel_ViewAttached;
            _view = e.View;
            var a = e.Context;
        }

        #endregion

        #region Singleton members

        private static FolderListEditViewModel _instance = null;

        public static FolderListEditViewModel Instance()
        {
            if (_instance == null)
                _instance = new FolderListEditViewModel();

            _instance.Model = FolderEditCollection.GetFolderEditCollection();

            return _instance;
        }

        #endregion

        #region Verbs

        public override void Close()
        {
            base.Close();
            TryClose();
        }

        #endregion
    }
}