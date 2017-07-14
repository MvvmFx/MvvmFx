
namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Allows selection of a converter for a binding.
    /// </summary>
    /// <typeparam name="TFollowOn">
    /// The follow-on type for methods in this interface.
    /// </typeparam>
    /// <typeparam name="TConverter">
    /// The converter type.
    /// </typeparam>
    public interface IConverterSelection<TFollowOn, TConverter> : IHideObjectMembers
    {
        /// <summary>
        /// Requests that the specified converter be used with the binding.
        /// </summary>
        /// <param name="converter">
        /// The converter.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        TFollowOn WithConverter(TConverter converter);

        /// <summary>
        /// Requests that the specified converter and converter parameter be used with the binding.
        /// </summary>
        /// <param name="converter">
        /// The converter.
        /// </param>
        /// <param name="converterParameter">
        /// The converter parameter.
        /// </param>
        /// <returns>
        /// The follow-on object.
        /// </returns>
        TFollowOn WithConverter(TConverter converter, object converterParameter);
    }
}
