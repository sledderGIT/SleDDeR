﻿using System;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class DateValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert (DateTime value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString ("MM/dd/yyyy");
        }
    }
}