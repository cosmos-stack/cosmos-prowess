namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Allow unsafe flag enum value attribute <br />
/// 允许使用 Flag 枚举值特性
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class AllowUnsafeFlagEnumValuesAttribute : Attribute { }