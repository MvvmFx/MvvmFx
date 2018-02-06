namespace MvvmFx.CaliburnMicro.ComponentHandlers
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
    /// Used to configure the binder binders used to wrap <see cref="Component"/> and allow bindings and actions.
    /// the binding method for a control type that wraps a component.
    /// </summary>
    public static class BinderManager
    {
        private static readonly Logging.ILog Log = LogManager.GetLog(typeof(BinderManager));

        private static readonly Dictionary<Type, BinderAgent> BinderAgent =
            new Dictionary<Type, BinderAgent>();

        /// <summary>
        /// Initializes the <see cref="BinderManager"/> class.
        /// Configures a default set of <see cref="BinderAgent"/>.
        /// </summary>
        static BinderManager()
        {
#if WINFORMS
            AddBinderAgent<ToolStripItemProxy>(ToolStripHandler.BindVisualProperties);
#else
            AddBinderAgent<MenuItemProxy>(MenuBarHandler.BindVisualProperties);
            AddBinderAgent<ToolBarButtonProxy>(ToolBarHandler.BindVisualProperties);
#endif
        }

        /// <summary>
        /// Gets the binder agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <returns>The binder agent if found, null otherwise.</returns>
        /// <remarks>Searches the class hierarchy for binder agents.</remarks>
        public static BinderAgent GetBinderAgent(Type controlType)
        {
            if (controlType == null)
                return null;

            BinderAgent binderAgent;
            BinderAgent.TryGetValue(controlType, out binderAgent);
            return binderAgent ?? GetBinderAgent(controlType.BaseType);
        }

        /// <summary>
        /// Adds a binder agent.
        /// </summary>
        /// <typeparam name="T">Type of the control.</typeparam>
        /// <param name="bindVisualProperties">Action to bind visual properties.</param>
        /// <returns>
        /// The added binder agent.
        /// </returns>
        public static BinderAgent AddBinderAgent<T>(
            Action<Control, object, BindingManager> bindVisualProperties)
        {
            return AddBinderAgent<T>(new BinderAgent
            {
                BindVisualProperties = bindVisualProperties
            });
        }

        /// <summary>
        /// Adds a binder agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="bindVisualProperties">Action to bind visual properties.</param>
        /// <returns>
        /// The added binder agent.
        /// </returns>
        public static BinderAgent AddBinderAgent(Type controlType,
            Action<Control, object, BindingManager> bindVisualProperties)
        {
            return AddBinderAgent(controlType, new BinderAgent
            {
                BindVisualProperties = bindVisualProperties
            });
        }

        /// <summary>
        /// Adds a binder agent.
        /// </summary>
        /// <typeparam name="T">Type of the control.</typeparam>
        /// <param name="binderAgent">The binder agent.</param>
        /// <returns>
        /// The added binder agent.
        /// </returns>
        public static BinderAgent AddBinderAgent<T>(BinderAgent binderAgent)
        {
            return AddBinderAgent(typeof(T), binderAgent);
        }

        /// <summary>
        /// Adds a binder agent.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="binderAgent">The binder agent.</param>
        /// <returns>
        /// The added binder agent.
        /// </returns>
        public static BinderAgent AddBinderAgent(Type controlType, BinderAgent binderAgent)
        {
            return BinderAgent[controlType] = binderAgent;
        }
    }
}