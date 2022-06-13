using Cosmos.Collections;

namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Flag dynamic enum base <br />
/// 带 Flag 的动态枚举基类
/// </summary>
/// <typeparam name="TEnum"></typeparam>
/// <typeparam name="TValue"></typeparam>
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

    /// <inheritdoc />
    public Type GetValueType() => typeof(TValue);

    /// <inheritdoc />
    public string Name => _name;

    /// <summary>
    /// Gets value <br />
    /// 获取值
    /// </summary>
    public TValue Value => _value;

    /// <summary>
    /// Gets all keys <br />
    /// 获取所有键
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> GetAllKeys() => DynamicEnumManager.GetFlagMembers<TEnum, TValue>().GetAllKeys().AsReadOnly();

    /// <summary>
    /// Gets all values <br />
    /// 获取所有值
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TEnum> GetAllValues() => DynamicEnumManager.GetFlagMembers<TEnum, TValue>().GetAllValues().AsReadOnly();

    /// <inheritdoc />
    public override string ToString() => _name;

    /// <inheritdoc />
    public override int GetHashCode() => _value.GetHashCode();

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        return obj is DynamicFlagEnum<TEnum, TValue> other && Equals(other);
    }

    /// <inheritdoc />
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
        return Enumerable.First<TEnum>(FromValue(value));
    }

    /// <summary>
    /// Returns an instance of <see cref="DynamicEnumWhen{TEnum, TValue}"/> that allows the given behavior to be performed when the given enumeration value is matched. <br />
    /// 返回一个 <see cref="DynamicEnumWhen{TEnum, TValue}"/> 实例，当匹配给定的枚举值时，允许执行给定的行为。
    /// </summary>
    /// <param name="dynamicEnumWhen"></param>
    /// <returns></returns>
    public DynamicEnumWhen<TEnum, TValue> When(DynamicFlagEnum<TEnum, TValue> dynamicEnumWhen)
    {
        return new DynamicEnumWhen<TEnum, TValue>(Equals(dynamicEnumWhen), false, this);
    }

    /// <summary>
    /// Returns an instance of <see cref="DynamicEnumWhen{TEnum, TValue}"/> that allows the given behavior to be performed when the given enumeration value is matched. <br />
    /// 返回一个 <see cref="DynamicEnumWhen{TEnum, TValue}"/> 实例，当匹配给定的枚举值时，允许执行给定的行为。
    /// </summary>
    /// <param name="dynamicEnumWhens"></param>
    /// <returns></returns>
    public DynamicEnumWhen<TEnum, TValue> When(params DynamicFlagEnum<TEnum, TValue>[] dynamicEnumWhens)
    {
        return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
    }

    /// <summary>
    /// Returns an instance of <see cref="DynamicEnumWhen{TEnum, TValue}"/> that allows the given behavior to be performed when the given enumeration value is matched. <br />
    /// 返回一个 <see cref="DynamicEnumWhen{TEnum, TValue}"/> 实例，当匹配给定的枚举值时，允许执行给定的行为。
    /// </summary>
    /// <param name="dynamicEnumWhens"></param>
    /// <returns></returns>
    public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<DynamicFlagEnum<TEnum, TValue>> dynamicEnumWhens)
    {
        return new DynamicEnumWhen<TEnum, TValue>(dynamicEnumWhens.Contains(this), false, this);
    }
}