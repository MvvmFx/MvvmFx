namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
#if WINFORMS
    using System.Windows.Forms;
#else
    using Wisej.Web;
#endif
    using MvvmFx.Windows.Data;

    /// <summary>
    /// Represents the binding methods and helpers for a particular control type.
    /// </summary>
    public class ProxyAgent
    {
        /// <summary>
        /// Return the <seealso cref="Control" /> named items.
        /// </summary>
        public Func<Control, IEnumerable<Control>> GetNamedItems;

        /// <summary>
        /// Binds the visible and enabled properties of a list of <see cref="Control"/> to 
        /// ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public Action<Control, object, BindingManager> BindVisualProperties;
    }
}