using System.Reflection;

namespace Cosmos.Reflection
{
    public interface IPropertyValueAccessor
    {
        object GetValue(string propertyName);
        object GetValue(string propertyName, BindingFlags bindingAttr);
        void SetValue(string propertyName, object value);
        void SetValue(string propertyName, BindingFlags bindingAttr, object value);
    }
}