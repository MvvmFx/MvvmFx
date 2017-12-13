using System;
using System.Collections.Generic;
using Csla.Core;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// An implementation of <see cref="IConductor" /> that holds on to and activates only one item at a time
    /// and also implements <see cref="IHaveModel" />.
    /// </summary>
    /// <typeparam name="TC">The type that is being conducted.</typeparam>
    /// <typeparam name="TM">Type of the Model object.</typeparam>
    public partial class ConductorWithModel<TC, TM> : ConductorWithModelBaseWithActiveItem<TC, TM>
        where TC : class
        where TM : IBusinessObject
    {
        /// <summary>
        /// Activates the specified item.
        /// </summary>
        /// <param name="item">The item to activate.</param>
        public override void ActivateItem(TC item)
        {
            if (item != null && item.Equals(ActiveItem))
            {
                if (IsActive)
                {
                    ScreenExtensions.TryActivate(item);
                    OnActivationProcessed(item, true);
                }
                return;
            }

            CloseStrategy.Execute(new[] {ActiveItem}, (canClose, items) =>
            {
                if (canClose)
                    ChangeActiveItem(item, true);
                else
                    OnActivationProcessed(item, false);
            });
        }

        /// <summary>
        /// Deactivates the specified item.
        /// </summary>
        /// <param name="item">The item to close.</param>
        /// <param name="close">Indicates whether or not to close the item after deactivating it.</param>
        public override void DeactivateItem(TC item, bool close)
        {
            if (item == null || !item.Equals(ActiveItem))
            {
                return;
            }

            CloseStrategy.Execute(new[] {ActiveItem}, (canClose, items) =>
            {
                if (canClose)
                    ChangeActiveItem(default(TC), close);
            });
        }

        /// <summary>
        /// Called to check whether or not this instance can close.
        /// </summary>
        /// <param name="callback">The implementor calls this action with the result of the close check.</param>
        public override void CanClose(Action<bool> callback)
        {
            CloseStrategy.Execute(new[] {ActiveItem}, (canClose, items) => callback(canClose));
        }

        /// <summary>
        /// Called when activating.
        /// </summary>
        protected override void OnActivate()
        {
            ScreenExtensions.TryActivate(ActiveItem);
        }

        /// <summary>
        /// Called when deactivating.
        /// </summary>
        /// <param name="close">Indicates whether this instance will be closed.</param>
        protected override void OnDeactivate(bool close)
        {
            ScreenExtensions.TryDeactivate(ActiveItem, close);
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <returns>The collection of children.</returns>
        public override IEnumerable<TC> GetChildren()
        {
            if (ActiveItem == null)
                return new TC[0];

            return new[] {ActiveItem};
        }
    }
}