using System.Runtime.CompilerServices;

namespace Cosmos
{
    public static class EnumVisitOptionsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Default(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Type(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Value(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions TypeAndValue(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(2);
        }
    }
}