
namespace MvvmFx.Bindings.Data
{
    /// <summary>
    /// Provides binding options for single-source binding fluent expressions.
    /// </summary>
    public interface ISingleSourceBindingOptions : IConverterSelection<ISingleSourceBindingOptions, IValueConverter>,
                                                   IModeSelection<ISingleSourceBindingOptions>, IActivation
    {
    }
}
