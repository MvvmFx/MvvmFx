namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// Represents an attachable object that encapsulates a unit of functionality.
    /// </summary>
    /// <typeparam name="T">The type to which this action can be attached.</typeparam>
    public abstract class TriggerAction<T> : TriggerAction where T : IDependencyObject
    {
        /// <summary>
        /// Gets the object to which this <see cref="T:MvvmFx.Bindings.Interactivity.TriggerAction`1"/> is attached.
        /// </summary>
        /// <value>
        /// The associated object.
        /// </value>
        protected new T AssociatedObject
        {
            get { return (T) base.AssociatedObject; }
        }
    }
}
