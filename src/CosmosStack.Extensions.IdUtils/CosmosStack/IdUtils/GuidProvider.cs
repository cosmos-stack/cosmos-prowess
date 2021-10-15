using System;
using System.Runtime.CompilerServices;
using CosmosStack.IdUtils.CombImplements;
using CosmosStack.IdUtils.GuidImplements;

namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Guid provider <br />
    /// GUID 提供者程序
    /// </summary>
    public static partial class GuidProvider
    {
        /// <summary>
        /// Create random style guid <br />
        /// 创建随机 GUID
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once RedundantArgumentDefaultValue
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Guid CreateRandom() => Create(GuidStyle.BasicStyle);

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="style"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Guid Create(GuidStyle style = GuidStyle.BasicStyle, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                //Creates a random (version 4) GUID.
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(mode);

                case GuidStyle.LegacySqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.LegacyWithNoRepeat.Create()
                        : InternalCombImplementProxy.Legacy.Create();

                case GuidStyle.SqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.MsSqlWithNoRepeat.Create()
                        : InternalCombImplementProxy.MsSql.Create();

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create()
                        : InternalCombImplementProxy.PostgreSql.Create();

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsString, mode);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsBinary, mode);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsEnd, mode);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(mode);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="secureTimestamp"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(DateTime secureTimestamp, GuidStyle style = GuidStyle.TimeStampStyle)
        {
            switch (style)
            {
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.LegacySqlTimeStampStyle:
                    return InternalCombImplementProxy.Legacy.Create(secureTimestamp);

                case GuidStyle.SqlTimeStampStyle:
                    return InternalCombImplementProxy.MsSql.Create(secureTimestamp);

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return InternalCombImplementProxy.PostgreSql.Create(secureTimestamp);

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsString);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsBinary);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsEnd);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(secureTimestamp);
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="endianGuidBytes"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Guid Create(byte[] endianGuidBytes, GuidBytesStyle style)
        {
            switch (style)
            {
                case GuidBytesStyle.LittleEndianByteArray:
                    return LittleEndianByteArrayProvider.Create(endianGuidBytes);

                case GuidBytesStyle.BigEndianByteArray:
                    return BigEndianByteArrayProvider.Create(endianGuidBytes);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }

        /// <summary>
        /// Create <br />
        /// 创建 GUID
        /// </summary>
        /// <param name="namespace"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static Guid Create(Guid @namespace, byte[] name, GuidVersion version)
        {
            switch (version)
            {
                //Creates a random (version 4) GUID.
                case GuidVersion.Random:
                    return CreateRandom();

                //Creates a named, MD5-based (version 3) GUID.
                case GuidVersion.NameBasedMd5:
                    return NamedGuidProvider.Create(@namespace, name, GuidVersion.NameBasedMd5);

                //Creates a named, SHA1-based (version 5) GUID.
                case GuidVersion.NameBasedSha1:
                    return NamedGuidProvider.Create(@namespace, name, GuidVersion.NameBasedSha1);

                //Creates a time based GUID
                case GuidVersion.TimeBased:
                    return GuidProvider.Create(CombStyle.NormalStyle);

                //Creates a random (version 4) GUID.
                default:
                    return Guid.NewGuid();
            }
        }
    }
}