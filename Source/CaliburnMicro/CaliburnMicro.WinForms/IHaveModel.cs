namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Defines a view model with a model object that maintains data.</summary>
    public interface IHaveModel
    {
        /// <summary>
        /// Gets or sets the Model property of the view model object.
        /// </summary>
        /// <value>
        /// The model object.
        /// </value>
        object Model { get; set; }
    }
}