using System;
using System.Reflection;

namespace Cosmos.Reflection.Core
{
    internal class DefaultPropertyValueAccessor<T> : IPropertyValueAccessor
    {
        public DefaultPropertyValueAccessor(T instance,
            Func<Type, object, string, BindingFlags, object> getterImpl,
            Action<Type, object, string, BindingFlags, object> setterImpl)
        {
            _getter = getterImpl ?? DefaultPropertyValueGetter.DefaultFunc;
            _setter = setterImpl ?? DefaultPropertyValueSetter.DefaultFunc;
            _type = typeof(T);
            _instance = instance;
        }

        public DefaultPropertyValueAccessor(T instance, IPropertyValueGetter getter, IPropertyValueSetter setter)
        {
            _getter = getter is not null ? getter.Invoke : DefaultPropertyValueGetter.DefaultFunc;
            _setter = setter is not null ? setter.Invoke : DefaultPropertyValueSetter.DefaultFunc;
            _type = typeof(T);
            _instance = instance;
        }

        private readonly Func<Type, object, string, BindingFlags, object> _getter;
        private readonly Action<Type, object, string, BindingFlags, object> _setter;
        private readonly Type _type;
        private readonly T _instance;

        public object GetValue(string propertyName)
        {
            return _getter.Invoke(_type, _instance, propertyName, DefaultPropertyValueGetter.Flags);
        }

        public object GetValue(string propertyName, BindingFlags bindingAttr)
        {
            return _getter(_type, _instance, propertyName, bindingAttr);
        }

        public void SetValue(string propertyName, object value)
        {
            _setter.Invoke(_type, _instance, propertyName, DefaultPropertyValueSetter.Flags, value);
        }

        public void SetValue(string propertyName, BindingFlags bindingAttr, object value)
        {
            _setter.Invoke(_type, _instance, propertyName, bindingAttr, value);
        }
    }
}