using Cosmos.Text.Joiners;

namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Dynamic Enum Base <br />
/// 动态枚举基类
/// </summary>
public abstract partial class DynamicEnum<TEnum, TValue>
{
    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static TEnum FromName(string name)
    {
        return TryFromName(name, out var result) ? result : default;
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreCase"></param>
    /// <returns></returns>
    public static TEnum FromName(string name, bool ignoreCase)
    {
        return TryFromName(name, ignoreCase, out var result) ? result : default;
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static IEnumerable<TEnum> FromValue(TValue value)
    {
        return FromValue(value, Enumerable.Empty<TEnum>());
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static IEnumerable<TEnum> FromValue(TValue value, IEnumerable<TEnum> defaultVal)
    {
        return TryFromValue(value, out var results) ? results : defaultVal;
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一个成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TEnum FromValueSingle(TValue value)
    {
        return FromValue(value).FirstOrDefault();
    }

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, obtain a member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，获取动态枚举的一个成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static TEnum FromValueSingle(TValue value, TEnum defaultVal)
    {
        return FromValue(value, new[] { defaultVal }).FirstOrDefault();
    }

    /// <summary>
    /// According to the dynamic enumeration type and the corresponding member, obtain the name of the dynamic enumeration value. <br />
    /// 根据动态枚举类型和对应的成员，获取动态枚举值的名称。
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FromValueToString(TValue value)
    {
        var valColl = FromValue(value);
        return Joiner.On(", ").SkipNulls().Join(valColl, val => val.Name);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryFromName(string name, out TEnum result)
    {
        return TryFromName(name, false, out result);
    }

    /// <summary>
    /// According to the dynamic enumeration type and the name of the given value, obtain the member value of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的值的名称，获取动态枚举的成员值。
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="result"></param>
    /// <returns></returns>
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

    /// <summary>
    /// According to the dynamic enumeration type and the value of the given underlying type, try to obtain a set of member values of the dynamic enumeration. <br />
    /// 根据动态枚举类型和给定的底层类型的值，尝试获取动态枚举的一组成员值。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="results"></param>
    /// <returns></returns>
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

    /// <summary>
    /// According to the dynamic enumeration type and corresponding members, try to obtain the name of the dynamic enumeration value. <br />
    /// 根据动态枚举类型和对应的成员，尝试获取动态枚举值的名称。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryFromValueToString(TValue value, out string result)
    {
        if (!TryFromValue(value, out var valColl))
        {
            result = default;
            return false;
        }
        else
        {
            result = Joiner.On(", ").SkipNulls().Join(valColl, val => val.Name);
            return true;
        }
    }
}