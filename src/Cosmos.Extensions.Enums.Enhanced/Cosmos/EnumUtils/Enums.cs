using Cosmos.Collections;

namespace Cosmos.EnumUtils;

/// <summary>
/// Enum Utilities <br />
/// 枚举工具
/// </summary>
public static class Enums
{
    #region Of

    /// <summary>
    /// Of <br />
    /// 将给定的字符串转换为对应枚举类型的值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TEnum Of<TEnum>(string member, bool ignoreCase = false, TEnum defaultVal = default) where TEnum : struct, Enum
        => EnumConv.ToEnum(member, ignoreCase, defaultVal);

    /// <summary>
    /// Of <br />
    /// 将给定的对象转换为对应枚举类型的值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TEnum Of<TEnum>(object member, TEnum defaultVal = default) where TEnum : struct, Enum
        => EnumConv.ToEnum(member, defaultVal);

    /// <summary>
    /// Of <br />
    /// 将给定的字符串转换为对应枚举类型的值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="enumType"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object Of(string member, Type enumType, bool ignoreCase = false, object defaultVal = default)
        => EnumConv.ToEnum(member, enumType, ignoreCase, defaultVal);

    /// <summary>
    /// Of <br />
    /// 将给定的对象转换为对应枚举类型的值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="enumType"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object Of(object member, Type enumType, object defaultVal = default)
        => EnumConv.ToEnum(member, enumType, defaultVal);

    #endregion

    #region NameOf

    /// <summary>
    /// Name of <br />
    /// 获取给定枚举值的名称
    /// </summary>
    /// <param name="member"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NameOf<TEnum>(TEnum member) where TEnum : struct, Enum
    {
        return EnumsNET.Enums.GetName(member) ?? string.Empty;
    }

    /// <summary>
    /// Name of <br />
    /// 获取给定枚举值的名称
    /// </summary>
    /// <param name="enumType"></param>
    /// <param name="member"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NameOf(Type enumType, object member)
    {
        return EnumsNET.Enums.GetName(enumType, member) ?? string.Empty;
    }

    #endregion

    #region DescriptionOf

    /// <summary>
    /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
    /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
    /// </summary>
    /// <param name="member"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string DescriptionOf<TEnum>(TEnum member) where TEnum : struct, Enum
    {
        return TypeReflections.GetDescription<TEnum>(NameOf(member));
    }

    /// <summary>
    /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
    /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
    /// </summary>
    /// <param name="enumType"></param>
    /// <param name="member"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string DescriptionOf(Type enumType, object member)
    {
        return TypeReflections.GetDescription(enumType, NameOf(enumType, member));
    }

    #endregion

    #region Count

    /// <summary>
    /// Counts the number of enums values contained in a given enum type. <br />
    /// 计算给定枚举类型中包含的枚举值的数量。
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count<TEnum>() where TEnum : struct, Enum
    {
        return EnumsNET.Enums.GetMembers<TEnum>().Count;
    }

    #endregion

    #region Values

    /// <summary>
    /// Get values <br />
    /// 从给定枚举类型中获取一组枚举值
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, Enum
    {
        return EnumsNET.Enums.GetValues<TEnum>();
    }

    /// <summary>
    /// Get values <br />
    /// 从给定枚举类型中获取一组枚举值
    /// </summary>
    /// <param name="enumType"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<object> GetValues(Type enumType)
    {
        return EnumsNET.Enums.GetValues(enumType);
    }

    #endregion

    #region RandomValue

    /// <summary>
    /// Random value <br />
    /// 根据给定的枚举类型，随机获得一个枚举的值
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TEnum RandomValue<TEnum>() where TEnum : struct, Enum
    {
        return EnumsNET.Enums.GetValues<TEnum>().OrderByRandom().FirstOrDefault();
    }

    #endregion
}