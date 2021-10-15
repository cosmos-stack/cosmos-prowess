using System;
using System.Reflection;
using CosmosStack.EnumUtils.DynamicEnumServices;
using CosmosStack.Exceptions;
using CosmosStack.Reflection;

namespace CosmosStack.EnumUtils
{
    public static class DynamicEnumVisit
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
            return IsEnum(value, type, EnumVisitOptions.For.TypeAndValueAndDynamic());
        }

        public static bool IsEnum(object value, Type type, IEnumVisitOptions options)
        {
            var optionsVal = options.Value;

            return optionsVal switch
            {
                0 => IsEnum(type),
                1 => Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
                2 => IsEnum(type) || Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
                3 => IsEnum(type) || Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess || IsDynamicEnum(type),
                _ => false
            };
        }

        public static bool IsEnum<T>(T value)
        {
            return IsEnum(value, typeof(T), EnumVisitOptions.For.TypeAndValueAndDynamic());
        }

        public static bool IsEnum<T>(T value, IEnumVisitOptions options)
        {
            return IsEnum(value, typeof(T), options);
        }

        #endregion

        #region IsDynamicEnum

        public static bool IsDynamicEnum(object obj)
        {
            return obj is IDynamicEnum;
        }

        public static bool IsDynamicEnum<T>()
        {
            return IsDynamicEnum(typeof(T), out _);
        }

        public static bool IsDynamicEnum<T>(out Type[] genericArguments)
        {
            return IsDynamicEnum(typeof(T), out genericArguments);
        }

        public static bool IsDynamicEnum(Type type)
        {
            return IsDynamicEnum(type, out _);
        }

        public static bool IsDynamicEnum(Type type, out Type[] genericArguments)
        {
            if (type is null || type.IsAbstract || type.IsGenericTypeDefinition)
            {
                genericArguments = null;
                return false;
            }

            return TypeReflections.IsImplementationOfGenericType(type, typeof(DynamicEnum<,>), out genericArguments) ||
                   TypeReflections.IsImplementationOfGenericType(type, typeof(DynamicFlagEnum<,>), out genericArguments);
        }

        #endregion
    }
}