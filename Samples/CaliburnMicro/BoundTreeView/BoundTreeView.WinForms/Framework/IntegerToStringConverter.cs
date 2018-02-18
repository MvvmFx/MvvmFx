using System;
using BoundTreeView.Properties;
using FamilyBusiness;
using MvvmFx.Bindings.Data;

namespace BoundTreeView.Framework
{
    public class IntegerToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (string))
                throw new InvalidOperationException("The target must be a string.");

            var result = string.Empty;

            if (value != null)
                result = value.ToString();

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (int?))
                throw new InvalidOperationException("The source must be a nullable 32 bits integer option.");

            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                int number;
                if (int.TryParse(value.ToString(), out number))
                    return number;
            }

            return null;
        }

        #endregion
    }
}