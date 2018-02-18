using System;
using System.Collections.Generic;
using System.Reflection;
using MvvmFx.Bindings.Data;
using Wisej.Web;

namespace MvvmFx.CaliburnMicro.WisejWeb.Toolable
{
    /// <summary>
    /// Proxy agent for <see cref="PanelEx"/> and binder agent for <see cref="ComponentToolExProxy"/>.
    /// </summary>
    /// <seealso cref="ComponentToolExProxy" />
    public static class PanelExHandler
    {
        #region GetChildItems

        /// <summary>
        /// Return the <see cref="PanelEx" /> child items as <see cref="ComponentToolExProxy"/>.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetChildItems = control =>
        {
            if (!(control is global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx).FullName),
                    @"control");

            return GetNamedElements((global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx) control);
        };

        private static IEnumerable<Control> GetNamedElements(global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx control)
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
        /// Binds the visible and enabled properties of a <see cref="ComponentToolExProxy"/> to 
        /// the ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public static Action<Control, object, BindingManager> BindVisualProperties =
            (control, viewModel, bindingManager) =>
            {
                if (!(control is ComponentToolExProxy))
                    throw new ArgumentException(
                        string.Format("Expecting type {0}", typeof(ComponentToolExProxy).FullName),
                        @"control");

                BindComponentProperties((ComponentToolExProxy) control, viewModel, bindingManager);
            };

        private static void BindComponentProperties(ComponentToolExProxy control, object viewModel,
            BindingManager bindingManager)
        {
            var property = viewModel.GetPropertyCaseInsensitive(control.Name + "Visible");
            if (property != null)
            {
                // must enforce the Visible property
                control.Item.Visible =
                    (bool) property.GetValue(viewModel,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null,
                        null);
                WinFormExtensionMethods.DoBind(control, "Visible", viewModel, property.Name, bindingManager);
            }
            else
            {
                property = viewModel.GetPropertyCaseInsensitive(control.Name + "Enabled");
                if (property != null)
                {
                    // no need for enforce the Enabled property
                    /*control.Item.Enabled =
                        (bool) property.GetValue(viewModel, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, null, null);*/
                    WinFormExtensionMethods.DoBind(control, "Enabled", viewModel, property.Name, bindingManager);
                }
            }
        }

        #endregion
    }
}