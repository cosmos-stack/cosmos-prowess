using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;

namespace Cosmos.Dynamic.DynamicEnums
{
    internal sealed class DynamicEnumMembers<TEnum, TValue> : IDynamicEnumMembers
        where TEnum : DynamicEnum<TEnum, TValue>, IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly Dictionary<string, TEnum> _enumKeyMembers;
        private readonly Dictionary<TValue, List<TEnum>> _enumValueMembers;
        private readonly object _enumMemberLockObj = new object();

        public DynamicEnumMembers()
        {
            EnumType = typeof(TEnum);
            _enumKeyMembers = new Dictionary<string, TEnum>();
            _enumValueMembers = new Dictionary<TValue, List<TEnum>>();
        }

        public Type EnumType { get; }

        public void AddMember(TEnum member)
        {
            if (member is null)
                return;

            UpdateEnumMember(member.Name, member.Value, member);
        }

        public void AddMemberRange(IEnumerable<TEnum> members)
        {
            if (members is null)
                return;

            foreach (var member in members)
                AddMember(member);
        }

        public TEnum GetMember(string name)
        {
            return TryGetNamedEnumMember(name, false, out var result) ? result : default;
        }

        public TEnum GetMember(string name, bool ignoreCase)
        {
            return TryGetNamedEnumMember(name, ignoreCase, out var result) ? result : default;
        }

        public List<TEnum> GetMembers(TValue value)
        {
            return TryGetValuedEnumMember(value, out var members) ? members : null;
        }

        public bool TryGetMember(string name, out TEnum member)
        {
            return TryGetNamedEnumMember(name, false, out member);
        }

        public bool TryGetMember(string name, bool ignoreCase, out TEnum member)
        {
            return TryGetNamedEnumMember(name, ignoreCase, out member);
        }

        public bool TryGetMembers(TValue value, out List<TEnum> members)
        {
            return TryGetValuedEnumMember(value, out members);
        }

        #region Private Impl

        private void UpdateEnumMember(string name, TValue value, TEnum member)
        {
            if (string.IsNullOrWhiteSpace(name) || value is null || member is null)
                return;

            lock (_enumMemberLockObj)
            {
                if (_enumKeyMembers.ContainsKey(name))
                    return;

                _enumKeyMembers.Add(name, member);

                _enumValueMembers.AddOrUpdate(
                    value,
                    k => new List<TEnum> {member},
                    (k, v) =>
                    {
                        if (!v.Contains(member))
                            v.Add(member);
                    });
            }
        }

        private bool TryGetNamedEnumMember(string name, bool ignoreCase, out TEnum member)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                member = default;
                return false;
            }

            lock (_enumMemberLockObj)
            {
                if (ignoreCase)
                {
                    var list = _enumKeyMembers.Where(pair => string.Compare(pair.Key, name, StringComparison.OrdinalIgnoreCase) == 0)
                                              .ToList();

                    if (!list.Any())
                    {
                        member = default;
                        return false;
                    }
                    else
                    {
                        member = list.FirstOrDefault().Value;
                        return true;
                    }
                }
                else
                {
                    return _enumKeyMembers.TryGetValue(name, out member);
                }
            }
        }

        private bool TryGetValuedEnumMember(TValue value, out List<TEnum> members)
        {
            if (value is null)
            {
                members = default;
                return false;
            }

            lock (_enumMemberLockObj)
            {
                return _enumValueMembers.TryGetValue(value, out members);
            }
        }

        #endregion

        #region Keys and Values

        public IEnumerable<string> GetAllKeys() => _enumKeyMembers.Keys;

        public IEnumerable<TEnum> GetAllValues() => _enumKeyMembers.Values;

        #endregion
    }
}