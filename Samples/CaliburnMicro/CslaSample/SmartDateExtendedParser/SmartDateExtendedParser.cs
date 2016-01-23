using System;
using System.Text.RegularExpressions;

namespace CslaContrib
{
  /// <summary>
  /// SmartDate extended parsing for relative dates and short date form parsing.
  /// </summary>
  public static class SmartDateExtendedParser
  {
    /// <summary>
    /// Entry point for Csla.SmartDate customized parser.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static DateTime? ExtendedParser(string value)
    {
      var result = new DateTime();
      if (TryStringToDate(value, ref result))
        return result;

      return null;
    }

    private static bool TryStringToDate(string value, ref DateTime result)
    {
      if (String.IsNullOrEmpty(value))
      {
        return false;
      }

      DateTime tmp;

      if (NearestDate(value, out tmp))
      {
        result = tmp;
        return true;
      }

      var ldate = value.Trim().ToLower();
      if (ldate == "<")
      {
        result = DateTime.Now.AddMonths(-1);
        return true;
      }
      if (ldate == ">")
      {
        result = DateTime.Now.AddMonths(1);
        return true;
      }
      if (ldate == "<<")
      {
        result = DateTime.Now.AddYears(-1);
        return true;
      }
      if (ldate == ">>")
      {
        result = DateTime.Now.AddYears(1);
        return true;
      }
      if (ldate.Substring(0, 1) == "+")
      {
        try
        {
          result = DateTime.Now.AddDays(Convert.ToInt32(ldate.Substring(1)));
        }
        catch (FormatException)
        {
          return false;
        }
        return true;
      }
      if (ldate.Substring(0, 1) == "-")
      {
        try
        {
          result = DateTime.Now.AddDays(-1*Convert.ToInt32(ldate.Substring(1)));
        }
        catch (FormatException)
        {
          return false;
        }
        return true;
      }
      if (ldate.Substring(0, 1) == "<")
      {
        try
        {
          result = DateTime.Now.AddMonths(-1*Convert.ToInt32(ldate.Substring(1)));
        }
        catch (FormatException)
        {
          return false;
        }
        return true;
      }
      if (ldate.Substring(0, 1) == ">")
      {
        try
        {
          result = DateTime.Now.AddMonths(Convert.ToInt32(ldate.Substring(1)));
        }
        catch (FormatException)
        {
          return false;
        }
        return true;
      }
      if (ldate.Length > 1)
      {
        if (ldate.Substring(0, 2) == "<<")
        {
          try
          {
            result = DateTime.Now.AddYears(-1*Convert.ToInt32(ldate.Substring(2)));
          }
          catch (FormatException)
          {
            return false;
          }
          return true;
        }
        if (ldate.Substring(0, 2) == ">>")
        {
          try
          {
            result = DateTime.Now.AddYears(Convert.ToInt32(ldate.Substring(2)));
          }
          catch (FormatException)
          {
            return false;
          }
          return true;
        }
      }
#if !SILVERLIGHT
      if (Regex.IsMatch(ldate, @"^\d{1,2}$", RegexOptions.Compiled))
#else
      if (Regex.IsMatch(ldate, @"^\d{1,2}$"))
#endif
      {
        int day;
        try
        {
          day = Convert.ToInt32(ldate);
        }
        catch (FormatException)
        {
          return false;
        }
        if (DateTime.Now.Day - day < -16)
        {
          return KeepDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1), day, out result);
        }
        if (DateTime.Now.Day - day > 16)
        {
          return KeepDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1), day, out result);
        }
        result = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
        return true;
      }

      value = NormalizeAllShortForms(value.Trim());
      if (DateTime.TryParse(value, out tmp))
      {
        result = tmp;
        return true;
      }

      return false;
    }

    private static string NormalizeAllShortForms(string value)
    {
      var pattern = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
#if! SILVERLIGHT
      var separator = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator;
#else
      var separator = pattern.Replace("y", string.Empty).Replace("d", string.Empty).Replace("M", string.Empty).Substring(0, 1);
#endif

      // Normalize separator
#if !SILVERLIGHT
      value = Regex.Replace(value, @"[ .,/\-\\]", separator, RegexOptions.Compiled);
#else
      value = Regex.Replace(value, @"[ .,/\-\\]", separator);
#endif
      // Insert missing zeros
      var valueParts = value.Split(separator.ToCharArray());
      for (var i = 0; i < valueParts.Length; i++)
      {
        if (valueParts[i].Length > 0 && valueParts[i].Length < 2)
          valueParts[i] = "0" + valueParts[i];
      }

      // Re-assemble without separator
      value = string.Join(string.Empty, valueParts);

      var nrDigits = value.Length;
      var patternElements = pattern.Split(separator.ToCharArray());
#if !SILVERLIGHT
      if (Regex.IsMatch(value, @"^\d{4}$", RegexOptions.Compiled) ||
          Regex.IsMatch(value, @"^\d{6}$", RegexOptions.Compiled) ||
          Regex.IsMatch(value, @"^\d{8}$", RegexOptions.Compiled))
#else
      if (Regex.IsMatch(value, @"^\d{4}$") ||
          Regex.IsMatch(value, @"^\d{6}$") ||
          Regex.IsMatch(value, @"^\d{8}$"))
#endif
      {
        var tempValue = string.Empty;
        var valuePointer = 0;

        foreach (var element in patternElements)
        {
          if (element.IndexOf("d", StringComparison.Ordinal) != -1)
          {
            tempValue += value.Substring(valuePointer, 2) + separator;
            valuePointer = valuePointer + 2;
          }
          else if (element.IndexOf("M", StringComparison.Ordinal) != -1)
          {
            tempValue += value.Substring(valuePointer, 2) + separator;
            valuePointer = valuePointer + 2;
          }
          else if (element.IndexOf("y", StringComparison.Ordinal) != -1)
          {
            if (nrDigits == 4)
            {
              tempValue += DateTime.Now.Year + separator;
            }
            else
            {
              tempValue += value.Substring(valuePointer, (nrDigits == 6 ? 2 : 4)) + separator;
              valuePointer = valuePointer + (nrDigits == 6 ? 2 : 4);
            }
          }
        }
        value = tempValue.Substring(0, tempValue.Length - 1);
      }

      return value;
    }

    private static bool NearestDate(string value, out DateTime result)
    {
      result = DateTime.MaxValue;

#if !SILVERLIGHT
      if (Regex.IsMatch(value, @"^\d{1,2}$", RegexOptions.Compiled))
#else
      if (Regex.IsMatch(value, @"^\d{1,2}$"))
#endif
      {
        // Convert day-only to nearest date and return
        int day;
        try
        {
          day = Convert.ToInt32(value);
        }
        catch (FormatException)
        {
          return false;
        }

        if (day > 31)
          return false;

        DateTime tmp;
        if (DateTime.Now.Day - day < -16)
        {
          if (KeepDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1), day, out tmp))
          {
            result = tmp;
            return true;
          }
        }
        else if (DateTime.Now.Day - day > 16)
        {
          if (KeepDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1), day, out tmp))
          {
            result = tmp;
            return true;
          }
        }
        else
        {
          try
          {
            result = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            return true;
          }
          catch (ArgumentOutOfRangeException)
          {
            return false;
          }
        }
      }

      return false;
    }

    private static bool KeepDay(DateTime monthYear, int day, out DateTime result)
    {
      try
      {
        result = new DateTime(monthYear.Year, monthYear.Month, day);
        return true;
      }
      catch
      {
        result = DateTime.MinValue;
        return false;
      }
    }
  }
}