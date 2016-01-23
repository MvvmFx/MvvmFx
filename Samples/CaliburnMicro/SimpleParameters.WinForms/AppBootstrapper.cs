using System;
using System.Collections.Generic;
using MvvmFx.CaliburnMicro;
using MvvmFx.Logging;

namespace SimpleParameters.UI
{
    internal class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        private static SimpleContainer _container;

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container
                .Singleton<ShellViewModel, ShellViewModel>()
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
    }
}