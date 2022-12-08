using Cosmos.Collections;

namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// Find and retrieve the first phrase that meets the requirements from the specified text.<br />
    /// 从指定文本中查找第一个满足要求的短语。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrasesToCheck"></param>
    /// <returns></returns>
    public static string FindFirstPhrase(string text, params string[] phrasesToCheck)
    {
        GuardParameter(phrasesToCheck, nameof(phrasesToCheck));
        return phrasesToCheck.FirstOrDefault(text.ContainsWholePhrase);
    }

    /// <summary>
    /// Find first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static string FindFirstOccurrence(string text, params string[] toCheck)
    {
        GuardParameter(toCheck, nameof(toCheck));
        return toCheck.FirstOrDefault(text.ContainsIgnoreCase);
    }

    /// <summary>
    /// Find and replace first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="newValue"></param>
    /// <param name="oldValues"></param>
    /// <returns></returns>
    public static string FindAndReplaceFirstOccurrence(string text, string newValue, params string[] oldValues)
    {
        GuardParameter(oldValues, nameof(oldValues));

        foreach (var oldValue in oldValues)
        {
            if (text.ContainsIgnoreCase(oldValue))
                return text.ReplaceIgnoreCase(oldValue, newValue);
        }

        return text;
    }

    /// <summary>
    /// Find and insert before first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="textInsert"></param>
    /// <param name="oldValues"></param>
    /// <returns></returns>
    public static string FindAndInsertBeforeFirstOccurrence(string text, string textInsert, params string[] oldValues)
    {
        GuardParameter(oldValues, nameof(oldValues));

        foreach (var oldValue in oldValues)
        {
            if (text.ContainsIgnoreCase(oldValue))
                return text.ReplaceIgnoreCase(oldValue, textInsert + oldValue);
        }

        return text;
    }

    private static void GuardParameter<T>(T[] target, string nameOfT)
    {
        if (target is null || target.Length == 0)
            throw new ArgumentException($"Parameter '{nameOfT}' cannot be null or empty.", nameOfT);
    }
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Find and retrieve the first phrase that meets the requirements from the specified text.<br />
    /// 从指定文本中查找第一个满足要求的短语。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrasesToCheck"></param>
    /// <returns></returns>
    public static string FindFirstPhrase(this string text, params string[] phrasesToCheck)
        => StringWords.FindFirstPhrase(text, phrasesToCheck);

    /// <summary>
    /// Find first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static string FindFirstOccurrence(this string text, params string[] toCheck)
        => StringWords.FindFirstOccurrence(text, toCheck);

    /// <summary>
    /// Find and replace first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="newValue"></param>
    /// <param name="oldValues"></param>
    /// <returns></returns>
    public static string FindAndReplaceFirstOccurrence(this string text, string newValue, params string[] oldValues)
        => StringWords.FindAndReplaceFirstOccurrence(text, newValue, oldValues);

    /// <summary>
    /// Find and insert before first occurrence
    /// </summary>
    /// <param name="text"></param>
    /// <param name="textInsert"></param>
    /// <param name="oldValues"></param>
    /// <returns></returns>
    public static string FindAndInsertBeforeFirstOccurrence(this string text, string textInsert, params string[] oldValues)
        => StringWords.FindAndInsertBeforeFirstOccurrence(text, textInsert, oldValues);
}