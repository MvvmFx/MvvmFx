using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings.Input
{
    /// <summary>
    /// Defines a bound command that can be used by the <see cref="MvvmFx.Bindings.Input.CommandBinding"/>.
    /// Bound commands may have or have not a parameter, but the parameter must be immutable
    /// as the binding system always pass <c>null</c> as parameter for <c>CanExecute()</c> and <c>Execute()</c>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1040", Justification = "The interface is used to identify a set of types at compile time.")]
    public interface IBoundCommand : ICommand
    {
    }
}
