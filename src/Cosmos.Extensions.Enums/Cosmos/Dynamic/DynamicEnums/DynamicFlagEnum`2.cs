using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;

namespace Cosmos.Dynamic.DynamicEnums
{
    public abstract partial class DynamicFlagEnum<TEnum, TValue> : IDynamicEnum,
        IEquatable<DynamicFlagEnum<TEnum, TValue>>,
        IComparable<DynamicFlagEnum<TEnum, TValue>>
        where TEnum : DynamicFlagEnum<TEnum, TValue>, IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly string _name;
        private readonly TValue _value;

        protected DynamicFlagEnum(string name, TValue value)
        {
            if (string.IsNullOrEmpty(name))
                DynamicExceptionHelper.ThrowArgumentNullOrEmptyException(nameof(name));
            if (value is null)
                DynamicExceptionHelper.ThrowArgumentNullException(nameof(value));

            _name = name;
            _value = value;
        }

        /// <summary>
        /// Get value's type.
        /// </summary>
        /// <returns></returns>
        public Type GetValueType() => typeof(TValue);

        public string Name => _name;

        public TValue Value => _value;

        public IEnumerable<string> GetAllKeys() => DynamicEnumManager.GetFlagMembers<TEnum, TValue>().GetAllKeys().AsReadOnly();

        public IEnumerable<TEnum> GetAllValues() => DynamicEnumManager.GetFlagMembers<TEnum, TValue>().GetAllValues().AsReadOnly();

        public override string ToString() => _name;

        public override int GetHashCode() => _value.GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is DynamicFlagEnum<TEnum, TValue> other && Equals(other);
        }

        public virtual bool Equals(DynamicFlagEnum<TEnum, TValue> other)
        {
            // check if same instance
            if (object.ReferenceEquals(this, other))
                return true;

            // it's not same instance so 
            // check if it's not null and is same value
            if (other is null)
                return false;

            return _value.Equals(other._value);
        }

        public static bool operator ==(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            return !(left == right);
        }

        public virtual int CompareTo(DynamicFlagEnum<TEnum, TValue> other)
        {
            return _value.CompareTo(other._value);
        }

        public static bool operator <(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(DynamicFlagEnum<TEnum, TValue> left, DynamicFlagEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static implicit operator TValue(DynamicFlagEnum<TEnum, TValue> dynamicFlagEnum)
        {
            return dynamicFlagEnum._value;
        }

        public static explicit operator DynamicFlagEnum<TEnum, TValue>(TValue value)
        {
            return FromValue(value).First();
        }
        
        public DynamicEnumWhen<TEnum, TValue> When(DynamicFlagEnum<TEnum, TValue> dynamicEnumWhen)
        {
            return new DynamicEnumWhen<TEnum, TValue>(Equals(dynamicEnumWhen), false, this);
        }

        public DynamicEnumWhen<TEnum, TValue> When(params DynamicFlagEnum<TEnum, TValue>[] dynamicEnumWhens)
        {
            return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
        }

        public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<DynamicFlagEnum<TEnum, TValue>> dynamicEnumWhens)
        {
            return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
        }
    }
}