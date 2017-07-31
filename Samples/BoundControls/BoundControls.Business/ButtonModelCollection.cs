using System.ComponentModel;

namespace BoundControls.Business
{
    public class ButtonModelCollection : BindingList<ButtonModel>
    {
        #region Factory methods

        public static ButtonModelCollection GetButtonModelCollection()
        {
            var collection = new ButtonModelCollection();
            collection.Add(new ButtonModel("bindMenu", "Bind menu bar", true, true));
            collection.Add(new ButtonModel("bindToolBar", "Bind tool bar", true, true));
            collection.Add(new ButtonModel("bindStatus", "Bind status bar", true, true));
            return collection;
        }

        #endregion
    }
}