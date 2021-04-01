using System;
using System.Reflection;
using Cosmos.Reflection.Core;

namespace Cosmos.Reflection
{
    public abstract class PropertyValueGetter : IPropertyValueGetter
    {
        private readonly Func<Type, object, string, BindingFlags, object> _implementationFunc;

        protected PropertyValueGetter(Func<Type, object, string, BindingFlags, object> implementationFunc)
        {
            _implementationFunc = implementationFunc ?? DefaultPropertyValueGetter.DefaultFunc;
        }

        public virtual object Invoke(Type type, object that, string propertyName)
        {
            return _implementationFunc(type, that, propertyName, DefaultPropertyValueGetter.Flags);
        }

        public virtual object Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr)
        {
            return _implementationFunc(type, that, propertyName, bindingAttr);
        }

        public static IPropertyValueGetter Instance => DefaultPropertyValueGetter.Instance;
    }
}