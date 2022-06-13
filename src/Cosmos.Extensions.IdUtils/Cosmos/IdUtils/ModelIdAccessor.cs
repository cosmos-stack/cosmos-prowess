using Cosmos.Date;

namespace Cosmos.IdUtils;

/// <summary>
/// Model Id Accessor <br />
/// 模型 ID 获取器
/// </summary>
public sealed class ModelIdAccessor
{
    private NoRepeatTimeStampFactory _factory = new();
    private int Index { get; set; }
    private DateTime Now { get; set; }

    private readonly object _lockObj = new();

    /// <summary>
    /// Create a new <see cref="ModelIdAccessor"/> instance.
    /// </summary>
    public ModelIdAccessor()
    {
        Now = _factory.GetTimeStamp();
    }

    /// <summary>
    /// Get next index
    /// </summary>
    /// <returns></returns>
    public int GetNextIndex()
    {
        int ix;

        lock (_lockObj)
        {
            ix = Index;
            Index += 1;
        }

        return ix;
    }

    /// <summary>
    /// Get time spot
    /// </summary>
    /// <returns></returns>
    public DateTime GetTimeSpot() => Now;

    /// <summary>
    /// Refresh time spot
    /// </summary>
    public void RefreshTimeSpot() => Now = _factory.GetTimeStamp();
}