using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Csla;
using Csla.Core;
using Csla.Reflection;
using Csla.Rules;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Base class used to create ScreenWithModel objects that implement their own commands/verbs/actions.
    /// </summary>
    /// <typeparam name="T">Type of the Model object.</typeparam>
    public abstract class ScreenWithModelBase<T> : Screen, IHaveModel where T : class
    {
        #region Constructors

        /// <summary>
        /// Create new instance of base class used to create ScreenWithModel objects
        /// that implement their own commands/verbs/actions.
        /// </summary>
        public ScreenWithModelBase()
            : this(CacheViewsByDefault)
        {
        }

        /// <summary>
        /// Create new instance of base class used to create ScreenWithModel objects
        /// that implement their own commands/verbs/actions.
        /// </summary>
        public ScreenWithModelBase(bool cacheViews)
        {
            SetPropertiesAtObjectLevel(); // ViewModelBase
            IsNotifying = true; // PropertyChangedBase
            DisplayName = GetType().FullName; // Screen
            CacheViews = cacheViews; // ViewAware
        }

        #endregion

        #region InitAsync

        /// <summary>
        /// Method used to perform async initialization of the viewmodel.
        /// This method is usually invoked immediately following construction of the object instance.
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<ScreenWithModelBase<T>> InitAsync()
        {
            try
            {
                IsBusy = true;
                Model = await DoInitAsync();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Error = ex;
            }
            return this;
        }

#pragma warning disable 1998
        /// <summary>
        /// Override this method to implement async initialization of the model object.
        /// The result of this method is used to set the Model property of the viewmodel.
        /// </summary>
        /// <returns>A Task that creates the model object.</returns>
        protected virtual async System.Threading.Tasks.Task<T> DoInitAsync()
        {
            throw new NotImplementedException("DoInitAsync");
        }
#pragma warning restore 1998

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Model object.
        /// </summary>
        public object ModelProperty;

        /// <summary>
        /// Gets or sets the Model object.
        /// </summary>
        public T Model
        {
            get { return (T) ModelProperty; }
            set
            {
                if (!ReferenceEquals(ModelProperty, value))
                {
                    var oldValue = ModelProperty;
                    ModelProperty = value;
                    if (ManageObjectLifetime)
                    {
                        var undoable = ModelProperty as ISupportUndo;
                        if (undoable != null)
                            undoable.BeginEdit();
                    }
                    OnModelChanged((T) oldValue, (T) ModelProperty);
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ViewModel 
        /// should automatically managed the lifetime of the Model.
        /// </summary>
        /// <remarks>Manage object lifetime means managing undo.</remarks>
        public bool ManageObjectLifetimeProperty = true;

        /// <summary>
        /// Gets or sets a value indicating whether the ViewModel 
        /// should automatically managed the lifetime of the Model.
        /// </summary>
        /// <remarks>Manage object lifetime means managing undo.</remarks>
        [Browsable(false)]
        [Display(AutoGenerateField = false)]
        public bool ManageObjectLifetime
        {
            get { return ManageObjectLifetimeProperty; }
            set
            {
                if (ManageObjectLifetimeProperty != value)
                {
                    ManageObjectLifetimeProperty = value;
                    NotifyOfPropertyChange("ManageObjectLifetime");
                }
            }
        }

        private Exception _error;

        /// <summary>
        /// Gets the Error object corresponding to the last asynchronous operation.
        /// </summary>
        [Browsable(false)]
        [Display(AutoGenerateField = false)]
        public Exception Error
        {
            get { return _error; }
            protected set
            {
                if (!ReferenceEquals(_error, value))
                {
                    _error = value;
                    NotifyOfPropertyChange("Error");
                    if (_error != null)
                        OnError(_error);
                }
            }
        }

        /// <summary>
        /// Event raised when an error occurs during processing.
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorOccurred;

        /// <summary>
        /// Raises ErrorOccurred event when an error occurs during processing.
        /// </summary>
        /// <param name="error"></param>
        protected virtual void OnError(Exception error)
        {
            if (ErrorOccurred != null)
                ErrorOccurred(this, new ErrorEventArgs(this, error));
        }

        private bool _isBusy;

        /// <summary>
        /// Gets a value indicating whether this object is executing an asynchronous process.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            protected set
            {
                _isBusy = value;
                NotifyOfPropertyChange("IsBusy");
                OnSetProperties();
            }
        }

        #endregion

        #region Can___ properties

        private bool _isDirty;

        /// <summary>
        /// Gets a value indicating whether the Model has been changed.
        /// </summary>
        public virtual bool IsDirty
        {
            get { return _isDirty; }
            protected set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    NotifyOfPropertyChange("IsDirty");
                }
            }
        }

        private bool _isValid;

        /// <summary>
        /// Gets a value indicating whether the Model is currently valid (has no broken rules).
        /// </summary>
        public virtual bool IsValid
        {
            get { return _isValid; }
            protected set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    NotifyOfPropertyChange("IsValid");
                }
            }
        }

        private bool _canSave;

        /// <summary>
        /// Gets a value indicating whether the Model can currently be saved.
        /// </summary>
        public virtual bool CanSave
        {
            get { return _canSave; }
            protected set
            {
                if (_canSave != value)
                {
                    _canSave = value;
                    NotifyOfPropertyChange("CanSave");
                }
            }
        }

        private bool _canCancel;

        /// <summary>
        /// Gets a value indicating whether the Model can currently be canceled.
        /// </summary>
        public virtual bool CanCancel
        {
            get { return _canCancel; }
            protected set
            {
                if (_canCancel != value)
                {
                    _canCancel = value;
                    NotifyOfPropertyChange("CanCancel");
                }
            }
        }

        private bool _canCreate;

        /// <summary>
        /// Gets a value indicating whether an instance of the Model can currently be created.
        /// </summary>
        public virtual bool CanCreate
        {
            get { return _canCreate; }
            protected set
            {
                if (_canCreate != value)
                {
                    _canCreate = value;
                    NotifyOfPropertyChange("CanCreate");
                }
            }
        }

        private bool _canDelete;

        /// <summary>
        /// Gets a value indicating whether the Model can currently be deleted.
        /// </summary>
        public virtual bool CanDelete
        {
            get { return _canDelete; }
            protected set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    NotifyOfPropertyChange("CanDelete");
                }
            }
        }

        private bool _canFetch;

        /// <summary>
        /// Gets a value indicating whether an instance of the Model can currently be retrieved.
        /// </summary>
        public virtual bool CanFetch
        {
            get { return _canFetch; }
            protected set
            {
                if (_canFetch != value)
                {
                    _canFetch = value;
                    NotifyOfPropertyChange("CanFetch");
                }
            }
        }

        private bool _canRemove;

        /// <summary>
        /// Gets a value indicating whether the Model can currently be removed.
        /// </summary>
        public virtual bool CanRemove
        {
            get { return _canRemove; }
            protected set
            {
                if (_canRemove != value)
                {
                    _canRemove = value;
                    NotifyOfPropertyChange("CanRemove");
                }
            }
        }

        private bool _canAddNew;

        /// <summary>
        /// Gets a value indicating whether the Model can currently be added.
        /// </summary>
        public virtual bool CanAddNew
        {
            get { return _canAddNew; }
            protected set
            {
                if (_canAddNew != value)
                {
                    _canAddNew = value;
                    NotifyOfPropertyChange("CanAddNew");
                }
            }
        }

        private void SetProperties()
        {
            ITrackStatus targetObject = Model as ITrackStatus;
            ICollection list = Model as ICollection;
            INotifyBusy busyObject = Model as INotifyBusy;
            var isObjectBusy = false;
            if (busyObject != null && busyObject.IsBusy)
                isObjectBusy = true;

            // Does Model instance implement ITrackStatus
            if (targetObject != null)
            {
                var canDeleteInstance = BusinessRules.HasPermission(AuthorizationActions.DeleteObject, targetObject);

                IsDirty = targetObject.IsDirty;
                IsValid = targetObject.IsValid;
                CanSave = CanEditObject && targetObject.IsSavable && !isObjectBusy;
                CanCancel = CanEditObject && targetObject.IsDirty && !isObjectBusy;
                CanCreate = CanCreateObject && !targetObject.IsDirty && !isObjectBusy;
                CanDelete = CanDeleteObject && !isObjectBusy && canDeleteInstance;
                CanFetch = CanGetObject && !targetObject.IsDirty && !isObjectBusy;

                // Set properties for List
                if (list == null)
                {
                    CanRemove = false;
                    CanAddNew = false;
                }
                else
                {
                    Type itemType = Csla.Utilities.GetChildItemType(Model.GetType());
                    if (itemType == null)
                    {
                        CanAddNew = false;
                        CanRemove = false;
                    }
                    else
                    {
                        CanRemove = BusinessRules.HasPermission(AuthorizationActions.DeleteObject, itemType) &&
                                    list.Count > 0 && !isObjectBusy;

                        CanAddNew = BusinessRules.HasPermission(AuthorizationActions.CreateObject, itemType) &&
                                    !isObjectBusy;
                    }
                }
            }

            // Else if Model instance implement ICollection
            else if (list != null)
            {
                Type itemType = Csla.Utilities.GetChildItemType(Model.GetType());
                if (itemType == null)
                {
                    CanAddNew = false;
                    CanRemove = false;
                }
                else
                {
                    CanRemove = BusinessRules.HasPermission(AuthorizationActions.DeleteObject, itemType) &&
                                list.Count > 0 && !isObjectBusy;

                    CanAddNew = BusinessRules.HasPermission(AuthorizationActions.CreateObject, itemType) &&
                                !isObjectBusy;
                }
            }
            else
            {
                IsDirty = false;
                IsValid = false;
                CanCancel = false;
                CanCreate = CanCreateObject;
                CanDelete = false;
                CanFetch = CanGetObject && !IsBusy;
                CanSave = false;
                CanRemove = false;
                CanAddNew = false;
            }
        }

        #endregion

        #region Can methods that only account for user rights

        private bool _canCreateObject;

        /// <summary>
        /// Gets a value indicating whether the current user is authorized to create a Model.
        /// </summary>
        public virtual bool CanCreateObject
        {
            get { return _canCreateObject; }
            protected set
            {
                if (_canCreateObject != value)
                {
                    _canCreateObject = value;
                    NotifyOfPropertyChange("CanCreateObject");
                }
            }
        }

        private bool _canGetObject;

        /// <summary>
        /// Gets a value indicating whether the current user is authorized to retrieve a Model.
        /// </summary>
        public virtual bool CanGetObject
        {
            get { return _canGetObject; }
            protected set
            {
                if (_canGetObject != value)
                {
                    _canGetObject = value;
                    NotifyOfPropertyChange("CanGetObject");
                }
            }
        }

        private bool _canEditObject;

        /// <summary>
        /// Gets a value indicating whether the current user is authorized to save (insert or update a Model.
        /// </summary>
        public virtual bool CanEditObject
        {
            get { return _canEditObject; }
            protected set
            {
                if (_canEditObject != value)
                {
                    _canEditObject = value;
                    NotifyOfPropertyChange("CanEditObject");
                }
            }
        }

        private bool _canDeleteObject;

        /// <summary>
        /// Gets a value indicating whether the current user is authorized to delete a Model.
        /// </summary>
        public virtual bool CanDeleteObject
        {
            get { return _canDeleteObject; }
            protected set
            {
                if (_canDeleteObject != value)
                {
                    _canDeleteObject = value;
                    NotifyOfPropertyChange("CanDeleteObject");
                }
            }
        }

        /// <summary>
        /// This method is only called from constuctor to set default values immediately.
        /// Sets the properties at object level.
        /// </summary>
        private void SetPropertiesAtObjectLevel()
        {
            var sourceType = typeof (T);

            CanCreateObject = BusinessRules.HasPermission(AuthorizationActions.CreateObject, sourceType);
            CanGetObject = BusinessRules.HasPermission(AuthorizationActions.GetObject, sourceType);
            CanEditObject = BusinessRules.HasPermission(AuthorizationActions.EditObject, sourceType);
            CanDeleteObject = BusinessRules.HasPermission(AuthorizationActions.DeleteObject, sourceType);

            // call SetProperties to set "instance" values
            OnSetProperties();
        }

        #endregion

        #region Verbs

        #region Helper methods

        private void ListApply()
        {
            var children = Model as IEnumerable;
            if (children != null)
            {
                foreach (var child in children)
                {
                    var editable = child as IEditableObject;
                    if (editable != null)
                        editable.EndEdit();
                }
            }
        }

        private void ObjectApply()
        {
            Unbind(Model, false);
            EndEdit(Model);

            /*var undo = Model as ISupportUndo;
            if (undo != null)
                undo.ApplyEdit();*/
        }

        /// <summary>
        /// Unbinds the specified source.
        /// </summary>
        /// <param name="source">The source Model.</param>
        /// <param name="cancel">if set to <c>true</c> [cancel].</param>
        /// <returns></returns>
        private ISupportUndo Unbind(object source, bool cancel)
        {
            var children = source as IEnumerable;
            if (children != null)
            {
                foreach (var child in children)
                {
                    Unbind(child, cancel);
                }
            }

            var undo = source as ISupportUndo;
            if (undo != null)
            {
                if (cancel)
                    undo.CancelEdit();
                else
                    undo.ApplyEdit();
            }

            return undo;
        }

        private void EndEdit(object source)
        {
            var children = source as IEnumerable;
            if (children != null)
            {
                foreach (var child in children)
                {
                    EndEdit(child);
                }
            }

            var editable = Model as IEditableObject;
            if (editable != null)
                editable.EndEdit();
        }

        #endregion

        #region Refresh

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Static factory method function.</param>
        /// <example>DoRefresh(BusinessList.GetList)</example>
        /// <example>DoRefresh(() => BusinessList.GetList())</example>
        /// <example>DoRefresh(() => BusinessList.GetList(id))</example>
        protected virtual void DoRefresh(Func<T> factoryMethod)
        {
            if (typeof (T) != null)
            {
                Error = null;
                try
                {
                    Model = factoryMethod.Invoke();
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                OnRefreshed();
            }
        }

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Name of the static factory method.</param>
        /// <param name="factoryParameters">Factory method parameters.</param>
        protected virtual void DoRefresh(string factoryMethod, params object[] factoryParameters)
        {
            if (typeof (T) != null)
            {
                Error = null;
                try
                {
                    Model = (T) MethodCaller.CallFactoryMethod(typeof (T), factoryMethod, factoryParameters);
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                OnRefreshed();
            }
        }

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Name of the static factory method.</param>
        protected virtual void DoRefresh(string factoryMethod)
        {
            DoRefresh(factoryMethod, new object[] {});
        }

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Static factory method action.</param>
        /// <example>BeginRefresh(BusinessList.BeginGetList)</example>
        /// <example>BeginRefresh(handler => BusinessList.BeginGetList(handler))</example>
        /// <example>BeginRefresh(handler => BusinessList.BeginGetList(id, handler))</example>
        protected virtual void BeginRefresh(Action<EventHandler<DataPortalResult<T>>> factoryMethod)
        {
            if (typeof (T) != null)
                try
                {
                    Error = null;
                    IsBusy = true;

                    var handler = (EventHandler<DataPortalResult<T>>) CreateHandler(typeof (T));
                    factoryMethod(handler);
                }
                catch (Exception ex)
                {
                    Error = ex;
                    IsBusy = false;
                }
        }

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Name of the static factory method.</param>
        /// <param name="factoryParameters">Factory method parameters.</param>
        protected virtual void BeginRefresh(string factoryMethod, params object[] factoryParameters)
        {
            if (typeof (T) != null)
                try
                {
                    Error = null;
                    IsBusy = true;
                    var parameters = new List<object>(factoryParameters);
                    parameters.Add(CreateHandler(typeof (T)));

                    MethodCaller.CallFactoryMethod(typeof (T), factoryMethod, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    Error = ex;
                    IsBusy = false;
                }
        }

        /// <summary>
        /// Creates or retrieves a new instance of the Model by invoking a static factory method.
        /// </summary>
        /// <param name="factoryMethod">Name of the static factory method.</param>
        protected virtual void BeginRefresh(string factoryMethod)
        {
            BeginRefresh(factoryMethod, new object[] {});
        }

        private Delegate CreateHandler(Type objectType)
        {
            System.Reflection.MethodInfo method = MethodCaller.GetNonPublicMethod(GetType(), "QueryCompleted");
            var innerType = typeof (DataPortalResult<>).MakeGenericType(objectType);
            var args = typeof (EventHandler<>).MakeGenericType(innerType);
            Delegate handler = Delegate.CreateDelegate(args, this, method);
            return handler;
        }

        private void QueryCompleted(object sender, EventArgs e)
        {
            try
            {
                var eventArgs = (IDataPortalResult) e;
                if (eventArgs.Error == null)
                {
                    var model = (T) eventArgs.Object;
                    OnRefreshing(model);
                    Model = model;
                }
                else
                    Error = eventArgs.Error;
                OnRefreshed();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Method called after a refresh operation has completed and before the model is updated (when successful).
        /// </summary>
        /// <param name="model">The model.</param>
        protected virtual void OnRefreshing(T model)
        {
        }

        /// <summary>
        /// Method called after a refresh operation has completed (whether successful or not).
        /// </summary>
        protected virtual void OnRefreshed()
        {
        }

        #endregion

        #region Save

        /// <summary>
        /// Saves the Model, first committing changes if ManagedObjectLifetime is true.
        /// </summary>
        protected virtual T DoSave()
        {
            T result = Model;
            Error = null;
            try
            {
                if (Model is IEnumerable)
                    ListApply();
                else
                    ObjectApply();

                var savable = Model as ISavable;
                if (ManageObjectLifetime)
                {
                    // clone the object if possible
                    ICloneable clonable = Model as ICloneable;
                    if (clonable != null)
                        savable = (ISavable) clonable.Clone();

                    //apply changes
                    var undoable = savable as ISupportUndo;
                    if (undoable != null)
                        undoable.ApplyEdit();
                }

                result = (T) savable.Save();

                Model = result;
                OnSaved();
            }
            catch (Exception ex)
            {
                Error = ex;
                OnSaved();
            }
            return result;
        }

        /// <summary>
        /// Saves the Model, first committing changes if ManagedObjectLifetime is true.
        /// </summary>
        protected virtual async System.Threading.Tasks.Task<T> SaveAsync()
        {
            try
            {
                if (Model is IEnumerable)
                    ListApply();
                else
                    ObjectApply();

                var savable = Model as ISavable;
                if (ManageObjectLifetime)
                {
                    // clone the object if possible
                    ICloneable clonable = Model as ICloneable;
                    if (clonable != null)
                        savable = (ISavable) clonable.Clone();

                    //apply changes
                    var undoable = savable as ISupportUndo;
                    if (undoable != null)
                        undoable.ApplyEdit();
                }

                Error = null;
                IsBusy = true;
                OnSaving(Model);
                Model = (T) await savable.SaveAsync();
                IsBusy = false;
                OnSaved();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Error = ex;
                OnSaved();
            }
            return Model;
        }

        /// <summary>
        /// Saves the Model, first committing changes if ManagedObjectLifetime is true.
        /// </summary>
        protected virtual void BeginSave()
        {
            try
            {
                if (Model is IEnumerable)
                    ListApply();
                else
                    ObjectApply();

                var savable = Model as ISavable;
                if (ManageObjectLifetime)
                {
                    // clone the object if possible
                    ICloneable clonable = Model as ICloneable;
                    if (clonable != null)
                        savable = (ISavable) clonable.Clone();

                    //apply changes
                    var undoable = savable as ISupportUndo;
                    if (undoable != null)
                        undoable.ApplyEdit();
                }

                savable.Saved += (o, e) =>
                {
                    IsBusy = false;
                    if (e.Error == null)
                    {
                        var result = e.NewObject;
                        var model = (T) result;
                        OnSaving(model);
                        Model = model;
                    }
                    else
                    {
                        Error = e.Error;
                    }
                    OnSaved();
                };
                Error = null;
                IsBusy = true;
                savable.BeginSave();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Error = ex;
                OnSaved();
            }
        }

        /// <summary>
        /// Method called after a save operation has completed and before Model is updated (when successful).
        /// </summary>
        protected virtual void OnSaving(T model)
        {
        }

        /// <summary>
        /// Method called after a save operation has completed (whether successful or not).
        /// </summary>
        protected virtual void OnSaved()
        {
        }

        #endregion

        #region Cancel

        /// <summary>
        /// Cancels changes made to the model if ManagedObjectLifetime is true.
        /// </summary>
        protected virtual void DoCancel()
        {
            if (ManageObjectLifetime)
            {
                UnhookChangedEvents(Model);
                try
                {
                    var undo = Unbind(Model, true);
                    undo.BeginEdit();

                    /*var undo = Model as ISupportUndo;
                    if (undo != null)
                    {
                        //undo.CancelEdit();
                        /*var editable = Model as IEditableObject;
                        if (editable != null)
                        {
                            editable.CancelEdit();
                            editable.BeginEdit();
                        }#1#
                        undo.BeginEdit();
                    }*/
                }
                finally
                {
                    HookChangedEvents(Model);
                    OnSetProperties();

                    // trigger control DataSource update
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        #endregion

        #region AddNew

        /// <summary>
        /// Adds a new item to the Model (if it is a collection).
        /// </summary>
        protected virtual void BeginAddNew()
        {
            // typically use IBindingList
            var ibl = (Model as IBindingList);
            if (ibl != null)
            {
                ibl.AddNew();
            }
            else
            {
                // else try to use as IObservableBindingList
                var iobl = ((IObservableBindingList) Model);
                iobl.AddNew();
            }
            OnSetProperties();
        }

        /// <summary>
        /// Adds a new item to the Model (if it is a collection).
        /// </summary>
        protected virtual object DoAddNew()
        {
            object result;
            // typically use IBindingList
            var ibl = (Model as IBindingList);
            if (ibl != null)
            {
                result = ibl.AddNew();
            }
            else
            {
                // else try to use as IObservableCollection
                var iobl = ((IObservableBindingList) Model);
                result = iobl.AddNew();
            }
            OnSetProperties();
            return result;
        }

        #endregion

        #region Remove/Delete

        /// <summary>
        /// Removes an item from the Model (if it is a collection).
        /// </summary>
        protected virtual void DoRemove(object item)
        {
            ((IList) Model).Remove(item);
            OnSetProperties();
        }

        /// <summary>
        /// Marks the Model for deletion (if it is an editable root object).
        /// </summary>
        protected virtual void DoDelete()
        {
            ((IEditableBusinessObject) Model).Delete();
        }

        #endregion

        #region Close

        /// <summary>
        /// Disconnects from the source object and cancels changes made to the model if ManagedObjectLifetime is true.
        /// </summary>
        protected void DoClose()
        {
            UnhookChangedEvents(Model);
            if (ManageObjectLifetime)
            {
                Unbind(Model, true);
            }
        }

        #endregion

        #region Model Changes Handling

        /// <summary>
        /// Invoked when the Model changes, allowing event handlers to be unhooked from the old object and hooked on the new object.
        /// </summary>
        /// <param name="oldValue">Previous Model reference.</param>
        /// <param name="newValue">New Model reference.</param>
        protected virtual void OnModelChanged(T oldValue, T newValue)
        {
            if (ReferenceEquals(oldValue, newValue))
                return;

            // unhook events from old value
            if (oldValue != null)
            {
                UnhookChangedEvents(oldValue);

                var nb = oldValue as INotifyBusy;
                if (nb != null)
                    nb.BusyChanged -= Model_BusyChanged;
            }

            // hook events on new value
            if (newValue != null)
            {
                HookChangedEvents(newValue);

                var nb = newValue as INotifyBusy;
                if (nb != null)
                    nb.BusyChanged += Model_BusyChanged;
            }

            OnSetProperties();
        }

        private void UnhookChangedEvents(T model)
        {
            var npc = model as INotifyPropertyChanged;
            if (npc != null)
                npc.PropertyChanged -= Model_PropertyChanged;

            var ncc = model as INotifyChildChanged;
            if (ncc != null)
                ncc.ChildChanged -= Model_ChildChanged;

            var cc = model as INotifyCollectionChanged;
            if (cc != null)
                cc.CollectionChanged -= Model_CollectionChanged;

            var bl = model as IBindingList;
            if (bl != null)
                bl.ListChanged -= Model_ListChanged;
        }

        private void HookChangedEvents(T model)
        {
            var npc = model as INotifyPropertyChanged;
            if (npc != null)
                npc.PropertyChanged += Model_PropertyChanged;

            var ncc = model as INotifyChildChanged;
            if (ncc != null)
                ncc.ChildChanged += Model_ChildChanged;

            var cc = model as INotifyCollectionChanged;
            if (cc != null)
                cc.CollectionChanged += Model_CollectionChanged;

            var bl = model as IBindingList;
            if (bl != null)
                bl.ListChanged += Model_ListChanged;
        }

        /// <summary>
        /// Override this method to hook into to logic of setting properties when model is changed or edited.
        /// </summary>
        protected virtual void OnSetProperties()
        {
            SetProperties();
        }

        private void Model_BusyChanged(object sender, BusyChangedEventArgs e)
        {
            // only set busy state for entire object. Ignore busy state based
            // on asynch rules being active
            if (e.PropertyName == string.Empty)
                IsBusy = e.Busy;
            else
                OnSetProperties();
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnSetProperties();
        }

        private void Model_ChildChanged(object sender, ChildChangedEventArgs e)
        {
            OnSetProperties();
        }

        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnSetProperties();
        }

        private void Model_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnSetProperties();
        }

        #endregion

        #endregion

        #region IViewModel Members

        /// <summary>
        /// Gets or sets the Model property of the ScreenWithModel object.
        /// </summary>
        object IHaveModel.Model
        {
            get { return Model; }
            set { Model = (T) value; }
        }

        #endregion
    }
}