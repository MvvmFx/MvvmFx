using System;
using System.Collections.Generic;
using MvvmFx.CaliburnMicro.ComponentHandlers;

namespace MvvmFx.CaliburnMicro.WisejWeb.Toolable
{
    /// <summary>
    /// Setup this Wisej extension on CaliburnMicro.WisejWeb.
    /// </summary>
    public static class Setup
    {
        private static readonly List<Type> SetupDone = new List<Type>();

        /// <summary>
        /// Runs ProxyAgent and ElementConvention configurations.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        public static void Run(Type controlType)
        {
            if (SetupDone.Contains(controlType))
                return;

            switch (controlType.Name)
            {
                case "PanelEx":
                    RunPanelEx();
                    break;
                default: return;
            }
        }

        #region PanelEx

        private static void RunPanelEx()
        {
            PanelExProxyAgent();
            PanelExBinderAgent();
            PanelExElementConvention();

            SetupDone.Add(typeof(PanelEx));
        }

        private static void PanelExProxyAgent()
        {
            ProxyManager.AddProxyAgent<PanelEx>(PanelExHandler.GetChildItems);
        }

        private static void PanelExBinderAgent()
        {
            BinderManager.AddBinderAgent<PanelEx>(PanelExHandler.BindVisualProperties);
        }

        private static void PanelExElementConvention()
        {
            ConventionManager.AddElementConvention<ComponentToolExProxy>("Name", null, "Click")
                .CreateAction = (element, methodName, parameters) =>
            {
                return new ActionMessage(element, "Click", methodName, parameters);
            };
        }

        #endregion
    }
}