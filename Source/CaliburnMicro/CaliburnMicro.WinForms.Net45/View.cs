namespace MvvmFx.CaliburnMicro
{
    using System;
#if WISEJ
    using Control = Wisej.Web.Control;
#else
    using System.Windows.Forms;
    using Control = System.Windows.Forms.Control;
#endif

    /// <summary>
    /// Hosts attached properties related to view models.
    /// </summary>
    public static class View
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof(View));

        /// <summary>
        /// The default view context.
        /// </summary>
        public static readonly object DefaultContext = new object();

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.View.ApplyConventions"/> attached property.
        /// </summary>
        /// <AttachedPropertyComments>
        /// <summary>A dependency property which allows the override of convention application behavior.</summary>
        /// </AttachedPropertyComments>
        public static readonly DependencyProperty ApplyConventionsProperty =
            DependencyProperty.RegisterAttached(
                "ApplyConventions",
                typeof(bool?),
                typeof(View),
                null
            );

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.View.Context"/> attached property.
        /// </summary>
        /// <AttachedPropertyComments>
        /// <summary>A dependency property for assigning a context to a particular portion of the UI.</summary>
        /// </AttachedPropertyComments>
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.RegisterAttached(
                "Context",
                typeof(object),
                typeof(View),
                new PropertyMetadata(null, OnContextChanged)
            );

        /// <summary>
        /// This defines the <see cref="P:MvvmFx.CaliburnMicro.View.Model"/> attached property.
        /// </summary>
        /// <AttachedPropertyComments>
        /// <summary>A dependency property for attaching a model to the UI.</summary>
        /// </AttachedPropertyComments>
        public static DependencyProperty ModelProperty =
            DependencyProperty.RegisterAttached(
                "Model",
                typeof(object),
                typeof(View),
                new PropertyMetadata(null, OnModelChanged)
            );

        /// <summary>
        /// Executes the handler immediately if the element is loaded, otherwise wires it to the Loaded event.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="handler">The handler.</param>
        /// <returns>true if the handler was executed immediately; false otherwise</returns>
        public static bool ExecuteOnLoad(Control control, EventHandler handler)
        {
            if (control.IsHandleCreated)
            {
                handler(control, new EventArgs());
                return true;
            }

            EventHandler loaded = null;
            loaded = (s, e) =>
            {
                handler(s, e);
                control.HandleCreated -= loaded;
            };

            control.HandleCreated += loaded;
            return false;
        }

#if WINFORMS
        /// <summary>
        /// Executes the handler the first time the elements's LayoutUpdated event fires.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="handler">The handler.</param>
        public static void ExecuteOnLayoutUpdated(Control control, LayoutEventHandler handler)
        {
            LayoutEventHandler onLayout = null;
            onLayout = (s, e) =>
            {
                handler(s, e);
                control.Layout -= onLayout;
            };
            control.Layout += onLayout;
        }
#endif

        /// <summary>
        /// Used to retrieve the root, non-framework-created view.
        /// </summary>
        /// <returns>The root element that was not created by the framework.</returns>
        /// <remarks>In certain instances the services create UI elements.
        /// For example, if you ask the window manager to show a UserControl as a dialog, it creates a window to host the UserControl in.
        /// The WindowManager marks that element as a framework-created element so that it can determine what it created vs. what was intended by the developer.
        /// Calling GetFirstNonGeneratedView allows the framework to discover what the original element was.
        /// </remarks>
        public static Func<object, object> GetFirstNonGeneratedView = view =>
        {
            var control = view as Control;
            if (control == null)
            {
                return view;
            }

            if (control is ContentContainer)
            {
                return ((ContentContainer) control).Content;
            }

            return control;
        };

        /// <summary>
        /// Gets the convention application behavior.
        /// </summary>
        /// <param name="d">The element the property is attached to.</param>
        /// <returns>Whether or not to apply conventions.</returns>
        public static bool? GetApplyConventions(DependencyObject d)
        {
            return (bool?) d.GetValue(ApplyConventionsProperty);
        }

        /// <summary>
        /// Sets the convention application behavior.
        /// </summary>
        /// <param name="d">The element to attach the property to.</param>
        /// <param name="value">Whether or not to apply conventions.</param>
        public static void SetApplyConventions(DependencyObject d, bool? value)
        {
            d.SetValue(ApplyConventionsProperty, value);
        }

        /// <summary>
        /// Sets the model.
        /// </summary>
        /// <param name="d">The element to attach the model to.</param>
        /// <param name="value">The model.</param>
        public static void SetModel(DependencyObject d, object value)
        {
            d.SetValue(ModelProperty, value);
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <param name="d">The element the model is attached to.</param>
        /// <returns>The model.</returns>
        public static object GetModel(DependencyObject d)
        {
            return d.GetValue(ModelProperty);
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <param name="d">The element the context is attached to.</param>
        /// <returns>The context.</returns>
        public static object GetContext(DependencyObject d)
        {
            return d.GetValue(ContextProperty);
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="d">The element to attach the context to.</param>
        /// <param name="value">The context.</param>
        public static void SetContext(DependencyObject d, object value)
        {
            d.SetValue(ContextProperty, value);
        }

        private static void OnModelChanged(DependencyObject targetLocation, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue == args.NewValue)
            {
                return;
            }

            if (args.NewValue != null)
            {
                var context = GetContext(targetLocation);
                var view = ViewLocator.LocateForModel(args.NewValue, targetLocation, context);

                SetContentProperty(targetLocation, view);
                ViewModelBinder.Bind(args.NewValue, view, context);
            }
            else
            {
                SetContentProperty(targetLocation, args.NewValue);
            }
        }

        private static void OnContextChanged(DependencyObject targetLocation, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
            {
                return;
            }

            var model = GetModel(targetLocation);
            if (model == null)
            {
                return;
            }

            var view = ViewLocator.LocateForModel(model, targetLocation, e.NewValue);

            SetContentProperty(targetLocation, view);
            ViewModelBinder.Bind(model, view, e.NewValue);
        }

        private static void SetContentProperty(object targetLocation, object view)
        {
            var fe = view as Control;
            if (fe != null && fe.Parent != null)
            {
                SetContentPropertyCore(fe.Parent, null);
            }

            SetContentPropertyCore(targetLocation, view);
        }

        private static void SetContentPropertyCore(object targetLocation, object view)
        {
            try
            {
                if (view is IHaveDataContext)
                {
                    Log.Info("Setting DC of {0} to {1}.", view, targetLocation);
                    ((IHaveDataContext) view).DataContext = targetLocation;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}