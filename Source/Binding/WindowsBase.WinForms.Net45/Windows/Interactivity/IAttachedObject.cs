namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAttachedObject
    {
        /// <summary>
        /// Attaches the specified <see cref="MvvmFx.Bindings.IDependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">The <see cref="MvvmFx.Bindings.IDependencyObject"/> to attach</param>
        void Attach(IDependencyObject dependencyObject);

        /// <summary>
        /// Detaches the currently associated <see cref="MvvmFx.Bindings.IDependencyObject"/>.
        /// </summary>
        void Detach();

        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <remarks>Represents the <see cref="MvvmFx.Bindings.IDependencyObject"/> this instance is attached to.</remarks>
        IDependencyObject AssociatedObject { get; }
    }
}
