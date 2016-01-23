using System;
#if WEBGUI
using Gizmox.WebGUI.Forms;
#else
using System.ComponentModel;
#endif
using MvvmFx.Windows;

namespace MvvmFx.MvvmLight.Command
{
    /// <summary>
    /// </summary>
    public partial class EventToCommand
    {
        #region protected properties

        /// <summary>
        /// Gets the <see cref="MvvmFx.Windows.FormElement"/> to which this <see cref="MvvmFx.MvvmLight.Command.EventToCommand"/> is attached.
        /// </summary>
        protected FormElement AssociatedObject { get; set; }

        #endregion

        #region public methods

        /// <summary>
        /// Attaches to the specified visual component as associated object.
        /// </summary>
        /// <param name="component">The object to attach to.</param><exception cref="T:System.InvalidOperationException">Cannot host the same TriggerAction on more than one object at a time.</exception><exception cref="T:System.InvalidOperationException">dependencyObject does not satisfy the TriggerAction type constraint.</exception>
        public void Attach(Component component)
        {
            if (component == null)
                throw new NullReferenceException("component");

            if (component == AssociatedObject.HostedComponent)
                return;

            if (AssociatedObject != null)
                throw new InvalidOperationException("Cannot host multiple components.");

            var element = new FormElement(component);
            AssociatedObject = element;
            OnAttached();
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        public void Detach()
        {
            AssociatedObject = null;
        }

        #endregion
    }
}
