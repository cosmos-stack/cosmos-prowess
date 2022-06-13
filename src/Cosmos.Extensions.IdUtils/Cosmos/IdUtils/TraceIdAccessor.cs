namespace Cosmos.IdUtils;

/// <summary>
/// Trace Id Accessor <br />
/// Trace Id 获取器
/// </summary>
public sealed class TraceIdAccessor
{
    private static readonly ITraceIdMaker DefaultMaker = new DefaultTraceIdMaker();
    private readonly string _id;

    /// <summary>
    /// Create a new <see cref="TraceIdAccessor"/> instance.
    /// </summary>
    /// <param name="maker"></param>
    public TraceIdAccessor(ITraceIdMaker maker)
    {
        _id = maker is null ? DefaultMaker.CreateId() : maker.CreateId();
    }

    /// <summary>
    /// Get Trace Id <br />
    /// 获取一个 Trace Id
    /// </summary>
    /// <returns></returns>
    public string GetTraceId() => _id;
}