using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Connects a target property to a single source property using simple path-formatted strings to resolve the bound properties on both
    /// the target and source objects.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Instances of the <c>Binding</c> class can be used to connect together two properties. The properties are specified via strings, so
    /// there is no compile-time check to ensure that the property actually exists. If the types of the target and source objects are
    /// known, it is recommended that a <see cref="TypedBinding{TTarget,TSource}"/> be used rather than a <c>Binding</c>.
    /// </para>
    /// <include file='Documentation/Shared.xml' path='Items/Item[@Name="BindingStringFormat"]/*'/>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="Binding.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="Binding.Simple.Fluent"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="Binding.Complex"]/*'/>
    public class Binding : SingleSourceBinding
    {
        private string _targetPath;
        private string _sourcePath;

        /// <summary>
        /// Constructs an instance of <c>Binding</c>.
        /// </summary>
        public Binding()
        {
        }

        /// <summary>
        /// Constructs an instance of <c>Binding</c> using the specified details.
        /// </summary>
        /// <param name="targetObject">
        /// The target object for the binding.
        /// </param>
        /// <param name="targetPath">
        /// A path used to resolve the bound property on the target object.
        /// </param>
        /// <param name="sourceObject">
        /// The source object for the binding.
        /// </param>
        /// <param name="sourcePath">
        /// A path used to resolve the bound property on the source object.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1720", Justification = "'Object' is the terminology used throughout the library.")]
        public Binding(object targetObject, string targetPath, object sourceObject, string sourcePath)
        {
            TargetObject = targetObject;
            SourceObject = sourceObject;
            _targetPath = targetPath;
            _sourcePath = sourcePath;
        }

        /// <summary>
        /// Gets or sets the target path for this <c>Binding</c>.
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
        /// Gets or sets the source path for this <c>Binding</c>.
        /// </summary>
        public string SourcePath
        {
            get { return _sourcePath; }
            set
            {
                VerifyNotActivated();
                _sourcePath = value;
            }
        }

        /// <summary>
        /// Attempts to create the <see cref="PropertyExpression"/> for this <c>Binding</c>'s target.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyExpression"/>, or <see langword="null"/> if the property expression cannot be created.
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

        /// <summary>
        /// Attempts to create the <see cref="PropertyExpression"/> for this <c>Binding</c>'s source.
        /// </summary>
        /// <returns>
        /// The <see cref="PropertyExpression"/>, or <see langword="null"/> if the property expression cannot be created.
        /// </returns>
        protected override PropertyExpression AttemptCreateSourcePropertyExpression()
        {
            var sourceObject = SourceObject;

            if (sourceObject == null || _sourcePath == null)
            {
                return null;
            }

            return PathPropertyExpression.FromPath(sourceObject, _sourcePath, BindOnValidation);
        }
    }
}
