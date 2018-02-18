using System;
using MvvmFx.Bindings.Data;

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Represents a parameter of an <see cref="ActionMessage"/>.
    /// </summary>
    public class Parameter
    {
        private object _value;
        private WeakReference _owner;
        private BindingManager _bindingManager;

        /// <summary>
        /// Gets the binding manager.
        /// </summary>
        /// <value>
        /// The binding manager.
        /// </value>
        public BindingManager BindingManager
        {
            get
            {
                if (_bindingManager == null)
                    _bindingManager = new BindingManager();

                return _bindingManager;
            }
        }

        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        /// <value>
        /// The parameter value.
        /// </value>
        /// <remarks>A <c>null</c> value is allowed.</remarks>
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (Owner != null)
                    Owner.UpdateAvailability();
            }
        }

        /// <summary>
        /// Gets or sets the MustEvaluate flag.
        /// </summary>
        /// <value>
        /// The MustEvaluate flag.
        /// </value>
        /// <remarks>Must be set for "$" parammeters.</remarks>
        public bool MustEvaluate { get; set; }

        private ActionMessage Owner
        {
            get { return _owner == null ? null : _owner.Target as ActionMessage; }
            set { _owner = new WeakReference(value); }
        }

        /// <summary>
        /// Creates a new parameter.
        /// </summary>
        public Parameter()
        {
        }

        /// <summary>
        /// Creates a new parameter.
        /// </summary>
        public Parameter(object value)
            : this()
        {
            Value = value;
        }

        /// <summary>
        /// Makes the parameter aware of the <see cref="ActionMessage"/> that it's attached to.
        /// </summary>
        /// <param name="owner">The action message.</param>
        internal void MakeAwareOf(ActionMessage owner)
        {
            Owner = owner;
        }
    }
}