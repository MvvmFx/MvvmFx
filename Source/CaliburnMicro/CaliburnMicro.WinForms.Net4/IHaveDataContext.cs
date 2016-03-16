using System;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Contains details about the data context.
    /// </summary>
    public class DataContextChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The data context
        /// </summary>
        public object DataContext;
    }

    /// <summary>
    /// Denotes a view that has a data context (view model).
    /// </summary>
    public interface IHaveDataContext
    {
        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        object DataContext { get; set; }

        /// <summary>
        /// Occurs when the data context changes.
        /// </summary>
        event EventHandler<DataContextChangedEventArgs> DataContextChanged;
    }
}