namespace Cosmos.Reflection;

/// <summary>
/// Property Value Accessor <br />
/// 属性值访问器
/// </summary>
public interface IPropertyValueAccessor
{
    /// <summary>
    /// Get value <br />
    /// 获取值
    /// </summary>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    object GetValue(string propertyName);

    /// <summary>
    /// Get Value <br />
    /// 获取值
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <returns></returns>
    object GetValue(string propertyName, BindingFlags bindingAttr);

    /// <summary>
    /// Set Value <br />
    /// 设置值
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    void SetValue(string propertyName, object value);

    /// <summary>
    /// Set Value <br />
    /// 设置值
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    void SetValue(string propertyName, BindingFlags bindingAttr, object value);
}