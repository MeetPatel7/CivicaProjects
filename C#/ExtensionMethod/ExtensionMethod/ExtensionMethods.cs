using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    internal static class ExtensionMethods
    {
        public static int AsInt(this string a, int defaultValue) => Int32.TryParse(a, out int result) ? Int32.Parse(a) : defaultValue;
        public static bool AsBool(this string a, bool defaultValue) => bool.TryParse(a, out bool result) ? bool.Parse(a) : defaultValue;
        public static float AsFloat(this string a, float defaultValue) => float.TryParse(a, out float result) ? float.Parse(a) : defaultValue;
        public static decimal AsDecimal(this string a, decimal defaultValue) => decimal.TryParse(a, out decimal result) ? decimal.Parse(a) : defaultValue;
        public static DateTime AsDatetime(this string a, DateTime defaultValue) => DateTime.TryParse(a, out DateTime result) ? DateTime.Parse(a) : defaultValue;

    }
}
