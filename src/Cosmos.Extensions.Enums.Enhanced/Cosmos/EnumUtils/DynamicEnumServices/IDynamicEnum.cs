namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// Dynamic Enum Interface <br />
/// 动态枚举接口
/// </summary>
public interface IDynamicEnum
{
    /// <summary>
    /// Get value's type. <br />
    /// 获取值的类型
    /// </summary>
    /// <returns></returns>
    Type GetValueType();

    /// <summary>
    /// Name <br />
    /// 名称
    /// </summary>
    string Name { get; }
}