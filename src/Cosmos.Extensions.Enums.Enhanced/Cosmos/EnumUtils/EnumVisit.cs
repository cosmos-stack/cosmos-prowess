namespace Cosmos.EnumUtils;

/// <summary>
/// Enum Visit <br />
/// 枚举访问器
/// </summary>
public static class EnumVisit
{
    #region IsEnum

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum<T>()
    {
        return Types.IsEnumType<T>();
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum(Type type)
    {
        return Types.IsEnumType(type);
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum(MemberInfo info)
    {
        return TypeReflections.IsEnum(info);
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum(PropertyInfo info)
    {
        return TypeReflections.IsEnum(info);
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum(object value, Type type)
    {
        return IsEnum(value, type, EnumVisitOptions.For.Default());
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static bool IsEnum(object value, Type type, IEnumVisitOptions options)
    {
        var optionsVal = options.Value;

        return optionsVal switch
        {
            0 => IsEnum(type),
            1 => Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
            2 => IsEnum(type) || Try.Create(() => EnumsNET.Enums.IsValid(type, value)).IsSuccess,
            _ => false
        };
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum<T>(T value)
    {
        return IsEnum(value, typeof(T));
    }

    /// <summary>
    /// Indicates whether the given type is an enumerated type <br />
    /// 指示给定的类型是否为枚举类型
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum<T>(T value, IEnumVisitOptions options)
    {
        return IsEnum(value, typeof(T), options);
    }

    #endregion
}