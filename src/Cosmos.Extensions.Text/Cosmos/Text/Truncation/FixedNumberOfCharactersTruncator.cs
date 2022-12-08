namespace Cosmos.Text;

/// <summary>
/// Truncate a string to a fixed number of letters or digits
/// </summary>
internal class FixedNumberOfCharactersTruncator : IStringTruncator
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

        var numberOfLetterOrDigit = text.ToCharArray().Count(char.IsLetterOrDigit);
        if (numberOfLetterOrDigit <= maxLength)
            return text;

        if (shortTruncationString.Length > maxLength)
            return truncateFrom == StringTruncateFrom.Left
                ? text.Substring(text.Length - maxLength)
                : text.Substring(0, maxLength);

        var spacePlaceholder = extraSpace ? " " : "";

        if (shortTruncationString.Length < maxLength && truncationString.Length > maxLength)
            return truncateFrom == StringTruncateFrom.Left
                ? TruncateFromLeft(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder)
                : TruncateFromRight(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder);

        if (numberOfLetterOrDigit <= truncationString.Length)
            return truncateFrom == StringTruncateFrom.Left
                ? TruncateFromLeft(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder)
                : TruncateFromRight(ref text, ref maxLength, ref shortTruncationString, ref spacePlaceholder);

        return truncateFrom == StringTruncateFrom.Left
            ? TruncateFromLeft(ref text, ref maxLength, ref truncationString, ref spacePlaceholder)
            : TruncateFromRight(ref text, ref maxLength, ref truncationString, ref spacePlaceholder);
    }

    private static string TruncateFromRight(ref string text, ref int maxLength, ref string truncationString, ref string spacePlaceholder)
    {
        var alphaNumericalCharactersProcessed = 0;
        for (var i = 0; i < text.Length - truncationString.Length; i++)
        {
            if (char.IsLetterOrDigit(text[i]))
            {
                alphaNumericalCharactersProcessed++;
            }

            if (alphaNumericalCharactersProcessed + truncationString.Length == maxLength)
            {
                return $"{text.Substring(0, i + 1)}{spacePlaceholder}{truncationString}";
            }
        }

        return text;
    }

    private static string TruncateFromLeft(ref string text, ref int maxLength, ref string truncationString, ref string spacePlaceholder)
    {
        var alphaNumericalCharactersProcessed = 0;
        for (var i = text.Length - 1; i > 0; i--)
        {
            if (char.IsLetterOrDigit(text[i]))
            {
                alphaNumericalCharactersProcessed++;
            }

            if (alphaNumericalCharactersProcessed + truncationString.Length == maxLength)
            {
                return $"{truncationString}{spacePlaceholder}{text.Substring(i)}";
            }
        }


        return text;
    }

    public static FixedNumberOfCharactersTruncator Instance { get; } = new();
}