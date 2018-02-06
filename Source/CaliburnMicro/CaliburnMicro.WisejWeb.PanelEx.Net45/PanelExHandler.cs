using System;
using System.Collections.Generic;
using MvvmFx.Windows.Data;
using Wisej.Web;

namespace CaliburnMicro.WisejWeb.PanelEx
{
    /// <summary>
    /// Proxy agent for <see cref="PanelEx"/> control.
    /// </summary>
    /// <seealso cref="ComponentToolExProxy" />
    public static class PanelExAgent
    {
        #region GetNamedItems

        /// <summary>
        /// Return the <see cref="PanelEx" /> named items.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetNamedItems = control =>
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!(control is PanelEx))
                throw new ArgumentException(
                    string.Format("Expecting type {0}",
                        typeof(PanelEx).FullName),
                    nameof(control));

            return GetNamedElements((PanelEx) control);
        };

        private static IEnumerable<Control> GetNamedElements(PanelEx control)
        {
            foreach (ComponentTool tool in control.Tools)
            {
                ComponentToolEx toolEx = tool as ComponentToolEx;
                if (toolEx != null)
                {
                    yield return new ComponentToolExProxy(toolEx, control.Parent, true);
                }
            }
        }

        #endregion

        #region BindVisualProperties

        /// <summary>
        /// Binds the visible and enabled properties of a <see cref="Control"/> to 
        /// the ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (namedElements, viewModel, bindingManager) =>
            {

            };

        #endregion
    }
}