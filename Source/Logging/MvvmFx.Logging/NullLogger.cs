using System;

namespace MvvmFx.Logging
{
    /// <summary>
    /// Creates and manages the NullLogger object.
    /// </summary>
    /// <remarks>The NullLogger discards all the logs.</remarks>
    public class NullLogger : ILog
    {
        /// <summary>
        /// Reports a Trace message.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// A Trace message just shows the execution path.
        /// This log level shouldn't be used in production environment.
        /// </remarks>
        public void Trace(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports a Debug message.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// A Debug message reports successful processing or shows key variable values.
        /// This log level shouldn't be used in production environment.
        /// </remarks>
        public void Debug(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports an information message.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// An information message is used to report harmless events like program start and stop.
        /// This log level is part of normal program log and can be used in production environment.
        /// </remarks>
        public void Info(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports a warning message.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// A warning message reports an event that could be an error but was or can be recovered by the program. Example:<br />
        /// - the configuration file didn't supply a value but a default value was used;<br />
        /// - there was an error sending an email message but the program will retry later.
        /// </remarks>
        public void Warn(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports an Error program condition.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// An Error message logs a serious error condition: an Exception
        /// or some essential program action didn't succeed.
        /// </remarks>
        public void Error(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports an Error program condition.
        /// </summary>
        /// <param name="exception">The Exception to report.</param>
        /// <remarks>
        /// An Error message logs a serious error condition: an Exception
        /// or some essential program action didn't succeed.
        /// </remarks>
        public void Error(Exception exception)
        {
        }

        /// <summary>
        /// Reports a Fatal program condition.
        /// </summary>
        /// <param name="format">A formatted message.</param>
        /// <param name="args">Parameters to be injected into the formatted message.</param>
        /// <remarks>
        /// A Fatal message is issued just before the program execution stops.
        /// The error makes impossible to the program to do what it was supposed to do.
        /// </remarks>
        public void Fatal(string format, params object[] args)
        {
        }

        /// <summary>
        /// Reports a Fatal program condition.
        /// </summary>
        /// <param name="exception">The Exception to report.</param>
        /// <remarks>
        /// A Fatal message is issued just before the program execution stops.
        /// The error makes impossible to the program to do what it was supposed to do.
        /// </remarks>
        public void Fatal(Exception exception)
        {
        }
    }
}