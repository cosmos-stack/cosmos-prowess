using System;
using System.Runtime.CompilerServices;
using CosmosStack.IdUtils.GuidImplements.Internals;

namespace CosmosStack.IdUtils.GuidImplements
{
    internal static class BigEndianByteArrayProvider
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Create(byte[] bytes) => new(GuidUtility.CopyWithEndianSwap(bytes));
    }
}