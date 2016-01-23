namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// A base class for various implementations of <see cref="IConductor" /> that maintains an active item
    /// and also implements <see cref="IHaveModel" />.
    /// </summary>
    /// <typeparam name="TC">The type that is being conducted.</typeparam>
    /// <typeparam name="TM">Type of the Model object.</typeparam>
    public abstract class ConductorWithModelBaseWithActiveItem<TC, TM> : ConductorWithModelBase<TC, TM>, IConductActiveItem
        where TC : class
        where TM : class
    {
        private TC activeItem;

        /// <summary>
        /// The currently active item.
        /// </summary>
        public TC ActiveItem
        {
            get { return activeItem; }
            set { ActivateItem(value); }
        }

        /// <summary>
        /// The currently active item.
        /// </summary>
        /// <value></value>
        object IHaveActiveItem.ActiveItem
        {
            get { return ActiveItem; }
            set { ActiveItem = (TC) value; }
        }

        /// <summary>
        /// Changes the active item.
        /// </summary>
        /// <param name="newItem">The new item to activate.</param>
        /// <param name="closePrevious">Indicates whether or not to close the previous active item.</param>
        protected virtual void ChangeActiveItem(TC newItem, bool closePrevious)
        {
            ScreenExtensions.TryDeactivate(activeItem, closePrevious);

            newItem = EnsureItem(newItem);

            if (IsActive)
                ScreenExtensions.TryActivate(newItem);

            activeItem = newItem;
            NotifyOfPropertyChange("ActiveItem");
            OnActivationProcessed(activeItem, true);
        }
    }
}