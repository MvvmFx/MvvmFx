using System.ComponentModel;
#if WISEJ
using MvvmFx.WisejWeb;
#else
using MvvmFx.Windows.Forms;
#endif

namespace BoundControls.Business
{
    public class ItemCollection : BindingList<Item>
    {
        private static ItemCollection _collection;

        private static ItemCollection Instance()
        {
            if (_collection == null)
            {
                _collection = new ItemCollection();
                _collection.Add(new Item("menuItem1", "File", "File menu entry.", false, true));
                _collection.Add(new Item("menuItem2", "Edit", "Edit a file.", true, true));
                _collection.Add(new Item("menuItem3", "Copy", "Copy a file.", true, true));
                _collection.Add(new Item("menuItem4", "Paste", "Paste clipboard\'s content.", true, true));

                _collection.Add(new Item("menuItem5", "Change Style", "Change style.", true, true));
                _collection.Add(new Item("menuItem6", "HIDDEN", "HIDDEN", true, false));
                _collection.Add(new Item("menuItem7", "Copy to Style Sheet", "Copy to Style Sheet.", true, true));
                _collection.Add(new Item("menuItem8", "Copy to all Style Sheets", "Copy to all Style Sheets.", false, true));

                _collection.Add(new Item("statusItem1", "Item(s) Saved", "One or more items were saved.", true, true));
                _collection.Add(new Item("statusItem2", "Plugins Loaded", "All configured plugins were successfully loaded.", true, true));
                _collection.Add(new Item("statusItem3", "HIDDEN", "HIDDEN", true, false));
                _collection.Add(new Item("statusItem4", "Reload Plugins", "Unload and reload all configured plugins.", true, true));
                _collection.Add(new Item("statusItem5", "Unload Plugins", "Unload all configured plugins.", false, true));
                _collection.Add(new Item("statusItem6", "Create a feature branch", "Use this option with parsimony.", true, true));
                _collection.Add(new Item("statusItem7", "Revert to \"development\" branch", "Go back to the last used branch.", true, true));

                _collection.Add(new Item("toolItem1", "Properties", "Check file properties.", true, true));
                _collection.Add(new Item("toolItem2", "Access Control", "Manage file access control.", true, true));
                _collection.Add(new Item("toolItem3", "Style", "Edit file styles.", true, true));
                _collection.Add(new Item("toolItem4", "Change Style", "Change style.", false, true));
                _collection.Add(new Item("toolItem5", "Copy to Style Sheet", "Copy to Style Sheet.", true, true));
                _collection.Add(new Item("toolItem6", "Copy to all Style Sheets", "Copy to all Style Sheets.", true, true));
                _collection.Add(new Item("toolItem7", "HIDDEN", "HIDDEN", true, false));
            }

            return _collection;
        }

        public static ItemCollection GetMenuCollection()
        {
            return Instance();
        }

        public static Item GetItem(INamedBindable namedComponent)
        {
            foreach (Item item in Instance())
            {
                if (item.Name == namedComponent.Name)
                    return item;
            }

            return null;
        }

        public static Item GetItem(string name)
        {
            foreach (Item item in Instance())
            {
                if (item.Name == name)
                    return item;
            }

            return null;
        }
    }
}