namespace MvvmFx.CaliburnMicro
{
    using System;

    /// <summary>
    /// Provides the startup arguments for the event that is raised when the application starts up.
    /// </summary>
    public class StartupEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartupEventArgs"/> class.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        public StartupEventArgs(string[] args)
        {
            Args = args;
        }

        /// <summary>
        /// Gets the startup arguments.
        /// </summary>
        /// <value>
        /// The startup arguments.
        /// </value>
        public string[] Args { get; private set; }
    }
}