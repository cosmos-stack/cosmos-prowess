namespace Cosmos.Reflection
{
    public interface IPropertyPathValueAccessor
    {
        object GetValue();
        void SetValue(object value);
    }
}