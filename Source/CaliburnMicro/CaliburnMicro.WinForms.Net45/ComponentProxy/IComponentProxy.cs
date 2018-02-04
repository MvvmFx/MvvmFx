namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
#if WINFORMS
    using System.ComponentModel;
    using System.Windows.Forms;
#else
    using Wisej.Web;
    using Component = Wisej.Web.Component;

#endif


    /// <summary>
    /// Interface used to define a <see cref="Control" /> proxy that wraps a <see cref="Component" />
    /// for purposes of data and <see cref="Action" /> binding.
    /// </summary>
    /// <typeparam name="T">A <see cref="Type" /> that inherits
    /// from <see cref="Component" />.</typeparam>
    /// <seealso cref="IDisposable" />
    public interface IComponentProxy<T> : IDisposable where T : Component
    {
        /// <summary>
        /// Gets the <see cref="Component"/> wraped item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        T Item { get; }

#if WISEJ
        /// <summary>
        /// Returns a dynamic object that can be used to store custom data in relation to this control.
        /// </summary>
        dynamic UserData { get; }
#endif

        /// <summary>
        /// Wires component the events.
        /// </summary>
        void WireEvents();

        /// <summary>
        /// Unwires component the events.
        /// </summary>
        void UnwireEvents();
    }
}