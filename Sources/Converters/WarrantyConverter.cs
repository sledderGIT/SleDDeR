using System;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class WarrantyConverter: MvxValueConverter<DateTime, string>
    {
        protected override string Convert (DateTime value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value <= DateTime.Now) {
                return "Нет";
            } else
                return value.ToString ("dd MMMM yyyy");
        }

    }
}