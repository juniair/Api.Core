using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RestApi.Core.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Enum"/>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Convert <see cref="Enum"/> to <see cref="string"/> for <see cref="DescriptionAttribute"/> of <see cref="Enum"/> 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            return displayAttribute?.Description ?? value.ToString();
        }

        /// <summary>
        /// Convert <see cref="String"/> to <see cref="Enum"/> for <see cref="DescriptionAttribute"/> of <see cref="Enum"/> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetValue<T>(this string description)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            throw new Exception("Not found");
        }
    }
}
