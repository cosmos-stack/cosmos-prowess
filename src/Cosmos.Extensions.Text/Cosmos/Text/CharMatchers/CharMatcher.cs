// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.Text.CharMatchers;

/// <summary>
/// Char matcher <br />
/// 字符命中器
/// </summary>
public partial class CharMatcher : ICharMatcher
{
    private MatchingPredicateOptions Options { get; set; } = new();

    private CharMatcher(char match, bool not)
    {
        Options.SetSingleChar(match);
        Options.Not = not;
    }

    private CharMatcher(string sequence, bool not)
    {
        Options.SetSequenceChars(sequence);
        Options.Not = not;
    }

    #region Factory

    /// <summary>
    /// Set the character to be hit, and return a new <see cref="CharMatcher"/> instance. <br />
    /// 设置需要被命中的字符，并返回一个新的 <see cref="CharMatcher"/> 实例。
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public static IIsModeCharMatcher Is(char match)
    {
        return new CharMatcher(match, MatchingMode.TRUE);
    }

    /// <summary>
    /// Set the characters that are not hit, and return a new <see cref="CharMatcher"/> instance. <br />
    /// 设置不被命中的字符，并返回一个新的 <see cref="CharMatcher"/> 实例。
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    public static IIsNotModeCharMatcher IsNot(char match)
    {
        return new CharMatcher(match, MatchingMode.FALSE);
    }

    /// <summary>
    /// Set a set of characters that can be hit arbitrarily, and return a new <see cref="CharMatcher"/> instance. <br />
    /// 设置一组可以任意被命中的字符，并返回一个新的 <see cref="CharMatcher"/> 实例。
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static ICharMatcher AnyOf(string sequence)
    {
        return new CharMatcher(sequence, MatchingMode.TRUE);
    }

    /// <summary>
    /// Set a set of characters that have not been hit, and return a new <see cref="CharMatcher"/> instance. <br />
    /// 设置一组无一被命中的字符，并返回一个新的 <see cref="CharMatcher"/> 实例。
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public static ICharMatcher NoneOf(string sequence)
    {
        return new CharMatcher(sequence, MatchingMode.FALSE);
    }

    #endregion

    #region Static getter

    /// <summary>
    /// Whitespace <br />
    /// 以空格符号作为需要被命中的字符，回一个新的 <see cref="CharMatcher"/> 实例。
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static IIsModeCharMatcher WHITESPACE => Is(' ');

    #endregion

    #region Private class

    private class MatchingPredicateOptions
    {
        #region NOT

        public bool Not { get; set; }

        #endregion

        #region SingleChar and SequenceChars

        // ReSharper disable once InconsistentNaming
        private char _singleChar { get; set; }

        // ReSharper disable once InconsistentNaming
        private string _sequenceChars { get; set; }

        public bool IsSingleCharMode { get; private set; }

        public void SetSingleChar(char @char)
        {
            _singleChar = @char;
            IsSingleCharMode = true;
        }

        public void SetSequenceChars(string @string)
        {
            _sequenceChars = @string;
            IsSingleCharMode = false;
        }

        public char GetSingleChar() => _singleChar;

        public string GetSequenceChars() => _sequenceChars;

        #endregion

        #region Negate

        public void Negate()
        {
            Not = !Not;
        }

        #endregion
    }

    private static class MatchingMode
    {
        // ReSharper disable once InconsistentNaming
        public static bool TRUE { get; } = true;

        // ReSharper disable once InconsistentNaming
        public static bool FALSE { get; } = false;

        // ReSharper disable once InconsistentNaming
        public static string AND { get; } = "AND";

        // ReSharper disable once InconsistentNaming
        public static string OR { get; } = "OR";

