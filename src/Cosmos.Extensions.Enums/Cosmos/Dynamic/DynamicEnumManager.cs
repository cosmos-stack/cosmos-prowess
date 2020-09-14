using System;
using System.Collections.Concurrent;

namespace Cosmos.Dynamic
{
    internal static class DynamicEnumManager
    {
        private static readonly ConcurrentDictionary<Type, IDynamicEnumMembers> _memberContainers;

        static DynamicEnumManager()
        {
            _memberContainers = new ConcurrentDictionary<Type, IDynamicEnumMembers>();
        }

        public static IDynamicEnumMembers GetMembers<TEnum>()
        {
            return GetMembers(typeof(TEnum));
        }

        public static IDynamicEnumMembers GetMembers(Type type)
        {
            return _memberContainers.TryGetValue(type, out var members) ? members : null;
        }

        public static DynamicEnumMembers<TEnum, TValue> GetMembers<TEnum, TValue>()
            where TEnum : DynamicEnum<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return GetMembers(typeof(TEnum)) as DynamicEnumMembers<TEnum, TValue>;
        }

        public static DynamicEnumMembers<TEnum, TValue> SetMembers<TEnum, TValue>(DynamicEnumMembers<TEnum, TValue> members)
            where TEnum : DynamicEnum<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return _memberContainers.GetOrAdd(typeof(TEnum), t => members) as DynamicEnumMembers<TEnum, TValue>;
        }
    }
}