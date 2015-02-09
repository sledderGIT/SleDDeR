using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cirrious.CrossCore;

namespace Investor.Core
{
    public static class QueryKeyValueExtension
    {
        public static Dictionary<string, string> ToQueryKeyValueCollection(this object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                //var valueType = properties[key].GetType();
                var enumerable = properties [key] as IList;
                /*for (int i = 0; i < enumerable.Count; i++) {
					enumerable[i] = "\"" + enumerable[i] + "\"";
				}*/
                properties[key] = "[" + string.Join(separator, enumerable.Cast<object>()) + "]";
            }
            var result = new Dictionary<string, string> ();
            var keys = properties.Keys.ToList ();
            foreach (var key in keys) {
                if (properties [key].ToString () == "True") {
                    properties [key] = "1";
                }
                if (properties [key].ToString () == "False") {
                    properties [key] = "0";
                }
                if (string.IsNullOrEmpty (properties [key].ToString())) { //properties [key].ToString() == "-1"
                    properties.Remove (key);
                } else {
                    var formattable = properties [key] as IFormattable;
                    result [key] = formattable == null? properties [key].ToString(): formattable.ToString(null, CultureInfo.InvariantCulture);
                }
            }
            return result;

            // Concat all key/value pairs into a string separated by ampersand
            /*var str= string.Join("&", properties
				.Select(x => string.Concat(Uri.EscapeDataString(x.Key), "=", x.Value == null?"null": Uri.EscapeDataString(x.Value.ToString()))
				));
			str = str.Replace ("True", "1").Replace ("False", "0");
			str = Regex.Replace (str, @"(\w+=&)?(\w+=$)?", "");
			return str;*/
        }
    }
}