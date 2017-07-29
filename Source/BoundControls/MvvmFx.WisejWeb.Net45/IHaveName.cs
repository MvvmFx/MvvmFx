namespace MvvmFx.WisejWeb
{
    /// <summary>
    /// Defines a component with a Name property.
    /// </summary>
    public interface IHaveName
    {
        /// <summary>
        /// Gets or sets the Name property of the component object.
        /// </summary>
        /// <value>
        /// The component Name.
        /// </value>
        string Name { get; set; }
    }
}