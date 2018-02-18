using System;
using System.Globalization;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// A base class for all bindings that have a single source.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class extends <see cref="BindingBase"/> for bindings that have a single source. The source object is exposed via the
    /// <see cref="SourceObject"/> property, while the <see cref="SourcePropertyExpression"/> provides access to the
    /// <see cref="PropertyExpression"/> that resolves to the source property.
    /// </para>
    /// <para>
    /// Conversions between the target and source properties can be customized by assigned an implementation of
    /// <see cref="IValueConverter"/> to the <see cref="Converter"/> property. Any object can be assigned to the
    /// <see cref="ConverterParameter"/> property, and that object will be passed to the converter during conversions.
    /// </para>
    /// </remarks>
    public abstract class SingleSourceBinding : BindingBase
    {
        private readonly WeakReference _sourceObject;
        private PropertyExpression _sourcePropertyExpression;
        private IValueConverter _converter;
        private object _converterParameter;
        private CultureInfo _converterCulture;
        private bool _changeLatch;

        /// <summary>
        /// Constructs an instance of <c>SingleSourceBinding</c>.
        /// </summary>
        protected SingleSourceBinding()
        {
            _sourceObject = new WeakReference(null);
        }

        /// <summary>
        /// Gets or sets the source object for this binding.
        /// </summary>
        public object SourceObject
        {
            get { return _sourceObject.Target; }
            set
            {
                VerifyNotActivated();
                _sourceObject.Target = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="PropertyExpression"/> that resolves to the bound property in the <see cref="SourceObject"/>.
        /// </summary>
        /// <value>
        /// The <see cref="PropertyExpression"/>, or <see langword="null"/> if it has not yet been determined.
        /// </value>
        public PropertyExpression SourcePropertyExpression
        {
            get { return _sourcePropertyExpression; }
            protected set { _sourcePropertyExpression = value; }
        }

        /// <summary>
        /// Gets or sets the converter to be used by this binding.
        /// </summary>
        public IValueConverter Converter
        {
            get { return _converter; }
            set
            {
                VerifyNotActivated();
                _converter = value;
            }
        }

        /// <summary>
        /// Gets or sets an object to be passed as a parameter to the converter applied to this binding.
        /// </summary>
        public object ConverterParameter
        {
            get { return _converterParameter; }
            set
            {
                VerifyNotActivated();
                _converterParameter = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CultureInfo"/> to be passed to the converter applied to this binding.
        /// </summary>
        /// <value>
        /// The <see cref="CultureInfo"/>, or <see langword="null"/> if it has not yet been determined.
        /// </value>
        public CultureInfo ConverterCulture
        {
            get { return _converterCulture; }
            set
            {
                VerifyNotActivated();
                _converterCulture = value;
            }
        }

        /// <summary>
        /// Attempts to create the property expressions for this <c>SingleSourceBinding</c>.
        /// </summary>
        protected override void OnActivated()
        {
            base.OnActivated();
            OnActivatedCore();
        }

        /// <summary>
        /// Destroys any property expressions created for this <c>SingleSourceBinding</c>.
        /// </summary>
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            OnDeactivatedCore();
        }

        /// <summary>
        /// Attempts to create the source <see cref="PropertyExpression"/> for this <c>SingleSourceBinding</c>.
        /// </summary>
        /// <returns>
        /// A <see cref="PropertyExpression"/>, or <see langword="null"/> if no expression could be created.
        /// </returns>
        protected abstract PropertyExpression AttemptCreateSourcePropertyExpression();

        /// <summary>
        /// Applies changes in the target property to the source property of this <c>SingleSourceBinding</c>.
        /// </summary>
        protected override void OnTargetPropertyExpressionValueChanged()
        {
            base.OnTargetPropertyExpressionValueChanged();
            PushTargetToSource();
        }

        private void OnActivatedCore()
        {
            //clean up any old binding expressions
            OnDeactivatedCore();

            SourcePropertyExpression = AttemptCreateSourcePropertyExpression();

            if (SourcePropertyExpression != null && (Mode == BindingMode.TwoWay || Mode == BindingMode.OneWayToTarget))
            {
                //listen for changes in the source
                SourcePropertyExpression.ValueChanged += SourcePropertyExpressionValueChanged;
                //perform initial push from source to target
                PushSourceToTarget();
            }
        }

        private void OnDeactivatedCore()
        {
            if (SourcePropertyExpression != null)
            {
                SourcePropertyExpression.ValueChanged -= SourcePropertyExpressionValueChanged;
                SourcePropertyExpression = null;
            }
        }

        private void SourcePropertyExpressionValueChanged(object sender, EventArgs e)
        {
            PushSourceToTarget();
        }

        private void PushSourceToTarget()
        {
            if (Container.SynchronizationContext != null)
            {
                Container.SynchronizationContext.Send(PushSourceToTargetCore, null);
            }
            else
            {
                PushSourceToTargetCore(null);
            }
        }

        private void PushSourceToTargetCore(object state)
        {
            if (_changeLatch)
            {
                return;
            }

            //copy changes from source to target
            var newValue = SourcePropertyExpression.NormalizedValue;

            if (_converter != null)
            {
                newValue = _converter.Convert(newValue, TargetPropertyExpression.PropertyType, _converterParameter, _converterCulture);
            }

            _changeLatch = true;

            try
            {
                if (TargetPropertyExpression != null)
                {
                    TargetPropertyExpression.Value = newValue;
                }
            }
            finally
            {
                _changeLatch = false;
            }
        }

        private void PushTargetToSource()
        {
            if (Container.SynchronizationContext != null)
            {
                Container.SynchronizationContext.Send(PushTargetToSourceCore, null);
            }
            else
            {
                PushTargetToSourceCore(null);
            }
        }

        private void PushTargetToSourceCore(object state)
        {
            if (_changeLatch)
            {
                return;
            }

            //copy changes from target to source
            var newValue = TargetPropertyExpression.NormalizedValue;

            if (_converter != null)
            {
                newValue = _converter.ConvertBack(newValue, SourcePropertyExpression.PropertyType, _converterParameter, _converterCulture);
            }

            _changeLatch = true;

            try
            {
                if (SourcePropertyExpression != null)
                {
                    SourcePropertyExpression.Value = newValue;
                }
            }
            finally
            {
                _changeLatch = false;
            }
        }
    }
}
