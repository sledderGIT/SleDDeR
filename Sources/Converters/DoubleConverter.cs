using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class DoubleConverter : MvxValueConverter<double, string>
    {
        protected override string Convert (double value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == 0)
                return "";
            else
                return value.ToString ();
        }
        protected override double ConvertBack (string value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value.Replace (",", ".");
            if (value.EndsWith (".")) {
                value = value.Replace (".", "");
            }
            if (value == "")
                value = "0";
            return double.Parse (value);
        }
    }
}