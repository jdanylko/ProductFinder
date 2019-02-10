using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace ProductFinder.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription<TEnum>(this TEnum value) where TEnum : struct
        {
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? value.ToString()
                    : descriptionAttribute.Description;
        }

        public static List<SelectListItem> ToSelectList<TEnum>(this Type type) where TEnum : struct
        {
            var result = new List<SelectListItem>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var value = (int)field.GetValue(name);
                var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);

                var selectList = fds.Cast<DescriptionAttribute>()
                    .Select(
                        fd => new SelectListItem(fd.Description, value.ToString())
                    );
                result.AddRange(selectList);
            }
            return result;
        }

        public static List<SelectListItem> ToSelectList<TEnum>(this Type type, List<SelectListItem> defaults) where TEnum : struct
        {
            var result = typeof(TEnum).ToSelectList<TEnum>();
            foreach (var item in defaults)
            {
                var found = result.FirstOrDefault(e => e.Value == item.Value);
                if (found == null) continue;
                found.Selected = item.Selected;
            }
            
            return result;
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> list, Func<T, string> dataField,
            Func<T, string> valueField, string defaultValue)
        {
            var result = new List<SelectListItem>();
            if (list.Any())
                result.AddRange(
                    list.Select(
                        resultItem => new SelectListItem
                        {
                            Value = valueField(resultItem),
                            Text = dataField(resultItem),
                            Selected = defaultValue == valueField(resultItem)
                        }));
            return result;
        }

    }
}
