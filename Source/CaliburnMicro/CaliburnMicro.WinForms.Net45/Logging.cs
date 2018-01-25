namespace MvvmFx.CaliburnMicro
{
    using System;

    /// <summary>
    /// Used to manage logging.
    /// </summary>
    public static class LogManager
    {
        private static readonly Logging.ILog NullLogInstance = new Logging.NullLogger();

        /// <summary>
        /// Creates an <see cref="Logging.ILog"/> for the provided type.
        /// </summary>
        public static Func<Type, Logging.ILog> GetLog = type => NullLogInstance;
    }
}