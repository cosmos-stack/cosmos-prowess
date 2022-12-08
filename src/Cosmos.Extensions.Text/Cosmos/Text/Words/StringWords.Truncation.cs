namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// Truncate By Words <br />
    /// 根据单词进行切割并截取，使用给定的占位符结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxNumber"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace">额外的空格</param>
    /// <returns></returns>
    public static string TruncateByWords(string text, int maxNumber, string placeholder = "...", bool extraSpace = false)
    {
        if (string.IsNullOrEmpty(text) || maxNumber <= 0)
            return string.Empty;
        if (string.IsNullOrEmpty(placeholder))
            placeholder = "...";
        var result = new List<string>();
        var counter = 0;
        var touchBoundary = false;
        foreach (var word in text.SplitByWords())
        {
            if (counter++ == maxNumber)
            {
                touchBoundary = true;
                break;
            }

            result.Add(word);
        }

        return StringWordHelper.AppendEndIfNeed(
            string.Join(" ", result),
            extraSpace ? $" {placeholder}" : placeholder,
            () => touchBoundary);
    }

    /// <summary>
    /// Truncate By Words <br />
    /// 根据单词进行切割并截取，使用给定的占位符结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxNumber"></param>
    /// <param name="truncateFrom"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    public static string TruncateByWords(string text, int maxNumber, StringTruncateFrom truncateFrom, string placeholder = "...", bool extraSpace = false)
        => StringTruncators.ByNumberOfWords.Truncate(text, maxNumber, placeholder, truncateFrom: truncateFrom, extraSpace: extraSpace);
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Truncate By Words <br />
    /// 根据单词进行切割并截取，使用给定的占位符结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxNumber"></param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace">额外的空格</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TruncateByWords(this string text, int maxNumber, string placeholder = "...", bool extraSpace = false)
        => StringWords.TruncateByWords(text, maxNumber, placeholder, extraSpace);

    /// <summary>
    /// Truncate By Words <br />
    /// 根据单词进行切割并截取，使用给定的占位符结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxNumber"></param>
    /// <param name="truncateFrom">裁剪方向</param>
    /// <param name="placeholder"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TruncateByWords(string text, int maxNumber, StringTruncateFrom truncateFrom, string placeholder = "...", bool extraSpace = false)
        => StringWords.TruncateByWords(text, maxNumber, truncateFrom, placeholder, extraSpace);
}