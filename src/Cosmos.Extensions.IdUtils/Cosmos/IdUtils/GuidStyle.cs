namespace Cosmos.IdUtils;

/// <summary>
/// Guid style <br />
/// GUID 风格
/// </summary>
public enum GuidStyle
{
    /// <summary>
    /// Basic <br />
    /// 基础
    /// </summary>
    BasicStyle,

    /// <summary>
    /// Timestamp <br />
    /// 时间戳
    /// </summary>
    TimeStampStyle,

    /// <summary>
    /// Unix timestamp <br />
    /// UNIX 时间戳
    /// </summary>
    UnixTimeStampStyle,

    /// <summary>
    /// Sql timestamp <br />
    /// SQL 时间戳
    /// </summary>
    SqlTimeStampStyle,

    /// <summary>
    /// Legacy sql timestamp <br />
    /// 合法 SQL 时间戳
    /// </summary>
    LegacySqlTimeStampStyle,

    /// <summary>
    /// PostgreSql timestamp <br />
    /// PostgreSQL 时间戳
    /// </summary>
    PostgreSqlTimeStampStyle,

    /// <summary>
    /// Comb <br />
    /// Comb 风格
    /// </summary>
    CombStyle,

    /// <summary>
    /// Sequential as string <br />
    /// 字符串序列
    /// </summary>
    SequentialAsStringStyle,

    /// <summary>
    /// Sequential as binary<br />
    /// 二进制序列
    /// </summary>
    SequentialAsBinaryStyle,

    /// <summary>
    /// Sequential as end<br />
    /// 顺序
    /// </summary>
    SequentialAsEndStyle,

    /// <summary>
    /// Equifax <br />
    /// Equifax 风格
    /// </summary>
    EquifaxStyle,
}