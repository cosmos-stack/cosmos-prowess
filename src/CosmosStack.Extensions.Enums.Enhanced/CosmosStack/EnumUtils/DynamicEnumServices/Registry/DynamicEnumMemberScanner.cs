using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CosmosStack.EnumUtils.DynamicEnumServices.Registry
{
    internal static class DynamicEnumMemberScanner
    {
        public static IEnumerable<TEnumField> GetBuildInFieldsFromType<TEnumField>(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                       .Where(p => type.IsAssignableFrom(p.FieldType))
                       .Select(pi => (TEnumField) pi.GetValue(null));
        }

        public static IEnumerable<TEnum> GetBuildInValuesFromAssembly<TEnum, TValue>()
            where TEnum : IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            var baseType = typeof(TEnum);
            var enumTypes = Assembly.GetAssembly(baseType).GetTypes().Where(t => baseType.IsAssignableFrom(t));

            var options = new List<TEnum>();
            foreach (var enumType in enumTypes)
            {
                options.AddRange(GetBuildInFieldsFromType<TEnum>(enumType));
            }

            return options.OrderBy(x => x.Name);
        }
    }
}