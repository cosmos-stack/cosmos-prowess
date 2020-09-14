using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dynamic
{
    /// <summary>
    /// Dynamic Enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public abstract partial class DynamicEnum<TEnum, TValue>
    {
        public static TEnum FromName(string name)
        {
            return TryFromName(name, out var result) ? result : default;
        }

        public static TEnum FromName(string name, bool ignoreCase)
        {
            return TryFromName(name, ignoreCase, out var result) ? result : default;
        }

        public static IEnumerable<TEnum> FromValue(TValue value)
        {
            return TryFromValue(value, out var results) ? results : Enumerable.Empty<TEnum>();
        }

        public static TEnum SingleFromValue(TValue value)
        {
            return FromValue(value).FirstOrDefault();
        }

        public static bool TryFromName(string name, out TEnum result)
        {
            return TryFromName(name, false, out result);
        }

        public static bool TryFromName(string name, bool ignoreCase, out TEnum result)
        {
            if (string.IsNullOrEmpty(name))
                DynamicExceptionHelper.ThrowArgumentNullOrEmptyException(nameof(name));

            var members = DynamicEnumManager.GetMembers<TEnum, TValue>();

            if (members is null)
            {
                result = default;
                return false;
            }

            return members.TryGetMember(name, ignoreCase, out result);
        }

        public static bool TryFromValue(TValue value, out List<TEnum> results)
        {
            if (value is null)
                DynamicExceptionHelper.ThrowArgumentNullException(nameof(value));

            var members = DynamicEnumManager.GetMembers<TEnum, TValue>();

            if (members is null)
            {
                results = default;
                return false;
            }

            return members.TryGetMembers(value, out results);
        }
    }
}