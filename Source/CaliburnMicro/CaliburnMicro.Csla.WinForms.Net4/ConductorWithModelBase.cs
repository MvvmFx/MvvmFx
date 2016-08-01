using System;
using System.Collections;
using System.Collections.Generic;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// A base class for various implementations of <see cref="IConductor" />
    /// and also implements <see cref="IHaveModel" />.
    /// </summary>
    /// <typeparam name="TC">The type that is being conducted.</typeparam>
    /// <typeparam name="TM">Type of the Model object.</typeparam>
    public abstract class ConductorWithModelBase<TC, TM> : ScreenWithModel<TM>, IConductor, IParent<TC>
        where TC : class
        where TM : class
    {
        private ICloseStrategy<TC> closeStrategy;

        /// <summary>
        /// Gets or sets the close strategy.
        /// </summary>
        /// <value>The close strategy.</value>
        public ICloseStrategy<TC> CloseStrategy
        {
            get { return closeStrategy ?? (closeStrategy = new DefaultCloseStrategy<TC>()); }
            set { closeStrategy = value; }
        }

        void IConductor.ActivateItem(object item)
        {
            ActivateItem((TC) item);
        }

        void IConductor.DeactivateItem(object item, bool close)
        {
            DeactivateItem((TC) item, close);
        }

        IEnumerable IParent.GetChildren()
        {
            return GetChildren();
        }

        /// <summary>
        /// Occurs when an activation request is processed.
        /// </summary>
        public event EventHandler<ActivationProcessedEventArgs> ActivationProcessed = delegate { };

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <returns>The collection of children.</returns>
        public abstract IEnumerable<TC> GetChildren();

        /// <summary>
        /// Activates the specified item.
        /// </summary>
        /// <param name="item">The item to activate.</param>
        public abstract void ActivateItem(TC item);

        /// <summary>
        /// Deactivates the specified item.
        /// </summary>
        /// <param name="item">The item to close.</param>
        /// <param name="close">Indicates whether or not to close the item after deactivating it.</param>
        public abstract void DeactivateItem(TC item, bool close);

        /// <summary>
        /// Called by a subclass when an activation needs processing.
        /// </summary>
        /// <param name="item">The item on which activation was attempted.</param>
        /// <param name="success">if set to <c>true</c> activation was successful.</param>
        protected virtual void OnActivationProcessed(TC item, bool success)
        {
            if (item == null)
            {
                return;
            }

            ActivationProcessed(this, new ActivationProcessedEventArgs
            {
                Item = item,
                Success = success
            });
        }

        /// <summary>
        /// Ensures that an item is ready to be activated.
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>The item to be activated.</returns>
        protected virtual TC EnsureItem(TC newItem)
        {
            var node = newItem as IChild;
            if (node != null && node.Parent != this)
                node.Parent = this;

            return newItem;
        }
    }
}