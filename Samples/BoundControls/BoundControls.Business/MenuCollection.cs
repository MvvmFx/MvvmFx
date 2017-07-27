using System.ComponentModel;

namespace BoundControls.Business
{
    public class MenuCollection : BindingList<Menu>
    {
        #region Factory methods

        public static MenuCollection GetMenuCollection()
        {
            var collection = new MenuCollection();
            collection.Add(new Menu("menuItem1", "File", "File menu entry", false, true));
            collection.Add(new Menu("menuItem2", "Edit", "Edit menu entry", true, true));
            collection.Add(new Menu("menuItem3", "Copy", "Copy menu entry", true, true));
            collection.Add(new Menu("menuItem4", "Paste", "Paste menu entry", true, true));
            return collection;
        }

        #endregion
    }
}