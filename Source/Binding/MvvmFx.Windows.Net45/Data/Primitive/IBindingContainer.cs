using System.Collections.Generic;
using System.Threading;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Provides functionality for binding containers, which are objects that contain zero or more <see cref="BindingBase"/> instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is implemented by objects that contain bindings. Since a binding may itself be a container for other bindings,
    /// MvvmFx supports a hierarchy of containers. A <see cref="BindingManager"/> will always be at the root of such a hierarchy.
    /// </para>
    /// <para>
    /// The <see cref="Container"/> property of this interface obtains the <c>IBindingContainer</c> in which this container is contained.
    /// This will be <see langword="null"/> for root-level containers (ie. <see cref="BindingManager"/>s).
    /// </para>
    /// <para>
    /// The <see cref="Bindings"/> property allows the bindings in this container to be enumerated, whilst the
    /// <see cref="SynchronizationContext"/> property yields the <see cref="System.Threading.SynchronizationContext"/> used to marshal
    /// property changes within this container.
    /// </para>
    /// </remarks>
    public interface IBindingContainer
    {
        /// <summary>
        /// Gets the container of this container.
        /// </summary>
        /// <value>
        /// The <see cref="IBindingContainer"/> that contains this container, or <see langword="null"/> if this container is not contained
        /// within another.
        /// </value>
        IBindingContainer Container { get; }

        /// <summary>
        /// Gets all <see cref="BindingBase"/> instances in this container.
        /// </summary>
        IEnumerable<BindingBase> Bindings { get; }

        /// <summary>
        /// Gets the <see cref="SynchronizationContext"/> being used by this binding container.
        /// </summary>
        /// <value>
        /// The <see cref="SynchronizationContext"/> being used by this container, or <see langword="null"/> if this container is not using
        /// a <see cref="SynchronizationContext"/>.
        /// </value>
        SynchronizationContext SynchronizationContext { get; }

        /// <summary>
        /// Gets or sets a flag indicating whether to update the bound value on property validation.
        /// </summary>
        /// <value>
        /// <c>true</c> if the bound value should be updated on property validation;
        /// <c>false</c> if the bound value should be updated on property change.
        /// </value>
        bool BindOnValidation { get; set; }
    }
}
