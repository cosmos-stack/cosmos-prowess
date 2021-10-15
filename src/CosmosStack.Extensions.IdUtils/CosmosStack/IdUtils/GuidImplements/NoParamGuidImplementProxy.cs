using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.IdUtils.GuidImplements
{
    internal static class NoParamGuidImplementProxy
    {
        // ReSharper disable once RedundantArgumentDefaultValue
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Basic() => GuidProvider.Create(GuidStyle.BasicStyle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid SequentialAsString() => GuidProvider.Create(GuidStyle.SequentialAsStringStyle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid SequentialAsBinary() => GuidProvider.Create(GuidStyle.SequentialAsBinaryStyle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid SequentialAsEnd() => GuidProvider.Create(GuidStyle.SequentialAsEndStyle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid Equifax() => GuidProvider.Create(GuidStyle.EquifaxStyle);
    }
}