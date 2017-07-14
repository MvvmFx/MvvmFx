namespace MvvmFx.CaliburnMicro
{
    using System.Windows;
#if !WINFORMS && !WEBGUI && !WISEJ
    using System.Linq;
    using System.Windows.Interactivity;
    using TriggerBase = System.Windows.Interactivity.TriggerBase;
#endif

    /// <summary>
    ///   Host's attached properties related to routed UI messaging.
    /// </summary>
    public static class Message
    {
        internal static readonly DependencyProperty HandlerProperty =
            DependencyProperty.RegisterAttached(
                "Handler",
                typeof (object),
                typeof (Message),
                null
                );

#if !WINFORMS && !WEBGUI && !WISEJ
        private static readonly DependencyProperty MessageTriggersProperty =
            DependencyProperty.RegisterAttached(
                "MessageTriggers",
                typeof(TriggerBase[]),
                typeof(Message),
                null
                );
#endif

        /// <summary>
        ///   Places a message handler on this element.
        /// </summary>
        /// <param name="d"> The element. </param>
        /// <param name="value"> The message handler. </param>
        public static void SetHandler(DependencyObject d, object value)
        {
            d.SetValue(HandlerProperty, value);
        }

        /// <summary>
        ///   Gets the message handler for this element.
        /// </summary>
        /// <param name="d"> The element. </param>
        /// <returns> The message handler. </returns>
        public static object GetHandler(DependencyObject d)
        {
            return d.GetValue(HandlerProperty);
        }

#if WINFORMS || WEBGUI || WISEJ
        /// <summary>
        ///   Gets the message handler for this element.
        /// </summary>
        /// <param name="d"> The object. </param>
        /// <returns> The message handler. </returns>
        public static object GetHandler(object d)
        {
            var dp = d.GetDependencyObject();

            if (dp == null)
                return null;

            var result = GetHandler(dp);

            return result;
        }
#endif

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.Message.Attach"/> attached property.
        /// </summary>
        /// <AttachedEventComments>
        /// <summary>
        /// A property definition representing attached triggers and messages.
        /// </summary>
        /// </AttachedEventComments>
        public static readonly DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached(
                "Attach",
                typeof (string),
                typeof (Message),
                new PropertyMetadata(null, OnAttachChanged)
                );

        /// <summary>
        ///   Sets the attached triggers and messages.
        /// </summary>
        /// <param name="d"> The element to attach to. </param>
        /// <param name="attachText"> The parsable attachment text. </param>
        public static void SetAttach(DependencyObject d, string attachText)
        {
            d.SetValue(AttachProperty, attachText);
        }

        /// <summary>
        ///   Gets the attached triggers and messages.
        /// </summary>
        /// <param name="d"> The element that was attached to. </param>
        /// <returns> The parsable attachment text. </returns>
        public static string GetAttach(DependencyObject d)
        {
            return d.GetValue(AttachProperty) as string;
        }

        private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
#if !WINFORMS && !WEBGUI && !WISEJ
            if(e.NewValue == e.OldValue)
            {
                return;
            }

            var messageTriggers = (TriggerBase[])d.GetValue(MessageTriggersProperty);
            var allTriggers = Interaction.GetTriggers(d);

            if (messageTriggers != null)
            {
                messageTriggers.Apply(x => allTriggers.Remove(x));
            }

            var newTriggers = Parser.Parse(d, e.NewValue as string).ToArray();
            newTriggers.Apply(allTriggers.Add);

            if (newTriggers.Length > 0)
            {
                d.SetValue(MessageTriggersProperty, newTriggers);
            }
            else
            {
                d.ClearValue(MessageTriggersProperty);
            }
#endif
        }
    }
}