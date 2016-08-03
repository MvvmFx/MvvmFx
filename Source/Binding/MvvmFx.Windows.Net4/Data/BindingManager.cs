using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Manages a collection of <see cref="BindingBase"/> instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of <c>BindingManager</c> are used to store activated bindings. If the <c>BindingManager</c> is disposed, all those
    /// bindings will be deactivated. Once disposed, a <c>BindingManager</c> is no longer usable.
    /// </para>
    /// <para>
    /// A <c>BindingManager</c> represents the root of a binding hierarchy. As a container of bindings, it implements the
    /// <see cref="IBindingContainer"/> interface. However, it never resides in a container itself, so its
    /// <see cref="IBindingContainer.Container"/> property always yields <see langword="null"/>.
    /// </para>
    /// <para>
    /// When a <c>BindingManager</c> is created, a <see cref="System.Threading.SynchronizationContext"/> can optionally be specified. If a
    /// <c>BindingManager</c> has a <see cref="System.Threading.SynchronizationContext"/>, it will be used to marshal any binding value
    /// changes onto the appropriate thread. If the default constructor is used, the
    /// <see cref="System.Threading.SynchronizationContext.Current"/> property is used to set <see cref="SynchronizationContext"/>.
    /// </para>
    /// <para>
    /// The <c>BindingManager</c> class is lightweight, which makes it feasible to create mulitple instances for the purposes of
    /// scoping bindings.
    /// </para>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="BindingManager.Creation"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="BindingManager.Creation.Fluent"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="BindingManager.Component"]/*'/>
    public class BindingManager : IBindingContainer, IDisposable
    {
        private readonly BindingBaseCollection _bindings;
#if !WEBGUI && !WISEJ
        private readonly SynchronizationContext _synchronizationContext;
#endif
        private bool _disposed;

        /// <summary>
        /// Constructs an instance of <c>BindingManager</c>, using the current <see cref="SynchronizationContext"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This constructor will use <see cref="System.Threading.SynchronizationContext.Current"/> for the <c>BindingManager</c>'s
        /// <see cref="SynchronizationContext"/> property.
        /// </para>
        /// </remarks>
        public BindingManager()
            : this(SynchronizationContext.Current)
        {
        }

        /// <summary>
        /// Constructs an instance of <c>BindingManager</c> with the specified <see cref="SynchronizationContext"/>.
        /// </summary>
        /// <param name="synchronizationContext">
        /// The <see cref="SynchronizationContext"/> to use for all bindings in this binding manager, or <see langword="null"/> if no
        /// <see cref="SynchronizationContext"/> should be used.
        /// </param>
        public BindingManager(SynchronizationContext synchronizationContext)
        {
            _bindings = new BindingBaseCollection(this);
#if !WEBGUI && !WISEJ
            _synchronizationContext = synchronizationContext;
#endif
        }

        /// <summary>
        /// Gets a collection of all the bindings activated in this <c>BindingManager</c>.
        /// </summary>
        public ICollection<BindingBase> Bindings
        {
            get
            {
                VerifyNotDisposed();
                return _bindings;
            }
        }

        /// <summary>
        /// Gets the <see cref="SynchronizationContext"/> in use within this <c>BindingManager</c>.
        /// </summary>
        /// <value>
        /// The <see cref="SynchronizationContext"/> being used for all bindings in this <c>BindingManager</c>, or <see langword="null"/>
        /// if no <see cref="SynchronizationContext"/> is being used in this <c>BindingManager</c>.
        /// </value>
        public SynchronizationContext SynchronizationContext
        {
            get
            {
                VerifyNotDisposed();
#if !WEBGUI && !WISEJ
                return _synchronizationContext;
#else
                return null;
#endif
            }
        }

        /// <summary>
        /// Always returns <see langword="null"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033", Justification = "A binding container is the root object and does not ever live inside another container.")]
        IBindingContainer IBindingContainer.Container
        {
            get
            {
                VerifyNotDisposed();
                return null;
            }
        }

        /// <summary>
        /// Gets a collection of all the bindings activated in this <c>BindingManager</c>.
        /// </summary>
        IEnumerable<BindingBase> IBindingContainer.Bindings
        {
            get { return Bindings; }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether to update the bound value on property validation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the bound value should be updated on property validation;
        /// <c>false</c> if the bound value should be updated on property change.
        /// </value>
        public bool BindOnValidation { get; set; }

        /// <summary>
        /// Disposes of this <c>BindingManager</c>.
        /// </summary>
        /// <remarks>
        /// This method deactivates all bindings currently activated in this <c>BindingManager</c>.
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
        /// Disposes of this <c>BindingManager</c>.
        /// </summary>
        /// <param name="disposing">
        /// Always <see langword="true"/>.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var binding in _bindings)
                {
                    binding.Deactivate();
                }
            }
        }

        private void VerifyNotDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("BindingManager");
        }

        private sealed class BindingBaseCollection : Collection<BindingBase>
        {
            private readonly BindingManager _bindingManager;

            public BindingBaseCollection(BindingManager bindingManager)
            {
                Debug.Assert(bindingManager != null);
                _bindingManager = bindingManager;
            }

            [SuppressMessage("Microsoft.Design", "CA1062", Justification = "The value can be null for reference type.")]
            protected override void InsertItem(int index, BindingBase item)
            {
                _bindingManager.VerifyNotDisposed();
                base.InsertItem(index, item);
                item.Activate(_bindingManager);
            }

            [SuppressMessage("Microsoft.Design", "CA1062", Justification = "The value can be null for reference type.")]
            protected override void SetItem(int index, BindingBase item)
            {
                _bindingManager.VerifyNotDisposed();
                this[index].Deactivate();
                base.SetItem(index, item);
                item.Activate(_bindingManager);
            }

            protected override void RemoveItem(int index)
            {
                _bindingManager.VerifyNotDisposed();
                this[index].Deactivate();
                base.RemoveItem(index);
            }

            protected override void ClearItems()
            {
                _bindingManager.VerifyNotDisposed();

                foreach (var item in this)
                {
                    item.Deactivate();
                }

                base.ClearItems();
            }
        }
    }
}
