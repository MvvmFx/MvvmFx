using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Connects a target property to multiple source properties using a simple path-formatted string to resolve the bound property on
    /// the target object.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of the <c>MultiBinding</c> class can be used to connect together multiple source properties to a single target property.
    /// The target property is specified via a string, so there is no compile-time check to ensure that the property actually exists. If
    /// the type of the target is known at compile-time, it is recommended that a <see cref="TypedMultiBinding{TTarget}"/> be used rather
    /// than a <c>MultiBinding</c>.
    /// </para>
    /// <para>
    /// The bindings comprising the sources for the <c>MultiBinding</c> must be added to the <see cref="MultiSourceBinding.Sources"/>
    /// collection prior to activation. Only <see cref="SingleSourceBinding"/>s are supported, and target information for those bindings
    /// must be absent. Only the source information should be provided.
    /// </para>
    /// <para>
    /// A <c>MultiBinding</c> always requires a converter be set via the <see cref="MultiSourceBinding.Converter"/> property before it can
    /// be activated.
    /// </para>
    /// <include file='Documentation/Shared.xml' path='Items/Item[@Name="BindingStringFormat"]/*'/>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="MultiBinding.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="MultiBinding.Simple.Fluent"]/*'/>
    public class MultiBinding : MultiSourceBinding
    {
        private string _targetPath;

        /// <summary>
        /// Constructs an instance of <c>MultiBinding</c>.
        /// </summary>
        public MultiBinding()
        {
        }

        /// <summary>
        /// Constructs an instance of <c>MultiBinding</c> using the specified information.
        /// </summary>
        /// <param name="targetObject">
        /// The target object for the binding.
        /// </param>
        /// <param name="targetPath">
        /// A path used to resolve the bound property on the target object.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        public MultiBinding(object targetObject, string targetPath)
        {
            TargetObject = targetObject;
            _targetPath = targetPath;
        }

        /// <summary>
        /// Gets or sets the target path for this <c>MultiBinding</c>.
        /// </summary>
        public string TargetPath
        {
            get { return _targetPath; }
            set
            {
                VerifyNotActivated();
                _targetPath = value;
            }
        }

        /// <summary>
        /// Attempts to create the target property expressions for this <c>MultiBinding</c>.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the target property expression was successfully created, otherwise <see langword="false"/>.
        /// </returns>
        protected override PropertyExpression AttemptCreateTargetPropertyExpression()
        {
            var targetObject = TargetObject;
            if (targetObject == null || _targetPath == null)
            {
                return null;
            }

            return PathPropertyExpression.FromPath(targetObject, _targetPath, BindOnValidation);
        }
    }
}
