using System;
using BoundTreeView.Properties;
using FamilyBusiness;
using MvvmFx.Bindings.Data;

namespace BoundTreeView.Framework
{
    public class GenderConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (string))
                throw new InvalidOperationException("The target must be a string.");

            var result = string.Empty;

            switch ((Gender?) value)
            {
                case null:
                    break;
                case Gender.Male:
                    result = Resources.Gender_Male;
                    break;
                case Gender.Female:
                    result = Resources.Gender_Female;
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (Gender?))
                throw new InvalidOperationException("The source must be a Gender option.");

            object result = null;

            if (string.Equals(((string) value), Resources.Gender_Male, StringComparison.CurrentCultureIgnoreCase))
            {
                result = Gender.Male;
            }
            else if (string.Equals(((string) value), Resources.Gender_Female, StringComparison.CurrentCultureIgnoreCase))
            {
                result = Gender.Female;
            }

            return result;
        }

        #endregion
    }
}