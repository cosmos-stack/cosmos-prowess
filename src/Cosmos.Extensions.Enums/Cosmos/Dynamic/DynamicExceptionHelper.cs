using System;

namespace Cosmos.Dynamic
{
    internal static class DynamicExceptionHelper
    {
        public static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        public static void ThrowArgumentNullOrEmptyException(string paramName)
        {
            throw new ArgumentException("Argument cannot be null or empty.", paramName);
        }

        public static void ThrowNameNotFoundException<TEnum, TValue>(string name)
            where TEnum : DynamicEnum<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            throw new DynamicEnumNotFoundException($"No {typeof(TEnum).Name} with Name \"{name}\" found.");
        }

        public static void ThrowValueNotFoundException<TEnum, TValue>(TValue value)
            where TEnum : DynamicEnum<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            throw new DynamicEnumNotFoundException($"No {typeof(TEnum).Name} with Value {value} found.");
        }
    }
}