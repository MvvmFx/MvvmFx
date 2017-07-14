using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using MvvmFx.Windows.Properties;

namespace MvvmFx.Windows.Input
{
    /// <summary>
    /// Connects an event on a source object to a command.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="Container"/> property provides access to the <see cref="ICommandBindingContainer"/> in which the binding is activated.
    /// For many bindings, this will be the <see cref="CommandBindingManager"/> to which they were added.
    /// </para>
    /// </remarks>
    public class CommandBinding : ICommandBinding
    {
        private ICommandBindingContainer _container;
        private readonly WeakReference _command;
        private readonly WeakReference _sourceObject;
        private string _sourceEvent;
        private bool _validEvent;
        private bool _attached;
        private int _activated;

        /// <summary>
        /// Constructs an instance of <c>CommandBinding</c>.
        /// </summary>
        public CommandBinding()
        {
            _command = new WeakReference(null);
            _sourceObject = new WeakReference(null);
        }

        /// <summary>
        /// Constructs an instance of <c>CommandBinding</c> using the specified details.
        /// </summary>
        /// <param name="command">The command object.</param>
        /// <param name="source">The source object.</param>
        /// <param name="sourceEvent">The source event.</param>
        public CommandBinding(IBoundCommand command, object source, string sourceEvent)
            :this()
        {
            Command = command;
            SourceObject = source;
            SourceEvent = sourceEvent;
        }

        /// <summary>
        /// Gets the <see cref="CommandBindingManager"/> that this binding is currently activated in, or <see langword="null"/> if it is not
        /// activated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ICommandBindingContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Gets or sets the command object for this binding.
        /// </summary>
        public IBoundCommand Command
        {
            get { return (IBoundCommand)_command.Target; }
            set
            {
                Detach();
                VerifyNotActivated();
                _command.Target = value;
                Attach();
            }
        }

        /// <summary>
        /// Gets or sets the source object for this binding.
        /// </summary>
        public object SourceObject
        {
            get { return _sourceObject.Target; }
            set
            {
                if (_sourceObject.Target == value)
                    return;

                Detach();
                VerifyNotActivated();
                _sourceObject.Target = value;
                if (string.IsNullOrEmpty(_sourceEvent))
                    _validEvent = false;
                else
                {
                    VerifyEventValid();
                    Attach();
                }
            }
        }

        /// <summary>
        /// Gets or sets the trigger event for this binding.
        /// </summary>
        public string SourceEvent
        {
            get { return _sourceEvent; }
            set
            {
                if (_sourceEvent == value)
                    return;

                Detach();
                VerifyNotActivated();
                _sourceEvent = value;
                if (_sourceObject.Target == null)
                    _validEvent = false;
                else
                {
                    VerifyEventValid();
                    Attach();
                }
            }
        }

        private void Detach()
        {
            if (_attached)
            {
                var binder = CommandBindingManager.FindBinder(SourceObject as IComponent);
                binder.Dettach(Command, SourceObject, _sourceEvent);
            }
        }

        private void Attach()
        {
            if (!_attached && Command != null && _validEvent)
            {
                var binder = CommandBindingManager.FindBinder(SourceObject as IComponent);
                binder.Attach(Command, SourceObject, _sourceEvent);
                _attached = true;
            }
        }

        /// <summary>
        /// Verifies whether the event is valid on the source object.
        /// </summary>
        private void VerifyEventValid()
        {
            if (!_validEvent)
            {
                var binder = CommandBindingManager.FindBinder(SourceObject as IComponent);
                if (binder.InputEvents.All(evt => SourceEvent != evt))
                    throw new InvalidEventException();
            }
            _validEvent = true;
        }

        /// <summary>
        /// Attempts to activate this <c>CommandBinding</c> in the specified <see cref="ICommandBindingContainer"/>.
        /// </summary>
        /// <param name="bindingContainer">
        /// The <see cref="ICommandBindingContainer"/> within which this binding will be activated.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1062", Justification = "'bindingContainer' is checked not null or ArgumentNullException will be thrown.")]
        public void Activate(ICommandBindingContainer bindingContainer)
        {
            if (bindingContainer == null)
                throw new ArgumentNullException("bindingContainer");
            if (!_validEvent)
                throw new InvalidOperationException(Resources.EventForCommandBindingIsNotValid);
            if (!_attached)
                throw new InvalidOperationException(Resources.EventForCommandBindingIsNotValid);
            if (!bindingContainer.CommandBindings.Contains(this))
                throw new InvalidOperationException(Resources.CommandBindingMustBeActivatedInOwningContainer);

            if (Interlocked.CompareExchange(ref _activated, 1, 0) != 0)
            {
                throw new InvalidOperationException(Resources.AlreadyActivated);
            }

            _container = bindingContainer;
            OnActivated();
        }

        /// <summary>
        /// Deactivates this <c>CommandBinding</c> so that it can be activated again.
        /// </summary>
        internal void Deactivate()
        {
            if (Interlocked.Exchange(ref _activated, 0) == 1)
            {
                _container = null;
                OnDeactivated();
            }
        }

        //TODO: these VerifyNotActivated methods aren't thread-safe from the caller's perspective
        //Consider: thread A calls VerifyNotInUse which returns without problem, then thread B uses the same object, then thread A continues
        //on thinking the object is not in use

        /// <summary>
        /// Verifies that this <c>CommandBinding</c> is activated, and throws an exception with a default message if it is not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void VerifyActivated()
        {
            VerifyActivated(Resources.BindingBaseNotActivatedExceptionMessage);
        }

        /// <summary>
        /// Verifies that this <c>CommandBinding</c> is activated, and throws an exception with the specified message if it is not.
        /// </summary>
        /// <param name="message">
        /// The message to use for the exception if the <c>CommandBinding</c> is not activated.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void VerifyActivated(string message)
        {
            if (_activated == 0)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Verifies that this <c>CommandBinding</c> is not activated, and throws an exception with a default message if it is.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void VerifyNotActivated()
        {
            VerifyNotActivated(Resources.BindingBaseActivatedExceptionMessage);
        }

        /// <summary>
        /// Verifies that this <c>CommandBinding</c> is not activated, and throws an exception with the specified message if it is.
        /// </summary>
        /// <param name="message">
        /// The message to use for the exception if the <c>CommandBinding</c> is activated.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void VerifyNotActivated(string message)
        {
            if (_activated == 1)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Called when this <c>CommandBinding</c> is activated.
        /// </summary>
        protected virtual void OnActivated()
        {
        }

        /// <summary>
        /// Called when this <c>CommandBinding</c> is deactivated.
        /// </summary>
        protected virtual void OnDeactivated()
        {
        }
    }
}
