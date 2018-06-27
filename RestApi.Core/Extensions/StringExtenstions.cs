using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Core.Extensions
{
    /// <summary>
    /// Extension methods for String
    /// </summary>
    public static class StringExtensions
    {


        /// <summary>
        /// Indicates wether the specified string is <see cref="null"/> or an <see cref="String.Empty"/> string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }


        /// <summary>
        /// Indicates wether the specified string is <see cref="null"/>, <see cref="String.Empty"/> or 
        /// consists only of white-space characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the value parameter is <see cref="null"/> or <see cref="String.Empty"/>,
        /// or if value consists excuusively of white-spcace characters.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="bool"/>.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"><paramref name="value"/> condition <see cref="predicate{T}"/>.</param>
        /// <returns></returns>
        public static bool ConvertToBoolean(this string value, Predicate<string> predicate)
        {
            if (predicate == null)
            {
                predicate = o => o.ToUpper().Equals("Y");
            }
            return predicate(value);
        }


        public static DateTime ConvertToDateTime(this string value, Func<string, DateTime> func = null)
        {
            if (func == null)
            {
                func = str =>
                {
                    str = str.Replace(".", "").Replace("-", "");
                    var length = str.Length;
                    var day = str.Substring(length - 2, 2);
                    var month = str.Substring(length - 4, 2);
                    var year = str.Substring(0, length - 4);
                    return DateTime.Parse($@"{year} {month} {day}");
                };
            }

            return func(value);
        }
    }
}
