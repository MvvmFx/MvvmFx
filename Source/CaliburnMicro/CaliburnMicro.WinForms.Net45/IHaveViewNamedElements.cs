namespace MvvmFx.CaliburnMicro
{
    using System.Collections.Generic;
#if WISEJ
    using Control = Wisej.Web.Control;
#else
    using Control = System.Windows.Forms.Control;
#endif

    /// <summary>
    /// Defines a view model that caches a list of all control objects on the attached view.
    /// </summary>
    public interface IHaveViewNamedElements
    {
        /// <summary>
        /// Gets or sets the control objects of the view.
        /// </summary>
        /// <value>
        /// The control objects of the view.
        /// </value>
        List<Control> ViewNamedElements { get; set; }
    }
}