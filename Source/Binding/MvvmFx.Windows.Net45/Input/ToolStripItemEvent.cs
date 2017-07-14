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

namespace MvvmFx.Windows.Input
{
    /// <summary>
    /// Defines the input that can be raised by a <see cref="ToolStripItem"/>.
    /// </summary>
    public enum ToolStripItemEvent
    {
        /// <summary>
        /// Occurs when the ToolStripItem is clicked.
        /// </summary>
        Click,

        /// <summary>
        /// Occurs when the item is double-clicked with the mouse.
        /// </summary>
        DoubleClick,

        /// <summary>
        /// Occurs when the control is clicked by the mouse.
        /// </summary>
        MouseDown,

        /// <summary>
        /// Occurs when the mouse pointer enters the item.
        /// </summary>
        MouseEnter,

        /// <summary>
        /// Occurs when the mouse pointer hovers over the item.
        /// </summary>
        MouseHover,

        /// <summary>
        /// Occurs when the mouse pointer leaves the item.
        /// </summary>
        MouseLeave,

        /// <summary>
        /// Occurs when the mouse pointer is moved over the item.
        /// </summary>
        MouseMove,

        /// <summary>
        /// Occurs when the mouse pointer is over the item and a mouse button is released.
        /// </summary>
        MouseUp,

        /// <summary>
        /// Occurs when the user drags an item and the user releases the mouse button,
        /// indicating that the item should be dropped into this item.
        /// </summary>
        DragDrop,

        /// <summary>
        /// Occurs when the user drags an item into the client area of this item.
        /// </summary>
        DragEnter,

        /// <summary>
        /// Occurs when the user drags an item and the mouse pointer
        /// is no longer over the client area of this item.
        /// </summary>
        DragLeave,

        /// <summary>
        /// Occurs when the user drags an item over the client area of this item.
        /// </summary>
        DragOver,

        /// <summary>
        /// Occurs during a drag operation.
        /// </summary>
        GiveFeedback,

        /// <summary>
        /// Occurs during a drag-and-drop operation and allows the drag source
        /// to determine whether the drag-and-drop operation should be canceled.
        /// </summary>
        QueryContinueDrag,

        /// <summary>
        /// Occurs when an accessibility client application invokes help for the ToolStripItem.
        /// </summary>
        QueryAccessibilityHelp
    }

    /// <summary>
    /// Converts the enumerable <see cref="ToolStripItemEvent"/> into a list of strings.
    /// </summary>
    public static class ToolStripItemEvents
    {
        private static readonly List<string> EventList = new List<string>(GetToolStripItemEvents());

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
        private static IEnumerable<string> GetToolStripItemEvents()
        {
            var eventList = new List<string>();
            var item = 0;
            while (true)
            {
                if (((ToolStripItemEvent)item).ToString() == item.ToString(CultureInfo.CurrentCulture))
                    break;

                eventList.Add(((ToolStripItemEvent)item).ToString());
                item++;
            }
            return eventList;
        }
    }
}
