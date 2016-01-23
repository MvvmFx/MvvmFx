namespace MvvmFx.Windows.Input
{
    /// <summary>
    /// Interface used to define a command binding.
    /// </summary>
    public interface ICommandBinding
    {
        /// <summary>
        /// Gets or sets the command for this binding.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        IBoundCommand Command { get; set; }

        /// <summary>
        /// Gets or sets the source for this binding.
        /// </summary>
        /// <value>
        /// The source object.
        /// </value>
        object SourceObject { get; set; }

        /// <summary>
        /// Gets or sets the trigger event for this binding.
        /// </summary>
        /// <value>
        /// The source event.
        /// </value>
        string SourceEvent { get; set; }
    }
}
