using MvvmFx.CaliburnMicro.ComponentHandlers;

namespace MvvmFx.CaliburnMicro.WisejWeb.Toolable
{
    /// <summary>
    /// Setup this Wisej extension on CaliburnMicro.WisejWeb.
    /// </summary>
    public static class Setup
    {
        private static bool _setupDone;

        /// <summary>
        /// Runs ProxyAgent and ElementConvention configurations.
        /// </summary>
        public static void Run()
        {
            if (_setupDone)
                return;

            ConfigureProxyAgent();
            ConfigureBinderAgent();
            ConfigureElementConvention();

            _setupDone = true;
        }

        private static void ConfigureProxyAgent()
        {
            ProxyManager.AddProxyAgent<global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx>(PanelExHandler.GetChildItems);
        }

        private static void ConfigureBinderAgent()
        {
            BinderManager.AddBinderAgent<global::MvvmFx.CaliburnMicro.WisejWeb.Toolable.PanelEx>(PanelExHandler.BindVisualProperties);
        }

        private static void ConfigureElementConvention()
        {
            ConventionManager.AddElementConvention<ComponentToolExProxy>("Name", null, "Click")
                .CreateAction = (element, methodName, parameters) =>
            {
                return new ActionMessage(element, "Click", methodName, parameters);
            };
        }
    }
}