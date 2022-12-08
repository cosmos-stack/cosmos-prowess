namespace Cosmos.Text;

/// <summary>
/// Truncate a string to a fixed number of words
/// </summary>
internal class FixedNumberOfWordsTruncator : IStringTruncator
{
    public string Truncate(
        string text, int maxLength,
        string truncationString = "...", string shortTruncationString = ".",
        StringTruncateFrom truncateFrom = StringTruncateFrom.Right, bool extraSpace = false)
    {
        if (string.IsNullOrEmpty(text) || maxLength < 0)
            return string.Empty;
        if (maxLength == 0)
            return text;
        if (string.IsNullOrEmpty(truncationString))
            truncationString = "...";
        if (string.IsNullOrEmpty(shortTruncationString))
            shortTruncationString = ".";
        if (truncationString.Length < shortTruncationString.Length)
            (shortTruncationString, truncationString) = (truncationString, shortTruncationString);

        var numberOfWords = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Length;
        if (numberOfWords <= maxLength)
            return text;

        var spacePlaceholder = extraSpace ? " " : "";
        var empty = string.Empty;

        if (shortTruncationString.Length > maxLength)
            return truncateFrom == StringTruncateFrom.Left
                ? TruncateFromLeft(ref text, ref maxLength, ref empty, ref spacePlaceholder)
                : TruncateFromRight(ref text, ref maxLength, ref empty, ref spacePlaceholder);

        if (shortTruncationString.Length < maxLength && truncationString.Length > maxLength)
            return truncateFrom == StringTruncateFrom.Left
                ? TruncateFromLeft(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder)
                : TruncateFromRight(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder);

        return truncateFrom == StringTruncateFrom.Left
            ? TruncateFromLeft(ref text, ref maxLength, ref truncationString, ref spacePlaceholder)
            : TruncateFromRight(ref text, ref maxLength, ref truncationString, ref spacePlaceholder);
    }

    private static string TruncateFromRight(ref string value, ref int length, ref string truncationString, ref string spacePlaceholder)
    {
        var lastCharactersWasWhiteSpace = true;
        var numberOfWordsProcessed = 0;
        for (var i = 0; i < value.Length; i++)
        {
            if (char.IsWhiteSpace(value[i]))
            {
                if (!lastCharactersWasWhiteSpace)
                {
                    numberOfWordsProcessed++;
                }

                lastCharactersWasWhiteSpace = true;

                if (numberOfWordsProcessed == length)
                {
                    return $"{value.Substring(0, i)}{spacePlaceholder}{truncationString}";
                }
            }
            else
            {
                lastCharactersWasWhiteSpace = false;
            }
        }

        return $"{value}{spacePlaceholder}{truncationString}";
    }

    private static string TruncateFromLeft(ref string value, ref int length, ref string truncationString, ref string spacePlaceholder)
    {
        var lastCharactersWasWhiteSpace = true;
        var numberOfWordsProcessed = 0;
        for (var i = value.Length - 1; i > 0; i--)
        {
            if (char.IsWhiteSpace(value[i]))
            {
                if (!lastCharactersWasWhiteSpace)
                {
                    numberOfWordsProcessed++;
                }

                lastCharactersWasWhiteSpace = true;

                if (numberOfWordsProcessed == length)
                {
                    return $"{truncationString}{spacePlaceholder}{value.Substring(i + 1).TrimEnd()}";
                }
            }
            else
            {
                lastCharactersWasWhiteSpace = false;
            }
        }

        return $"{truncationString}{spacePlaceholder}{value}";
    }

    public static FixedNumberOfWordsTruncator Instance { get; } = new();
}