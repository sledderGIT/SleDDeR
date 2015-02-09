using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class OutputPriceConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numbers = NumericToStringConverter.NumericToString (value);
            var formatted = numbers;
            var q = (int) numbers.Length / 3;
            for (var i = 1; i <= q; i++) {
                formatted = formatted.Insert (formatted.Length - (i * 3 + (i - 1)), " ");
            }
            var result = value.ToString().Replace(numbers, formatted);
            return result;
        }
    }
}