using System.Collections.Generic;
using System;
using System.Reflection;
#if WEBGUI
using Gizmox.WebGUI.Forms;
#elif WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Represents the conventions for a particular element type.
    /// </summary>
    public class ElementConvention
    {
        /// <summary>
        /// The type of element to which the conventions apply.
        /// </summary>
        public Type ElementType;

        /// <summary>
        /// The default property to be used in binding conventions.
        /// </summary>
        public string BindingPropertyName;

        /// <summary>
        /// The default event to be used when wiring actions on this element.
        /// </summary>
        public string EventName;

        /// <summary>
        /// The default property to be used for parameters of this type in actions.
        /// </summary>
        public string ParameterProperty;

        /// <summary>
        /// The default action to be used when wiring actions on this element.
        /// </summary>
        public Func<Control, string, IEnumerable<Parameter>, ActionMessage> CreateAction;

        /// <summary>
        /// Applies custom conventions for elements of this type.
        /// </summary>
        /// <remarks>Pass the view model object, property path (aka data member), property instance, control and its convention.</remarks>
        public Func<object, string, PropertyInfo, Control, ElementConvention, bool> ApplyBinding =
            (viewModel, path, property, control, convention) =>
                ConventionManager.SetBindingWithoutBindingOverwrite(viewModel, path, property, control, convention);
    }
}