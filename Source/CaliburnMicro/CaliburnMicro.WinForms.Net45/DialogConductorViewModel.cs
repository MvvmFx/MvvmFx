namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MvvmFx.CaliburnMicro.PropertyChangedBase" />
    /// <seealso cref="MvvmFx.CaliburnMicro.IDialogManager" />
    /// <seealso cref="MvvmFx.CaliburnMicro.IConductActiveItem" />
    public class DialogConductorViewModel : PropertyChangedBase, IDialogManager, IConductActiveItem
    {
        private readonly Func<IMessageBox> createMessageBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogConductorViewModel"/> class.
        /// </summary>
        /// <param name="messageBoxFactory">The message box factory.</param>
        public DialogConductorViewModel(Func<IMessageBox> messageBoxFactory)
        {
            createMessageBox = messageBoxFactory;
        }

        /// <summary>
        /// Gets the active item.
        /// </summary>
        /// <value>
        /// The active item.
        /// </value>
        public IScreen ActiveItem { get; private set; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetChildren()
        {
            return ActiveItem != null ? new[] {ActiveItem} : new object[0];
        }

        /// <summary>
        /// Activates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void ActivateItem(object item)
        {
            ActiveItem = item as IScreen;

            var child = ActiveItem as IChild;
            if (child != null)
                child.Parent = this;

            if (ActiveItem != null)
                ActiveItem.Activate();

            NotifyOfPropertyChange(() => ActiveItem);
            ActivationProcessed(this, new ActivationProcessedEventArgs {Item = ActiveItem, Success = true});
        }

        /// <summary>
        /// Deactivates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="close">if set to <c>true</c> [close].</param>
        public void DeactivateItem(object item, bool close)
        {
            var guard = item as IGuardClose;
            if (guard != null)
            {
                guard.CanClose(result =>
                {
                    if (result)
                        CloseActiveItemCore();
                });
            }
            else CloseActiveItemCore();
        }

        object IHaveActiveItem.ActiveItem
        {
            get { return ActiveItem; }
            set { ActivateItem(value); }
        }

        /// <summary>
        /// Occurs when after the item activation is processed.
        /// </summary>
        public event EventHandler<ActivationProcessedEventArgs> ActivationProcessed = delegate { };

        /// <summary>
        /// Shows the view model as a dialog.
        /// </summary>
        /// <param name="dialogModel">The view model.</param>
        public void ShowDialog(IScreen dialogModel)
        {
            ActivateItem(dialogModel);
        }

        /// <summary>
        /// Shows a message box.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The message box title.</param>
        /// <param name="options">The message box options.</param>
        /// <param name="callback">The callback method.</param>
        public void ShowMessageBox(string message, string title = "Hello Screens",
            MessageBoxOptions options = MessageBoxOptions.OK, Action<IMessageBox> callback = null)
        {
            var box = createMessageBox();

            box.DisplayName = title;
            box.Options = options;
            box.Message = message;

            if (callback != null)
                box.Deactivated += delegate { callback(box); };

            ActivateItem(box);
        }

        private void CloseActiveItemCore()
        {
            var oldItem = ActiveItem;
            ActivateItem(null);
            oldItem.Deactivate(true);
        }
    }
}