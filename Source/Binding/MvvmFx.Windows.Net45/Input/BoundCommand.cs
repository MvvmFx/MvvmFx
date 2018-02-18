using System;

namespace MvvmFx.Bindings.Input
{
    /// <summary>
    /// A command implementation that uses Action&lt;object&gt; as the Execute method,
    /// Func&lt;object, bool&gt; as the CanExecute method
    /// and an immutable <see cref="System.Object"/> as parameter.
    /// </summary>
    public class BoundCommand : CommandBase, IBoundCommand
    {
        private readonly object _parameter;
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundCommand"/> class.
        /// </summary>
        /// <param name="execute">The <see cref="System.Action"/> to execute.</param>
        /// <param name="canExecute">The guard <see cref="System.Action"/> method.</param>
        /// <param name="parameter">The command's parameter.</param>
        public BoundCommand(Action<object> execute, Func<object, bool> canExecute, object parameter)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _canExecute = canExecute;
            _execute = execute;
            _parameter = parameter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundCommand"/> class without a guard method.
        /// </summary>
        /// <param name="execute">The <see cref="System.Action"/> to execute.</param>
        /// <param name="parameter">The command's parameter.</param>
        public BoundCommand(Action<object> execute, object parameter)
            : this(execute, null, parameter)
        {
        }

        #region ICommand

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        public override void Execute(object parameter)
        {
            if (_canExecute(_parameter))
                _execute(_parameter);
        }

        /// <summary>
        /// Determines whether this instance can execute.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(_parameter);
        }

        #endregion
    }
}
