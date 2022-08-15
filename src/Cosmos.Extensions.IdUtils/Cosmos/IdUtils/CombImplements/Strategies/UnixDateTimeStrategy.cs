// ReSharper disable InconsistentNaming

namespace Cosmos.IdUtils.CombImplements.Strategies;

internal class UnixDateTimeStrategy : IDateStrategy
{
    private const long TICKS_PER_MILLISECOND = 10_000;
    public int NumDateBytes => 6;

    public DateTime MinDateTimeValue { get; } = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    public DateTime MaxDateTimeValue => MinDateTimeValue.AddMilliseconds(2 ^ (8 * NumDateBytes));

    public byte[] DateTimeToBytes(DateTime timestamp)
    {
        var ms = ToUnixTmeMilliseconds(timestamp);
        var msBytes = BitConverter.GetBytes(ms);

        BitConverter.IsLittleEndian.IfTrue(() => Array.Reverse(msBytes));

        var ret = new byte[NumDateBytes];
        var index = msBytes.GetUpperBound(0) + 1 - NumDateBytes;

        Array.Copy(msBytes, index, ret, 0, NumDateBytes);

        return ret;
    }

    public DateTime BytesToDateTime(byte[] value)
    {
        var msBytes = new byte[8];
        var index = 8 - NumDateBytes;

        Array.Copy(value, 0, msBytes, index, NumDateBytes);

        BitConverter.IsLittleEndian.IfTrue(() => Array.Reverse(msBytes));

        var ms = BitConverter.ToInt64(msBytes, 0);

        return FromUnixTimeMilliseconds(ms);
    }

    private long ToUnixTmeMilliseconds(DateTime timestamp) => (timestamp.Ticks - MinDateTimeValue.Ticks) / TICKS_PER_MILLISECOND;

    private DateTime FromUnixTimeMilliseconds(long ms) => MinDateTimeValue.AddTicks(ms * TICKS_PER_MILLISECOND);
}