using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MvvmFx.Windows.Properties;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Represents an expression that resolves to a property in an object.
    /// </summary>
    [DebuggerDisplay("Value={Value}, PropertyType={PropertyType}, FinalPart={_finalPart}, NumberOfParts={_parts.Count}")]
    public abstract class PropertyExpression
    {
        private readonly IList<PropertyExpressionPart> _parts;
        private readonly PropertyExpressionPart _finalPart;

        /// <summary>
        /// Constructs an instance of <c>PropertyExpression</c>.
        /// </summary>
        /// <param name="obj">
        /// The object against which the property expression is evaluated.
        /// </param>
        /// <param name="parts">
        /// The parts comprising the <c>PropertyExpression</c>.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        protected PropertyExpression(object obj, IEnumerable<PropertyExpressionPart> parts)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (parts == null)
                throw new ArgumentNullException("parts");
            /*foreach (object item in parts)
            {
                if (item == null)
                {
                    throw new ArgumentException("An item inside the enumeration was null.", "parts");
                }
            }*/
            if (parts.Cast<object>().Any(item => item == null))
            {
                throw new ArgumentException(Resources.AnItemWasNull, "parts");
            }

            _parts = new List<PropertyExpressionPart>(parts);

            if (_parts.Count == 0)
                throw new ArgumentException(Resources.OnePartRequired, "parts");

            _finalPart = _parts.Last();
            //whenever the final part's value changes, that means the value of the expression as a whole has changed
            _finalPart.ValueChanged += delegate
                {
                    OnValueChanged();
                };

            //assign the initial object in the potential chain of objects resolved by the expression parts
            _parts[0].Object = obj;
        }

        /// <summary>
        /// Occurs whenever the value of the property that this expression resolves to changes.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets the value of the property this expression resolves to.
        /// </summary>
        /// <remarks>
        /// This property will return <see cref="PropertyExpressionPart.Unresolved"/> if the expression does not yet successfully resolve to the property.
        /// </remarks>
        public object Value
        {
            get { return _finalPart.Value; }
            set
            {
                var currentValue = Value;

                if (currentValue == PropertyExpressionPart.Unresolved)
                {
                    //the expression part hasn't resolved yet, so no point trying to set the value
                    return;
                }

                if (!Equals(currentValue, value))
                {
                    _finalPart.Value = value;
                }
            }
        }

        /// <summary>
        /// Gets the normalized value of this <c>PropertyExpression</c>.
        /// </summary>
        /// <remarks>
        /// This property returns the normalized value of this <c>PropertyExpression</c>, which will be equivalent to <see cref="Value"/>
        /// unless <see cref="Value"/> returns <see cref="PropertyExpressionPart.Unresolved"/>, in which case this property will return
        /// <see langword="null"/>.
        /// </remarks>
        public object NormalizedValue
        {
            get
            {
                var value = Value;

                if (value == PropertyExpressionPart.Unresolved)
                {
                    return null;
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the type of the property that this expression resolves to.
        /// </summary>
        public Type PropertyType
        {
            get { return _finalPart.PropertyType; }
        }

        /// <summary>
        /// Gets the name of the property that this expression resolves to.
        /// </summary>
        public string PropertyName
        {
            get { return _finalPart.PropertyName; }
        }

        /// <summary>
        /// Raises the <see cref="ValueChanged"/> event.
        /// </summary>
        protected virtual void OnValueChanged()
        {
            //thread safe
            EventHandler<EventArgs> handler;
            lock (this)
            {
                handler = ValueChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
