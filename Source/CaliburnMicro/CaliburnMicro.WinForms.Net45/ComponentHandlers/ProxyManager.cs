namespace MvvmFx.CaliburnMicro.ComponentProxy
{
    using System;
    using System.Collections.Generic;
#if WINFORMS
    using Component = System.ComponentModel.Component;
    using System.Windows.Forms;
#else
    using Wisej.Web;
    using Component = Wisej.Web.Component;
#endif
    using MvvmFx.Windows.Data;

    /// <summary>
    /// Used to configure the proxy agents used to wrap <see cref="Component"/> and allow bindings and actions.
    /// </summary>
    public static class ProxyManager
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof(ProxyManager));

        private static readonly Dictionary<Type, ProxyAgent> ProxyAgent = new Dictionary<Type, ProxyAgent>();

        /// <summary>
        /// Initializes the <see cref="ProxyManager"/> class.
        /// Configures a default set of <see cref="ProxyAgent"/>.
        /// </summary>
        static ProxyManager()
        {
#if WINFORMS
            AddProxyAgent<ToolStrip>(ToolStripAgent.GetNamedItems, ToolStripAgent.BindVisualProperties);
#else
            AddProxyAgent<MenuBar>(MenuBarAgent.GetNamedItems, MenuBarAgent.BindVisualProperties);
            AddProxyAgent<ToolBar>(ToolBarAgent.GetNamedItems, ToolBarAgent.BindVisualProperties);
            AddProxyAgent<StatusBar>(StatusBarAgent.GetNamedItems, StatusBarAgent.BindVisualProperties);
#endif
        }

        /// <summary>
        /// Gets the proxy agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <returns>The proxy agent if found, null otherwise.</returns>
        /// <remarks>Searches the class hierarchy for proxy agents.</remarks>
        public static ProxyAgent GetProxyAgent(Type controlType)
        {
            if (controlType == null)
                return null;

            ProxyAgent proxyAgent;
            ProxyAgent.TryGetValue(controlType, out proxyAgent);
            return proxyAgent ?? GetProxyAgent(controlType.BaseType);
        }

        /// <summary>
        /// Adds a proxy agent.
        /// </summary>
        /// <typeparam name="T">Type of the control.</typeparam>
        /// <param name="getNamedItems">Func to get the named items.</param>
        /// <param name="bindVisualProperties">Action to bind visual properties.</param>
        /// <returns>
        /// The added proxy agent.
        /// </returns>
        public static ProxyAgent AddProxyAgent<T>(Func<Control, IEnumerable<Control>> getNamedItems,
            Action<Control, object, BindingManager> bindVisualProperties)
        {
            return AddProxyAgent<T>(new ProxyAgent
            {
                GetNamedItems = getNamedItems,
                BindVisualProperties = bindVisualProperties
            });
        }

        /// <summary>
        /// Adds a proxy agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="getNamedItems">Func to get the named items.</param>
        /// <param name="bindVisualProperties">Action to bind visual properties.</param>
        /// <returns>
        /// The added proxy agent.
        /// </returns>
        public static ProxyAgent AddProxyAgent(Type controlType, Func<Control, IEnumerable<Control>> getNamedItems,
            Action<Control, object, BindingManager> bindVisualProperties)
        {
            return AddProxyAgent(controlType, new ProxyAgent
            {
                GetNamedItems = getNamedItems,
                BindVisualProperties = bindVisualProperties
            });
        }

        /// <summary>
        /// Adds a proxy agent.
        /// </summary>
        /// <typeparam name="T">Type of the control.</typeparam>
        /// <param name="proxyAgent">The proxy agent.</param>
        /// <returns>
        /// The added proxy agent.
        /// </returns>
        public static ProxyAgent AddProxyAgent<T>(ProxyAgent proxyAgent)
        {
            return AddProxyAgent(typeof(T), proxyAgent);
        }

        /// <summary>
        /// Adds a proxy agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="proxyAgent">The proxy agent.</param>
        /// <returns>
        /// The added proxy agent.
        /// </returns>
        public static ProxyAgent AddProxyAgent(Type controlType, ProxyAgent proxyAgent)
        {
            return ProxyAgent[controlType] = proxyAgent;
        }
    }
}