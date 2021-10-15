using System.Runtime.CompilerServices;
using CosmosStack.Date;
using CosmosStack.IdUtils.CombImplements.Providers;

namespace CosmosStack.IdUtils.GuidImplements
{
    internal static class NoRepeatTimeStampManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly NoRepeatTimeStampFactory _factory;

        static NoRepeatTimeStampManager()
        {
            _factory = new NoRepeatTimeStampFactory();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NoRepeatTimeStampFactory GetFactory() => _factory;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static InternalTimeStampProvider GetTimeStampProvider(NoRepeatMode mode)
        {
            if (mode == NoRepeatMode.On)
                return GetFactory().GetTimeStamp;
            return null;
        }
    }
}