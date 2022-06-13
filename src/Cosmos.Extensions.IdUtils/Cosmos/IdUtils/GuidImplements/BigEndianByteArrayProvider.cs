using Cosmos.IdUtils.GuidImplements.Internals;

namespace Cosmos.IdUtils.GuidImplements;

internal static class BigEndianByteArrayProvider
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid Create(byte[] bytes) => new(GuidUtility.CopyWithEndianSwap(bytes));
}