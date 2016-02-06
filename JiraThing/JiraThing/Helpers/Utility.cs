using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace JiraThing
{
    static class Utility
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string StringJoin(this IEnumerable<string> items, string delimiter)
        {
            return String.Join(delimiter, items.ToArray());
        }

        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key, V defaultValue = default(V))
        {
            V value = defaultValue;
            if (!dictionary.TryGetValue(key, out value))
                return defaultValue;
            else
                return value;
        }

        public static IEnumerable<T> RemoveEmpty<T>(this IEnumerable<T> items)
        {
            return items.Where(p => p != null);
        }

        public static IEnumerable<T> AssertNotEmpty<T>(this IEnumerable<T> items)
        {
            if (!items.Any())
                throw new Exception("List was empty");

            return items;
        }
    }

    static class XMLExtensions
    {
        //https://gist.github.com/BlueReZZ/1570129
        public static XmlDocument RemoveAllNamespaces(this XmlNode documentElement)   
        {
            var xmlnsPattern = "\\s+xmlns\\s*(:\\w)?\\s*=\\s*\\\"(?<url>[^\\\"]*)\\\"";
            var outerXml = documentElement.OuterXml;
            var matchCol = Regex.Matches(outerXml, xmlnsPattern);
            foreach (var match in matchCol)
                outerXml = outerXml.Replace(match.ToString(), "");

            var result = new XmlDocument();
            result.LoadXml(outerXml);

            return result;
        }
    }

    static class DateExtensions
    {
        public static DateTime GetMorningTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
    }

    static class JSONHelper
    {
        public static T FromJSON<T>(string json)
        {
            //     Dim settings As New Newtonsoft.Json.JsonSerializerSettings With {.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore, .NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore}         
            json = json.Replace("/r", "").Replace("/n", "");
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
