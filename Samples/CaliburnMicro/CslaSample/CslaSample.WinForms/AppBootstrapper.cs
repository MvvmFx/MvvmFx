using System;
using System.Collections.Generic;
using System.Threading;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif
using MvvmFx.CaliburnMicro;
using MvvmFx.Logging;

namespace CslaSample
{
    internal class AppBootstrapper : Bootstrapper<IMainFormViewModel>
    {
        private static SimpleContainer _container;

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
            Csla.SmartDate.CustomParser = CslaContrib.SmartDateExtendedParser.ExtendedParser;
            LogManager.GetLog = type => new DebugLogger(type);
            base.StartRuntime();
        }

        /*protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }*/

        protected override void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                var message = Environment.NewLine + ex.InnerException.Message;
                if (message != "\r\nExit")
                    MessageBox.Show(message, @"Fatal error");
            }
            else
                MessageBox.Show(e.ExceptionObject.ToString(), @"Fatal error");
        }

        protected override void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                var message = Environment.NewLine + ex.InnerException.Message;
                MessageBox.Show(message, @"Fatal error");
            }
            else
                MessageBox.Show(e.Exception.Message, @"Fatal error");
        }
    }
}