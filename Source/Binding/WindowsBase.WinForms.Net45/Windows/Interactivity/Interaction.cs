using System;

namespace MvvmFx.Bindings.Interactivity
{
    /// <summary>
    /// /// Static class that owns the Triggers and Behaviors attached properties. Handles propagation of AssociatedObject change notifications.
    /// </summary>
    public static class Interaction
    {
        /// <summary>
        /// This property is used as the internal backing store for the public Triggers attached property.
        /// </summary>
        public static readonly DependencyProperty TriggersProperty =
            DependencyProperty.RegisterAttached("Triggers", typeof (TriggerCollection), typeof (Interaction), new PropertyMetadata(null, OnTriggersChanged));

        /// <summary>
        /// Gets the TriggerCollection containing the triggers associated with the specified object.
        /// </summary>
        /// <param name="obj">The object from which to retrieve the triggers.</param>
        /// <returns>
        /// A TriggerCollection containing the triggers associated with the specified object.
        /// </returns>
        public static TriggerCollection GetTriggers(IDependencyObject obj)
        {
            var triggerCollection = (TriggerCollection) obj.GetValue(TriggersProperty);
            if (triggerCollection == null)
            {
                triggerCollection = new TriggerCollection();
                obj.SetValue(TriggersProperty, triggerCollection);
            }
            return triggerCollection;
        }

        private static void OnTriggersChanged(IDependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var triggerCollection1 = args.OldValue as TriggerCollection;
            var triggerCollection2 = args.NewValue as TriggerCollection;
            if (triggerCollection1 == triggerCollection2)
            {
                return;
            }
            if (triggerCollection1 != null && triggerCollection1.AssociatedObject != null)
            {
                triggerCollection1.Detach();
            }
            if (triggerCollection2 == null || obj == null)
            {
                return;
            }
            if (triggerCollection2.AssociatedObject != null)
            {
                throw new InvalidOperationException("Cannot attach TriggerCollection multiple imes");
            }
            var fElement = obj as FormElement;
            if (fElement == null)
            {
                throw new InvalidOperationException("Can only host TriggerCollection on FormElement");
            }
            triggerCollection2.Attach(fElement);
        }
    }
}
