using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
#if WEBGUI
using Gizmox.WebGUI.Forms;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.Windows.Input
{
    #region ICommandBinder interface

    /// <summary>
    /// Interface used to define a command binder.
    /// </summary>
    internal interface ICommandBinder
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the source object.
        /// </summary>
        /// <value>
        /// The type of the source object.
        /// </value>
        Type SourceType { get; }

        /// <summary>
        /// List the name of all supported input events
        /// </summary>
        ReadOnlyCollection<string> InputEvents { get; }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        void Attach(IBoundCommand command, object source, string sourceEvent);

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        void Dettach(IBoundCommand command, object source, string sourceEvent);
    }

    #endregion

    #region ICommandBinder implementations

    /// <summary>
    /// Binder for <see cref="Control"/> objects.
    /// </summary>
    internal class ControlBinder : ICommandBinder
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the source object.
        /// </summary>
        /// <value>
        /// The type of the source object.
        /// </value>
        public Type SourceType
        {
            get { return typeof(Control); }
        }

        /// <summary>
        /// List the name of all supported input events
        /// </summary>
        public ReadOnlyCollection<string> InputEvents
        {
            get { return ControlEvents.InputEvents; }
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502", Justification = "The class is immutable so no maintenance problems expected.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1506", Justification = "The class is immutable so no maintenance problems expected.")]
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Attach(IBoundCommand command, object source, string sourceEvent)
        {
            var control = source as Control;
            if (control == null)
                throw new NullReferenceException();

            control.Enabled = command.CanExecute(null);
            var attached = true;
            var triggerEvent = TypeDescriptor.GetEvents(control).Find(sourceEvent, false);
            if (triggerEvent != null)
            {
                if (triggerEvent.EventType == typeof(EventHandler))
                    triggerEvent.AddEventHandler(control, (EventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(MouseEventHandler))
                    triggerEvent.AddEventHandler(control, (MouseEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(DragEventHandler))
                    triggerEvent.AddEventHandler(control, (DragEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(QueryContinueDragEventHandler))
                    triggerEvent.AddEventHandler(control, (QueryContinueDragEventHandler)((s, e) => command.Execute(null)));
#endif
                else if (triggerEvent.EventType == typeof(KeyEventHandler))
                    triggerEvent.AddEventHandler(control, (KeyEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(KeyPressEventHandler))
                    triggerEvent.AddEventHandler(control, (KeyPressEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(PreviewKeyDownEventHandler))
                    triggerEvent.AddEventHandler(control, (PreviewKeyDownEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(UICuesEventHandler))
                    triggerEvent.AddEventHandler(control, (UICuesEventHandler)((s, e) => command.Execute(null)));
#endif
                else if (triggerEvent.EventType == typeof(HelpEventHandler))
                    triggerEvent.AddEventHandler(control, (HelpEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(QueryAccessibilityHelpEventHandler))
                    triggerEvent.AddEventHandler(control, (QueryAccessibilityHelpEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(GiveFeedbackEventHandler))
                    triggerEvent.AddEventHandler(control, (GiveFeedbackEventHandler)((s, e) => command.Execute(null)));
#endif
                else attached = false;
            }

            if (!attached)
                control.Click += (s, e) => command.Execute(null);

            command.CanExecuteChanged += (s, e) => control.Enabled = command.CanExecute(null);
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502", Justification = "The class is immutable so no maintenance problems expected.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1506", Justification = "The class is immutable so no maintenance problems expected.")]
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Dettach(IBoundCommand command, object source, string sourceEvent)
        {
            var control = source as Control;
            if (control == null)
                throw new NullReferenceException();

            control.Enabled = false;
            var detached = true;
            var triggerEvent = TypeDescriptor.GetEvents(control).Find(sourceEvent, false);
            if (triggerEvent != null)
            {
                if (triggerEvent.EventType == typeof(EventHandler))
                    triggerEvent.RemoveEventHandler(control, (EventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(MouseEventHandler))
                    triggerEvent.RemoveEventHandler(control, (MouseEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(DragEventHandler))
                    triggerEvent.RemoveEventHandler(control, (DragEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(QueryContinueDragEventHandler))
                    triggerEvent.RemoveEventHandler(control, (QueryContinueDragEventHandler)((s, e) => command.Execute(null)));
#endif
                else if (triggerEvent.EventType == typeof(KeyEventHandler))
                    triggerEvent.RemoveEventHandler(control, (KeyEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(KeyPressEventHandler))
                    triggerEvent.RemoveEventHandler(control, (KeyPressEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(PreviewKeyDownEventHandler))
                    triggerEvent.RemoveEventHandler(control, (PreviewKeyDownEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(UICuesEventHandler))
                    triggerEvent.RemoveEventHandler(control, (UICuesEventHandler)((s, e) => command.Execute(null)));
#endif
                else if (triggerEvent.EventType == typeof(HelpEventHandler))
                    triggerEvent.RemoveEventHandler(control, (HelpEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(QueryAccessibilityHelpEventHandler))
                    triggerEvent.RemoveEventHandler(control, (QueryAccessibilityHelpEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(GiveFeedbackEventHandler))
                    triggerEvent.RemoveEventHandler(control, (GiveFeedbackEventHandler)((s, e) => command.Execute(null)));
#endif
                else detached = false;
            }

            if (!detached)
                control.Click -= (s, e) => command.Execute(null);

            command.CanExecuteChanged -= (s, e) => control.Enabled = command.CanExecute(null);
        }
    }

    /// <summary>
    /// Binder for <see cref="ToolStripItem"/> objects.
    /// </summary>
    internal class ToolStripItemBinder : CommandBinding, ICommandBinder
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the source object.
        /// </summary>
        /// <value>
        /// The type of the source object.
        /// </value>
        public Type SourceType
        {
            get { return typeof(ToolStripItem); }
        }

        /// <summary>
        /// List the name of all supported input events
        /// </summary>
        public ReadOnlyCollection<string> InputEvents
        {
            get { return ToolStripItemEvents.InputEvents; }
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Attach(IBoundCommand command, object source, string sourceEvent)
        {
            var toolStripItem = source as ToolStripItem;
            if (toolStripItem == null)
                throw new NullReferenceException();

            toolStripItem.Enabled = command.CanExecute(null);
            var attached = true;
            var triggerEvent = TypeDescriptor.GetEvents(toolStripItem).Find(sourceEvent, false);
            if (triggerEvent != null)
            {
                if (triggerEvent.EventType == typeof(EventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (EventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(MouseEventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (MouseEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(DragEventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (DragEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(GiveFeedbackEventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (GiveFeedbackEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(QueryContinueDragEventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (QueryContinueDragEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(QueryAccessibilityHelpEventHandler))
                    triggerEvent.AddEventHandler(toolStripItem, (QueryAccessibilityHelpEventHandler)((s, e) => command.Execute(null)));
#endif
                else attached = false;
            }

            if (!attached)
                toolStripItem.Click += (s, e) => command.Execute(null);

            command.CanExecuteChanged += (s, e) => toolStripItem.Enabled = command.CanExecute(null);
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Dettach(IBoundCommand command, object source, string sourceEvent)
        {
            var toolStripItem = source as ToolStripItem;
            if (toolStripItem == null)
                throw new NullReferenceException();

            toolStripItem.Enabled = false;
            var detached = true;
            var triggerEvent = TypeDescriptor.GetEvents(toolStripItem).Find(sourceEvent, false);
            if (triggerEvent != null)
            {
                if (triggerEvent.EventType == typeof(EventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (EventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(MouseEventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (MouseEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(DragEventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (DragEventHandler)((s, e) => command.Execute(null)));
#if !WEBGUI
                else if (triggerEvent.EventType == typeof(GiveFeedbackEventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (GiveFeedbackEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(QueryContinueDragEventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (QueryContinueDragEventHandler)((s, e) => command.Execute(null)));
                else if (triggerEvent.EventType == typeof(QueryAccessibilityHelpEventHandler))
                    triggerEvent.RemoveEventHandler(toolStripItem, (QueryAccessibilityHelpEventHandler)((s, e) => command.Execute(null)));
#endif
                else detached = false;
            }

            if (!detached)
                toolStripItem.Click -= (s, e) => command.Execute(null);

            command.CanExecuteChanged -= (s, e) => toolStripItem.Enabled = command.CanExecute(null);
        }
    }

    /// <summary>
    /// Binder for <see cref="MenuItem"/> objects.
    /// </summary>
    internal class MenuItemBinder : CommandBinding, ICommandBinder
    {
        /// <summary>
        /// Gets the <see cref="System.Type"/> of the source object.
        /// </summary>
        /// <value>
        /// The type of the source object.
        /// </value>
        public Type SourceType
        {
            get { return typeof(MenuItem); }
        }

        /// <summary>
        /// List the name of all supported input events
        /// </summary>
        public ReadOnlyCollection<string> InputEvents
        {
            get { return MenuItemEvents.InputEvents; }
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Attach(IBoundCommand command, object source, string sourceEvent)
        {
            var menuItem = source as MenuItem;
            if (menuItem == null)
                throw new NullReferenceException();

            menuItem.Enabled = command.CanExecute(null);
            var triggerEvent = TypeDescriptor.GetEvents(menuItem).Find(sourceEvent, false);

            if (triggerEvent != null && triggerEvent.EventType == typeof(EventHandler))
                triggerEvent.AddEventHandler(menuItem, (EventHandler)((s, e) => command.Execute(null)));
            else
                menuItem.Click += (s, e) => command.Execute(null);

            command.CanExecuteChanged += (s, e) => menuItem.Enabled = command.CanExecute(null);
        }

        /// <summary>
        /// Binds the the event on the source object to the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">Name of the source event.</param>
        [SuppressMessage("Microsoft.Usage", "CA2201", Justification = "This is base API code much like framework code.")]
        public void Dettach(IBoundCommand command, object source, string sourceEvent)
        {
            var menuItem = source as MenuItem;
            if (menuItem == null)
                throw new NullReferenceException();

            menuItem.Enabled = false;
            var triggerEvent = TypeDescriptor.GetEvents(menuItem).Find(sourceEvent, false);

            if (triggerEvent != null && triggerEvent.EventType == typeof(EventHandler))
                triggerEvent.RemoveEventHandler(menuItem, (EventHandler)((s, e) => command.Execute(null)));
            else
                menuItem.Click -= (s, e) => command.Execute(null);

            command.CanExecuteChanged -= (s, e) => menuItem.Enabled = command.CanExecute(null);
        }
    }

    #endregion
}
