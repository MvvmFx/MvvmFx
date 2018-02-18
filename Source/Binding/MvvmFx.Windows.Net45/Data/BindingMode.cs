namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Defines the various modes a <see cref="BindingBase"/> can operate in.
    /// </summary>
    public enum BindingMode
    {
        /// <summary>
        /// Changes are pushed both from the binding's target to its source, and from its source to its target.
        /// </summary>
        TwoWay,

        /// <summary>
        /// Changes are pushed only from the binding's target to its source.
        /// </summary>
        OneWayToSource,

        /// <summary>
        /// Changes are pushed only from the binding's source to its target.
        /// </summary>
        OneWayToTarget
    }
}
