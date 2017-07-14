namespace MvvmFx.CaliburnMicro
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
#if WEBGUI
    using Gizmox.WebGUI.Forms;
#else
    using System.Windows.Forms;
#endif

    /// <summary>
    /// Used to configure the conventions used by the framework to apply bindings and create actions.
    /// </summary>
    public static class ConventionManager
    {
        static ConventionManager()
        {
            AddElementConvention<TextBoxBase>("Text", null, "TextChanged");
            AddElementConvention<IActivate>(string.Empty, null, "Activated");
            AddElementConvention<Label>("Text", null, "TextChanged");
            AddElementConvention<CheckBox>("Checked", null, "Click");
            AddElementConvention<ContentContainer>("Content", null, "ContentChanged");
            AddElementConvention<ButtonBase>("Name", null, "Click");
            AddElementConvention<ToolBarButton>("Name", null, "Click");
            AddElementConvention<ListControl>("DataSource", null, null);
            AddElementConvention<TreeView>("DataSource", null, null);
            AddElementConvention<GroupBox>("Name", null, null);
            AddElementConvention<ToolStripItemProxy>("Name", null, "Click")
                .CreateAction = (element, methodName, parameters) =>
                {
                    ((ToolStripItemProxy) element).WireEvents();
                    return new ActionMessage(element, "Click", methodName, parameters);
                };
            AddElementConvention<TabControl>("SelectedTab", null, null)
                .ApplyBinding = (viewModel, path, property, control, convention) => { return true; };
        }

        private static readonly Dictionary<Type, ElementConvention> ControlConventions =
            new Dictionary<Type, ElementConvention>();

        /// <summary>
        /// Gets an element convention for the provided element type.
        /// </summary>
        /// <param name="controlType">The type of control to locate the convention for.</param>
        /// <returns>The convention if found, null otherwise.</returns>
        /// <remarks>Searches the class hierarchy for conventions.</remarks>
        public static ElementConvention GetElementConvention(Type controlType)
        {
            if (controlType == null)
                return null;

            ElementConvention propertyConvention;
            ControlConventions.TryGetValue(controlType, out propertyConvention);
            return propertyConvention ?? GetElementConvention(controlType.BaseType);
        }

        /// <summary>
        /// Adds an element convention.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        /// <param name="bindingPropertyName">The default property for binding conventions.</param>
        /// <param name="parameterProperty">The default property for action parameters.</param>
        /// <param name="eventName">The default event to trigger actions.</param>
        /// <returns>The newly added element convention.</returns>
        public static ElementConvention AddElementConvention<T>(string bindingPropertyName, string parameterProperty,
            string eventName)
        {
            return AddElementConvention(new ElementConvention
            {
                ElementType = typeof (T),
                BindingPropertyName = bindingPropertyName,
                ParameterProperty = parameterProperty,
                EventName = eventName,
                CreateAction =
                    (element, methodName, parameters) => new ActionMessage(element, eventName, methodName, parameters)
            });
        }

        /// <summary>
        /// Adds an element convention.
        /// </summary>
        /// <param name="convention">The <see cref="ElementConvention"/> to add.</param>
        /// <returns>The added element convention.</returns>
        public static ElementConvention AddElementConvention(ElementConvention convention)
        {
            return ControlConventions[convention.ElementType] = convention;
        }

        /// <summary>
        /// Creates a binding and sets it on the element, applying the appropriate conventions.
        /// </summary>
        /// <remarks>The binding will be set as explained below<br/>
        /// Binding(convention.BindingPropertyName, viewModel, path)<br/>
        /// Binding(string propertyName, object dataSource, string dataMember)</remarks>
        public static Func<object, string, PropertyInfo, Control, ElementConvention, bool> SetBinding =
            (viewModel, path, property, control, convention) =>
            {
                if (HasBinding(control, convention.BindingPropertyName))
                    return false;

                /*if (control is ContentContainer)
                    {
                        var vm = property.GetValue(viewModel, null);
                        ViewModelBinder.Bind(vm, ViewLocator.LocateForModel(vm, null, null), null);
                    }*/

                var binding = new Binding(convention.BindingPropertyName, viewModel, path);

                var prop = convention.ElementType.GetProperty(convention.BindingPropertyName);
                ApplyBindingMode(binding, prop);

                //TODO: Add auto validation hookup

                control.DataBindings.Add(binding);

                return true;
            };

        /// <summary>
        /// Applies the appropriate binding mode to the binding.
        /// </summary>
        public static Action<Binding, PropertyInfo> ApplyBindingMode = (binding, property) =>
        {
            var setMethod = property.GetSetMethod();
            binding.DataSourceUpdateMode =
                (property.CanWrite && setMethod != null && setMethod.IsPublic)
                    ? DataSourceUpdateMode.OnPropertyChanged
                    : DataSourceUpdateMode.Never;
        };

        /// <summary>
        /// Determines whether a particular property already has a binding on the provided control.
        /// </summary>
        /// <param name="control">The control to search the property binding.</param>
        /// <param name="property">The property to search fo bindings.</param>
        /// <returns>
        /// 	<c>true</c> if the specified property already has a binding on the provided control; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasBinding(Control control, string property)
        {
            foreach (Binding binding in control.DataBindings)
            {
                if (binding.PropertyName == property)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether a particular dependency property already has a binding on the provided control.
        /// </summary>
        /// <param name="control">The control to search the property binding.</param>
        /// <param name="property">The dependency property to search fo bindings.</param>
        /// <returns>
        /// 	<c>true</c> if the specified dependency property already has a binding on the provided control; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasBinding(Control control, DependencyProperty property)
        {
            return HasBinding(control, property.Name);
        }

        /// <summary>
        /// Creates a binding and sets it on the element, guarding against pre-existing bindings.
        /// </summary>
        /// <param name="viewModel">The view model (dataSource).</param>
        /// <param name="path">The dataMember.</param>
        /// <param name="property">The binding property.</param>
        /// <param name="element">The control element.</param>
        /// <param name="convention">The element convention.</param>
        /// <returns>
        /// 	<c>true</c> if the specified property already has a binding on the provided control; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>The binding will be set as explained below<br/>
        /// Binding(convention.BindingPropertyName, viewModel, path)<br/>
        /// Binding(string propertyName, object dataSource, string dataMember)</remarks>
        public static bool SetBindingWithoutBindingOverwrite(object viewModel, string path, PropertyInfo property,
            Control element, ElementConvention convention)
        {
            if (HasBinding(element, path))
            {
                return false;
            }

            SetBinding(viewModel, path, property, element, convention);
            return true;
        }
    }
}