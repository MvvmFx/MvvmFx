using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Arguments passed to a method invoked
    /// by the Execute trigger action.
    /// </summary>
    public class ExecuteEventArgs : EventArgs
    {
        /// <summary>
        /// The control that raised the event that
        /// triggered invocation of this method.
        /// </summary>
        public Control TriggerSource { get; set; }

        /// <summary>
        /// The MethodParameter value provided by
        /// the designer.
        /// </summary>
        public object MethodParameter { get; set; }

        /// <summary>
        /// The EventArgs parameter from the event
        /// that triggered invocation of this method.
        /// </summary>
        public object TriggerParameter { get; set; }
    }
}