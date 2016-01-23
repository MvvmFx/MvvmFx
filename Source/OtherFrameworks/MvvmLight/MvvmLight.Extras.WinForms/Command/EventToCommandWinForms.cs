using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MvvmFx.Windows;
using MvvmFx.Windows.Input;

namespace MvvmFx.MvvmLight.Command
{
    /// <summary>
    /// This <see cref="MvvmFx.Windows.Interactivity.TriggerAction" /> can be
    /// used to bind any event on any FrameworkElement to an <see cref="ICommand" />.
    /// Typically, this element is used in XAML to connect the attached element
    /// to a command located in a ViewModel. This trigger can only be attached
    /// to a FrameworkElement or a class deriving from FrameworkElement.
    /// <para>To access the EventArgs of the fired event, use a RelayCommand&lt;EventArgs&gt;
    /// and leave the CommandParameter and CommandParameterValue empty!</para>
    /// </summary>
    public partial class EventToCommand
    {
        /// <summary>
        /// Gets the object to which this <see cref="MvvmFx.MvvmLight.Command.EventToCommand"/> is attached.
        /// </summary>
        protected Component AssociatedObject { get; private set; }

        private bool IsEnabled(Component element)
        {
            if (element == null)
                throw new NullReferenceException("element");

            if (element is Control)
            {
                return (element as Control).Enabled;
            }
            if (element is ToolStripItem)
            {
                return (element as ToolStripItem).Enabled;
            }
            if (element is MenuItem)
            {
                return (element as MenuItem).Enabled;
            }

            throw new InvalidCastException("Invalid 'element' base type.");
        }

        private void IsEnabled(Component element, bool value)
        {
            if (element == null)
                throw new NullReferenceException("element");

            if (element is Control)
            {
                (element as Control).Enabled = value;
            }
            else if (element is ToolStripItem)
            {
                (element as ToolStripItem).Enabled = value;
            }
            else if (element is MenuItem)
            {
                (element as MenuItem).Enabled = value;
            }
            else
                throw new InvalidCastException("Invalid 'element' base type.");
        }

        private bool Visibility(Component element)
        {
            if (element == null)
                throw new NullReferenceException("element");

            if (element is Control)
            {
                return (element as Control).Visible;
            }
            if (element is ToolStripItem)
            {
                return (element as ToolStripItem).Visible;
            }
            if (element is MenuItem)
            {
                return (element as MenuItem).Visible;
            }

            throw new InvalidCastException("Invalid 'element' base type.");
        }

        private void Visibility(Component element, bool value)
        {
            if (element == null)
                throw new NullReferenceException("element");

            if (element is Control)
            {
                (element as Control).Visible = value;
            }
            else if (element is ToolStripItem)
            {
                (element as ToolStripItem).Visible = value;
            }
            else if (element is MenuItem)
            {
                (element as MenuItem).Visible = value;
            }
            else
                throw new InvalidCastException("Invalid 'element' base type.");
        }
    }
}
