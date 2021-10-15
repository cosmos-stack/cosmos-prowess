using System;
using System.Collections.Concurrent;

namespace CosmosStack.EnumUtils.DynamicEnumServices
{
    internal static class DynamicEnumManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly ConcurrentDictionary<Type, IDynamicEnumMembers> _memberContainers;

        static DynamicEnumManager()
        {
            _memberContainers = new ConcurrentDictionary<Type, IDynamicEnumMembers>();
        }

        public static IDynamicEnumMembers GetMembers<TEnum>()
            where TEnum : IDynamicEnum
        {
            return _memberContainers.TryGetValue(typeof(TEnum), out var members) ? members : null;
        }

        public static DynamicEnumMembers<TEnum, TValue> GetMembers<TEnum, TValue>()
            where TEnum : DynamicEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return GetMembers<TEnum>() as DynamicEnumMembers<TEnum, TValue>;
        }

        public static DynamicEnumMembers<TEnum, TValue> SetMembers<TEnum, TValue>(DynamicEnumMembers<TEnum, TValue> members)
            where TEnum : DynamicEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return _memberContainers.GetOrAdd(typeof(TEnum), t => members) as DynamicEnumMembers<TEnum, TValue>;
        }

        public static DynamicFlagEnumMembers<TEnum, TValue> GetFlagMembers<TEnum, TValue>()
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return GetMembers<TEnum>() as DynamicFlagEnumMembers<TEnum, TValue>;
        }

        public static DynamicFlagEnumMembers<TEnum, TValue> SetFlagMembers<TEnum, TValue>(DynamicFlagEnumMembers<TEnum, TValue> members)
            where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
            where TValue : IEquatable<TValue>, IComparable<TValue>
        {
            return _memberContainers.GetOrAdd(typeof(TEnum), t => members) as DynamicFlagEnumMembers<TEnum, TValue>;
        }
    }
}