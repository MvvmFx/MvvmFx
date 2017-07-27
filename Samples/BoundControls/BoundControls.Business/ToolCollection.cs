using System.ComponentModel;

namespace BoundControls.Business
{
    public class ToolCollection : BindingList<Tool>
    {
        #region Factory methods

        public static ToolCollection GetToolCollection()
        {
            var collection = new ToolCollection();
            collection.Add(new Tool("toolBarButton1", "File", "PushButton", true, true));
            collection.Add(new Tool("toolBarButton2", "Edit", "ToggleButton", false, true));
            collection.Add(new Tool("toolBarButton3", "Separator", "Separator", true, true));
            collection.Add(new Tool("toolBarButton4", "View", "DropDownButton", true, true));
            return collection;
        }

        #endregion
    }
}