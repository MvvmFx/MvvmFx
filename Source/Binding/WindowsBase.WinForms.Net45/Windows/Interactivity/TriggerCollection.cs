using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// Represents a collection of triggers with a shared AssociatedObject and provides change notifications to its contents when that AssociatedObject changes.
    /// 
    /// </summary>
    public sealed class TriggerCollection : AttachableCollection<TriggerBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerCollection"/> class.
        /// </summary>
        internal TriggerCollection()
        {
        }

        #region Overrides of AttachableCollection<TriggerBase>

        /// <summary>
        /// Called immediately after the collection is attached to an AssociatedObject.
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            foreach (TriggerBase triggerBase in this)
            {
                triggerBase.Attach(AssociatedObject);
                Interaction.GetTriggers(AssociatedObject).Add(triggerBase);
            }
        }

        /// <summary>
        /// Called when the collection is being detached from its AssociatedObject, but before it has actually occurred.
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            foreach (TriggerBase triggerBase in this)
            {
                triggerBase.Detach();
            }
        }

        /// <summary>
        /// Called when a new item is added to the collection.
        /// 
        /// </summary>
        /// <param name="item">The new item.</param>
        internal override void ItemAdded(TriggerBase item)
        {
            if (AssociatedObject == null)
            {
                return;
            }
            item.Attach(AssociatedObject);
        }

        /// <summary>
        /// Called when an item is removed from the collection.
        /// 
        /// </summary>
        /// <param name="item">The removed item.</param>
        internal override void ItemRemoved(TriggerBase item)
        {
            if (item.AssociatedObject == null)
            {
                return;
            }
            item.Detach();
        }

        #endregion
    }
}
