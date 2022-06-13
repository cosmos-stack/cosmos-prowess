using Cosmos.Collections;
using Cosmos.Date;

namespace Cosmos.IdUtils.GuidImplements;

/// <summary>
/// Unix timestamp style provider
/// </summary>
public static class UnixTimeStampStyleProvider
{
    private static DateTime GetUnixUtcNow() => new UnixTimeStamp(DateTime.UtcNow).ToDateTime();
    private static DateTime GetNoRepeatUnixUtcNow() => NoRepeatTimeStampManager.GetFactory().GetUtcUnixTimeStampObject().ToDateTime();

    /// <summary>
    /// Create
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create()
        => Create(NoRepeatMode.Off);

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(Guid value)
        => Create(value, NoRepeatMode.Off);

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(NoRepeatMode mode)
        => Create(Guid.NewGuid(), mode);

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="value"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(Guid value, NoRepeatMode mode)
        => Create(value, mode == NoRepeatMode.On ? GetNoRepeatUnixUtcNow() : GetUnixUtcNow());

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="secureTimestamp"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(DateTime secureTimestamp)
        => Create(Guid.NewGuid(), secureTimestamp);

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="value"></param>
    /// <param name="secureTimestamp"></param>
    /// <returns></returns>
    public static Guid Create(Guid value, DateTime secureTimestamp)
    {
        byte[] guidArray = value.ToByteArray();
        DateTime basedTime = new DateTime(1_900, 1, 1);

        //To get the number of day and ms
        TimeSpan days = new TimeSpan(secureTimestamp.Ticks - basedTime.Ticks);
        TimeSpan msecs = new TimeSpan(secureTimestamp.Ticks - (new DateTime(secureTimestamp.Year, secureTimestamp.Month, secureTimestamp.Day).Ticks));

        //Convert to byte array
        byte[] daysArray = BitConverter.GetBytes(days.Days);
        byte[] msecsArray = BitConverter.GetBytes((long) (msecs.TotalMilliseconds / 3.333_333));

        //Reserve byte
        Array.Reverse(daysArray);
        Array.Reverse(msecsArray);

        //Copy bytes into Guid
        daysArray.Copy(daysArray.Length - 2, guidArray, guidArray.Length - 6, 2);
        msecsArray.Copy(msecsArray.Length - 4, guidArray, guidArray.Length - 4, 4);

        return new Guid(guidArray);
    }
}