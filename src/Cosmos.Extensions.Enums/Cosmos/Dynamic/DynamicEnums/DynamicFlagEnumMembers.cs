using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable PossibleMultipleEnumeration

namespace Cosmos.Dynamic.DynamicEnums
{
    internal sealed class DynamicFlagEnumMembers<TEnum, TValue> : IDynamicEnumMembers
        where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly Dictionary<string, TEnum> _enumKeyMembers;
        private readonly List<TEnum> _enumValueMembers;
        private readonly object _enumMemberLockObj = new object();

        public DynamicFlagEnumMembers()
        {
            EnumType = typeof(TEnum);
            _enumKeyMembers = new Dictionary<string, TEnum>();
            _enumValueMembers = new List<TEnum>();
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

                if (_enumValueMembers.Contains(member))
                    return;

                _enumValueMembers.Add(member);
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
                var valColl = GetFlagEnumValues(value, _enumValueMembers);

                if (valColl != null && valColl.Any())
                {
                    members = valColl.ToList();
                    return true;
                }
                else
                {
                    members = default;
                    return false;
                }
            }
        }

        #endregion

        #region Private methods

        private static IEnumerable<TEnum> GetFlagEnumValues(TValue value, List<TEnum> allEnumList)
        {
            GuardAgainstNull(value);
            GuardAgainstInvalidInputValue(value);
            GuardAgainstNegativeInputValue(value);

            var inputValueAsInt = int.Parse(value.ToString());
            var enumFlagStateDictionary = new Dictionary<TEnum, bool>();
            var inputEnumList = allEnumList;

            ApplyUnsafeFlagEnumAttributeSettings(inputEnumList);

            var maximumAllowedValue = CalculateHighestAllowedFlagValue(inputEnumList);

            var typeMaxValue = GetMaxValue();

            foreach (var enumValue in inputEnumList)
            {
                var currentEnumValueAsInt = int.Parse(enumValue.Value.ToString());

                CheckEnumForNegativeValues(currentEnumValueAsInt);

                if (currentEnumValueAsInt == inputValueAsInt)
                    return new List<TEnum> {enumValue};

                if (inputValueAsInt == -1 || value.Equals(typeMaxValue))
                {
                    return inputEnumList.Where(x => long.Parse(x.Value.ToString()) > 0);
                }

                AssignFlagStateValuesToDictionary(inputValueAsInt, currentEnumValueAsInt, enumValue, enumFlagStateDictionary);
            }

            return inputValueAsInt > maximumAllowedValue ? default : CreateSmartEnumReturnList(enumFlagStateDictionary);
        }

        private static void GuardAgainstNull(TValue value)
        {
            if (value is null)
                DynamicExceptionHelper.ThrowArgumentNullException(nameof(value));
        }

        private static void GuardAgainstInvalidInputValue(TValue value)
        {
            if (!int.TryParse(value.ToString(), out _))
                DynamicExceptionHelper.ThrowInvalidValueCastException<TEnum, TValue>(value);
        }

        private static void GuardAgainstNegativeInputValue(TValue value)
        {
            var attribute = (AllowNegativeInputValuesAttribute)
                Attribute.GetCustomAttribute(typeof(TEnum), typeof(AllowNegativeInputValuesAttribute));

            if (attribute is null && int.Parse(value.ToString()) < -1)
                DynamicExceptionHelper.ThrowNegativeValueArgumentException<TEnum, TValue>(value);
        }

        private static void CheckEnumForNegativeValues(int value)
        {
            if (value < -1)
                DynamicExceptionHelper.ThrowContainsNegativeValueException<TEnum, TValue>();
        }

        private static int CalculateHighestAllowedFlagValue(IReadOnlyList<TEnum> inputEnumList)
        {
            return (HighestFlagValue(inputEnumList) * 2) - 1;
        }

        private static void AssignFlagStateValuesToDictionary(int inputValueAsInt, int currentEnumValue, TEnum enumValue, IDictionary<TEnum, bool> enumFlagStateDictionary)
        {
            if (!enumFlagStateDictionary.ContainsKey(enumValue) && currentEnumValue != 0)
            {
                var flagState = (inputValueAsInt & currentEnumValue) == currentEnumValue;
                enumFlagStateDictionary.Add(enumValue, flagState);
            }
        }

        private static IEnumerable<TEnum> CreateSmartEnumReturnList(Dictionary<TEnum, bool> enumFlagStateDictionary)
        {
            var outputList = new List<TEnum>();

            foreach (var entry in enumFlagStateDictionary)
            {
                if (entry.Value)
                {
                    outputList.Add(entry.Key);
                }
            }

            return outputList.DefaultIfEmpty();
        }

        private static void ApplyUnsafeFlagEnumAttributeSettings(IEnumerable<TEnum> list)
        {
            var attribute = (AllowUnsafeFlagEnumValuesAttribute) Attribute
                .GetCustomAttribute(typeof(TEnum), typeof(AllowUnsafeFlagEnumValuesAttribute));

            if (attribute is null)
            {
                CheckEnumListForPowersOfTwo(list);
            }
        }

        private static void CheckEnumListForPowersOfTwo(IEnumerable<TEnum> enumEnumerable)
        {
            var enumList = enumEnumerable.ToList();
            var enumValueList = new List<int>();
            foreach (var smartFlagEnum in enumList)
            {
                enumValueList.Add(int.Parse(smartFlagEnum.Value.ToString()));
            }

            var firstPowerOfTwoValue = 0;
            if (int.Parse(enumList[0].Value.ToString()) == 0)
            {
                enumList.RemoveAt(0);
            }

            foreach (var flagEnum in enumList)
            {
                var x = int.Parse(flagEnum.Value.ToString());
                if (IsPowerOfTwo(x))
                {
                    firstPowerOfTwoValue = x;
                    break;
                }
            }

            var highestValue = HighestFlagValue(enumList);
            var currentValue = firstPowerOfTwoValue;

            while (currentValue != highestValue)
            {
                var nextPowerOfTwoValue = currentValue * 2;
                var result = enumValueList.BinarySearch(nextPowerOfTwoValue);
                if (result < 0)
                {
                    DynamicExceptionHelper.ThrowDoesNotContainPowerOfTwoValuesException<TEnum, TValue>();
                }

                currentValue = nextPowerOfTwoValue;
            }
        }

        private static bool IsPowerOfTwo(int input)
        {
            if (input != 0 && ((input & (input - 1)) == 0))
            {
                return true;
            }

            return false;
        }

        private static int HighestFlagValue(IReadOnlyList<TEnum> enumList)
        {
            var highestIndex = enumList.Count - 1;
            var highestValue = int.Parse(enumList.Last().Value.ToString());

            if (!IsPowerOfTwo(highestValue))
            {
                for (var i = highestIndex; i >= 0; i--)
                {
                    var currentValue = int.Parse(enumList[i].Value.ToString());
                    if (IsPowerOfTwo(currentValue))
                    {
                        highestValue = currentValue;
                        break;
                    }
                }
            }

            return highestValue;
        }

        private static TValue GetMaxValue()
        {
            var maxValueField = typeof(TValue)
                .GetField("MaxValue", BindingFlags.Public | BindingFlags.Static);

            if (maxValueField is null)
                throw new NotSupportedException(typeof(TValue).Name);

            var maxValue = (TValue) maxValueField.GetValue(null);

            return maxValue;
        }

        #endregion

        #region Keys and Values

        public IEnumerable<string> GetAllKeys() => _enumKeyMembers.Keys;

        public IEnumerable<TEnum> GetAllValues() => _enumKeyMembers.Values;

        #endregion
    }
}