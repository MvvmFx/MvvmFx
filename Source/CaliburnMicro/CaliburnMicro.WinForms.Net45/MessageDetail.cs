using System.Collections.Generic;
#if WISEJ
using FrameworkElement = Wisej.Web.Control;
#else
using FrameworkElement = System.Windows.Forms.Control;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Object used to collect data for an action message.
    /// </summary>
    public class MessageDetail
    {
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>
        /// The name of the event.
        /// </value>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets the collection of parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public List<Parameter> Parameters { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDetail"/> class.
        /// </summary>
        public MessageDetail()
        {
            EventName = string.Empty;
            MethodName = string.Empty;
            Parameters = new List<Parameter>();
        }
    }
}