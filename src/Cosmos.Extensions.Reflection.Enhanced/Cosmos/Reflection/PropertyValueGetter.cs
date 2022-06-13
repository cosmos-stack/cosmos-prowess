using Cosmos.Reflection.Core;

namespace Cosmos.Reflection;

/// <summary>
/// Property value getter <br />
/// 属性值读取器
/// </summary>
public abstract class PropertyValueGetter : IPropertyValueGetter
{
    private readonly Func<Type, object, string, BindingFlags, object> _implementationFunc;

    protected PropertyValueGetter(Func<Type, object, string, BindingFlags, object> implementationFunc)
    {
        _implementationFunc = implementationFunc ?? DefaultPropertyValueGetter.DefaultFunc;
    }

    /// <inheritdoc />
    public virtual object Invoke(Type type, object that, string propertyName)
    {
        return _implementationFunc(type, that, propertyName, DefaultPropertyValueGetter.Flags);
    }

    /// <inheritdoc />
    public virtual object Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr)
    {
        return _implementationFunc(type, that, propertyName, bindingAttr);
    }

    /// <summary>
    /// Get an instance of <see cref="IPropertyValueGetter"/> <br />
    /// 获取一个 <see cref="IPropertyValueGetter"/> 实例
    /// </summary>
    public static IPropertyValueGetter Instance => DefaultPropertyValueGetter.Instance;
}