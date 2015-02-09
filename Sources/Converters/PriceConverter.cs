using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class PriceConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numbers = NumericToStringConverter.NumericToString (value);
            if (numbers == "0") {
                return "";
            }
            var formatted = numbers;
            var q = (int) numbers.Length / 3;
            for (var i = 1; i <= q; i++) {
                formatted = formatted.Insert (formatted.Length - (i * 3 + (i - 1)), " ");
            }
            var result = value.ToString().Replace(numbers, formatted);
            return result;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return NumericToStringConverter.StringToNumeric (value);
        }
    }
}