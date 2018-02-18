using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using MvvmFx.Bindings.Properties;

namespace MvvmFx.Bindings.Input
{
    /// <summary>
    /// Manages a collection of <see cref="CommandBinding"/> instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of <c>CommandBindingManager</c> are used to store activated bindings. If the <c>CommandBindingManager</c> is disposed, all those
    /// bindings will be deactivated. Once disposed, a <c>CommandBindingManager</c> is no longer usable.
    /// </para>
    /// <para>
    /// The <c>CommandBindingManager</c> class is lightweight, which makes it feasible to create mulitple instances for the purposes of
    /// scoping bindings.
    /// </para>
    /// </remarks>
    public class CommandBindingManager : ICommandBindingContainer, IDisposable
    {
        private readonly CommandBindingCollection _commandBindings;
        private bool _disposed;
        private static readonly ICollection<ICommandBinder> Binders = new List<ICommandBinder>
        {
            new ControlBinder(),
#if !WISEJ
            new ToolStripItemBinder(),
#endif
            new MenuItemBinder()
        };

        /// <summary>
        /// Constructs an instance of <c>CommandBindingManager</c> with the specified <see cref="SynchronizationContext"/>.
        /// </summary>
        public CommandBindingManager()
        {
            _commandBindings = new CommandBindingCollection(this);
        }

        /// <summary>
        /// Gets a collection of all the command bindings activated in this <c>CommandBindingManager</c>.
        /// </summary>
        public ICollection<CommandBinding> CommandBindings
        {
            get
            {
                VerifyNotDisposed();
                return _commandBindings;
            }
        }

        /// <summary>
        /// Gets a collection of all the command bindings activated in this <c>CommandBindingManager</c>.
        /// </summary>
        IEnumerable<CommandBinding> ICommandBindingContainer.CommandBindings
        {
            get { return CommandBindings; }
        }

        /// <summary>
        /// Finds the command binder for the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <exception cref="NoBinderForComponentException"> if the component is unbound.</exception>
        /// <returns>The command binder.</returns>
        internal static ICommandBinder FindBinder(IComponent component)
        {
            var binder = GetBinderFor(component);
            if (binder == null)
            {
                throw new NoBinderForComponentException(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.NoBindingForComponentExceptionMessage,
                    component.GetType()));
            }

            return binder;
        }

        /// <summary>
        /// Gets the binder for the specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        private static ICommandBinder GetBinderFor(IComponent component)
        {
            var type = component.GetType();
            while (type != null)
            {
                var binder = Binders.FirstOrDefault(x => x.SourceType == type);
                if (binder != null)
                {
                    return binder;
                }

                type = type.BaseType;
            }

            return null;
        }

        /// <summary>
        /// Disposes of this <c>CommandBindingManager</c>.
        /// </summary>
        /// <remarks>
        /// This method deactivates all bindings currently activated in this <c>CommandBindingManager</c>.
        /// </remarks>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Dispose(true);
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of this <c>CommandBindingManager</c>.
        /// </summary>
        /// <param name="disposing">
        /// Always <see langword="true"/>.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var binding in _commandBindings)
                {
                    binding.Deactivate();
                }
            }
        }

        private void VerifyNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("CommandBindingManager");
        }

        private sealed class CommandBindingCollection : Collection<CommandBinding>
        {
            private readonly CommandBindingManager _commandBindingManager;

            public CommandBindingCollection(CommandBindingManager commandBindingManager)
            {
                Debug.Assert(commandBindingManager != null);
                _commandBindingManager = commandBindingManager;
            }

            [SuppressMessage("Microsoft.Design", "CA1062", Justification = "The value can be null for reference type.")]
            protected override void InsertItem(int index, CommandBinding item)
            {
                _commandBindingManager.VerifyNotDisposed();
                base.InsertItem(index, item);
                item.Activate(_commandBindingManager);
            }

            [SuppressMessage("Microsoft.Design", "CA1062", Justification = "The value can be null for reference type.")]
            protected override void SetItem(int index, CommandBinding item)
            {
                _commandBindingManager.VerifyNotDisposed();
                this[index].Deactivate();
                base.SetItem(index, item);
                item.Activate(_commandBindingManager);
            }

            protected override void RemoveItem(int index)
            {
                _commandBindingManager.VerifyNotDisposed();
                this[index].Deactivate();
                base.RemoveItem(index);
            }

            protected override void ClearItems()
            {
                _commandBindingManager.VerifyNotDisposed();

                foreach (var item in this)
                {
                    item.Deactivate();
                }

                base.ClearItems();
            }
        }
    }
}
