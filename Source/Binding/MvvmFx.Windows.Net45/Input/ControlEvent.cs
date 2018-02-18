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
    /// Defines the input events that can be raised by a <see cref="Control"/>.
    /// </summary>
    public enum ControlEvent
    {
        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        Click,

        /// <summary>
        /// Occurs when the control is double-clicked.
        /// </summary>
        DoubleClick,

        /// <summary>
        /// Occurs when the control is clicked by the mouse.
        /// </summary>
        MouseClick,

        /// <summary>
        /// Occurs when the control is double clicked by the mouse.
        /// </summary>
        MouseDoubleClick,

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed.
        /// </summary>
        MouseDown,

        /// <summary>
        /// Occurs when the mouse pointer enters the control.
        /// </summary>
        MouseEnter,

        /// <summary>
        /// Occurs when the mouse pointer rests on the control.
        /// </summary>
        MouseHover,

        /// <summary>
        /// Occurs when the mouse pointer leaves the control.
        /// </summary>
        MouseLeave,

        /// <summary>
        /// Occurs when the mouse pointer is moved over the control.
        /// </summary>
        MouseMove,

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released.
        /// </summary>
        MouseUp,

        /// <summary>
        /// Occurs when the mouse wheel moves while the control has focus.
        /// </summary>
        MouseWheel,

        /// <summary>
        /// Occurs when the control loses mouse capture. ,
        /// </summary>
        MouseCaptureChanged,

        /// <summary>
        /// Occurs when a drag-and-drop operation is completed.
        /// </summary>
        DragDrop,

        /// <summary>
        /// Occurs when an object is dragged into the control's bounds.
        /// </summary>
        DragEnter,

        /// <summary>
        /// Occurs when an object is dragged out of the control's bounds.
        /// </summary>
        DragLeave,

        /// <summary>
        /// Occurs when an object is dragged over the control's bounds.
        /// </summary>
        DragOver,

        /// <summary>
        /// Occurs during a drag operation.
        /// </summary>
        GiveFeedback,

        /// <summary>
        /// Occurs during a drag-and-drop operation and enables the drag source,
        /// to determine whether the drag-and-drop operation should be canceled.
        /// </summary>
        QueryContinueDrag,

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        KeyDown,

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        KeyPress,

        /// <summary>
        /// Occurs when a key is released while the control has focus.
        /// </summary>
        KeyUp,

        /// <summary>
        /// Occurs before the KeyDown event when a key is pressed while focus is on this control.
        /// </summary>
        PreviewKeyDown,

        /// <summary>
        /// Occurs when the control is entered.
        /// </summary>
        Enter,

        /// <summary>
        /// Occurs when the input focus leaves the control.
        /// </summary>
        Leave,

        /// <summary>
        /// Occurs when the control loses focus.
        /// </summary>
        LostFocus,

        /// <summary>
        /// Occurs when the control receives focus.
        /// </summary>
        GotFocus,

        /// <summary>
        /// Occurs when the focus or keyboard user interface (UI) cues change.
        /// </summary>
        ChangeUICues,

        /// <summary>
        /// Occurs when the user requests help for a control.
        /// </summary>
        HelpRequested,

        /// <summary>
        /// Occurs when AccessibleObject is providing help to accessibility applications.
        /// </summary>
        QueryAccessibilityHelp
    }

    /// <summary>
    /// Converts the enumerable <see cref="ControlEvent"/> into a list of strings.
    /// </summary>
    public static class ControlEvents
    {
        private static readonly List<string> EventList = new List<string>(GetControlEvents());

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
        private static IEnumerable<string> GetControlEvents()
        {
            var eventList = new List<string>();
            var item = 0;
            while (true)
            {
                if (((ControlEvent) item).ToString() == item.ToString(CultureInfo.CurrentCulture))
                    break;

                eventList.Add(((ControlEvent) item).ToString());
                item++;
            }
            return eventList;
        }
    }
}
