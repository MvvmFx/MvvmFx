namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.Collections.Generic;
    using Wisej.Web;

    /// <summary>
    /// Proxy agent for <see cref="StatusBar"/> control.
    /// </summary>
    /// <seealso cref="StatusBarPanelProxy" />
    public static class StatusBarHandler
    {
        #region GetChildItems

        /// <summary>
        /// Return the <see cref="StatusBar" /> child items as <see cref="StatusBarPanelProxy"/>.
        /// </summary>
        public static Func<Control, IEnumerable<Control>> GetChildItems = (control) =>
        {
            if (!(control is StatusBar))
                throw new ArgumentException(
                    string.Format("Expecting type {0}", typeof(StatusBar).FullName),
                    @"control");

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
    }
}