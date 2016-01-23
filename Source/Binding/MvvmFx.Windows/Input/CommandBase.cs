using System;

namespace MvvmFx.Windows.Input
{
    /// <summary>
    /// A base class for command types.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        #region ICommand

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Determines whether this instance can execute.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            /*EventHandler canExecuteChanged = CanExecuteChanged;
            if (canExecuteChanged != null)
            {
                canExecuteChanged.Invoke(this, EventArgs.Empty);
            }*/
            //thread safe
            EventHandler handler;
            lock (this)
            {
                handler = CanExecuteChanged;
            }

            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
