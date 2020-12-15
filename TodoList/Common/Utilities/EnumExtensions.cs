using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;


namespace TodoList.Common.Utilities
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()?
                .GetMember(enumValue.ToString())?
                .First()?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name;
        }

        public static Dictionary<T, string> ToDictionary<T>() where T : struct
            => Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(e => e, e => e.ToString());
    }
}