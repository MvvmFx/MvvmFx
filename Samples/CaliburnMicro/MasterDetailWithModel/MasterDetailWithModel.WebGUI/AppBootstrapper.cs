using System;
using System.Collections.Generic;
using Gizmox.WebGUI.Forms;
using MvvmFx.CaliburnMicro;
using MvvmFx.Logging;

namespace MasterDetailWithModel
{
    internal class AppBootstrapper : Bootstrapper<IMainFormViewModel>
    {
        private static SimpleContainer _container;

        internal AppBootstrapper(Form startupForm)
            : base()
        {
            ApplicationContext.SetStartupForm(startupForm);
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container
                .Singleton<IMainFormViewModel, MainFormViewModel>()
                .PerRequest<IWindowManager, WindowManager>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);

            if (null != instance)
            {
                return instance;
            }

            throw new ArgumentException(string.Format("Could not locate any instances of contract {0}.", service.Name));
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            foreach (var instance in _container.GetAllInstances(service))
            {
                yield return instance;
            }
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void StartRuntime()
        {
            LogManager.GetLog = type => new DebugLogger(type);
            base.StartRuntime();
        }

        /*/// <summary>
        /// Override this to add custom behavior to execute after the application starts.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The args.</param>
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            new ApplicationContext(StartupForm);
            //DisplayRootViewFor(typeof(TRootModel));
        }*/
    }
}