        public static bool IsAndMode(string mode)
        {
            return string.Compare(mode, AND, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsOrMode(string mode)
        {
            return string.Compare(mode, OR, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }

    private static class SingleUtils
    {
        #region Match

        public static bool MatchesAnyOf(string sequence, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            return sequence.Any(t => t == @char);
        }

        public static bool MatchesAllOf(string sequence, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            return sequence.All(t => t == @char);
        }

        #endregion

        #region IndexIn

        public static int IndexIn(string sequence, char @char)
        {
            return sequence.IndexOf(@char);
        }

        public static int IndexIn(string sequence, char @char, int startIndex)
        {
            return sequence.IndexOf(@char, startIndex);
        }

        public static int LastIndexIn(string sequence, char @char)
        {
            return sequence.LastIndexOf(@char);
        }

        #endregion

        #region CountIn

        public static int CountIn(string sequence, char @char)
        {
            return sequence.Count(c => c == @char);
        }

        #endregion

        #region Operation from

        public static string RemoveFrom(string sequence, MatchingPredicateOptions options, bool antiNot = false)
        {
            var @char = options.GetSingleChar();
            var counter = 0;
            var sb = new StringBuilder();
            for (var i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == @char)
                {
                    ++counter;
                    continue;
                }

                sb.Append(sequence[i]);
            }

            return antiNot
                ? options.Not.Ifttt(() => Chars.Repeat(@char, counter), () => sb.ToString())
                : options.Not.Ifttt(() => sb.ToString(), () => Chars.Repeat(@char, counter));
        }

        public static string ReplaceFrom(string sequence, string replacement, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();

            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            for (var i = 0; i < sequence.Length; i++)
            {
                var index = i;

                if (sequence[i] == @char)
                {
                    sb1.Append(replacement);
                    sb2.Append(sequence[i]);
                }
                else
                {
                    sb2.Append(replacement);
                    sb1.Append(sequence[i]);
                }
            }

            return options.Not.Ifttt(sb1.ToString, sb2.ToString);
        }

        #endregion

        #region Trim

        public static string TrimFrom(string sequence, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            var result = sequence.Trim(@char);
            if (!options.Not)
            {
                var (f, l) = CharMatcherUtils.GetHeadAndTailLength(sequence, result);
                return $"{@char.Repeat(f)}{@char.Repeat(l)}";
            }

            return result;
        }

        public static string TrimStartFrom(string sequence, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            var result = sequence.TrimStart(@char);
            if (!options.Not)
            {
                var times = sequence.Length - result.Length;
                return @char.Repeat(times);
            }

            return result;
        }

        public static string TrimEndFrom(string sequence, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            var result = sequence.TrimEnd(@char);
            if (!options.Not)
            {
                var times = sequence.Length - result.Length;
                return @char.Repeat(times);
            }

            return result;
        }

        #endregion

        #region Collapse

        public static string CollapseFrom(string sequence, char replacement, MatchingPredicateOptions options)
        {
            var @char = options.GetSingleChar();
            var sb = new StringBuilder();
            void UpdateAct(StringBuilder c, char r) => c.Append(r);

            for (var i = 0; i < sequence.Length; i++)
            {
                var index = i;
                var checker = sequence[i] == @char;
                options.Not.Ifttt(
                    () => checker.Ifttt(() => UpdateAct(sb, replacement), () => UpdateAct(sb, sequence[index])),
                    () => checker.Ifttt(() => UpdateAct(sb, sequence[index]), () => UpdateAct(sb, replacement)));
            }

            return sb.ToString();
        }

        #endregion
    }

    private static class SequenceUtils
    {
        #region Match

        public static bool MatchesAnyOf(string sequence, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            return sequence.IndexOfWholePhrase(@string) >= 0;
        }

        public static bool MatchesAllOf(string sequence, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            if (sequence.Length % @string.Length != 0)
                return false;
            var times = sequence.Length / @string.Length;
            return sequence == @string.Repeat(times);
        }

        #endregion

        #region IndexIn

        public static int IndexIn(string sequence, string @string)
        {
            return sequence.IndexOfWholePhrase(@string);
        }

        public static int IndexIn(string sequence, string @string, int startIndex)
        {
            return sequence.IndexOfWholePhrase(@string, startIndex);
        }

        public static int LastIndexIn(string sequence, string @string)
        {
            return sequence.LastIndexOf(@string, StringComparison.Ordinal);
        }

        #endregion

        #region CountIn

        public static int CountIn(string sequence, string @string)
        {
            return Regex.Matches(sequence, @string).Count;
        }

        #endregion

        #region Operation from

        public static string RemoveFrom(string sequence, MatchingPredicateOptions options, bool antiNot = false)
        {
            var @string = options.GetSequenceChars();
            var sb = new StringBuilder();
            var counter = 0;
            if (@string.Length > sequence.Length)
            {
                sb.Append(sequence);
            }
            else
            {
                for (var i = 0; i < sequence.Length; i++)
                {
                    if (i + @string.Length > sequence.Length)
                    {
                        var rest = sequence[i..];
                        sb.Append(rest);
                        break;
                    }

                    var t = sequence.Substring(i, @string.Length);
                    if (t != @string)
                    {
                        sb.Append(sequence[i]);
                    }
                    else
                    {
                        i = i + @string.Length - 1; //fix position
                        ++counter; //update counter
                    }
                }
            }

            return antiNot
                ? options.Not.Ifttt(sb.ToString, () => Strings.Repeat(@string, counter))
                : options.Not.Ifttt(() => Strings.Repeat(@string, counter), sb.ToString);
        }

        public static string ReplaceFrom(string sequence, string replacement, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            var result = sequence.Replace(@string, replacement);

            if (!options.Not)
                return result;

            var replacedTimes = (result.Length - sequence.Length) / (replacement.Length - @string.Length);
            var unchangedLength = result.Length - replacedTimes * replacement.Length;
            var repeatTimes = unchangedLength + replacedTimes;
            return Strings.Repeat(replacement, repeatTimes);
        }

        #endregion

        #region Trim

        public static string TrimFrom(string sequence, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            var result = sequence.TrimPhrase(@string);
            if (options.Not)
            {
                var (f, l) = CharMatcherUtils.GetHeadAndTailLength(sequence, result);
                var f2 = (int)(f / @string.Length);
                var l2 = (int)(l / @string.Length);
                return $"{@string.Repeat(f2)}{@string.Repeat(l2)}";
            }
            else
            {
                return result;
            }
        }

        public static string TrimStartFrom(string sequence, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            var result = sequence.TrimPhraseStart(@string);
            if (options.Not)
            {
                var length = sequence.Length - result.Length;
                var times = (int)(length / @string.Length);
                return @string.Repeat(times);
            }
            else
            {
                return result;
            }
        }

        public static string TrimEndFrom(string sequence, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            var result = sequence.TrimPhraseStart(@string);
            if (options.Not)
            {
                var length = sequence.Length - result.Length;
                var times = (int)(length / @string.Length);
                return @string.Repeat(times);
            }
            else
            {
                return result;
            }
        }

        #endregion

        #region Collapse

        public static string CollapseFrom(string sequence, char replacement, MatchingPredicateOptions options)
        {
            var @string = options.GetSequenceChars();
            var sb = new StringBuilder();
            void UpdateAct(StringBuilder c, char r) => c.Append(r);

            for (var i = 0; i < sequence.Length; i++)
            {
                var index = i;
                for (var j = 0; j < @string.Length; j++)
                {
                    var checker = sequence[i] == @string[j];
                    options.Not.Ifttt(
                        () => checker.Ifttt(() => UpdateAct(sb, sequence[index]), () => UpdateAct(sb, replacement)),
                        () => checker.Ifttt(() => UpdateAct(sb, replacement), () => UpdateAct(sb, sequence[index])));
                }
            }

            return sb.ToString();
        }

        #endregion
    }

    private static class CharMatcherUtils
    {
        public static (int FirstLength, int LastLength) GetHeadAndTailLength(string originalSequence, string result)
        {
            var index = originalSequence.IndexOfWholePhrase(result);
            var firstLength = index;
            var lastLength = originalSequence.Length - firstLength - result.Length;
            return (firstLength, lastLength);
        }

        public static (char MinChar, char MaxChar) GetMinAndMax(char startInclusive, char endInclusive)
        {
            if (startInclusive >= endInclusive)
                return (endInclusive, startInclusive);
            return (startInclusive, endInclusive);
        }
    }

    #endregion
}