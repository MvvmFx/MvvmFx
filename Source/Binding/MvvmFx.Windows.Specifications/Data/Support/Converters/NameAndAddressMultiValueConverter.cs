using System;
using System.Globalization;
using System.Linq;
using MvvmFx.Windows.Data;

namespace MvvmFx.Windows.Specifications.Support.Converters
{
    public sealed class NameAndAddressMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.All(x => x == null))
            {
                return null;
            }

            return string.Join("~", values.Select(x => x == null ? "" : x.ToString()).ToArray());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var valueStr = value as string;

            if (valueStr == null)
            {
                return new object[targetTypes.Length];
            }

            return (value as string).Split('~');
        }
    }
}