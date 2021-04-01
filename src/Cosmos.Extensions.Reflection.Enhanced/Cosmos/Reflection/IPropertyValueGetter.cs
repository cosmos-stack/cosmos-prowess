using System;
using System.Reflection;

namespace Cosmos.Reflection
{
    public interface IPropertyValueGetter 
    {
        object Invoke(Type type, object that, string propertyName);
        object Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr);
    }
}