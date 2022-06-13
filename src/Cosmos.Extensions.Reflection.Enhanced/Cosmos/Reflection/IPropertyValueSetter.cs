namespace Cosmos.Reflection;

/// <summary>
/// Property Value Setter <br />
/// 属性值设置器接口
/// </summary>
public interface IPropertyValueSetter
{
    /// <summary>
    /// Invoke <br />
    /// 调用
    /// </summary>
    /// <param name="type"></param>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="value"></param>
    void Invoke(Type type, object that, string propertyName, object value);

    /// <summary>
    /// Invoke <br />
    /// 调用
    /// </summary>
    /// <param name="type"></param>
    /// <param name="that"></param>
    /// <param name="propertyName"></param>
    /// <param name="bindingAttr"></param>
    /// <param name="value"></param>
    void Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr, object value);
}