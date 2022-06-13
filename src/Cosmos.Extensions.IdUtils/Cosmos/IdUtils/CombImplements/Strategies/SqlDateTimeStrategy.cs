using Cosmos.Collections;
using Cosmos.Numeric;

// ReSharper disable InconsistentNaming

namespace Cosmos.IdUtils.CombImplements.Strategies;

internal class SqlDateTimeStrategy : IDateStrategy
{
    private const double TICKS_PER_DAY = 86_400d * 300d;
    private const double TICKS_PER_MILLISECOND = 3d / 10d;

    public int NumDateBytes => 6;

    public DateTime MinDateTimeValue { get; } = new(1900, 1, 1);

    public DateTime MaxDateTimeValue => MinDateTimeValue.AddDays(NumericConstants.USHORT_MAX);

    public byte[] DateTimeToBytes(DateTime timestamp)
    {
        var ticks = (int)(timestamp.TimeOfDay.TotalMilliseconds * TICKS_PER_MILLISECOND);
        var days = (ushort)(timestamp - MinDateTimeValue).TotalDays;
        var tickBytes = BitConverter.GetBytes(ticks);
        var dayBytes = BitConverter.GetBytes(days);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(dayBytes);
            Array.Reverse(tickBytes);
        }

        var ret = new byte[NumDateBytes];
        dayBytes.Copy(0, ret, 0, 2);
        tickBytes.Copy(0, ret, 2, 4);

        return ret;
    }

    public DateTime BytesToDateTime(byte[] value)
    {
        var dayBytes = new byte[2];
        var tickBytes = new byte[4];
        value.Copy(0, dayBytes, 0, 2);
        value.Copy(2, tickBytes, 0, 4);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(dayBytes);
            Array.Reverse(tickBytes);
        }

        var days = BitConverter.ToUInt16(dayBytes, 0);
        var ticks = BitConverter.ToInt32(tickBytes, 0);

        if (ticks < 0f)
        {
            throw new ArgumentException("Not a COMB, time component is negative.");
        }
        else if (ticks > TICKS_PER_DAY)
        {
            throw new ArgumentException("Not a COMB, time component exceeds 24 hours.");
        }

        // ReSharper disable once RedundantCast
        return MinDateTimeValue.AddDays(days).AddMilliseconds((double)ticks / TICKS_PER_MILLISECOND);
    }
}