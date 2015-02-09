using System;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class RateConverter: MvxValueConverter<double, string>
    {
        protected override string Convert (double value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString () + "%";
        }
    }
}