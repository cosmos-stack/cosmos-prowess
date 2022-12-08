using Cosmos.Collections;

namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// Split by words <br />
    /// 根据单词进行切割
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> SplitByWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Arrays.Empty<string>();
        return text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Split on all non-word characters,
    /// and returns an array of all the words greater than the specified length.<br />
    /// 拆分所有非单词字符，并返回所有大于指定长度的单词的数组。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="lengthAtLeast"></param>
    /// <returns></returns>
    public static IEnumerable<string> SplitByWordsLongerThan(string text, int lengthAtLeast)
    {
        return SplitByWords(text).Where(x => x.Length > lengthAtLeast);
    }

    /// <summary>
    /// The specified text is divided into words according to the given index position,
    /// and the two parts of characters obtained from the division are returned in the form of tuples. <br />
    /// 将指定文本根据给定的索引位置按单词（word）进行分割，
    /// 并将分割所得的两部分字符以元组形式返回。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Tuple<string, string> SplitByWordsByIndex(string that, int index)
    {
        var splitByIndex = that.SplitByIndex(index);
        var res = new Tuple<string, string>(splitByIndex.Item1, splitByIndex.Item2);

        var wordsInItem1 = SplitByWords(res.Item1).ToArray();
        res = new Tuple<string, string>(
            wordsInItem1.Take(wordsInItem1.Length - 1).JoinToString(" ").Trim(),
            wordsInItem1.Last() + splitByIndex.Item2);

        return res;
    }
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Split by words <br />
    /// 根据单词进行切割
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> SplitByWords(this string text) => StringWords.SplitByWords(text);

    /// <summary>
    /// Split on all non-word characters,
    /// and returns an array of all the words greater than the specified length.<br />
    /// 拆分所有非单词字符，并返回所有大于指定长度的单词的数组。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="lengthAtLeast"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> SplitByWordsLongerThan(this string text, int lengthAtLeast)
        => StringWords.SplitByWordsLongerThan(text, lengthAtLeast);

    /// <summary>
    /// The specified text is divided into words according to the given index position,
    /// and the two parts of characters obtained from the division are returned in the form of tuples. <br />
    /// 将指定文本根据给定的索引位置按单词（word）进行分割，
    /// 并将分割所得的两部分字符以元组形式返回。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tuple<string, string> SplitByWordsByIndex(string that, int index)
        => StringWords.SplitByWordsByIndex(that, index);
}