namespace Cosmos.Text;

/// <summary>
/// String Words Helper
/// </summary>
public static partial class StringWords
{
    /// <summary>
    /// Determine whether the specified text contains the given word. <br />
    /// This check will ignore the case.<br />
    /// 判断指定文本是否包含给定的单词（word），此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsWholeWord(string text, string toCheck)
    {
        if (text.IsNullOrEmpty())
            return false;
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return text.SplitByWords().Any(p => p.EqualsIgnoreCase(toCheck));
    }

    /// <summary>
    /// Determine whether the specified text contains any given word. <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否包含给定的任意一个单词（word）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAnyWholeWord(string text, params string[] toCheck)
    {
        if (text.IsNullOrEmpty())
            return false;
        if (toCheck is null || toCheck.Length == 0)
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return text.SplitByWords().Any(p => toCheck.Any(p.EqualsIgnoreCase));
    }

    /// <summary>
    /// Determine whether the specified text completely contains a given phrase
    /// (a phrase can contain several words and non-letter content). <br />
    /// This check will ignore case.<br />
    /// 判断指定文本是否完整包含给定的一个短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsWholePhrase(string text, string toCheck)
    {
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");

        var startIndex = 0;
        while (startIndex <= text.Length)
        {
            var index = text.IndexOfIgnoreCase(toCheck, startIndex);
            if (index < 0)
                return false;

            var indexPreviousCar = index - 1;
            var indexNextCar = index + toCheck.Length;
            if ((index == 0 || !char.IsLetter(text[indexPreviousCar])) &&
                (index + toCheck.Length == text.Length || !char.IsLetter(text[indexNextCar])))
                return true;

            startIndex = index + toCheck.Length;
        }

        return false;
    }

    /// <summary>
    /// Determine whether the specified text completely contains any given phrase
    /// (phrase can contain several words and non-letter content). <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否完整包含给定的任意一个短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWholePhraseAny(string text, params string[] toCheck)
        => toCheck.Any(text.ContainsWholePhrase);

    /// <summary>
    /// Determine whether the specified text completely contains all the given phrases
    /// (phrases can contain several words and non-letter content). <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否完整包含给定的所有短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWholePhraseAll(string text, params string[] toCheck)
        => toCheck.All(text.ContainsWholePhrase);

    /// <summary>
    /// Determine whether the specified text contains Chinese characters.<br />
    /// 判断指定文本是否包含中文汉字。
    /// </summary>
    /// <param name="text"></param>
    public static bool ContainsChinese(string text) => StringJudge.ContainsChineseCharacters(text);

    /// <summary>
    /// Determine whether the specified text contains numbers.<br />
    /// 判断指定文本是否包含数字。
    /// </summary>
    /// <param name="text">文本</param>
    public static bool ContainsNumber(string text) => StringJudge.ContainsNumber(text);

    /// <summary>
    /// Determine whether the specified text contains the given text. <br />
    /// This check will ignore case.<br />
    /// 判断指定文本是否包含给定的文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsIgnoreCase(string text, string toCheck)
    {
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return text.IndexOfIgnoreCase(toCheck) >= 0;
    }

    /// <summary>
    /// Determine whether the specified text contains any given text. <br />
    /// This check will ignore the case. <br />
    /// 判断指定文本是否包含给定的任意一个文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAnyIgnoreCase(string text, params string[] toCheck)
    {
        if (toCheck is null || toCheck.Length == 0)
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return toCheck.Any(checking => text.IndexOfIgnoreCase(checking) >= 0);
    }

    /// <summary>
    /// Determine whether the specified text contains all given texts. <br />
    /// This check will ignore the case. <br />
    /// 判断指定文本是否包含给定的所有文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAllIgnoreCase(string text, params string[] toCheck)
    {
        if (toCheck is null || toCheck.Length == 0)
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return toCheck.All(checking => text.IndexOfIgnoreCase(checking) >= 0);
    }

    /// <summary>
    /// Determine whether there are only given characters in the specified text. <br />
    /// 判断指定文本内是否只存在给定的字符。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsOnlyThisChar(string text, char toCheck)
    {
        return text.Length != 0 && text.All(t => t == toCheck);
    }
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringWordsExtensions
{
    /// <summary>
    /// Determine whether the specified text contains the given word. <br />
    /// This check will ignore the case.<br />
    /// 判断指定文本是否包含给定的单词（word），此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsWholeWord(this string text, string toCheck)
        => StringWords.ContainsWholeWord(text, toCheck);

    /// <summary>
    /// Determine whether the specified text contains any given word. <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否包含给定的任意一个单词（word）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAnyWholeWord(this string text, params string[] toCheck)
        => StringWords.ContainsAnyWholeWord(text, toCheck);

    /// <summary>
    /// Determine whether the specified text completely contains a given phrase
    /// (a phrase can contain several words and non-letter content). <br />
    /// This check will ignore case.<br />
    /// 判断指定文本是否完整包含给定的一个短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsWholePhrase(this string text, string toCheck)
        => StringWords.ContainsWholePhrase(text, toCheck);

    /// <summary>
    /// Determine whether the specified text completely contains any given phrase
    /// (phrase can contain several words and non-letter content). <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否完整包含给定的任意一个短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWholePhraseAny(this string text, params string[] toCheck)
        => StringWords.ContainsWholePhraseAny(text, toCheck);

    /// <summary>
    /// Determine whether the specified text completely contains all the given phrases
    /// (phrases can contain several words and non-letter content). <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否完整包含给定的所有短语（短语可以包含若干个单词和非字母内容）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsWholePhraseAll(this string text, params string[] toCheck)
        => StringWords.ContainsWholePhraseAll(text, toCheck);

    /// <summary>
    /// Determine whether the specified text contains Chinese characters.<br />
    /// 判断指定文本是否包含中文汉字。
    /// </summary>
    /// <param name="text"></param>
    public static bool ContainsChinese(string text) => StringWords.ContainsChinese(text);

    /// <summary>
    /// Determine whether the specified text contains numbers.<br />
    /// 判断指定文本是否包含数字。
    /// </summary>
    /// <param name="text">文本</param>
    public static bool ContainsNumber(string text) => StringWords.ContainsNumber(text);

    /// <summary>
    /// Determine whether the specified text contains the given text. <br />
    /// This check will ignore case.<br />
    /// 判断指定文本是否包含给定的文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsIgnoreCase(this string text, string toCheck)
        => StringWords.ContainsIgnoreCase(text, toCheck);

    /// <summary>
    /// Determine whether the specified text contains any given text. <br />
    /// This check will ignore the case. <br />
    /// 判断指定文本是否包含给定的任意一个文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAnyIgnoreCase(this string text, params string[] toCheck)
        => StringWords.ContainsAnyIgnoreCase(text, toCheck);

    /// <summary>
    /// Determine whether the specified text contains all given texts. <br />
    /// This check will ignore the case. <br />
    /// 判断指定文本是否包含给定的所有文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAllIgnoreCase(this string text, params string[] toCheck)
        => StringWords.ContainsAllIgnoreCase(text, toCheck);

    /// <summary>
    /// Determine whether there are only given characters in the specified text. <br />
    /// 判断指定文本内是否只存在给定的字符。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsOnlyThisChar(this string text, char toCheck)
        => StringWords.ContainsOnlyThisChar(text, toCheck);
}