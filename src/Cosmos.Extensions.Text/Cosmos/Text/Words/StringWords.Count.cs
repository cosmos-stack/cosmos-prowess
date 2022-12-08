namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// Count by words <br />
    /// 单词数统计
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountByWords(string text) => string.IsNullOrWhiteSpace(text) ? 0 : SplitByWords(text).Count();
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Count by words <br />
    /// 单词数统计
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountByWords(this string text) => StringWords.CountByWords(text);
}