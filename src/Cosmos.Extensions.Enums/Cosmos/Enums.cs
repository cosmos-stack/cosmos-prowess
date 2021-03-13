using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;
using Cosmos.Conversions;
using Cosmos.Reflection;

namespace Cosmos
{
    /// <summary>
    /// Enum utilities
    /// </summary>
    public static class Enums
    {
        #region Of

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum Of<TEnum>(string member, bool ignoreCase = false, TEnum defaultVal = default) where TEnum : struct, Enum
        {
            return EnumConv.ToEnum(member, ignoreCase, defaultVal);
        }

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum Of<TEnum>(object member, TEnum defaultVal = default) where TEnum : struct, Enum
        {
            return EnumConv.ToEnum(member, defaultVal);
        }

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="enumType"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object Of(string member, Type enumType, bool ignoreCase = false, object defaultVal = default)
        {
            return EnumConv.ToEnum(member, enumType, ignoreCase, defaultVal);
        }

        /// <summary>
        /// Of
        /// </summary>
        /// <param name="member"></param>
        /// <param name="enumType"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static object Of(object member, Type enumType, object defaultVal = default)
        {
            return EnumConv.ToEnum(member, enumType, defaultVal);
        }

        #endregion

        #region NameOf

        /// <summary>
        /// Name of
        /// </summary>
        /// <param name="member"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static string NameOf<TEnum>(TEnum member) where TEnum : struct, Enum
        {
            return EnumsNET.Enums.GetName(member) ?? string.Empty;
        }

        /// <summary>
        /// Name of
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string NameOf(Type enumType, object member)
        {
            return EnumsNET.Enums.GetName(enumType, member) ?? string.Empty;
        }

        #endregion

        #region DescriptionOf

        /// <summary>
        /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
        /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
        /// </summary>
        /// <param name="member"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static string DescriptionOf<TEnum>(TEnum member) where TEnum : struct, Enum
        {
            return TypeReflections.GetDescription<TEnum>(NameOf(member));
        }

        /// <summary>
        /// Get description via <see cref="System.ComponentModel.DescriptionAttribute"/> <br />
        /// 获取描述，使用 <see cref="System.ComponentModel.DescriptionAttribute"/> 特性设置描述
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string DescriptionOf(Type enumType, object member)
        {
            return TypeReflections.GetDescription(enumType, NameOf(enumType, member));
        }

        #endregion

        #region Count

        /// <summary>
        /// Counts the number of enums values contained in a given enum type.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static int Count<TEnum>() where TEnum : struct, Enum
        {
            return EnumsNET.Enums.GetMembers<TEnum>().Count;
        }

        #endregion

        #region Values

        /// <summary>
        /// Get values
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, Enum
        {
            return EnumsNET.Enums.GetValues<TEnum>();
        }

        /// <summary>
        /// Get values
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static IEnumerable<object> GetValues(Type enumType)
        {
            return EnumsNET.Enums.GetValues(enumType);
        }

        #endregion

        #region RandomValue

        /// <summary>
        /// Random value
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum RandomValue<TEnum>() where TEnum : struct, Enum
        {
            return EnumsNET.Enums.GetValues<TEnum>().OrderByRandom().FirstOrDefault();
        }

        #endregion
    }
}