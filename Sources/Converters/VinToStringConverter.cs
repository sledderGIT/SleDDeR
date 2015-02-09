using System;
using System.Text.RegularExpressions;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class VinToStringConverter: MvxValueConverter
    {
        public override object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = Regex.Replace (value.ToString(), @"[^A-Za-z0-9]", "");
            if (val.Length > 17)
                val = val.Substring (0, 17);
            return val;
        }

        public override object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = Regex.Replace (value.ToString(), @"[^A-Za-z0-9]", "");
            if (val.Length > 17)
                val = val.Substring (0, 17);
            return val;
        }
    }
}