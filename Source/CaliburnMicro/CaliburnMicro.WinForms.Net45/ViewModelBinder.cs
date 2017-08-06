namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
#if WISEJ
    using Wisej.Web;
    using FrameworkElement = Wisej.Web.Control;
#else
    using System.Windows.Forms;
    using FrameworkElement = System.Windows.Forms.Control;
#endif

    /// <summary>
    /// Manages control events.
    /// </summary>
    public static class ControlEvents
    {
        /// <summary>
        /// Determines whether the specified control has events with listeners.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>
        /// 	<c>true</c> if the specified control has events with listeners; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasEventsWithListeners(Control control)
        {
            //TODO make this work

            return false;
        }
    }

    /// <summary>
    /// Binds a view to a view model.
    /// </summary>
    public static class ViewModelBinder
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof (ViewModelBinder));

        /// <summary>
        /// Gets or sets a value indicating whether to apply conventions by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if conventions should be applied by default; otherwise, <c>false</c>.
        /// </value>
        public static bool ApplyConventionsByDefault = true;

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.ViewModelBinder.ConventionsApplied"/> attached property.
        /// </summary>
        /// <AttachedEventComments>
        /// <summary>
        /// Indicates whether or not the conventions have already been applied to the view.
        /// </summary>
        /// </AttachedEventComments>
        public static readonly DependencyProperty ConventionsAppliedProperty =
            DependencyProperty.RegisterAttached(
                "ConventionsApplied",
                typeof (bool),
                typeof (ViewModelBinder),
                null
                );

        /// <summary>
        /// Determines whether a view should have conventions applied to it.
        /// </summary>
        /// <param name="view">The view to check.</param>
        /// <returns>Whether or not conventions should be applied to the view.</returns>
        public static bool ShouldApplyConventions(FrameworkElement view)
        {
            var overriden = View.GetApplyConventions(view.GetDependencyObject());
            return overriden.GetValueOrDefault(ApplyConventionsByDefault);
        }

        /// <summary>
        /// Rebinds data bindings on the view's controls based on the provided <see cref="IViewAware"/> view model.
        /// </summary>
        /// <remarks>The view model object to find rebindable properties is passed as parameter.
        /// Returns <c>true</c> if every unbound property was rebound; otherwise, <c>false</c></remarks>
        public static Func<IViewAware, bool> RebindProperties =
            viewModel =>
            {
                var iHaveNamedElements = viewModel as IHaveViewNamedElements;
                if (iHaveNamedElements == null)
                {
                    Log.Info("Rebinding Rule Not Applied: View Model {0} does not implement IHaveNamedElements.",
                        viewModel is IHaveDisplayName
                            ? ((IHaveDisplayName) viewModel).DisplayName
                            : viewModel.GetType().Name);

                    return false;
                }

                IEnumerable<Control> namedElements = iHaveNamedElements.ViewNamedElements;
                namedElements = UnbindProperties(namedElements, viewModel);
                namedElements = BindProperties(namedElements, viewModel);
                return !namedElements.Any();
            };

        /// <summary>
        /// Removes data bindings on the view's controls based on the provided properties.
        /// </summary>
        /// <remarks>Parameters include named Elements to search through and the view model object to find unbindable properties.
        /// Returns matched elements only, to simplify rebinding.</remarks>
        public static Func<IEnumerable<FrameworkElement>, object, IEnumerable<FrameworkElement>> UnbindProperties =
            (namedElements, viewModel) =>
            {
                var matchedElements = new List<FrameworkElement>();

                foreach (var element in namedElements)
                {
                    var cleanName = element.Name.Trim('_');

                    if (string.IsNullOrEmpty(cleanName))
                        continue;

                    var parts = cleanName.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                    var property = viewModel.GetPropertyCaseInsensitive(parts[0]);

                    for (var i = 1; i < parts.Length && property != null; i++)
                    {
                        var interpretedViewModelType = property.PropertyType;
                        if (interpretedViewModelType.FullName == "System.Object")
                            interpretedViewModelType = property.GetValue(viewModel, null).GetType();
                        property = interpretedViewModelType.GetPropertyCaseInsensitive(parts[i]);
                    }

                    if (property == null)
                    {
                        Log.Info("Unbinding Rule Not Applied: Element {0} did not match a property.", element.Name);
                        continue;
                    }

                    if (element.DataBindings.Count > 0)
                    {
                        element.DataBindings.Clear();
                        matchedElements.Add(element);
                        Log.Info("Unbinding Rule Applied: Element {0}.", element.Name);
                    }
                    else
                    {
                        Log.Info("Unbinding Rule Not Applied: Element {0} has no bindings.", element.Name);
                    }
                }

                return matchedElements;
            };


        /// <summary>
        /// Creates data bindings on the view's controls based on the provided properties.
        /// </summary>
        /// <remarks>Parameters include named Elements to search through and the view model object to determine conventions for. Returns unmatched elements.</remarks>
        public static Func<IEnumerable<FrameworkElement>, object, IEnumerable<FrameworkElement>> BindProperties =
            (namedElements, viewModel) =>
            {
                var unmatchedElements = new List<FrameworkElement>();

                foreach (var element in namedElements)
                {
                    var cleanName = element.Name.Trim('_');

                    if (string.IsNullOrEmpty(cleanName))
                        continue;

                    var parts = cleanName.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                    var property = viewModel.GetPropertyCaseInsensitive(parts[0]);

                    for (var i = 1; i < parts.Length && property != null; i++)
                    {
                        var interpretedViewModelType = property.PropertyType;
                        if (interpretedViewModelType.FullName == "System.Object")
                            interpretedViewModelType = property.GetValue(viewModel, null).GetType();
                        property = interpretedViewModelType.GetPropertyCaseInsensitive(parts[i]);
                    }

                    if (property == null)
                    {
                        unmatchedElements.Add(element);
                        Log.Info("Binding Convention Not Applied: Element {0} did not match a property.", element.Name);
                        continue;
                    }

                    var convention = ConventionManager.GetElementConvention(element.GetType());
                    if (convention == null)
                    {
                        unmatchedElements.Add(element);
                        Log.Warn("Binding Convention Not Applied: No conventions configured for {0}.", element.GetType());
                        continue;
                    }

                    var applied = convention.ApplyBinding(
                        viewModel,
                        cleanName.Replace('_', '.'),
                        property,
                        element,
                        convention
                        );

                    if (applied)
                    {
                        Log.Info("Binding Convention Applied: Element {0}.", element.Name);
                    }
                    else
                    {
                        Log.Info("Binding Convention Not Applied: Element {0} has existing binding.", element.Name);
                        unmatchedElements.Add(element);
                    }
                }

                return unmatchedElements;
            };

        /// <summary>
        /// Attaches instances of <see cref="ActionMessage"/> to the view's controls based on the provided methods.
        /// </summary>
        /// <remarks>Parameters include the named elements to search through and the type of view model to determine conventions for. Returns unmatched elements.</remarks>
        public static Func<IEnumerable<FrameworkElement>, object, IEnumerable<FrameworkElement>> BindActions =
            (namedElements, viewModel) =>
            {
                var methods = viewModel.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
                var unmatchedElements = namedElements.ToList();

                foreach (var method in methods)
                {
                    var foundControl = unmatchedElements.FindName(method.Name);
                    if (foundControl == null)
                    {
                        Log.Info("Action Convention Not Applied: No actionable element for {0}.", method.Name);
                        continue;
                    }

                    if (!string.IsNullOrEmpty(foundControl.GetFullAttachedMessage()))
                    {
                        Log.Info("Action Convention Not Applied: Message.Attach found on {0}.", foundControl.Name);
                        continue;
                    }

                    unmatchedElements.Remove(foundControl);

                    if (ControlEvents.HasEventsWithListeners(foundControl))
                    {
                        Log.Info("Action Convention Not Applied: Events with listeners already set on {0}.",
                            foundControl.Name);
                        continue;
                    }

                    var convention = ConventionManager.GetElementConvention(foundControl.GetType());
                    if (convention != null && convention.CreateAction != null)
                    {
                        convention.CreateAction(foundControl, method.Name, null);
                        Log.Info("Action Convention Applied: Action {0} on element {1}.", method.Name, foundControl);
                    }

                    if (unmatchedElements.Count == 0)
                        break;
                }

                var unmatchedControls = new Control[unmatchedElements.Count];
                unmatchedElements.CopyTo(unmatchedControls);

                foreach (var control in unmatchedControls)
                {
                    var attachedMessage = control.GetFullAttachedMessage();
                    if (!string.IsNullOrEmpty(attachedMessage))
                    {
                        var messageElements = Parser.Parse(control, attachedMessage, unmatchedElements);
                        foreach (var element in messageElements)
                        {
                            var method = viewModel.GetMethodCaseSensitive(element.MethodName);
                            if (method != null)
                            {
                                new ActionMessage(control, element.EventName, element.MethodName, element.Parameters);

                                unmatchedElements.Remove(control);

                                Log.Info("Attached Message Applied: Action {0} on element {1} with message {2}.",
                                    method.Name, control, attachedMessage);
                            }
                        }
                    }
                }

                return unmatchedElements;
            };

        /// <summary>
        /// Allows the developer to add custom handling of named elements which were not matched by any default conventions.
        /// </summary>
        public static Action<IEnumerable<FrameworkElement>, object> HandleUnmatchedElements =
            (elements, viewModel) => { };

        /// <summary>
        /// Binds the specified viewModel to the view.
        /// </summary>
        ///<remarks>Passes the the view model, view and creation context (or null for default) to use in applying binding.</remarks>
        public static Action<object, FrameworkElement, object> Bind = (viewModel, view, context) =>
        {
            Log.Info("Binding {0} and {1}.", view, viewModel);

            if (view is IHaveDataContext)
                view.SetTarget(viewModel);
            else
                view.SetTargetWithoutContext(viewModel);

            var viewAware = viewModel as IViewAware;
            if (viewAware != null)
            {
                Log.Info("Attaching {0} to {1}.", view, viewAware);
                viewAware.AttachView(view, context);
            }

            if ((bool) view.GetDependencyObject().GetValue(ConventionsAppliedProperty))
            {
                return;
            }

            if (!ShouldApplyConventions(view))
            {
                Log.Info("Skipping conventions for {0} and {1}.", view, viewModel);
                return;
            }

            IEnumerable<FrameworkElement> namedElements = BindingScope.GetNamedElements(view).ToList();

            var iHaveNamedElements = viewModel as IHaveViewNamedElements;
            if (iHaveNamedElements != null)
                iHaveNamedElements.ViewNamedElements = namedElements.ToList();

            namedElements = BindActions(namedElements, viewModel);
            namedElements = BindProperties(namedElements, viewModel);
            HandleUnmatchedElements(namedElements, viewModel);

            view.GetDependencyObject().SetValue(ConventionsAppliedProperty, true);
        };
    }
}