namespace Cosmos.Text;

/// <summary>
/// Gets a instance of Truncator
/// </summary>
public static class StringTruncators
{
    /// <summary>
    /// Fixed length truncator
    /// </summary>
    public static IStringTruncator ByLength => FixedLengthTruncator.Instance;

    /// <summary>
    /// Fixed number of characters truncator
    /// </summary>
    public static IStringTruncator ByNumberOfCharacters => FixedNumberOfCharactersTruncator.Instance;

    /// <summary>
    /// Fixed number of words truncator
    /// </summary>
    public static IStringTruncator ByNumberOfWords => FixedNumberOfWordsTruncator.Instance;

    /// <summary>
    /// Fixed number of lines truncator
    /// </summary>
    public static IStringTruncator ByNumberOfLines => FixedNumberOfLinesTruncator.Instance;
}

public static class StringTruncateExtensions
{
    /// <summary>
    /// Truncate the string <br />
    /// 截短，并用给定的字符串开头或结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLength"></param>
    /// <param name="truncationString"></param>
    /// <param name="shortTruncationString"></param>
    /// <param name="from"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    public static string Truncate(
        this string text, int maxLength, string truncationString = "...", string shortTruncationString = ".",
        StringTruncateFrom from = StringTruncateFrom.Right, bool extraSpace = false)
    {
        return text.Truncate(maxLength, truncationString, shortTruncationString, StringTruncators.ByLength, from, extraSpace);
    }

    /// <summary>
    /// Truncate the string <br />
    /// 截短，并用给定的字符串开头或结尾
    /// </summary>
    /// <param name="text"></param>
    /// <param name="maxLength"></param>
    /// <param name="truncator"></param>
    /// <param name="from"></param>
    /// <param name="extraSpace"></param>
    /// <returns></returns>
    public static string Truncate(
        this string text, int maxLength,
        IStringTruncator truncator, StringTruncateFrom from = StringTruncateFrom.Right, bool extraSpace = false)
    {
        return text.Truncate(maxLength, "...", ".", truncator, from, extraSpace);
    }

    /// <summary>
    /// Truncate the string <br />
    /// 截短，并用给定的字符串开头或结尾
    /// </summary>
    /// <param name="text">The string to be truncated</param>
    /// <param name="maxLength">The length to truncate to</param>
    /// <param name="truncationString">The string used to truncate with</param>
    /// <param name="shortTruncationString"></param>
    /// <param name="truncator">The truncator to use</param>
    /// <param name="from">The enum value used to determine from where to truncate the string</param>
    /// <param name="extraSpace"></param>
    /// <returns>The truncated string</returns>
    public static string Truncate(
        this string text, int maxLength, string truncationString, string shortTruncationString,
        IStringTruncator truncator, StringTruncateFrom from = StringTruncateFrom.Right, bool extraSpace = false)
    {
        truncator ??= StringTruncators.ByLength;
        return truncator.Truncate(text, maxLength, truncationString, shortTruncationString, from, extraSpace);
    }
}