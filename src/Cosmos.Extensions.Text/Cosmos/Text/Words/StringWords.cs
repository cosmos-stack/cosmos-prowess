using Cosmos.Collections;

namespace Cosmos.Text;

internal static class StringWordHelper
{
    /// <summary>
    /// To all capitals
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool AllCapitals(string input)
    {
        return input.ToCharArray().All(char.IsUpper);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string AppendEndIfNeed(string text, string appendStr, Func<bool> condition)
    {
        if (condition?.Invoke() ?? false)
            return $"{text}{appendStr}";
        return text;
    }
}

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords { }

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Get the last word from the given text.<br />
    /// 从给定的本文中获得最后一个单词。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string LastWord(this string that) => IndexOfWord(that, -1);

    /// <summary>
    /// Get the first word from the given text.<br />
    /// 从给定的本文中获得第二个单词。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string SecondWord(this string that) => IndexOfWord(that, 2);

    /// <summary>
    /// Get the first word from the given text.<br />
    /// 从给定的本文中获得第一个单词。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string FirstWord(this string that) => IndexOfWord(that, 1);

    /// <summary>
    /// Get the word at the specified position from the given text.<br />
    /// Find positive numbers from front to back,<br />
    /// and negative numbers from back to front.<br />
    /// 从给定的本文中获得指定位置的单词。正数从前往后找，负数从后往前找。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static string IndexOfWord(this string that, int position)
    {
        if (string.IsNullOrWhiteSpace(that))
            return string.Empty;

        // == 0
        if (position == 0)
            return string.Empty;

        var parts = that.SplitByWords().ToArray();

        position = position > 0 ? position : parts.Length + position + 1;

        return parts.Length >= position ? parts[position - 1] : string.Empty;
    }

    /// <summary>
    /// Determine that the specified text has exactly the same words as the given text. <br />
    /// Note that the order between words will be ignored. <br />
    /// 判断指定的文本与给定的文本具有完全相同的单词。<br />
    /// 注意，单词之间的顺序将被忽略。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="check"></param>
    /// <returns></returns>
    public static bool IsSameWord(this string text, string check)
    {
        if (check.IsNullOrEmpty())
            return text.IsNullOrEmpty();

        var wordsText = text.SplitByWords().ToArray();
        var wordsCheck = check.SplitByWords().ToArray();

        var wordsTextNotInCheck = wordsText.FindAll(x => !x.IsOn(wordsCheck));
        if (wordsTextNotInCheck.Length > 0)
            return false;

        var wordsCheckNotInText = wordsCheck.FindAll(x => !x.IsOn(wordsText));
        if (wordsCheckNotInText.Length > 0)
            return false;

        return true;
    }
}