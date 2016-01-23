namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
#if WEBGUI
    using Gizmox.WebGUI.Forms;
    using FrameworkElement = Gizmox.WebGUI.Forms.Control;
#else
    using System.Windows.Forms;
    using FrameworkElement = System.Windows.Forms.Control;
#endif

    /// <summary>
    /// Used to send a message from the UI to a presentation model class, indicating that a particular Action should be invoked.
    /// </summary>
    public class ActionMessage : IHaveParameters
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof (ActionMessage));
        private ActionExecutionContext context;
        private List<Parameter> parameters = new List<Parameter>();
        private Control associatedObject;
        private EventInfo associatedEvent;
        private EventHandler associatedEventHandler;

        internal static readonly DependencyProperty HandlerProperty = DependencyProperty.RegisterAttached(
            "Handler",
            typeof (object),
            typeof (ActionMessage),
            new PropertyMetadata(null, HandlerPropertyChanged)
            );

        ///<summary>
        /// Causes the action invocation to "double check" if the action should be invoked by executing the guard immediately before hand.
        ///</summary>
        /// <remarks>This is disabled by default. If multiple actions are attached to the same element, you may want to enable this so that each individaul action checks its guard regardless of how the UI state appears.</remarks>
        public static bool EnforceGuardsDuringInvocation = false;

        ///<summary>
        /// Causes the action to throw if it cannot locate the target or the method at invocation time.
        ///</summary>
        /// <remarks>True by default.</remarks>
        public static bool ThrowsExceptions = true;

        /// <summary>
        /// Gets or sets the name of the method to be invoked on the presentation model class.
        /// </summary>
        /// <value>The name of the method.</value>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets the parameters to pass as part of the method invocation.
        /// </summary>
        /// <value>The parameters.</value>
        public IList<Parameter> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// Occurs before the message detaches from the associated object.
        /// </summary>
        public event EventHandler Detaching = delegate { };

        /// <summary>
        /// Creates an instance of <see cref="ActionMessage"/>.
        /// </summary>
        /// <param name="associatedObject">The associated <see cref="Control"/> object.</param>
        /// <param name="eventName">Name of the event on the view that triggers the ActionMessage.</param>
        /// <param name="methodName">Name of the method to be invoked on the presentation model class.</param>
        public ActionMessage(Control associatedObject, string eventName, string methodName)
        {
            EventName = eventName;
            MethodName = methodName;
            AssociatedObject = associatedObject;
        }

        /// <summary>
        /// Creates an instance of <see cref="ActionMessage" />.
        /// </summary>
        /// <param name="associatedObject">The associated <see cref="Control"/> object.</param>
        /// <param name="eventName">Name of the event on the view that triggers the ActionMessage.</param>
        /// <param name="methodName">Name of the method to be invoked on the presentation model class.</param>
        /// <param name="parameters">The parameters to pass as part of the method invocation.</param>
        public ActionMessage(Control associatedObject, string eventName, string methodName,
            IEnumerable<Parameter> parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    parameter.MakeAwareOf(this);
                    Parameters.Add(parameter);
                }
            }
            EventName = eventName;
            MethodName = methodName;
            AssociatedObject = associatedObject;
        }

        private static void HandlerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ActionMessage) d.Object).UpdateContext();
        }

        /// <summary>
        /// Gets or sets the <see cref="Control"/> object to which this <see cref="ActionMessage"/> is attached.
        /// </summary>
        /// <value>
        /// The associated <see cref="Control"/> object.
        /// </value>
        public Control AssociatedObject
        {
            get { return associatedObject; }
            set
            {
                if (value != associatedObject)
                {
                    if (null != associatedObject)
                    {
                        if (associatedEvent != null)
                            associatedEvent.RemoveEventHandler(associatedObject, associatedEventHandler);

                        associatedObject.Disposed -= associatedObject_Disposed;
                    }

                    associatedObject = value;

                    if (null != associatedObject)
                    {
                        if (!string.IsNullOrEmpty(EventName))
                        {
                            associatedEvent = associatedObject.GetType().GetEvent(EventName);
                            if (associatedEvent != null)
                            {
                                associatedEventHandler = (s, e) => associatedObject_Event(s, e);
                                associatedEvent.AddEventHandler(associatedObject, associatedEventHandler);
                            }
                        }

                        associatedObject.Disposed += associatedObject_Disposed;
                    }

                    UpdateContext();
                }
            }
        }

        private void associatedObject_Event(object sender, object e)
        {
            Invoke(e);
        }

        private void associatedObject_Disposed(object sender, EventArgs e)
        {
            if (associatedEvent != null)
                associatedEvent.RemoveEventHandler(associatedObject, associatedEventHandler);
            context.Dispose();
        }

        /// <summary>
        /// Gets or sets the name of the event on the view that triggers the ActionMessage.
        /// </summary>
        /// <value>The name of the event.</value>
        public string EventName { get; set; }

        private void UpdateContext()
        {
            if (context != null)
                context.Dispose();

            context = new ActionExecutionContext
            {
                Message = this,
                Source = AssociatedObject
            };

            PrepareContext(context);
            UpdateAvailabilityCore();
        }

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="eventArgs">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        public void Invoke(object eventArgs)
        {
            Log.Info("Invoking {0}.", this);

            if (context == null)
            {
                UpdateContext();
            }

            if (context.Target == null || context.View == null)
            {
                PrepareContext(context);
                if (context.Target == null)
                {
                    var ex = new Exception(string.Format("No target found for method {0}.", context.Message.MethodName));
                    Log.Error(ex);

                    if (!ThrowsExceptions)
                        return;
                    throw ex;
                }

                if (!UpdateAvailabilityCore())
                {
                    return;
                }
            }

            if (context.Method == null)
            {
                var ex =
                    new Exception(string.Format("Method {0} not found on target of type {1}.",
                        context.Message.MethodName, context.Target.GetType()));
                Log.Error(ex);

                if (!ThrowsExceptions)
                    return;
                throw ex;
            }

            context.EventArgs = eventArgs;

            if (EnforceGuardsDuringInvocation && context.CanExecute != null && !context.CanExecute())
            {
                return;
            }

            InvokeAction(context);
            context.EventArgs = null;
        }

        /// <summary>
        /// Forces an update of the UI's Enabled/Disabled state based on the the preconditions associated with the method.
        /// </summary>
        public void UpdateAvailability()
        {
            if (context == null)
                return;

            if (context.Target == null || context.View == null)
                PrepareContext(context);

            UpdateAvailabilityCore();
        }

        private bool UpdateAvailabilityCore()
        {
            Log.Info("{0} availability update.", this);
            return ApplyAvailabilityEffect(context);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return "Action: " + MethodName;
        }

        /// <summary>
        /// Invokes the action using the specified <see cref="ActionExecutionContext"/>
        /// </summary>
        public static Action<ActionExecutionContext> InvokeAction = context =>
        {
            var values = MessageBinder.DetermineParameters(context, context.Method.GetParameters());
            var returnValue = context.Method.Invoke(context.Target, values);

            var result = returnValue as IResult;
            if (result != null)
            {
                returnValue = new[] {result};
            }

            var enumerable = returnValue as IEnumerable<IResult>;
            if (enumerable != null)
            {
                returnValue = enumerable.GetEnumerator();
            }

            var enumerator = returnValue as IEnumerator<IResult>;
            if (enumerator != null)
            {
                Coroutine.BeginExecute(enumerator, context);
            }
        };

        /// <summary>
        /// Applies an availability effect, such as Enabled, to an element.
        /// </summary>
        /// <remarks>Returns a value indicating whether or not the action is available.</remarks>
        public static Func<ActionExecutionContext, bool> ApplyAvailabilityEffect = context =>
        {
            var source = context.Source;
            if (ConventionManager.HasBinding(source, "Enabled"))
            {
                return source.Enabled;
            }

            if (context.CanExecute != null)
            {
                source.Enabled = context.CanExecute();
            }

            return source.Enabled;
        };

        /// <summary>
        /// Finds the method on the target matching the specified message and the specified target object.
        /// </summary>
        /// <returns>The matching method, if available.</returns>
        public static Func<ActionMessage, object, MethodInfo> GetTargetMethod = (message, target) =>
        {
            return (from method in target.GetType().GetMethods()
                where method.Name == message.MethodName
                let methodParameters = method.GetParameters()
                where message.Parameters.Count == methodParameters.Length
                select method).FirstOrDefault();
        };

        /// <summary>
        /// Sets the target, method and view on the context. Uses a bubbling strategy by default.
        /// </summary>
        public static Action<ActionExecutionContext> SetMethodBinding = context =>
        {
            FrameworkElement currentElement = context.Source;

            while (currentElement != null)
            {
                if (Action.HasTargetSet(currentElement))
                {
                    var target = Message.GetHandler(currentElement);
                    if (target != null)
                    {
                        var method = GetTargetMethod(context.Message, target);
                        if (method != null)
                        {
                            context.Method = method;
                            context.Target = target;
                            context.View = currentElement.GetDependencyObject();
                            return;
                        }
                    }
                    else
                    {
                        context.View = currentElement.GetDependencyObject();
                        return;
                    }
                }

                currentElement = currentElement.Parent;
            }

            var dc = context.Source as IHaveDataContext;

            if (dc != null && dc.DataContext != null)
            {
                var target = dc.DataContext;
                var method = GetTargetMethod(context.Message, target);

                if (method != null)
                {
                    context.Target = target;
                    context.Method = method;
                    context.View = context.Source.GetDependencyObject();
                }
            }
        };

        /// <summary>
        /// Prepares the action execution context for use.
        /// </summary>
        public static Action<ActionExecutionContext> PrepareContext = context =>
        {
            SetMethodBinding(context);
            if (context.Target == null || context.Method == null)
            {
                return;
            }

            var guardName = "Can" + context.Method.Name;
            var targetType = context.Target.GetType();
            var guard = TryFindGuardMethod(context);

            if (guard == null)
            {
                var inpc = context.Target as INotifyPropertyChanged;
                if (inpc == null)
                    return;

                guard = targetType.GetMethod("get_" + guardName);
                if (guard == null)
                    return;

                PropertyChangedEventHandler handler = null;
                handler = (s, e) =>
                {
                    if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == guardName)
                    {
                        Execute.OnUIThread(() =>
                        {
                            var message = context.Message;
                            if (message == null)
                            {
                                inpc.PropertyChanged -= handler;
                                return;
                            }
                            message.UpdateAvailability();
                        });
                    }
                };

                inpc.PropertyChanged += handler;
                context.Disposing += delegate { inpc.PropertyChanged -= handler; };
                context.Message.Detaching += delegate { inpc.PropertyChanged -= handler; };
            }

            context.CanExecute = () => (bool) guard.Invoke(
                context.Target,
                MessageBinder.DetermineParameters(context, guard.GetParameters())
                );
        };

        /// <summary>
        /// Try to find a candidate for guard function, having:
        ///		- a name in the form "CanXXX"
        ///		- no generic parameters
        ///		- a bool return type
        ///		- no parameters or a set of parameters corresponding to the action method
        /// </summary>
        /// <param name="context">The execution context</param>
        /// <returns>A MethodInfo, if found; null otherwise</returns>
        private static MethodInfo TryFindGuardMethod(ActionExecutionContext context)
        {
            var guardName = "Can" + context.Method.Name;
            var targetType = context.Target.GetType();
            var guard = targetType.GetMethod(guardName);

            if (guard == null) return null;
            if (guard.ContainsGenericParameters) return null;
            if (typeof (bool) != guard.ReturnType) return null;

            var guardPars = guard.GetParameters();
            var actionPars = context.Method.GetParameters();
            if (guardPars.Length == 0) return guard;
            if (guardPars.Length != actionPars.Length) return null;

            var comparisons = guardPars.Zip(
                context.Method.GetParameters(),
                (x, y) => x.ParameterType == y.ParameterType
                );

            if (comparisons.Any(x => !x))
            {
                return null;
            }

            return guard;
        }
    }
}