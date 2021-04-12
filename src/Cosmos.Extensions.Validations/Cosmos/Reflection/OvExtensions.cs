namespace Cosmos.Reflection
{
    internal static class OvExtensions
    {
        static OvExtensions()
        {
#if !NETFRAMEWORK
            NatashaInitializer.InitializeAndPreheating();

#endif
        }
        
        public static bool TryGetPropertyValue(this object obj, string propertyName, out object result)
        {
            try
            {
                result = obj.ToVisitor().GetValue(propertyName);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
        
        public static T GetPropertyValueQuickly<T>(this object obj, string propertyName)
        {
            return obj.ToVisitor().GetValue<T>(propertyName);
        }
    }
}