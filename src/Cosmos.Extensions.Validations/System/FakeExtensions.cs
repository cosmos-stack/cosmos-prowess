namespace System
{
    internal static class FakeExtensions
    {
                    
        //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
        // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
        // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
        // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 TryGetPropertyValue 扩展方法
        
        public static bool TryGetPropertyValue(this object obj, string propertyName, out object result)
        {
            result = null;
            return false;
        }
                    
        //TODO 此处，我们将使用 Cosmos.Extensions.ObjectVisitor 来达成目的
        // 注意，Cosmos.Extensions.ObjectVisitor 将与 LeoVisitor 共用一套代码
        // 注意，我们将在 Cosmos.Extensions.ObjectVisitor 中使用 Cosmos.Validation（而不是 LeoVisitor 中的验证器）
        // 注意，此处的代码不可用，我们目前使用的是 Fake 版本的 GetPropertyValueQuickly 扩展方法
        
        public static T GetPropertyValueQuickly<T>(this object obj, string propertyName, bool what)
        {
            // 注意，此处我们使用异常抛出，原因是触发 Try 组件的失败流程并返回 Failure 包装器。
            throw new ArgumentException();
        }
    }
}