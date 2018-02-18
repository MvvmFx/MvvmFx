using System;
using MvvmFx.Bindings.Data;

namespace BoundTreeView.Framework
{
    public class BooleanYesNoConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (string))
                throw new InvalidOperationException("The target must be a string");

            if ((bool) value)
                return "Yes";

            return "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (bool))
                throw new InvalidOperationException("The source must be a boolean");

            if ((string) value == "Yes")
                return true;

            if ((string) value == "No")
                return false;

            return null;
        }

        #endregion
    }
}