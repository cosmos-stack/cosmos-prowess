namespace CosmosStack.EnumUtils
{
    /// <summary>
    /// Configurable Enum Visit Options Interface <br />
    /// 接口，用于可配置的枚举访问器
    /// </summary>
    public interface IConfigurableEnumVisitOptions { }

    /// <summary>
    /// Enum Visit Options Interface <br />
    /// 接口，枚举访问器选项
    /// </summary>
    public interface IEnumVisitOptions
    {
        /// <summary>
        /// Get value <br />
        /// 获取值
        /// </summary>
        int Value { get; }
    }

    /// <summary>
    /// Enum Visit Options <br />
    /// 枚举访问器选项
    /// </summary>
    public static class EnumVisitOptions
    {
        /// <summary>
        /// Obtain a configuration entry so that the new configuration can take effect. <br />
        /// 获取一个配置入口，以便能将新配置生效。
        /// </summary>
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