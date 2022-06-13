namespace Cosmos.IdUtils;

/// <summary>
/// Default TraceIdMaker <br />
/// 默认的 Trace Id 生成器
/// </summary>
public class DefaultTraceIdMaker : ITraceIdMaker
{
    /// <summary>
    /// Create Id <br />
    /// 创建 Id
    /// </summary>
    /// <returns></returns>
    public string CreateId()
    {
        var now = DateTime.Now;
        return $"{now:yyyyMMddHHmmddffff}{RandomIdGenerator.Create(7)}{now.Ticks}";
    }
}