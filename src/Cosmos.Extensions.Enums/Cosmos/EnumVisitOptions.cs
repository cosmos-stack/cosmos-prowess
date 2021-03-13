namespace Cosmos
{
    public interface IConfigurableEnumVisitOptions { }

    public interface IEnumVisitOptions
    {
        int Value { get; }
    }

    public static class EnumVisitOptions
    {
        public static IConfigurableEnumVisitOptions For => new ConfigurableEnumVisitOptions();

        internal class ConfigurableEnumVisitOptions : IConfigurableEnumVisitOptions { }

        internal class FinalEnumVisitOptions : IEnumVisitOptions
        {
            public FinalEnumVisitOptions(int value)
            {
                Value = value;
            }

            public int Value { get; internal set; }
        }
    }
}