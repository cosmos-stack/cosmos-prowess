namespace Cosmos.IdUtils.GuidImplements;

internal static class EquifaxStyleProvider
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create()
        => Create(DateTime.UtcNow);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(NoRepeatMode mode)
        => Create(mode == NoRepeatMode.On ? NoRepeatTimeStampManager.GetFactory().GetUtcTimeStamp() : DateTime.UtcNow);

    public static Guid Create(DateTime secureTimestamp)
        => new($"00000000-0000-0000-0000-00" +
               $"{secureTimestamp.Month:00}" +
               $"{secureTimestamp.Day:00}" +
               $"{secureTimestamp.Year % 100:00}" +
               $"{secureTimestamp.Hour:00}" +
               $"{secureTimestamp.Minute:00}");
}