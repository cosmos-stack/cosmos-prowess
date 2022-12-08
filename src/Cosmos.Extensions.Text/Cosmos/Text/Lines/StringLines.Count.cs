namespace Cosmos.Text;

public static partial class StringLines
{
    /// <summary>
    /// Count by lines <br />
    /// 计算行数
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static int CountByLines(string text)
    {
        int index = 0, lines = 0;

        while (true)
        {
            var newIndex = text.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);

            if (newIndex < 0)
            {
                if (text.Length > index)
                    lines++;

                return lines;
            }

            index = newIndex + 2;
            lines++;
        }
    }
}

/// <summary>
/// Strings extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringLinesExtensions
{
    /// <summary>
    /// Line count <br />
    /// 计算行数
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountByLines(this string text) => StringLines.CountByLines(text);
}