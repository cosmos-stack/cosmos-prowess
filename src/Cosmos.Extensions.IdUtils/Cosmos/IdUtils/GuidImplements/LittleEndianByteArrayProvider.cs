using System;
using System.Runtime.CompilerServices;

namespace Cosmos.IdUtils.GuidImplements
{
    internal static class LittleEndianByteArrayProvider
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Create(byte[] bytes) => new(bytes);
    }
}