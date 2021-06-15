using System;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection.Core
{
    internal class DefaultPropertyValueGetter : PropertyValueGetter
    {
        public static readonly Func<Type, object, string, BindingFlags, object> DefaultFunc = (t, o, s, b) =>
        {
            var property = t.GetProperty(s, b);
            var isStatic = property?.GetGetMethod()?.IsStatic
                        ?? property?.GetSetMethod()?.IsStatic
                        ?? throw new ArgumentException("The specified property was not found.");
            return isStatic
                ? property.GetReflector().GetStaticValue()
                : property.GetReflector().GetValue(o);
        };

        public static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

        private DefaultPropertyValueGetter() : base(DefaultFunc) { }

        public new static IPropertyValueGetter Instance { get; } = new DefaultPropertyValueGetter();
    }

    internal class NestPropertyValueGetter : PropertyValueGetter
    {
        public NestPropertyValueGetter(Func<Type, object, string, BindingFlags, object> implementationFunc)
            : base(implementationFunc) { }
    }
}