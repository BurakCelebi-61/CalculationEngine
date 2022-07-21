using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculationEngine
{
    public static class Tool
    {
        #region ToInt
        public static int ToInt(this decimal value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this float value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt(this Variable value)
        {
            return value.Value.ToInt();
        }
        #endregion
        #region ToDecimal
        public static decimal ToDecimal(this Variable value)
        {
            return value.Value;
        }
        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }
        #endregion
        public static bool ToBool(this string value)
        {
            return bool.Parse(value);
        }
        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> original)
        {
            return original ?? Enumerable.Empty<T>();
        }
        public enum Comparison
        {
            //{
            //string _cond = Condition
            //.Replace("!=", "ED")
            //.Replace("==", "EE")
            //.Replace(">=", "BE")
            //.Replace(">", "BB")
            //.Replace("<=", "KE")
            //.Replace("<", "KK");
            //}
            

        }
    }
}
