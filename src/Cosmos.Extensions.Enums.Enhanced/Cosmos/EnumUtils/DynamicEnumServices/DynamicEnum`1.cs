namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Dynamic Enum base <br />
/// 动态枚举基类
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public abstract class DynamicEnum<TEnum> : DynamicEnum<TEnum, int>
    where TEnum : DynamicEnum<TEnum, int>, IDynamicEnum
{
    protected DynamicEnum(string name, int value) : base(name, value) { }
}