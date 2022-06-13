namespace Cosmos.Reflection;

/// <summary>
/// Property path value accessor <br />
/// 带路径的属性值访问器
/// </summary>
public interface IPropertyPathValueAccessor
{
    /// <summary>
    /// Get value <br />
    /// 获取值
    /// </summary>
    /// <returns></returns>
    object GetValue();

    /// <summary>
    /// Set value <br />
    /// 设置值
    /// </summary>
    /// <param name="value"></param>
    void SetValue(object value);
}