using Cosmos.Collections;

namespace Cosmos.Text;

/// <summary>
/// Additional <see cref="string" /> extensions. <br />
/// 额外的字符串扩展
/// </summary>
public static class AdditionalStringExtensions
{
    #region Contains

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
    /// Determine whether the specified text contains the given word. <br />
    /// This check will ignore the case.<br />
    /// 判断指定文本是否包含给定的单词（word），此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsWholeWord(this string text, string toCheck)
    {
        if (text.IsNullOrEmpty())
            return false;
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return text.SplitInWords().Any(p => p.EqualsIgnoreCase(toCheck));
    }

    /// <summary>
    /// Determine whether the specified text contains any given word. <br />
    /// This check will ignore case. <br />
    /// 判断指定文本是否包含给定的任意一个单词（word）。此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsAnyWholeWord(this string text, params string[] toCheck)
    {
        if (text.IsNullOrEmpty())
            return false;
        if (toCheck is null || toCheck.Length == 0)
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");
        return text.SplitInWords().Any(p => toCheck.Any(p.EqualsIgnoreCase));
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
    public static bool ContainsWholePhrase(this string text, string toCheck)
    {
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentException($"The given phrase '{toCheck}' cannot be empty.");

        var startIndex = 0;
        while (startIndex <= text.Length)
        {
            var index = text.IndexOfIgnoreCase(toCheck,startIndex);
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
    public static bool ContainsWholePhraseAny(this string text, params string[] toCheck) => toCheck.Any(text.ContainsWholePhrase);

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
    public static bool ContainsWholePhraseAll(this string text, params string[] toCheck) => toCheck.All(text.ContainsWholePhrase);

    /// <summary>
    /// Determine whether the specified text contains the given text. <br />
    /// This check will ignore case.<br />
    /// 判断指定文本是否包含给定的文本，此次检查将忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static bool ContainsIgnoreCase(this string text, string toCheck)
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
    public static bool ContainsAnyIgnoreCase(this string text, params string[] toCheck)
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
    public static bool ContainsAllIgnoreCase(this string text, params string[] toCheck)
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
    public static bool ContainsOnlyThisChar(this string text, char toCheck) => text.Length != 0 && text.All(t => t == toCheck);

    #endregion

    #region Find

    /// <summary>
    /// Find and retrieve the first phrase that meets the requirements from the specified text.<br />
    /// 从指定文本中查找第一个满足要求的短语。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrasesToCheck"></param>
    /// <returns></returns>
    public static string FindFirstPhrase(this string text, params string[] phrasesToCheck)
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
    public static string FindFirstOccurrence(this string text, params string[] toCheck)
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
    public static string FindAndReplaceFirstOccurrence(this string text, string newValue, params string[] oldValues)
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
    public static string FindAndInsertBeforeFirstOccurrence(this string text, string textInsert, params string[] oldValues)
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

    #endregion

    #region Join

    /// <summary>
    /// Combine the given set with a specific string as the delimiter. <br />
    /// 将给定的集合以特定的字符串为分隔符进行合并。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="separator"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static string JoinStringFor<T>(this string separator, IEnumerable<T> list) =>
        StringCollectionExtensions.JoinToString(list, separator);

    #endregion

    #region Split

    /// <summary>
    /// Cut the string according to the given separator. <br />
    /// 根据给定的分隔符号对字符串进行切割。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="separator">分隔符</param>
    /// <returns></returns>
    public static string[] Split(this string that, string separator) => Regex.Split(that, separator);

    // ReSharper disable once InconsistentNaming
    private static readonly Regex SplitWordsPattern = new Regex(@"\W+");

    /// <summary>
    /// Split on all non-word characters,
    /// and returns an array of all the words.<br />
    /// 拆分所有非单词字符，并返回所有单词的数组。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public static string[] SplitInWords(this string that)
    {
        //
        // Split on all non-word characters.
        // ... Returns an array of all the words.
        //
        // 拆分所有非单词字符。
        // ...返回所有单词的数组。
        return SplitWordsPattern.Split(that);
        // @      special verbatim string syntax
        //        特殊逐字字符串语法
        // \W+    one or more non-word characters together
        //        一个或多个非单词字符一起
    }

    /// <summary>
    /// Split on all non-word characters,
    /// and returns an array of all the words greater than the specified length.<br />
    /// 拆分所有非单词字符，并返回所有大于指定长度的单词的数组。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="lengthAtLeast"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<string> SplitInWordsLongerThan(this string that, int lengthAtLeast)
    {
        return SplitWordsPattern.Split(that).Where(word => word.Length > lengthAtLeast);
    }

    /// <summary>
    /// Split text line by line.<br />
    /// 逐行分割文本。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] SplitInLines(this string that)
    {
        return that.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] SplitInLinesTyped<T>(this string that) where T : IComparable
    {
        return SplitTyped<T>(that, Environment.NewLine);
    }

    /// <summary>
    /// Split the text line by line and remove blank lines.<br />
    /// 逐行分割文本，并移除空行。
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string[] SplitInLinesWithoutEmpty(this string that)
    {
        return that.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Split the specified text according to the given index position,
    /// and return the two parts of the characters obtained as a tuple. <br />
    /// 将指定文本根据给定的索引位置进行分割，
    /// 并将分割所得的两部分字符以元组形式返回。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Tuple<string, string> SplitByIndex(this string that, int index)
    {
        if (that.IsNullOrEmpty())
            return new Tuple<string, string>("", "");

        if (index >= that.Length)
            return new Tuple<string, string>(that, "");

        if (index <= 0)
            return new Tuple<string, string>("", that);

        return new Tuple<string, string>(that.Substring(0, index - 1), that.Substring(index - 1));
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
    public static Tuple<string, string> SplitWordsByIndex(this string that, int index)
    {
        var splitByIndex = that.SplitByIndex(index);
        var res = new Tuple<string, string>(splitByIndex.Item1, splitByIndex.Item2);

        var wordsInItem1 = res.Item1.SplitInWords();
        res = new Tuple<string, string>(
            wordsInItem1.Take(wordsInItem1.Length - 1).JoinToString(" ").Trim(),
            wordsInItem1.Last() + splitByIndex.Item2);

        return res;
    }

    /// <summary>
    /// Split the specified text according to the given delimiter,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 将指定文本根据给定的分隔符进行分割，并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static T[] SplitTyped<T>(this string that, char delimiter) where T : IComparable
    {
        if (that.IsNullOrWhiteSpace())
            return Arrays.Empty<T>();

        return that
               .Trim()
               .Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries)
               .Select(p => (T) Convert.ChangeType(p, typeof(T)))
               .ToArray();
    }

    /// <summary>
    /// Split the specified text according to the given delimiter,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 将指定文本根据给定的分隔符进行分割，并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static T[] SplitTyped<T>(this string that, string delimiter) where T : IComparable
    {
        if (that.IsNullOrWhiteSpace())
            return Arrays.Empty<T>();

        return that
               .Trim()
               .Split(new[] {delimiter}, StringSplitOptions.RemoveEmptyEntries)
               .Select(p => (T) Convert.ChangeType(p, typeof(T)))
               .ToArray();
    }

    #endregion

    #region Word

    /// <summary>
    /// Count the total number of words. <br />
    /// 统计总单词数。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static int TotalWords(this string text)
    {
        text = text.Trim();

        if (text.IsNullOrEmpty())
            return 0;

        var res = 0;

        var prevCharIsSeparator = true;
        foreach (var c in text)
        {
            if (char.IsSeparator(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c))
            {
                if (!prevCharIsSeparator)
                    res++;
                prevCharIsSeparator = true;
            }
            else
                prevCharIsSeparator = false;
        }

        if (!prevCharIsSeparator)
            res++;

        return res;
    }

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

        var parts = that.SplitInWords();

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

        var wordsText = text.SplitInWords();
        var wordsCheck = check.SplitInWords();

        var wordsTextNotInCheck = wordsText.FindAll(x => !x.IsOn(wordsCheck));
        if (wordsTextNotInCheck.Length > 0)
            return false;

        var wordsCheckNotInText = wordsCheck.FindAll(x => !x.IsOn(wordsText));
        if (wordsCheckNotInText.Length > 0)
            return false;

        return true;
    }

    #endregion
}