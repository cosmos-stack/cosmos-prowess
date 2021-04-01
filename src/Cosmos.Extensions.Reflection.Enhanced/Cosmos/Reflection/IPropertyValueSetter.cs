using System;
using System.Reflection;

namespace Cosmos.Reflection
{
    public interface IPropertyValueSetter
    {
        void Invoke(Type type, object that, string propertyName, object value);

        void Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr, object value);
    }
}