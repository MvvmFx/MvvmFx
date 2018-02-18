using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
#if WISEJ
using Wisej.Web;
#elif WEBGUI
using Gizmox.WebGUI.Forms;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.Bindings.Input
{
    /// <summary>
    /// Defines the input that can be raised by a <see cref="MenuItem"/>.
    /// </summary>
    public enum MenuItemEvent
    {
        /// <summary>
        /// Occurs when the menu item is clicked or selected using
        /// a shortcut key or access key defined for the menu item.
        /// </summary>
        Click,

        /// <summary>
        /// Occurs when the user places the pointer over a menu item.
        /// </summary>
        Select
    }

    /// <summary>
    /// Converts the enumerable <see cref="MenuItemEvent"/> into a list of strings.
    /// </summary>
    public static class MenuItemEvents
    {
        private static readonly List<string> EventList = new List<string>(GetMenuItemEvents());

        /// <summary>
        /// Gets the input events list.
        /// </summary>
        /// <value>
        /// The input events.
        /// </value>
        public static ReadOnlyCollection<string> InputEvents
        {
            get { return EventList.AsReadOnly(); }
        }

        /// <summary>
        /// Initializes the <see cref="ControlEvents"/> class.
        /// </summary>
        private static IEnumerable<string> GetMenuItemEvents()
        {
            var eventList = new List<string>();
            var item = 0;
            while (true)
            {
                if (((MenuItemEvent)item).ToString() == item.ToString(CultureInfo.CurrentCulture))
                    break;

                eventList.Add(((MenuItemEvent)item).ToString());
                item++;
            }
            return eventList;
        }
    }
}
