using System.Security.Cryptography;
using Cosmos.Collections;

namespace Cosmos.IdUtils.GuidImplements;

internal static class SequentialStylesProvider
{
    private static readonly RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(SequentialGuidTypes type)
        => Create(DateTime.UtcNow, type);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(SequentialGuidTypes type, NoRepeatMode mode)
        => Create(mode == NoRepeatMode.On ? NoRepeatTimeStampManager.GetFactory().GetUtcTimeStamp() : DateTime.UtcNow, type);

    public static Guid Create(DateTime secureTimestamp, SequentialGuidTypes type)
    {
        var rndBytes = new byte[10];
        RandomGenerator.GetBytes(rndBytes);

        var timestamp = secureTimestamp.Ticks / 1_000L;

        var timestampBytes = BitConverter.GetBytes(timestamp);

        BitConverter.IsLittleEndian.IfTrue(timestampBytes.Reverse);

        var guidBytes = new byte[16];

        switch (type)
        {
            case SequentialGuidTypes.SequentialAsString:
            case SequentialGuidTypes.SequentialAsBinary:
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                Buffer.BlockCopy(rndBytes, 0, guidBytes, 6, 10);

                if (type == SequentialGuidTypes.SequentialAsString && BitConverter.IsLittleEndian)
                {
                    Array.Reverse(guidBytes, 0, 4);
                    Array.Reverse(guidBytes, 4, 2);
                }

                break;

            case SequentialGuidTypes.SequentialAsEnd:
                Buffer.BlockCopy(rndBytes, 0, guidBytes, 0, 10);
                Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                break;
        }

        return new Guid(guidBytes);
    }
}