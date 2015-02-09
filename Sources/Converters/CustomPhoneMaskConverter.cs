using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Cirrious.CrossCore.Converters;

namespace Jeopardy.Core
{
    public class CustomPhoneMaskConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numbers = Regex.Replace(value.ToString(), @"[^0-9\+]", "");
            //return string.Format ("{0} ({1}) {2}", head, tail.Substring (0, 3), numbers.Substring (3, 3));
            var head = "";
            var tail = "";
            var length = 0;

            if (numbers.StartsWith ("8")) {
                length = 1;
                head = "8";
            } else if (numbers.StartsWith ("+7")) {
                head = "+7";
                length = 2;
            } else if (numbers.StartsWith ("+")) {
                head = "+";
                length = 1;
            }

            tail = numbers.Substring (length, numbers.Length - length);
            if (numbers.Length <= length) {
                return numbers;
            } else if (numbers.Length <= length + 3) {
                return string.Format ("{0} {1}", head, tail);
            } else if (numbers.Length <= length + 6) {
                return string.Format ("{0} ({1}) {2}", head, tail.Substring (0, 3), tail.Substring (3, tail.Length - 3));
            } else if (numbers.Length <= length + 8) {
                return string.Format ("{0} ({1}) {2}-{3}", head, tail.Substring (0, 3), tail.Substring (3, 3), tail.Substring (6, tail.Length - 6));
            } else if (numbers.Length <= length + 10) {
                return string.Format ("{0} ({1}) {2}-{3}-{4}", head, tail.Substring (0, 3), tail.Substring (3, 3), 
                    tail.Substring (6, 2), tail.Substring (8, tail.Length - 8));
            } else {
                return string.Format ("{0} ({1}) {2}-{3}-{4}", head, tail.Substring (0, 3), tail.Substring (3, 3), 
                    tail.Substring (6, 2), tail.Substring (8, 2));
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = Regex.Replace(value.ToString(), @"[^0-9\+]", "");
            return val;
        }
    }
}