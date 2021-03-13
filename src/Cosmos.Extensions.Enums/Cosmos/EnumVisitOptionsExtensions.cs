namespace Cosmos
{
    public static class EnumVisitOptionsExtensions
    {
        public static IEnumVisitOptions Default(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        public static IEnumVisitOptions Type(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        public static IEnumVisitOptions Value(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(1);
        }

        public static IEnumVisitOptions TypeAndValue(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(2);
        }
    }
}