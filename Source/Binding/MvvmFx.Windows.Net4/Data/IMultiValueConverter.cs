using System;

namespace MvvmFx.Windows.Data
{
    /// <summary>
    /// Provides a way to convert values for a <see cref="MultiSourceBinding"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="MultiSourceBinding"/> requires a means to convert multiple values into one, and vice-versa. An implementation of
    /// this interface must be assigned to the <see cref="MultiSourceBinding.Converter"/> parameter before the binding can be activated.
    /// </para>
    /// </remarks>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="IMultiValueConverter.Simple"]/*'/>
    /// <include file='Documentation/Examples.xml' path='Examples/Example[@Name="IMultiValueConverter.Complex"]/*'/>
    public interface IMultiValueConverter
    {
        /// <summary>
        /// Converts multiple source values into a single target value.
        /// </summary>
        /// <param name="values">The array of values from all sources of the <see cref="MultiSourceBinding"/>.</param>
        /// <param name="targetType">The type of the target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// The single target value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="MultiSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToTarget"/>.
        /// </remarks>
        object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture);

        /// <summary>
        /// Converts back a single target value into multiple source values.
        /// </summary>
        /// <param name="value">The single target value.</param>
        /// <param name="taregtTypes">The array of types of the source properties.
        /// The array length indicates the number and types of values that are suggested
        /// for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// The multiple source values, which must have the same length as <paramref name="taregtTypes"/>.
        /// </returns>
        /// <remarks>
        /// This method will only be called if the mode of the <see cref="MultiSourceBinding"/> is either <see cref="BindingMode.TwoWay"/>
        /// or <see cref="BindingMode.OneWayToSource"/>.
        /// </remarks>
        object[] ConvertBack(object value, Type[] taregtTypes, object parameter, System.Globalization.CultureInfo culture);
    }
}
