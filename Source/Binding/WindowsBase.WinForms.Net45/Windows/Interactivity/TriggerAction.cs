using System;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TriggerAction : DependencyObject, IAttachedObject
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register("IsEnabled", typeof (bool), typeof (TriggerAction), new PropertyMetadata(true));

        internal bool IsAttached { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get { return (bool) GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        internal void CallInvoke(object parameter)
        {
            if (!IsEnabled)
                return;
            Invoke(parameter);
        }

        protected abstract void Invoke(object parameter);

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
                throw new InvalidOperationException("Cannot attach TriggerAction multiple times");
            }
            AssociatedObject = dependencyObject;
            OnAssociatedObjectChanged();
            OnAttached();
        }

        /// <summary>
        /// Detaches the currently associated <see cref="MvvmFx.Bindings.IDependencyObject"/>
        /// </summary>
        public void Detach()
        {
            OnDetaching();
            AssociatedObject = null;
            OnAssociatedObjectChanged();
        }

        #endregion
    }
}
