using System;
using System.Reflection;
using Cosmos.Reflection.Core;

namespace Cosmos.Reflection
{
    public abstract class PropertyValueSetter : IPropertyValueSetter
    {
        private readonly Action<Type, object, string, BindingFlags, object> _implementationFunc;

        protected PropertyValueSetter(Action<Type, object, string, BindingFlags, object> implementationFunc)
        {
            _implementationFunc = implementationFunc ?? DefaultPropertyValueSetter.DefaultFunc;
        }

        public virtual void Invoke(Type type, object that, string propertyName, object value)
        {
            _implementationFunc(type, that, propertyName, DefaultPropertyValueGetter.Flags, value);
        }

        public virtual void Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr, object value)
        {
            _implementationFunc(type, that, propertyName, bindingAttr, value);
        }
        
        public static IPropertyValueSetter Instance => DefaultPropertyValueSetter.Instance;
    }
}