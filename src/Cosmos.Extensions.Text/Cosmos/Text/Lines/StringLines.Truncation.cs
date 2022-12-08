namespace Cosmos.Text;

public static partial class StringLines
{
    /// <summary>
    /// Truncate by lines <br />
    /// 将多行文本分割为单行文本集合，并截取其中的一部分，其余部分用指定的占位符代替
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLines"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    public static string TruncateByLines(string text, int maxLines, string placeholder = "...", bool extraSpace = false)
        => StringTruncators.ByNumberOfLines.Truncate(text, maxLines, placeholder, extraSpace: extraSpace);

    /// <summary>
    /// Truncate by lines <br />
    /// 将多行文本分割为单行文本集合，并截取其中的一部分，其余部分用指定的占位符代替
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLines"></param>
    /// <param name="truncateFrom"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    public static string TruncateByLines(string text, int maxLines, StringTruncateFrom truncateFrom, string placeholder = "...", bool extraSpace = false)
        => StringTruncators.ByNumberOfLines.Truncate(text, maxLines, placeholder, truncateFrom: truncateFrom, extraSpace: extraSpace);
}

/// <summary>
/// Strings extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringLinesExtensions
{
    /// <summary>
    /// Truncate by lines <br />
    /// 将多行文本分割为单行文本集合，并截取其中的一部分，其余部分用指定的占位符代替
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLines"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TruncateByLines(this string text, int maxLines, string placeholder = "...", bool extraSpace = false)
        => StringLines.TruncateByLines(text, maxLines, placeholder, extraSpace);

    /// <summary>
    /// Truncate by lines <br />
    /// 将多行文本分割为单行文本集合，并截取其中的一部分，其余部分用指定的占位符代替
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLines"></param>
    /// <param name="truncateFrom"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TruncateByLines(this string text, int maxLines, StringTruncateFrom truncateFrom, string placeholder = "...", bool extraSpace = false)
        => StringLines.TruncateByLines(text, maxLines, truncateFrom, placeholder, extraSpace);
}