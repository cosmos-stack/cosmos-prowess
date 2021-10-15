using System;
using System.Reflection;
using CosmosStack.Reflection.Core;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// Property value setter <br />
    /// 属性值设置器
    /// </summary>
    public abstract class PropertyValueSetter : IPropertyValueSetter
    {
        private readonly Action<Type, object, string, BindingFlags, object> _implementationFunc;

        protected PropertyValueSetter(Action<Type, object, string, BindingFlags, object> implementationFunc)
        {
            _implementationFunc = implementationFunc ?? DefaultPropertyValueSetter.DefaultFunc;
        }

        /// <inheritdoc />
        public virtual void Invoke(Type type, object that, string propertyName, object value)
        {
            _implementationFunc(type, that, propertyName, DefaultPropertyValueGetter.Flags, value);
        }

        /// <inheritdoc />
        public virtual void Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr, object value)
        {
            _implementationFunc(type, that, propertyName, bindingAttr, value);
        }

        /// <summary>
        /// Get an instance of <see cref="IPropertyValueSetter"/> <br />
        /// 获取一个 <see cref="IPropertyValueSetter"/> 实例
        /// </summary>
        public static IPropertyValueSetter Instance => DefaultPropertyValueSetter.Instance;
    }
}