
namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Allows a mode to be selected.
    /// </summary>
    /// <typeparam name="TFollowOn">
    /// The follow-on type for methods in this interface.
    /// </typeparam>
    public interface IModeSelection<TFollowOn> : IHideObjectMembers
    {
        /// <summary>
        /// Requests that the binding be two-way.
        /// </summary>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        TFollowOn TwoWay();

        /// <summary>
        /// Requests that the binding be one-way to source.
        /// </summary>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        TFollowOn OneWayToSource();

        /// <summary>
        /// Requests that the binding be one-way to target.
        /// </summary>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        TFollowOn OneWayToTarget();
    }
}
