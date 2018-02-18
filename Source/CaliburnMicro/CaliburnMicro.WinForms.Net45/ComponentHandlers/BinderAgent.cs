namespace MvvmFx.CaliburnMicro.ComponentHandlers
{
    using System;
#if WINFORMS
    using Component = System.ComponentModel.Component;
    using System.Windows.Forms;
#else
    using Wisej.Web;
    using Component = Wisej.Web.Component;
#endif
    using MvvmFx.Bindings.Data;

    /// <summary>
    /// Represents the binding method for a control type that wraps a <see cref="Component"/>.
    /// </summary>
    public class BinderAgent
    {
        /// <summary>
        /// Binds the visible and enabled properties of a <see cref="Control"/> to 
        /// ViewModel properties, using a <see cref="BindingManager"/>.
        /// </summary>
        public Action<Control, object, BindingManager> BindVisualProperties;
    }
}