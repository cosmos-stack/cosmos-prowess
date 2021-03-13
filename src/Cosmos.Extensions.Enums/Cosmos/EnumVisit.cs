using System;
using System.Reflection;
using Cosmos.Exceptions;
using Cosmos.Reflection;

namespace Cosmos
{
    public static class EnumVisit
    {
        #region IsEnum

        public static bool IsEnum<T>()
        {
            return Types.IsEnumType<T>();
        }

        public static bool IsEnum(Type type)
        {
            return Types.IsEnumType(type);
        }

        public static bool IsEnum(MemberInfo info)
        {
            return TypeReflections.IsEnum(info);
        }

        public static bool IsEnum(PropertyInfo info)
        {
            return TypeReflections.IsEnum(info);
        }

        public static bool IsEnum(object value, Type type)
        {
            return IsEnum(value, type, EnumVisitOptions.For.Default());
        }

        public static bool IsEnum(object value, Type type, IEnumVisitOptions options)
        {
            var optionsVal = options.Value;

            return optionsVal switch
            {
                0 => IsEnum(type),
                1 => Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
                2 => IsEnum(type) || Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
                _ => false
            };
        }

        public static bool IsEnum<T>(T value)
        {
            return IsEnum(value, typeof(T));
        }

        public static bool IsEnum<T>(T value, IEnumVisitOptions options)
        {
            return IsEnum(value, typeof(T), options);
        }

        #endregion
    }
}