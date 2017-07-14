using System;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Provides a way to convert values for a <see cref="SingleSourceBinding"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Converters on a <see cref="SingleSourceBinding"/> are not required. However, if a default conversion between target and source
    /// does not exist, or if the conversion should be customized in some manner, implementations of this interface allow the conversion
    /// behavior to be tailored.
    /// </para>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="IValueConverter.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="IValueConverter.Complex"]/*'/>
    public interface IValueConverter
    {
        /// <summary>
        /// Converts the source value to a target value.
        /// </summary>
        /// <param name="value">The source value to convert.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="SingleSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToTarget"/>.
        /// </remarks>
        object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        /// <summary>
        /// Converts back the target value to a source value.
        /// </summary>
        /// <param name="value">The target value to convert.</param>
        /// <param name="sourceType">The type of the source property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="SingleSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToSource"/>.
        /// </remarks>
        object ConvertBack(object value, Type sourceType, object parameter, System.Globalization.CultureInfo culture);
    }
}
