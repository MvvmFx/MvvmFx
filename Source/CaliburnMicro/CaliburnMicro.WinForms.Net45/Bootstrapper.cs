namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
#if WISEJ
    using Wisej.Web;
#else
    using System.Windows.Forms;
#endif

    /// <summary>
    /// Inherit from this class in order to customize the configuration of the framework.
    /// </summary>
    public abstract class BootstrapperBase
    {
        private readonly bool useApplication;
        private bool isInitialized;

        /// <summary>
        /// Creates an instance of the bootstrapper.
        /// </summary>
        /// <param name="useApplication">Set this to false when hosting MvvmFx.CaliburnMicro inside and Office or WinForms application. The default is true.</param>
        protected BootstrapperBase(bool useApplication = true)
        {
            this.useApplication = useApplication;
        }

        /// <summary>
        /// Start the framework.
        /// </summary>
        public void Start()
        {
            if (isInitialized)
            {
                return;
            }

            isInitialized = true;

            if (Execute.InDesignMode)
            {
                try
                {
                    StartDesignTime();
                }
                catch
                {
                    //if something fails at design-time, there's really nothing we can do...
                    isInitialized = false;
                    throw;
                }
            }
            else
            {
                StartRuntime();
            }
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            OnStartup(null, new StartupEventArgs(Environment.GetCommandLineArgs()));
        }

        /// <summary>
        /// Called by the bootstrapper's constructor at design time to start the framework.
        /// </summary>
        protected virtual void StartDesignTime()
        {
            AssemblySource.Instance.Clear();
            AssemblySource.Instance.AddRange(SelectAssemblies());

            Configure();
            IoC.GetInstance = GetInstance;
            IoC.GetAllInstances = GetAllInstances;
            IoC.BuildUp = BuildUp;
        }

        /// <summary>
        /// Called by the bootstrapper's constructor at runtime to start the framework.
        /// </summary>
        protected virtual void StartRuntime()
        {
#if WISEJ
            Execute.ResetWithoutDispatcher();
#else
            Execute.InitializeWithDispatcher();
#endif
            EventAggregator.DefaultPublicationThreadMarshaller = Execute.OnUIThread;

            EventAggregator.HandlerResultProcessing = (target, result) =>
            {
                var coroutine = result as IEnumerable<IResult>;
                if (coroutine != null)
                {
                    var viewAware = target as IViewAware;
                    var view = viewAware != null ? viewAware.GetView() : null;
                    var context = new ActionExecutionContext {Target = target, View = (DependencyObject) view};

                    Coroutine.BeginExecute(coroutine.GetEnumerator(), context);
                }
            };

            AssemblySource.Instance.AddRange(SelectAssemblies());

            if (useApplication)
            {
                //Application = System.Windows.Forms.Application;

                PrepareApplication();
            }

            Configure();
            IoC.GetInstance = GetInstance;
            IoC.GetAllInstances = GetAllInstances;
            IoC.BuildUp = BuildUp;
        }

        /// <summary>
        /// Provides an opportunity to hook into the application object.
        /// </summary>
        protected virtual void PrepareApplication()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.ApplicationExit += OnExit;
        }

        /// <summary>
        /// Override to configure the framework and setup your IoC container.
        /// </summary>
        protected virtual void Configure()
        {
        }

        /// <summary>
        /// Override to tell the framework where to find assemblies to inspect for views, etc.
        /// </summary>
        /// <returns>A list of assemblies to inspect.</returns>
        protected virtual IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {GetType().Assembly};
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <param name="key">The key to locate.</param>
        /// <returns>The located service.</returns>
        protected virtual object GetInstance(Type service, string key)
        {
            if (service == typeof(IWindowManager))
                service = typeof(WindowManager);

            return Activator.CreateInstance(service);
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <returns>The located services.</returns>
        protected virtual IEnumerable<object> GetAllInstances(Type service)
        {
            return new[] {Activator.CreateInstance(service)};
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="instance">The instance to perform injection on.</param>
        protected virtual void BuildUp(object instance)
        {
        }

        /// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected virtual void OnStartup(object sender, StartupEventArgs e)
        {
        }

        /// <summary>
        /// Override this to add custom behavior on exit.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected virtual void OnExit(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the UnhandledException event of the AppDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        protected virtual void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
        protected virtual void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
        }

        /// <summary>
        /// Locates the view model, locates the associate view, binds them and shows it as the root view.
        /// </summary>
        /// <param name="viewModelType">The view model type.</param>
        /// <param name="settings">The optional window settings.</param>
        protected void DisplayRootViewFor(Type viewModelType, IDictionary<string, object> settings = null)
        {
            var windowManager = IoC.Get<IWindowManager>();
            windowManager.ShowWindow(IoC.GetInstance(viewModelType, null), null, settings);
        }

        /// <summary>
        /// Locates the view model, locates the associate view, binds them and shows it as the root view.
        /// </summary>
        /// <typeparam name="TViewModel">The view model type.</typeparam>
        /// <param name="settings">The optional window settings.</param>
        protected void DisplayRootViewFor<TViewModel>(IDictionary<string, object> settings = null)
        {
            DisplayRootViewFor(typeof(TViewModel), settings);
        }

#if WISEJ
        /// <summary>
        /// Locates the view model, locates the associate view, binds them and shows it as the root view.
        /// </summary>
        /// <param name="viewModelType">The view model type.</param>
        /// <param name="settings">The optional window settings.</param>
        protected void DisplayPageRootViewFor(Type viewModelType, IDictionary<string, object> settings = null)
        {
            var windowManager = IoC.Get<IWindowManager>();
            windowManager.ShowPage(IoC.GetInstance(viewModelType, null), null, settings);
        }

        /// <summary>
        /// Locates the view model, locates the associate view, binds them and shows it as the root view.
        /// </summary>
        /// <typeparam name="TViewModel">The view model type.</typeparam>
        /// <param name="settings">The optional window settings.</param>
        protected void DisplayPageRootViewFor<TViewModel>(IDictionary<string, object> settings = null)
        {
            DisplayPageRootViewFor(typeof(TViewModel), settings);
        }
#endif
    }

    /// <summary>
    /// A strongly-typed version of <see cref="BootstrapperBase"/> that specifies the type of root model to create for the application.
    /// </summary>
    /// <typeparam name="TRootModel">The type of root model for the application.</typeparam>
    public class Bootstrapper<TRootModel> : BootstrapperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper&lt;TRootModel&gt;"/> class.
        /// </summary>
        public Bootstrapper() : base(true)
        {
            Start();
        }

        /// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<TRootModel>();
        }
    }

#if WISEJ
    /// <summary>
    /// A strongly-typed version of <see cref="BootstrapperBase"/> that specifies the type of root model to create for the application.
    /// </summary>
    /// <typeparam name="TRootModel">The type of root model for the application.</typeparam>
    public class PageBootstrapper<TRootModel> : BootstrapperBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper&lt;TRootModel&gt;"/> class.
        /// </summary>
        public PageBootstrapper() : base(true)
        {
            Start();
        }

        /// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayPageRootViewFor<TRootModel>();
        }
    }
#endif
}