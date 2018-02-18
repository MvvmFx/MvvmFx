using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Provides extension methods for instigating the fluent interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class provides extension methods to the <see cref="BindingManager"/> type to support a fluent interface for MvvmFx. This enables bindings to be added
    /// to a <see cref="BindingManager"/> with a more natural, simpler API.
    /// </para>
    /// </remarks>
    public static class BindingManagerExtensions
    {
        /// <summary>
        /// Binds to the specified target object with a given path.
        /// </summary>
        /// <param name="bindingManager">
        /// The <see cref="BindingManager"/> to which the <see cref="Binding"/> will be added.
        /// </param>
        /// <param name="targetObject">
        /// The target object.
        /// </param>
        /// <param name="targetPath">
        /// The path within the target object to bind to.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        public static IPathBasedSourceSelection Bind(this BindingManager bindingManager, object targetObject, string targetPath)
        {
            if (bindingManager == null)
                throw new ArgumentNullException("bindingManager");
            if (targetObject == null)
                throw new ArgumentNullException("targetObject");
            if (targetPath == null)
                throw new ArgumentNullException("targetPath");
            return new SingleSourcePathBased(bindingManager, targetObject, targetPath);
        }

        /// <summary>
        /// Binds to the specified target object with a given expression.
        /// </summary>
        /// <typeparam name="TTarget">
        /// The type of the target object.
        /// </typeparam>
        /// <param name="bindingManager">
        /// The <see cref="BindingManager"/> to which the <see cref="TypedBinding{TTarget, TSource}"/> will be added.
        /// </param>
        /// <param name="targetObject">
        /// The target object.
        /// </param>
        /// <param name="targetExpression">
        /// The expression that resolves the bound property within the target object.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public static ILambdaBasedSourceSelection Bind<TTarget>(
            this BindingManager bindingManager, TTarget targetObject, Expression<Func<TTarget, object>> targetExpression)
        {
            if (bindingManager == null)
                throw new ArgumentNullException("bindingManager");
            Assert.GenericArgumentNotNull(targetObject, "targetObject");
            if (targetExpression == null)
                throw new ArgumentNullException("targetExpression");
            return new SingleSourceLambdaBasedSourceNotYetResolved<TTarget>(
                bindingManager, targetObject, targetExpression);
        }

        /// <summary>
        /// Multi-binds the specified target object with a given path.
        /// </summary>
        /// <param name="bindingManager">
        /// The <see cref="BindingManager"/> to which the <see cref="MultiBinding"/> will be added.
        /// </param>
        /// <param name="targetObject">
        /// The target object.
        /// </param>
        /// <param name="targetPath">
        /// The path within the target object to bind to.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        public static IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter> MultiBind(
            this BindingManager bindingManager, object targetObject, string targetPath)
        {
            if (bindingManager == null)
                throw new ArgumentNullException("bindingManager");
            if (targetObject == null)
                throw new ArgumentNullException("targetObject");
            if (targetPath == null)
                throw new ArgumentNullException("targetPath");
            return new MultiSourcePathBased(bindingManager, targetObject, targetPath);
        }

        /// <summary>
        /// Multi-binds the specified target object with a given expression.
        /// </summary>
        /// <typeparam name="TTarget">
        /// The type of the target object.
        /// </typeparam>
        /// <param name="bindingManager">
        /// The <see cref="BindingManager"/> to which the <see cref="TypedMultiBinding{TTarget}"/> will be added.
        /// </param>
        /// <param name="targetObject">
        /// The target object.
        /// </param>
        /// <param name="targetExpression">
        /// The expression that resolves the bound property of the target object.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006", Justification = "The parameter is easily provided by virtue of lambda syntax.")]
        public static IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter> MultiBind<TTarget>(
            this BindingManager bindingManager, TTarget targetObject, Expression<Func<TTarget, object>> targetExpression)
        {
            if (bindingManager == null)
                throw new ArgumentNullException("bindingManager");
            Assert.GenericArgumentNotNull(targetObject, "targetObject");
            if (targetExpression == null)
                throw new ArgumentNullException("targetExpression");
            return new MultiSourceLambdaBased<TTarget>(bindingManager, targetObject, targetExpression);
        }

        //types below implement the various interfaces that comprise the fluent interface
        private sealed class SingleSourcePathBased : IPathBasedSourceSelection, ISingleSourceBindingOptions
        {
            private readonly BindingManager _bindingManager;
            private readonly Binding _binding;

            public SingleSourcePathBased(BindingManager bindingManager, object targetObject, string targetPath)
            {
                _bindingManager = bindingManager;
                _binding = new Binding();
                _binding.TargetObject = targetObject;
                _binding.TargetPath = targetPath;
            }

            ISingleSourceBindingOptions IPathBasedSourceSelection.To(object sourceObject, string sourcePath)
            {
                if (sourceObject == null)
                    throw new ArgumentNullException("sourceObject");
                if (sourcePath == null)
                    throw new ArgumentNullException("sourcePath");
                _binding.SourceObject = sourceObject;
                _binding.SourcePath = sourcePath;
                return this;
            }

            ISingleSourceBindingOptions IConverterSelection<ISingleSourceBindingOptions, IValueConverter>.WithConverter(
                IValueConverter converter)
            {
                _binding.Converter = converter;
                return this;
            }

            ISingleSourceBindingOptions IConverterSelection<ISingleSourceBindingOptions, IValueConverter>.WithConverter(
                IValueConverter converter, object converterParameter)
            {
                _binding.Converter = converter;
                _binding.ConverterParameter = converterParameter;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.TwoWay()
            {
                _binding.Mode = BindingMode.TwoWay;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.OneWayToSource()
            {
                _binding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.OneWayToTarget()
            {
                _binding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            void IActivation.Activate()
            {
                _bindingManager.Bindings.Add(_binding);
            }
        }

        private sealed class SingleSourceLambdaBasedSourceNotYetResolved<TTarget> : ILambdaBasedSourceSelection
        {
            private readonly BindingManager _bindingManager;
            private readonly TTarget _targetObject;
            private readonly Expression<Func<TTarget, object>> _targetExpression;

            public SingleSourceLambdaBasedSourceNotYetResolved(
                BindingManager bindingManager, TTarget targetObject, Expression<Func<TTarget, object>> targetExpression)
            {
                _bindingManager = bindingManager;
                _targetObject = targetObject;
                _targetExpression = targetExpression;
            }

            ISingleSourceBindingOptions ILambdaBasedSourceSelection.To<TSource>(
                TSource sourceObject, Expression<Func<TSource, object>> sourceExpression)
            {
                return new SingleSourceLambdaBased<TTarget, TSource>(
                    _bindingManager, _targetObject, _targetExpression, sourceObject, sourceExpression);
            }
        }

        private sealed class SingleSourceLambdaBased<TTarget, TSource> : ISingleSourceBindingOptions
        {
            private readonly BindingManager _bindingManager;
            private readonly TypedBinding<TTarget, TSource> _binding;

            public SingleSourceLambdaBased(BindingManager bindingManager, TTarget targetObject,
                                           Expression<Func<TTarget, object>> targetExpression, TSource sourceObject,
                                           Expression<Func<TSource, object>> sourceExpression)
            {
                _bindingManager = bindingManager;
                _binding = new TypedBinding<TTarget, TSource>(targetObject, targetExpression, sourceObject,
                                                              sourceExpression);
            }

            ISingleSourceBindingOptions IConverterSelection<ISingleSourceBindingOptions, IValueConverter>.WithConverter(
                IValueConverter converter)
            {
                _binding.Converter = converter;
                return this;
            }

            ISingleSourceBindingOptions IConverterSelection<ISingleSourceBindingOptions, IValueConverter>.WithConverter(
                IValueConverter converter, object converterParameter)
            {
                _binding.Converter = converter;
                _binding.ConverterParameter = converterParameter;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.TwoWay()
            {
                _binding.Mode = BindingMode.TwoWay;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.OneWayToSource()
            {
                _binding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            ISingleSourceBindingOptions IModeSelection<ISingleSourceBindingOptions>.OneWayToTarget()
            {
                _binding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            void IActivation.Activate()
            {
                _bindingManager.Bindings.Add(_binding);
            }
        }

        private sealed class MultiSourcePathBased :
            IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>, IMultiSourceBindingOptions,
            ISubsequentSourceBindingOptions
        {
            private readonly BindingManager _bindingManager;
            private readonly MultiBinding _binding;
            private SingleSourceBinding _currentChildBinding;

            public MultiSourcePathBased(BindingManager bindingManager, object targetObject, string targetPath)
            {
                _bindingManager = bindingManager;
                _binding = new MultiBinding(targetObject, targetPath);
            }

            IMultiSourceBindingOptions IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>.
                WithConverter(IMultiValueConverter converter)
            {
                _binding.Converter = converter;
                return this;
            }

            IMultiSourceBindingOptions IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>.
                WithConverter(IMultiValueConverter converter, object converterParameter)
            {
                _binding.Converter = converter;
                _binding.ConverterParameter = converterParameter;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.TwoWay()
            {
                _binding.Mode = BindingMode.TwoWay;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.OneWayToSource()
            {
                _binding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.OneWayToTarget()
            {
                _binding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            ISubsequentSourceBindingOptions IMultiSourceBindingOptions.To(object sourceObject, string sourcePath)
            {
                _currentChildBinding = new Binding {SourceObject = sourceObject, SourcePath = sourcePath};
                return this;
            }

            ISubsequentSourceBindingOptions IMultiSourceBindingOptions.To<TSource>(
                TSource sourceObject, Expression<Func<TSource, object>> sourceExpression)
            {
                _currentChildBinding = new TypedBinding<object, TSource> {SourceObject = sourceObject, SourceExpression = sourceExpression};
                return this;
            }

            ISubsequentSourceBindingOptions ISubsequentSourceBindingOptions.AndTo(object sourceObject, string sourcePath)
            {
                _binding.Sources.Add(_currentChildBinding);
                return (this as IMultiSourceBindingOptions).To(sourceObject, sourcePath);
            }

            ISubsequentSourceBindingOptions ISubsequentSourceBindingOptions.AndTo<TSource>(
                TSource sourceObject, Expression <Func<TSource, object>> sourceExpression)
            {
                _binding.Sources.Add(_currentChildBinding);
                return (this as IMultiSourceBindingOptions).To(sourceObject, sourceExpression);
            }

            ISubsequentSourceBindingOptions IConverterSelection<ISubsequentSourceBindingOptions, IValueConverter>.
                WithConverter(IValueConverter converter)
            {
                _currentChildBinding.Converter = converter;
                return this;
            }

            ISubsequentSourceBindingOptions IConverterSelection<ISubsequentSourceBindingOptions, IValueConverter>.
                WithConverter(IValueConverter converter, object converterParameter)
            {
                _currentChildBinding.Converter = converter;
                _currentChildBinding.ConverterParameter = converterParameter;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.TwoWay()
            {
                _currentChildBinding.Mode = BindingMode.TwoWay;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.OneWayToSource()
            {
                _currentChildBinding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.OneWayToTarget()
            {
                _currentChildBinding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            void IActivation.Activate()
            {
                _binding.Sources.Add(_currentChildBinding);
                _bindingManager.Bindings.Add(_binding);
            }
        }

        private sealed class MultiSourceLambdaBased<TTarget> :
            IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>, IMultiSourceBindingOptions,
            ISubsequentSourceBindingOptions
        {
            private readonly BindingManager _bindingManager;
            private readonly TypedMultiBinding<TTarget> _binding;
            private SingleSourceBinding _currentChildBinding;

            public MultiSourceLambdaBased(BindingManager bindingManager, TTarget targetObject,
                                          Expression<Func<TTarget, object>> targetExpression)
            {
                _bindingManager = bindingManager;
                _binding = new TypedMultiBinding<TTarget>(targetObject, targetExpression);
            }

            IMultiSourceBindingOptions IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>.
                WithConverter(IMultiValueConverter converter)
            {
                _binding.Converter = converter;
                return this;
            }

            IMultiSourceBindingOptions IConverterSelection<IMultiSourceBindingOptions, IMultiValueConverter>.
                WithConverter(IMultiValueConverter converter, object converterParameter)
            {
                _binding.Converter = converter;
                _binding.ConverterParameter = converterParameter;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.TwoWay()
            {
                _binding.Mode = BindingMode.TwoWay;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.OneWayToSource()
            {
                _binding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            IMultiSourceBindingOptions IModeSelection<IMultiSourceBindingOptions>.OneWayToTarget()
            {
                _binding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            ISubsequentSourceBindingOptions IMultiSourceBindingOptions.To(object sourceObject, string sourcePath)
            {
                _currentChildBinding = new Binding {SourceObject = sourceObject, SourcePath = sourcePath};
                return this;
            }

            ISubsequentSourceBindingOptions IMultiSourceBindingOptions.To<TSource>(
                TSource sourceObject, Expression<Func<TSource, object>> sourceExpression)
            {
                _currentChildBinding = new TypedBinding<object, TSource>
                    {SourceObject = sourceObject, SourceExpression = sourceExpression};
                return this;
            }

            ISubsequentSourceBindingOptions ISubsequentSourceBindingOptions.AndTo(object sourceObject, string sourcePath)
            {
                _binding.Sources.Add(_currentChildBinding);
                return (this as IMultiSourceBindingOptions).To(sourceObject, sourcePath);
            }

            ISubsequentSourceBindingOptions ISubsequentSourceBindingOptions.AndTo<TSource>(
                TSource sourceObject, Expression <Func<TSource, object>> sourceExpression)
            {
                _binding.Sources.Add(_currentChildBinding);
                return (this as IMultiSourceBindingOptions).To(sourceObject, sourceExpression);
            }

            ISubsequentSourceBindingOptions IConverterSelection<ISubsequentSourceBindingOptions, IValueConverter>.
                WithConverter(IValueConverter converter)
            {
                _currentChildBinding.Converter = converter;
                return this;
            }

            ISubsequentSourceBindingOptions IConverterSelection<ISubsequentSourceBindingOptions, IValueConverter>.
                WithConverter(IValueConverter converter, object converterParameter)
            {
                _currentChildBinding.Converter = converter;
                _currentChildBinding.ConverterParameter = converterParameter;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.TwoWay()
            {
                _currentChildBinding.Mode = BindingMode.TwoWay;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.OneWayToSource()
            {
                _currentChildBinding.Mode = BindingMode.OneWayToSource;
                return this;
            }

            ISubsequentSourceBindingOptions IModeSelection<ISubsequentSourceBindingOptions>.OneWayToTarget()
            {
                _currentChildBinding.Mode = BindingMode.OneWayToTarget;
                return this;
            }

            void IActivation.Activate()
            {
                _binding.Sources.Add(_currentChildBinding);
                _bindingManager.Bindings.Add(_binding);
            }
        }
    }
}
