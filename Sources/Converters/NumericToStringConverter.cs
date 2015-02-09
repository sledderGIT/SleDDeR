using System;
using System.Text.RegularExpressions;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class NumericToStringConverter: MvxValueConverter
    {
        public override object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = NumericToString (value);
            if (val == "0") {
                return "";
            }
            return val;
        }

        public override object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return StringToNumeric (value);
        }

        public static string NumericToString(object value)
        {
            var val = Regex.Replace (value.ToString(), @"\D", "");
            return val;
        }

        public static int StringToNumeric(object value)
        {
            var result = 0;
            var val = Regex.Replace (value.ToString (), @"\D", "");
            int.TryParse (val, out result);
            return result;
        }
    }
}