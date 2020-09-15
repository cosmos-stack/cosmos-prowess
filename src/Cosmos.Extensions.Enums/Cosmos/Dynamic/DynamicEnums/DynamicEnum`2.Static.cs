using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dynamic.DynamicEnums
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
            return FromValue(value, Enumerable.Empty<TEnum>());
        }

        public static IEnumerable<TEnum> FromValue(TValue value, IEnumerable<TEnum> defaultVal)
        {
            return TryFromValue(value, out var results) ? results : defaultVal;
        }

        public static TEnum FromValueSingle(TValue value)
        {
            return FromValue(value).FirstOrDefault();
        }

        public static TEnum FromValueSingle(TValue value, TEnum defaultVal)
        {
            return FromValue(value, new[] {defaultVal}).FirstOrDefault();
        }

        public static string FromValueToString(TValue value)
        {
            var valColl = FromValue(value);
            return Joiners.Joiner.On(", ").SkipNulls().Join(valColl, val => val.Name);
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

        public static bool TryFromValueToString(TValue value, out string result)
        {
            if (!TryFromValue(value, out var valColl))
            {
                result = default;
                return false;
            }
            else
            {
                result = Joiners.Joiner.On(", ").SkipNulls().Join(valColl, val => val.Name);
                return true;
            }
        }
    }
}