using System.Runtime.CompilerServices;

namespace CosmosStack.EnumUtils
{
    /// <summary>
    /// Enum Visit Options Extensions <br />
    /// 枚举访问器选项扩展
    /// </summary>
    public static class EnumVisitOptionsExtensions
    {
        /// <summary>
        /// Default <br />
        /// 默认
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Default(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        /// <summary>
        /// Type <br />
        /// 类型，判断给定类型是否为枚举
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Type(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(0);
        }

        /// <summary>
        /// Value <br />
        /// 值，判断给定值是否为枚举
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions Value(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(1);
        }

        /// <summary>
        /// Type and Value <br />
        /// 类型与值，判断给定的类型和值是否为枚举，任何一个为 True 则返回 True
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumVisitOptions TypeAndValue(this IConfigurableEnumVisitOptions options)
        {
            return new EnumVisitOptions.FinalEnumVisitOptions(2);
        }
    }
}