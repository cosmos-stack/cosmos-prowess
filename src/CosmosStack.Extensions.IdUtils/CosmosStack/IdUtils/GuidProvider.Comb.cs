using System;
using CosmosStack.IdUtils.CombImplements;
using CosmosStack.IdUtils.GuidImplements;

namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Guid provider
    /// </summary>
    public static partial class GuidProvider
    {
        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="style"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Guid Create(CombStyle style, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(mode);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(mode);

                case CombStyle.SqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.MsSqlWithNoRepeat.Create()
                        : InternalCombImplementProxy.MsSql.Create();

                case CombStyle.LegacySqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.LegacyWithNoRepeat.Create()
                        : InternalCombImplementProxy.Legacy.Create();

                case CombStyle.PostgreSqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create()
                        : InternalCombImplementProxy.PostgreSql.Create();

                default:
                    return TimeStampStyleProvider.Create(mode);
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Guid Create(Guid value, CombStyle style, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(value, mode);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(value, mode);

                case CombStyle.SqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.MsSqlWithNoRepeat.Create(value)
                        : InternalCombImplementProxy.MsSql.Create(value);

                case CombStyle.LegacySqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.LegacyWithNoRepeat.Create(value)
                        : InternalCombImplementProxy.Legacy.Create(value);

                case CombStyle.PostgreSqlStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create(value)
                        : InternalCombImplementProxy.PostgreSql.Create(value);

                default:
                    return TimeStampStyleProvider.Create(value, mode);
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="secureTimestamp"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(DateTime secureTimestamp, CombStyle style)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(secureTimestamp);

                case CombStyle.SqlStyle:
                    return InternalCombImplementProxy.MsSql.Create(secureTimestamp);

                case CombStyle.LegacySqlStyle:
                    return InternalCombImplementProxy.Legacy.Create(secureTimestamp);

                case CombStyle.PostgreSqlStyle:
                    return InternalCombImplementProxy.PostgreSql.Create(secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(secureTimestamp);
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="value"></param>
        /// <param name="secureTimestamp"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(Guid value, DateTime secureTimestamp, CombStyle style)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(value, secureTimestamp);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(value, secureTimestamp);

                case CombStyle.SqlStyle:
                    return InternalCombImplementProxy.MsSql.Create(value, secureTimestamp);

                case CombStyle.LegacySqlStyle:
                    return InternalCombImplementProxy.Legacy.Create(value, secureTimestamp);

                case CombStyle.PostgreSqlStyle:
                    return InternalCombImplementProxy.PostgreSql.Create(value, secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(value, secureTimestamp);
            }
        }
    }
}