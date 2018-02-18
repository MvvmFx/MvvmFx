using System;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TriggerBase : DependencyObject, IAttachedObject
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ActionsProperty =
            DependencyProperty.Register("Actions", typeof (TriggerActionCollection), typeof (TriggerBase), null);

        /// <summary>
        /// Gets the actions associated with this trigger.
        /// </summary>
        public TriggerActionCollection Actions
        {
            get { return (TriggerActionCollection) GetValue(ActionsProperty); }
        }

        /// <summary>
        /// Invoke all actions associated with this trigger.
        /// </summary>
        /// <param name="parameter">The parameter object.</param>
        protected void InvokeActions(object parameter)
        {
            foreach (TriggerAction triggerAction in Actions)
            {
                triggerAction.CallInvoke(parameter);
            }
        }

        internal event EventHandler AssociatedObjectChanged;

        protected virtual void OnAttached()
        {
        }

        protected virtual void OnDetaching()
        {
        }

        protected void OnAssociatedObjectChanged()
        {
            if (AssociatedObjectChanged == null)
            {
                return;
            }
            AssociatedObjectChanged(this, new EventArgs());
        }

        #region IAttachedObject

        /// <summary>
        /// Gets the associated object.
        /// </summary>
        /// <remarks>Represents the <see cref="MvvmFx.Bindings.IDependencyObject"/> this instance is attached to.</remarks>
        public IDependencyObject AssociatedObject { get; private set; }

        /// <summary>
        /// Attaches the specified <see cref="MvvmFx.Bindings.IDependencyObject"/> to the collection
        /// </summary>
        /// <param name="dependencyObject">The <see cref="MvvmFx.Bindings.IDependencyObject"/> to attach</param>
        public void Attach(IDependencyObject dependencyObject)
        {
            if (dependencyObject == AssociatedObject)
            {
                return;
            }
            if (AssociatedObject != null)
            {
                throw new InvalidOperationException("Cannot attach Trigger multiple times");
            }
            AssociatedObject = dependencyObject;
            OnAssociatedObjectChanged();
            Actions.Attach(dependencyObject);
            OnAttached();
        }

        /// <summary>
        /// Detaches the currently associated <see cref="MvvmFx.Bindings.IDependencyObject"/>
        /// </summary>
        public void Detach()
        {
            OnDetaching();
            AssociatedObject = null;
            Actions.Detach();
            OnAssociatedObjectChanged();
        }

        #endregion
    }
}
