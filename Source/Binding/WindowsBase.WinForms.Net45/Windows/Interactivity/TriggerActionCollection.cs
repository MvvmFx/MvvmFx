using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// 
    /// </summary>
    public class TriggerActionCollection : AttachableCollection<TriggerAction>
    {
        internal TriggerActionCollection()
        {
        }

        #region Overrides of AttachableCollection<TriggerAction>

        /// <summary>
        /// Called immediately after the collection is attached to an AssociatedObject.
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            foreach (TriggerAction triggerAction in this)
            {
                triggerAction.Attach(AssociatedObject);
            }
        }

        /// <summary>
        /// Called when the collection is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            foreach (TriggerAction triggerAction in this)
            {
                triggerAction.Detach();
            }
        }

        /// <summary>
        /// Called when a new item is added to the collection.
        /// 
        /// </summary>
        /// <param name="item">The new item.</param>
        internal override void ItemAdded(TriggerAction item)
        {
            if (item.IsAttached)
            {
                throw new InvalidOperationException("Cannot attach TriggerAction multiple times");
            }
            if (AssociatedObject == null)
            {
                return;
            }
            item.Attach(AssociatedObject);
            item.IsAttached = true;
        }

        /// <summary>
        /// Called when an item is removed from the collection.
        /// 
        /// </summary>
        /// <param name="item">The removed item.</param>
        internal override void ItemRemoved(TriggerAction item)
        {
            if (item.AssociatedObject == null)
            {
                return;
            }
            item.Detach();
            item.IsAttached = false;
        }

        #endregion
    }
}
