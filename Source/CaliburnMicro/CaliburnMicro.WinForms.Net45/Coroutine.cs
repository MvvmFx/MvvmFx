﻿namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manages coroutine execution.
    /// </summary>
    public static class Coroutine
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof(Coroutine));

        /// <summary>
        /// Creates the parent enumerator.
        /// </summary>
        public static Func<IEnumerator<IResult>, IResult> CreateParentEnumerator = inner => new SequentialResult(inner);

        /// <summary>
        /// Executes a coroutine.
        /// </summary>
        /// <param name="coroutine">The coroutine to execute.</param>
        /// <param name="context">The context to execute the coroutine within.</param>
        /// /// <param name="callback">The completion callback for the coroutine.</param>
        public static void BeginExecute(IEnumerator<IResult> coroutine, ActionExecutionContext context = null,
            EventHandler<ResultCompletionEventArgs> callback = null)
        {
            Log.Info("Executing coroutine.");

            var enumerator = CreateParentEnumerator(coroutine);
            IoC.BuildUp(enumerator);

            if (callback != null)
            {
                ExecuteOnCompleted(enumerator, callback);
            }

            ExecuteOnCompleted(enumerator, Completed);
            enumerator.Execute(context ?? new ActionExecutionContext());
        }

        private static void ExecuteOnCompleted(IResult result, EventHandler<ResultCompletionEventArgs> handler)
        {
            EventHandler<ResultCompletionEventArgs> onCompledted = null;
            onCompledted = (s, e) =>
            {
                result.Completed -= onCompledted;
                handler(s, e);
            };
            result.Completed += onCompledted;
        }

        /// <summary>
        /// Called upon completion of a coroutine.
        /// </summary>
        public static event EventHandler<ResultCompletionEventArgs> Completed = (s, e) =>
        {
            if (e.Error != null)
            {
                Log.Error(e.Error);
            }
            else if (e.WasCancelled)
            {
                Log.Info("Coroutine execution cancelled.");
            }
            else
            {
                Log.Info("Coroutine execution completed.");
            }
        };
    }

    /// <summary>
    ///  Denotes a class which can handle a particular type of message and uses a Coroutine to do so.
    /// </summary>
    public interface IHandleWithCoroutine<TMessage> : IHandle
    {
        //don't use contravariance here
        /// <summary>
        ///  Handle the message with a Coroutine.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The coroutine to execute.</returns>
        IEnumerable<IResult> Handle(TMessage message);
    }
}