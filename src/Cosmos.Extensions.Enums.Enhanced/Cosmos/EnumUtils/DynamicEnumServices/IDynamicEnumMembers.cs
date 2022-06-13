namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Dynamic Enum Member <br />
/// 动态枚举成员
/// </summary>
internal interface IDynamicEnumMembers
{
    /// <summary>
    /// Type of enum <br />
    /// 枚举之类型
    /// </summary>
    Type EnumType { get; }
}