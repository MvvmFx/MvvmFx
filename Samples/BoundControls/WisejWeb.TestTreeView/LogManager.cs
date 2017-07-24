using System;
using MvvmFx.Logging;

namespace WisejWeb.TestTreeView
{
    /// <summary>
    /// Used to manage logging.
    /// </summary>
    public class LogManager
    {
        private static readonly ILog NullLogInstance = new NullLogger();

        /// <summary>
        /// Creates an <see cref="ILog"/> for the provided type.
        /// </summary>
        public static Func<Type, ILog> GetLog = type => NullLogInstance;
    }
}