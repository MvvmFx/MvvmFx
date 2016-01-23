using System.Collections.Generic;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Defines a message with parameters.
    /// </summary>
    public interface IHaveParameters
    {
        /// <summary>
        /// Gets the parameters of a message.
        /// </summary>
        /// <value>
        /// The message parameters.
        /// </value>
        IList<Parameter> Parameters { get; }
    }
}