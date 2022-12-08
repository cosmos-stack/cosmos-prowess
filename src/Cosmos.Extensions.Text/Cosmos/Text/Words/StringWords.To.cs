namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// To capital case <br />
    /// 将所有单词转换为首字符大写的词
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToCapitalCase(string text) => To.CapitalCase.Transform(text);

    /// <summary>
    /// To camel case <br />
    /// 转换为 CamelCase 风格的值
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToCamelCase(string text) => To.CamelCase.Transform(text);
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// To capital case <br />
    /// 将所有单词转换为首字符大写的词
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToCapitalCase(this string text) => StringWords.ToCapitalCase(text);

    /// <summary>
    /// To camel case <br />
    /// 转换为 CamelCase 风格的值
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToCamelCase(this string text) => StringWords.ToCamelCase(text);
}