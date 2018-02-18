namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
    using System.Collections.Generic;
#if WINFORMS
    using System.Windows.Forms;
#else
    using Wisej.Web;
#endif
    using MvvmFx.Bindings.Data;

    /// <summary>
    /// Represents the helper method to handle component child items for a particular control type.
    /// </summary>
    public class ProxyAgent
    {
        /// <summary>
        /// Return the <see cref="Control" /> component child items wraped in proxy controls.
        /// </summary>
        public Func<Control, IEnumerable<Control>> GetChildItems;
    }
}