namespace MvvmFx.Windows.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAttachedObject
    {
        /// <summary>
        /// Attaches the specified <see cref="MvvmFx.Windows.IDependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">The <see cref="MvvmFx.Windows.IDependencyObject"/> to attach</param>
        void Attach(IDependencyObject dependencyObject);

        /// <summary>
        /// Detaches the currently associated <see cref="MvvmFx.Windows.IDependencyObject"/>.
        /// </summary>
        void Detach();

        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <remarks>Represents the <see cref="MvvmFx.Windows.IDependencyObject"/> this instance is attached to.</remarks>
        IDependencyObject AssociatedObject { get; }
    }
}
