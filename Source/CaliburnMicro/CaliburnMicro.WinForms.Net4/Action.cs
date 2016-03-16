namespace MvvmFx.CaliburnMicro
{
    using System.Windows;
#if WEBGUI
    using FrameworkElement = Gizmox.WebGUI.Forms.Control;
#else
    using FrameworkElement = System.Windows.Forms.Control;
#endif

    /// <summary>
    ///   A host for action related attached properties.
    /// </summary>
    public static class Action
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof (Action));

        /// <summary>
        /// A property definition representing  the target of a<see cref="P:MvvmFx.CaliburnMicro.Action.Target"/> attached property.
        /// </summary>
        /// <AttachedEventComments>
        /// <summary>
        /// A property definition representing the target of an <see cref="ActionMessage" />.
        /// The DataContext of the element will be set to this instance.
        /// </summary>
        /// </AttachedEventComments>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.RegisterAttached(
                "Target",
                typeof (object),
                typeof (Action),
                new PropertyMetadata(null, OnTargetChanged)
                );

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.Action.TargetWithoutContext"/> attached property.
        /// </summary>
        /// <AttachedEventComments>
        /// <summary>
        /// A property definition representing the target of an <see cref="ActionMessage" />.
        /// The DataContext of the element is not set to this instance.
        /// </summary>
        /// </AttachedEventComments>
        public static readonly DependencyProperty TargetWithoutContextProperty =
            DependencyProperty.RegisterAttached(
                "TargetWithoutContext",
                typeof (object),
                typeof (Action),
                new PropertyMetadata(null, OnTargetWithoutContextChanged)
                );

        /// <summary>
        ///   Sets the target of the <see cref="ActionMessage" /> .
        /// </summary>
        /// <param name="d"> The element to attach the target to. </param>
        /// <param name="target"> The target for instances of <see cref="ActionMessage" /> . </param>
        public static void SetTarget(DependencyObject d, object target)
        {
            d.SetValue(TargetProperty, target);
        }

        /// <summary>
        ///   Gets the target for instances of <see cref="ActionMessage" /> .
        /// </summary>
        /// <param name="d"> The element to which the target is attached. </param>
        /// <returns> The target for instances of <see cref="ActionMessage" /> </returns>
        public static object GetTarget(DependencyObject d)
        {
            return d.GetValue(TargetProperty);
        }

        /// <summary>
        ///   Sets the target of the <see cref="ActionMessage" /> .
        /// </summary>
        /// <param name="d"> The element to attach the target to. </param>
        /// <param name="target"> The target for instances of <see cref="ActionMessage" /> . </param>
        /// <remarks>
        ///   The DataContext will not be set.
        /// </remarks>
        public static void SetTargetWithoutContext(DependencyObject d, object target)
        {
            d.SetValue(TargetWithoutContextProperty, target);
        }

        /// <summary>
        ///   Gets the target for instances of <see cref="ActionMessage" /> .
        /// </summary>
        /// <param name="d"> The element to which the target is attached. </param>
        /// <returns> The target for instances of <see cref="ActionMessage" /> </returns>
        public static object GetTargetWithoutContext(DependencyObject d)
        {
            return d.GetValue(TargetWithoutContextProperty);
        }

#if WINFORMS || WEBGUI
        /// <summary>
        /// Checks if the <see cref="ActionMessage"/> Target was set.
        /// </summary>
        /// <param name="element">The object to check.</param>
        /// <returns>True if Target or TargetWithoutContext was set on <paramref name="element"/></returns>
        public static bool HasTargetSet(object element)
        {
            return HasTargetSet(element.GetDependencyObject());
        }

        /// <summary>
        /// Sets the target of the <see cref="ActionMessage"/> .
        /// </summary>
        /// <param name="d">The object to attach the target to.</param>
        /// <param name="target">The target for instances of <see cref="ActionMessage"/>.</param>
        public static void SetTarget(this object d, object target)
        {
            var dp = d.GetDependencyObject();
            dp.SetValue(TargetProperty, target);
        }

        /// <summary>
        /// Sets the target of the <see cref="ActionMessage"/> .
        /// </summary>
        /// <param name="d">The object to attach the target to.</param>
        /// <param name="target">The target for instances of <see cref="ActionMessage"/>.</param>
        /// <remarks>The DataContext will not be set.</remarks>
        public static void SetTargetWithoutContext(this object d, object target)
        {
            var dp = d.GetDependencyObject();
            /*if (dp == null)
                dp = new DependencyObject(d);*/
            dp.SetValue(TargetWithoutContextProperty, target);
        }
#endif

        ///<summary>
        ///  Checks if the <see cref="ActionMessage" /> -Target was set.
        ///</summary>
        ///<param name="element"> DependencyObject to check </param>
        ///<returns> True if Target or TargetWithoutContext was set on <paramref name="element" /> </returns>
        public static bool HasTargetSet(DependencyObject element)
        {
            if (GetTarget(element) != null || GetTargetWithoutContext(element) != null)
                return true;
#if WINFORMS || WEBGUI
            var frameworkElement = element.Object as FrameworkElement;
#else
            var frameworkElement = element as FrameworkElement;
#endif
            if (frameworkElement == null)
                return false;

            return ConventionManager.HasBinding(frameworkElement, TargetProperty)
                   || ConventionManager.HasBinding(frameworkElement, TargetWithoutContextProperty);
        }

        ///<summary>
        ///  Uses the action pipeline to invoke the method.
        ///</summary>
        ///<param name="target"> The object instance to invoke the method on. </param>
        ///<param name="methodName"> The name of the method to invoke. </param>
        ///<param name="view"> The view. </param>
        ///<param name="source"> The source of the invocation. </param>
        ///<param name="eventArgs"> The event args. </param>
        ///<param name="parameters"> The method parameters. </param>
        public static void Invoke(object target, string methodName, DependencyObject view = null,
            FrameworkElement source = null, object eventArgs = null, object[] parameters = null)
        {
            var context = new ActionExecutionContext
            {
                Target = target,
                Method = target.GetType().GetMethod(methodName),
#if WINFORMS || WEBGUI
                Message = new ActionMessage(source, null, methodName),
#else
                Message = new ActionMessage {
                    MethodName = methodName
                },
#endif
                View = view,
                Source = source,
                EventArgs = eventArgs
            };

            if (parameters != null)
            {
                parameters.Apply(x => context.Message.Parameters.Add(x as Parameter ?? new Parameter {Value = x}));
            }

            ActionMessage.InvokeAction(context);
        }

        private static void OnTargetWithoutContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetTargetCore(e, d, false);
        }

        private static void OnTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetTargetCore(e, d, true);
        }

        private static void SetTargetCore(DependencyPropertyChangedEventArgs e, DependencyObject d, bool setContext)
        {
            if (e.NewValue == e.OldValue)
            {
                return;
            }

            var target = e.NewValue;
            var containerKey = e.NewValue as string;//todo containerKey is null for classes

            if (containerKey != null)
            {
                target = IoC.GetInstance(null, containerKey);
            }
#if WINFORMS || WEBGUI
            if (setContext && d.Object is IHaveDataContext)
            {
                Log.Info("Setting DC of {0} to {1}.", d, target);
                ((IHaveDataContext) d.Object).DataContext = target;
            }
#else
            if(setContext && d is FrameworkElement)
            {
                Log.Info("Setting DC of {0} to {1}.", d, target);
                ((FrameworkElement)d).DataContext = target;
            }
#endif

            Log.Info("Attaching message handler {0} to {1}.", target, d);
            Message.SetHandler(d, target);
        }
    }
}