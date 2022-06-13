namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Flag dynamic enum base <br />
/// 带 Flag 的动态枚举基类
/// </summary>
/// <typeparam name="TEnum"></typeparam>
// ReSharper disable once RedundantExtendsListEntry
public abstract class DynamicFlagEnum<TEnum> : DynamicFlagEnum<TEnum, int>, IDynamicEnum
    where TEnum : DynamicFlagEnum<TEnum, int>, IDynamicEnum
{
    protected DynamicFlagEnum(string name, int value) : base(name, value) { }
}