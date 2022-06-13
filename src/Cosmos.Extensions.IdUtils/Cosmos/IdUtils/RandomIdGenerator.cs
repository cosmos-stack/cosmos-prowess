﻿namespace Cosmos.IdUtils;

/// <summary>
/// Random Id Provider <br />
/// 随机 Id 提供者程序
/// </summary>
public static class RandomIdGenerator
{
    /// <summary>
    /// All numbers from 0 to 9 <br />
    /// 常量，0 - 9 的所有数字
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public const string ALLNUMBERS = "0123456789";

    /// <summary>
    /// 1234567890qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM <br />
    /// 常量，包含 0 -9，a - z 和 A - Z
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public const string ALLWORDS = "1234567890qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM";

    /// <summary>
    /// 2345678wertyuiopasdfghjkzxcvbnm23456780QWERTYUPASDFGHJKLZXCVBNM <br />
    /// 常量，但不包含容易混淆的字符，比如 1 和 I，0 和 O 等
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public const string SIMPLEWORDS = "2345678wertyuipasdfghjkzxcvbnm2345678WERTYUPASDFGHJKLZXCVBNM";

    /// <summary>
    /// NanoId's default alphabet <br />
    /// 常量，Nano Id 所需的字符
    /// </summary>
    public const string NANOWORDS =  "_-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Create Random Id <br />
    /// 创建一个随机 Id
    /// </summary>
    /// <param name="length">Length of random id you want to create</param>
    /// <param name="dict">Random Charter Dictionary, 0-9a-zA-Z as default.</param>
    public static string Create(int length, string dict = ALLWORDS) => new RandomId(length, dict).Create();

    /// <summary>
    /// Create Random Id <br />
    /// 创建一个随机 Id
    /// </summary>
    /// <param name="format">Format of random id you want to create</param>
    /// <param name="dict">Random Charter Dictionary, 0-9a-zA-Z as default.</param>
    public static string Create(string format, string dict = ALLWORDS) => new RandomId(format, dict).Create();
}

internal sealed class RandomId : IFormattable
{
    // ReSharper disable once InconsistentNaming
    private const string ONE = "{0}";

    private static readonly Func<int, string> ToFormat = length =>
    {
        var sb = new StringBuilder(length * 3);
        for (var i = 0; i < length; i++)
            sb.Append(ONE);
        return sb.ToString();
    };

    private readonly string _dict;
    private readonly int _rMax;
    private readonly string _format;

    /// <summary> 构造函数
    /// </summary>
    /// <param name="length">生成Id长度</param>
    /// <param name="dict">随机字符字典,默认字典为0-9a-zA-Z</param>
    public RandomId(int length, string dict = RandomIdGenerator.ALLWORDS) : this(ToFormat(length), dict) { }

    /// <summary> 构造函数
    /// </summary>
    /// <param name="format">生成Id格式</param>
    /// <param name="dict">随机字符字典,默认字典为0-9a-zA-Z</param>
    public RandomId(string format, string dict = RandomIdGenerator.ALLWORDS)
    {
        _dict = dict;
        _format = format;
        _rMax = dict.Length;
    }

    /// <summary> 生成Id
    /// </summary>
    public string Create()
    {
        return string.Format(_format, this);
    }

    #region IFormattable 成员

    private static readonly Random Rand = new();

    string IFormattable.ToString(string format, IFormatProvider formatProvider)
    {
        return _dict[Rand.Next(0, _rMax)].ToString();
    }

    #endregion IFormattable 成员
}