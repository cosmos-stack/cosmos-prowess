namespace Cosmos.Reflection.Core;

internal class DefaultPropertyValueSetter : PropertyValueSetter
{
    public static readonly Action<Type, object, string, BindingFlags, object> DefaultFunc = (t, o, s, b, v) =>
    {
        var property = t.GetProperty(s, b);
        var isStatic = property?.GetGetMethod()?.IsStatic
                    ?? property?.GetSetMethod()?.IsStatic
                    ?? throw new ArgumentException("The specified property was not found.");
        if (isStatic)
            property.GetReflector().SetStaticValue(v);
        else
            property.GetReflector().SetValue(o, v);
    };

    public static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

    private DefaultPropertyValueSetter() : base(DefaultFunc) { }

    public new static IPropertyValueSetter Instance { get; } = new DefaultPropertyValueSetter();
}

internal class NestPropertyValueSetter : PropertyValueSetter
{
    public NestPropertyValueSetter(Action<Type, object, string, BindingFlags, object> implementationFunc) : base(implementationFunc) { }
}