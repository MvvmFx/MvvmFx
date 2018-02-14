using Wisej.Web;

namespace MvvmFx.Controls.WisejWeb
{
    /// <summary>
    /// Defines a bindable component with a Name property.
    /// </summary>
    public interface INamedBindable : IBindableComponent
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