namespace Cosmos.Text;

public static partial class StringLines
{
    /// <summary>
    /// Split by lines <br />
    /// 将多行文本分割为单行文本集合
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static IEnumerable<string> SplitByLines(string text)
    {
        var index = 0;

        while (true)
        {
            var newIndex = text.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
            if (newIndex < 0)
            {
                if (text.Length > index)
                    yield return text.Substring(index);

                yield break;
            }

            var currentString = text.Substring(index, newIndex - index);
            index = newIndex + 2;

            yield return currentString;
        }
    }

    /// <summary>
    /// Split the text line by line,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 逐行分割文本，
    /// 并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <returns></returns>
    public static T[] SplitInLinesTyped<T>(string that) where T : IComparable
        => that.SplitTyped<T>(Environment.NewLine);

    /// <summary>
    /// Split the text line by line and remove blank lines.<br />
    /// 逐行分割文本，并移除空行。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public static string[] SplitInLinesWithoutEmpty(string that)
        => that.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
}

/// <summary>
/// Strings extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringLinesExtensions
{
    /// <summary>
    /// To lines <br />
    /// 将多行文本分割为单行文本集合
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> SplitByLines(this string text) => StringLines.SplitByLines(text);

    /// <summary>
    /// Split the text line by line,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 逐行分割文本，
    /// 并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] SplitInLinesTyped<T>(this string that) where T : IComparable
        => StringLines.SplitInLinesTyped<T>(that);

    /// <summary>
    /// Split the text line by line and remove blank lines.<br />
    /// 逐行分割文本，并移除空行。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] SplitInLinesWithoutEmpty(this string that)
        => StringLines.SplitInLinesWithoutEmpty(that);
}