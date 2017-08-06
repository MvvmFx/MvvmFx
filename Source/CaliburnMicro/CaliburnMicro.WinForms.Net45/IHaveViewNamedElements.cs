using System.Collections.Generic;
#if WISEJ
using FrameworkElement = Wisej.Web.Control;
#else
using FrameworkElement = System.Windows.Forms.Control;

#endif

namespace MvvmFx.CaliburnMicro
{
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
        List<FrameworkElement> ViewNamedElements { get; set; }
    }
}