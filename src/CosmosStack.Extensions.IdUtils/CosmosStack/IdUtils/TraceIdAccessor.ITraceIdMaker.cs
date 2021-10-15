namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Trace Maker Interface <br />
    /// Trace Id 生成器接口
    /// </summary>
    public interface ITraceIdMaker
    {
        /// <summary>
        /// Create Id <br />
        /// 生成 Id
        /// </summary>
        /// <returns></returns>
        string CreateId();
    }
}