namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Dynamic Enum Utilities <br />
/// 动态枚举工具
/// </summary>
public static class DynamicEnums
{
    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TEnum FromName<TEnum, TValue>(string name)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromName(name);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreCase"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TEnum FromName<TEnum, TValue>(string name, bool ignoreCase)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromName(name, ignoreCase);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TEnum> FromValue<TEnum, TValue>(TValue value)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromValue(value);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static IEnumerable<TEnum> FromValue<TEnum, TValue>(TValue value, IEnumerable<TEnum> defaultVal)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromValue(value, defaultVal);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一个成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TEnum FromValueSingle<TEnum, TValue>(TValue value)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromValueSingle(value);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一个成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TEnum FromValueSingle<TEnum, TValue>(TValue value, TEnum defaultVal)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromValueSingle(value, defaultVal);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the corresponding member, obtain the name of the dynamic enumeration value. <br />
    /// 根据动态枚举类型和对应的成员，获取动态枚举值的名称。
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string FromValueToString<TEnum, TValue>(TValue value)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.FromValueToString(value);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, try to get the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，尝试获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="result"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool TryFromName<TEnum, TValue>(string name, out TEnum result)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.TryFromName(name, out result);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, try to get the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，尝试获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="result"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool TryFromName<TEnum, TValue>(string name, bool ignoreCase, out TEnum result)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.TryFromName(name, ignoreCase, out result);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, try to obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，尝试获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="results"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool TryFromValue<TEnum, TValue>(TValue value, out List<TEnum> results)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.TryFromValue(value, out results);
    }

    /// <summary>
    /// According to the dynamic enumeration type and corresponding members, try to obtain the name of the dynamic enumeration value. <br />
    /// 根据动态枚举类型和对应的成员，尝试获取动态枚举值的名称。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool TryFromValueToString<TEnum, TValue>(TValue value, out string result)
        where TEnum : DynamicEnum<TEnum, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        return DynamicEnum<TEnum, TValue>.TryFromValueToString(value, out result);
    }
}