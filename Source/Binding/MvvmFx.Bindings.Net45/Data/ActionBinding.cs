using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Connects events on a target property to an action using a lambda expression to resolve the target property.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public class ActionBinding<TTarget> : BindingBase
    {
        private Expression<Func<TTarget, object>> _targetExpression;
        private Action<object> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionBinding&lt;TTarget&gt;"/> class.
        /// </summary>
        public ActionBinding()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionBinding&lt;TTarget&gt;"/> class.
        /// </summary>
        /// <param name="targetObject">The target object.</param>
        /// <param name="targetExpression">The target expression.</param>
        /// <param name="action">The action.</param>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public ActionBinding(TTarget targetObject, Expression<Func<TTarget, object>> targetExpression, Action<object> action)
        {
            TargetObject = targetObject;
            _targetExpression = targetExpression;
            _action = action;
        }

        /// <summary>
        /// Gets or sets the target expression.
        /// </summary>
        /// <value>
        /// The target expression.
        /// </value>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public Expression<Func<TTarget, object>> TargetExpression
        {
            get { return _targetExpression; }
            set { _targetExpression = value; }
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public Action<object> Action
        {
            get { return _action; }
            set { _action = value; }
        }

        /// <summary>
        /// Attempts to create the target <see cref="PropertyExpression"/> for this binding.
        /// </summary>
        /// <returns>
        /// A <see cref="PropertyExpression"/>, or <see langword="null"/> if no expression could be created.
        /// </returns>
        protected override PropertyExpression AttemptCreateTargetPropertyExpression()
        {
            var targetObject = TargetObject;

            if (targetObject == null || _targetExpression == null)
            {
                return null;
            }

            return LambdaPropertyExpression.FromLambdaExpression(targetObject, _targetExpression, BindOnValidation);
        }

        /// <summary>
        /// Called when this <c>BindingBase</c> is activated.
        /// </summary>
        protected override void OnActivated()
        {
            base.OnActivated();
            TargetPropertyExpression.ValueChanged += TargetPropertyExpressionValueChanged;
        }

        private void TargetPropertyExpressionValueChanged(object sender, EventArgs e)
        {
            if (_action != null)
            {
                _action(TargetPropertyExpression.Value);
            }
        }
    }
}
