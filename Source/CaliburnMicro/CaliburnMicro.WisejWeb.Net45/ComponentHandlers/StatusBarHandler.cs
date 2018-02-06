namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
    using MvvmFx.Windows.Data;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="StatusBar"/> control.
    /// </summary>
    /// <seealso cref="StatusBarPanelProxy" />
    public static class StatusBarAgent
    {
        #region GetNamedItems

        /// <summary>
        /// Return the <see cref="StatusBar" /> named items.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetNamedItems = (control) =>
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (!(control is StatusBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(StatusBar).FullName),
                    nameof(control));

            return GetNamedElements((StatusBar) control);
        };

        private static IEnumerable<Control> GetNamedElements(StatusBar control)
        {
            foreach (StatusBarPanel statusBarPanel in control.Panels)
            {
                yield return new StatusBarPanelProxy(statusBarPanel, control.Parent, true);
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