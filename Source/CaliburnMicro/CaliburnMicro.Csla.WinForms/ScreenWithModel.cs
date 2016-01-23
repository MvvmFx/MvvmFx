namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Base class used to create ScreenWithModel objects, with pre-existing verbs for use by InvokeMethod or Invoke.
    /// </summary>
    /// <typeparam name="T">Type of the Model object.</typeparam>
    public abstract class ScreenWithModel<T> : ScreenWithModelBase<T> where T : class
    {
        #region Verbs

        /// <summary>
        /// Saves the Model, first committing changes if ManagedObjectLifetime is true.
        /// </summary>
        public virtual void Save()
        {
            DoSave();
        }

        /// <summary>
        /// Cancels changes made to the model if ManagedObjectLifetime is true.
        /// The Model state is reverted to the initial state and is prepared for editing again.
        /// </summary>
        public virtual void Cancel()
        {
            DoCancel();
        }

        /// <summary>
        /// Adds a new item to the Model (use it for collection items).
        /// </summary>
        public virtual void AddNew()
        {
            DoAddNew();
        }

        /// <summary>
        /// Removes an item from the Model (use it for collection items).
        /// </summary>
        public virtual void Remove(object sender, ExecuteEventArgs e)
        {
            DoRemove(e.MethodParameter);
        }

        /// <summary>
        /// Marks the Model for deletion.
        /// </summary>
        public virtual void Delete()
        {
            DoDelete();
        }

        /// <summary>
        /// Immediately deletes the Model.
        /// </summary>
        public virtual void DeleteImmediate()
        {
            DoDelete();
            DoSave();
        }

        /// <summary>
        /// Cancels changes made to the Model if ManagedObjectLifetime is true.
        /// Unlike Cancel, the Model isn't prepared for editing (again).
        /// </summary>
        public virtual void Close()
        {
            DoClose();
        }

        #endregion
    }
}