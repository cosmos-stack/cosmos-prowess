namespace Cosmos.EnumUtils;

public static class DynamicEnumVisitOptionsExtensions
{
    public static IEnumVisitOptions TypeAndValueAndDynamic(this IConfigurableEnumVisitOptions options)
    {
        return new EnumVisitOptions.FinalEnumVisitOptions(3);
    }
}