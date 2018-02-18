using System.Collections.Generic;
using System.Threading;

namespace MvvmFx.Bindings.Input
{
    /// <summary>
    /// Provides functionality for command containers, which are objects that contain zero or more <see cref="CommandBinding"/> instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is implemented by objects that contain commands.
    /// </para>
    /// <para>
    /// The <see cref="CommandBindings"/> property allows the commands in this container to be enumerated, whilst the
    /// <see cref="SynchronizationContext"/> property yields the <see cref="System.Threading.SynchronizationContext"/> used to marshal
    /// property changes within this container.
    /// </para>
    /// </remarks>
    public interface ICommandBindingContainer
    {
        /// <summary>
        /// Gets all <see cref="CommandBinding"/> instances in this container.
        /// </summary>
        IEnumerable<CommandBinding> CommandBindings { get; }
    }
}
