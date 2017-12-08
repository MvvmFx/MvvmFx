using System.ComponentModel;
#if WISEJ
using MvvmFx.WisejWeb;
#else
using MvvmFx.Windows.Forms;
#endif

namespace BoundControls.Business
{
    public class MenuCollection : BindingList<Menu>
    {
        private static MenuCollection _collection;

        private static MenuCollection Instance()
        {
            if (_collection == null)
            {
                _collection = new MenuCollection();
                _collection.Add(new Menu("menuItem1", "File", "File menu entry", false, true));
                _collection.Add(new Menu("menuItem2", "Edit", "Edit menu entry", true, true));
                _collection.Add(new Menu("menuItem3", "Copy", "Copy menu entry", true, true));
                _collection.Add(new Menu("menuItem4", "Paste", "Paste menu entry", true, true));

                _collection.Add(new Menu("menuItem5", "Change Style", "Change Style menu entry", true, true));
                _collection.Add(new Menu("menuItem6", "Hidden", "Hidden menu entry", true, false));
                _collection.Add(new Menu("menuItem7", "Copy to Style Sheet", "Copy to Style Sheet menu entry", true, true));
                _collection.Add(new Menu("menuItem8", "Copy to all Style Sheets", "Copy to all Style Sheets menu entry", false, true));

            }

            return _collection;
        }

        public static MenuCollection GetMenuCollection()
        {
            return Instance();
        }

        public static Menu GetMenu(IHaveName namedComponent)
        {
            foreach (Menu menu in Instance())
            {
                if (menu.Name == namedComponent.Name)
                    return menu;
            }

            return null;
        }

        public static Menu GetMenu(string name)
        {
            foreach (Menu menu in Instance())
            {
                if (menu.Name == name)
                    return menu;
            }

            return null;
        }
    }
}