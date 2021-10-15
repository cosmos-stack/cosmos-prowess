using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.IdUtils.GuidImplements
{
    internal static class LittleEndianByteArrayProvider
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Create(byte[] bytes) => new(bytes);
    }
}