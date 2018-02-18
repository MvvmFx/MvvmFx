using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using MvvmFx.Bindings.Properties;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// A base class for all bindings that have multiple sources.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class extends <see cref="BindingBase"/> for bindings that have multiple sources. Each source is represented as an instance
    /// of <see cref="BindingBase"/> inside the <see cref="Sources"/> collection. Bindings added to this collection must have only their
    /// source information set, as the target is implicitly the <c>MultiSourceBinding</c>.
    /// </para>
    /// <para>
    /// Since there is no sensible default way to convert multiple sources into a single target and vice versa, every
    /// <c>MultiSourceBinding</c> requires a converter. To that end, the <see cref="Converter"/> parameter allows an implementation of
    /// <see cref="IMultiValueConverter"/> to be supplied. Any object can be assigned to the <see cref="ConverterParameter"/> property,
    /// and that object will be passed to the converter during conversions.
    /// </para>
    /// <para>
    /// The <c>MultiSourceBinding</c> class implements the <see cref="IBindingContainer"/> interface because it contains bindings in its
    /// <see cref="Sources"/> collection. Any binding added to the <see cref="Sources"/> collection will have the <c>MultiSourceBinding</c>
    /// as its container.
    /// </para>
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1702", Justification = "'Multi' and 'Source' are two words and the intention is to use them as such.")]
    public abstract class MultiSourceBinding : BindingBase, IBindingContainer
    {
        private readonly BindingBaseCollection _sources;
        private IMultiValueConverter _converter;
        private object _converterParameter;
        private CultureInfo _converterCulture;
        private bool _changeLatch;

        /// <summary>
        /// Constructs an instance of <c>MultiSourceBinding</c>.
        /// </summary>
        protected MultiSourceBinding()
        {
            _sources = new BindingBaseCollection(this);
        }

        /// <summary>
        /// Gets the collection of <see cref="SingleSourceBinding"/> objects comprising the source of this <c>MultiSourceBinding</c>.
        /// </summary>
        public ICollection<BindingBase> Sources
        {
            get { return _sources; }
        }

        /// <summary>
        /// Gets or sets the converter to be used by this binding.
        /// </summary>
        public IMultiValueConverter Converter
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
        /// Gets the <see cref="IBindingContainer"/> instance within which this <c>MultiSourceBinding</c> is activated.
        /// </summary>
        IBindingContainer IBindingContainer.Container
        {
            get { return Container; }
        }

        /// <summary>
        /// Gets all <see cref="BindingBase"/> instances activated within this <c>MultiSourceBinding</c>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033", Justification = "The functionality is exposed to base classes and consumers via the Sources collection.")]
        IEnumerable<BindingBase> IBindingContainer.Bindings
        {
            get { return _sources; }
        }

        /// <summary>
        /// Gets the <see cref="SynchronizationContext"/> being used by this <c>MultiSourceBinding</c>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033", Justification = "The functionality is exposed to base classes and consumers via the Container property.")]
        SynchronizationContext IBindingContainer.SynchronizationContext
        {
            get
            {
#if !WEBGUI && !WISEJ
                return Container == null ? null : Container.SynchronizationContext;
#else
                return null;
#endif
            }
        }

        /// <summary>
        /// Attempts to activate this <c>MultiSourceBinding</c>.
        /// </summary>
        protected override void OnActivated()
        {
            base.OnActivated();
            OnActivatedCore();
        }

        /// <summary>
        /// Deactivate this <c>MultiSourceBinding</c>.
        /// </summary>
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            OnDeactivatedCore();
        }

        private void OnActivatedCore()
        {
            //clean up any old binding expressions
            OnDeactivatedCore();

            if (_converter == null)
                throw new InvalidOperationException(Resources.ConverterIsRequired);

            if (TargetPropertyExpression != null)
            {
                foreach (var binding in _sources)
                {
                    binding.VerifyNotActivated(Resources.BindingAlreadyActivatedExceptionMessage);
                    binding.Activate(this, MultiSourceBindingPropertyExpression.FromMultiSourceBinding(this, BindOnValidation));

                    if (Mode == BindingMode.TwoWay || Mode == BindingMode.OneWayToTarget)
                    {
                        //listen for changes in the sources
                        binding.TargetPropertyExpression.ValueChanged += ChildBindingTargetValueChanged;
                    }
                }

                if (Mode == BindingMode.TwoWay || Mode == BindingMode.OneWayToTarget)
                {
                    //perform initial push from sources to target
                    PushSourcesToTarget();
                }
            }
        }

        /// <summary>
        /// Applies changes in the target property to the source property of this <c>MultiSourceBinding</c>.
        /// </summary>
        protected override void OnTargetPropertyExpressionValueChanged()
        {
            base.OnTargetPropertyExpressionValueChanged();

            Debug.Assert(_converter != null, "Converter should not be null at this point.");
            PushTargetToSources();
        }

        private void OnDeactivatedCore()
        {
            foreach (var binding in _sources)
            {
                if (binding.TargetPropertyExpression == null)
                {
                    continue;
                }

                binding.TargetPropertyExpression.ValueChanged -= ChildBindingTargetValueChanged;
            }
        }

        private void ChildBindingTargetValueChanged(object sender, EventArgs e)
        {
            PushSourcesToTarget();
        }

        private void PushSourcesToTarget()
        {
            if (Container.SynchronizationContext != null)
            {
                Container.SynchronizationContext.Send(PushSourcesToTargetCore, null);
            }
            else
            {
                PushSourcesToTargetCore(null);
            }
        }

        private void PushSourcesToTargetCore(object state)
        {
            if (_changeLatch)
            {
                return;
            }

            //if the target value of one of the child bindings changes, that means we need to push that value to the target of the MultiSourceBinding
            var values = new object[_sources.Count];

            for (var i = 0; i < values.Length; ++i)
            {
                values[i] = _sources[i].TargetPropertyExpression.NormalizedValue;
            }

            _changeLatch = true;

            try
            {
                TargetPropertyExpression.Value = _converter.Convert(
                    values, TargetPropertyExpression.PropertyType, _converterParameter, _converterCulture);
            }
            finally
            {
                _changeLatch = false;
            }
        }

        private void PushTargetToSources()
        {
            if (Container.SynchronizationContext != null)
            {
                Container.SynchronizationContext.Send(PushTargetToSourcesCore, null);
            }
            else
            {
                PushTargetToSourcesCore(null);
            }
        }

        private void PushTargetToSourcesCore(object state)
        {
            if (_changeLatch)
            {
                return;
            }

            //copy changes from target to sources
            var types = new Type[_sources.Count];

            for (var i = 0; i < types.Length; ++i)
            {
                types[i] = _sources[i].TargetPropertyExpression.PropertyType;
            }

            var values = _converter.ConvertBack(TargetPropertyExpression.NormalizedValue, types, _converterParameter, _converterCulture);
            if (values == null)
                throw new InvalidOperationException(Resources.ConverterMustReturnValue);
            if (values.Length != types.Length)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.ExpectedMoreOrLessValues, values.Length, types.Length));

            _changeLatch = true;

            try
            {
                for (var i = 0; i < _sources.Count; ++i)
                {
                    Debug.Assert(_sources[i].TargetPropertyExpression is MultiSourceBindingPropertyExpression,
                                 "TargetPropertyExpression in a source of a MultiSourceBinding must be a MultiSourceBindingPropertyExpression.");
                    (_sources[i].TargetPropertyExpression as MultiSourceBindingPropertyExpression).
                        MultiSourceBindingPropertyExpressionPart.Value = values[i];
                }
            }
            finally
            {
                _changeLatch = false;
            }
        }

        private sealed class BindingBaseCollection : Collection<BindingBase>
        {
            private readonly MultiSourceBinding _multiSourceBinding;

            public BindingBaseCollection(MultiSourceBinding multiSourceBinding)
            {
                Debug.Assert(multiSourceBinding != null);
                _multiSourceBinding = multiSourceBinding;
            }

            protected override void InsertItem(int index, BindingBase item)
            {
                _multiSourceBinding.VerifyNotActivated();
                base.InsertItem(index, item);
            }

            protected override void SetItem(int index, BindingBase item)
            {
                _multiSourceBinding.VerifyNotActivated();
                base.SetItem(index, item);
            }

            protected override void RemoveItem(int index)
            {
                _multiSourceBinding.VerifyNotActivated();
                base.RemoveItem(index);
            }

            protected override void ClearItems()
            {
                _multiSourceBinding.VerifyNotActivated();
                base.ClearItems();
            }
        }

        private sealed class MultiSourceBindingPropertyExpression : PropertyExpression
        {
            private readonly MultiSourceBindingPropertyExpressionPart _multiSourceBindingPropertyExpressionPart;

            private MultiSourceBindingPropertyExpression(
                object obj, MultiSourceBindingPropertyExpressionPart multiSourceBindingPropertyExpressionPart)
                : base(obj, new PropertyExpressionPart[] {multiSourceBindingPropertyExpressionPart})
            {
                Debug.Assert(multiSourceBindingPropertyExpressionPart != null);
                _multiSourceBindingPropertyExpressionPart = multiSourceBindingPropertyExpressionPart;
            }

            public MultiSourceBindingPropertyExpressionPart MultiSourceBindingPropertyExpressionPart
            {
                get { return _multiSourceBindingPropertyExpressionPart; }
            }

            public static MultiSourceBindingPropertyExpression FromMultiSourceBinding(MultiSourceBinding multiSourceBinding, bool bindOnValidation)
            {
                Debug.Assert(multiSourceBinding != null);
                return new MultiSourceBindingPropertyExpression(
                    multiSourceBinding, new MultiSourceBindingPropertyExpressionPart(multiSourceBinding, bindOnValidation));
            }
        }

        /// <summary>
        /// An implementation of PropertyExpressionPart for multi source.
        /// </summary>
        private sealed class MultiSourceBindingPropertyExpressionPart : PropertyExpressionPart
        {
            private readonly string _propertyName;
            private object _value;

            public MultiSourceBindingPropertyExpressionPart(MultiSourceBinding multiSourceBinding, bool bindOnValidation)
                : base(null, bindOnValidation)
            {
                Debug.Assert(multiSourceBinding != null);
                Debug.Assert(multiSourceBinding.TargetPropertyExpression != null);
                Debug.Assert(multiSourceBinding.TargetPropertyExpression.PropertyName != null);
                _propertyName = "(" + multiSourceBinding.TargetPropertyExpression.PropertyName + ")";
            }

            public override string PropertyName
            {
                get { return _propertyName; }
            }

            public override Type PropertyType
            {
                get { return _value == null ? typeof (object) : _value.GetType(); }
            }

            protected override object GetValueCore()
            {
                return _value;
            }

            protected override void SetValueCore(object value)
            {
                if (!Equals(_value, value))
                {
                    _value = value;
                    //notify the MultiSourceBinding that the value of the child binding has changed
                    OnValueChanged();
                }
            }
        }
    }
}
