namespace Cosmos.Reflection.Core;

internal class DefaultPropertyPathValueAccessor : IPropertyPathValueAccessor
{
    public DefaultPropertyPathValueAccessor(PropertyPath path, object instance)
    {
        if (!path.Path.Any())
            throw new ArgumentNullException(nameof(path.Path), "There is no property path in 'PropertyPath' object.");
        _property = path.Path.Last();
        _instance = instance;
    }

    private readonly PropertyInfo _property;
    private readonly object _instance;

    public object GetValue()
    {
        return _property.GetValue(_instance);
    }

    public void SetValue(object value)
    {
        _property.SetValue(_instance, value);
    }
}