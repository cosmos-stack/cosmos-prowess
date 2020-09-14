using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Dynamic
{
    /// <summary>
    /// Dynamic Enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public abstract partial class DynamicEnum<TEnum, TValue> :
        IDynamicEnum,
        IEquatable<DynamicEnum<TEnum, TValue>>,
        IComparable<DynamicEnum<TEnum, TValue>>
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly string _name;
        private readonly TValue _value;

        protected DynamicEnum(string name, TValue value)
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

        public IEnumerable<string> GetAllKeys() => DynamicEnumManager.GetMembers<TEnum, TValue>().GetAllKeys();

        public IEnumerable<TEnum> GetAllValues() => DynamicEnumManager.GetMembers<TEnum, TValue>().GetAllValues();

        public override string ToString() => _name;

        public override int GetHashCode() => _value.GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is DynamicEnum<TEnum, TValue> other && Equals(other);
        }

        public virtual bool Equals(DynamicEnum<TEnum, TValue> other)
        {
            // check if same instance
            if (ReferenceEquals(this, other))
                return true;

            // it's not same instance so 
            // check if it's not null and is same value
            if (other is null)
                return false;

            return _value.Equals(other._value);
        }

        public static bool operator ==(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            return !(left == right);
        }

        public virtual int CompareTo(DynamicEnum<TEnum, TValue> other)
        {
            return _value.CompareTo(other._value);
        }

        public static bool operator <(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(DynamicEnum<TEnum, TValue> left, DynamicEnum<TEnum, TValue> right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static implicit operator TValue(DynamicEnum<TEnum, TValue> dynamicEnum)
        {
            return dynamicEnum._value;
        }

        public static explicit operator DynamicEnum<TEnum, TValue>(TValue value)
        {
            return FromValue(value).FirstOrDefault();
        }

        public DynamicEnumWhen<TEnum, TValue> When(DynamicEnum<TEnum, TValue> dynamicEnumWhen)
        {
            return new DynamicEnumWhen<TEnum, TValue>(Equals(dynamicEnumWhen), false, this);
        }

        public DynamicEnumWhen<TEnum, TValue> When(params DynamicEnum<TEnum, TValue>[] dynamicEnumWhens)
        {
            return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
        }

        public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<DynamicEnum<TEnum, TValue>> dynamicEnumWhens)
        {
            return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
        }
    }
}