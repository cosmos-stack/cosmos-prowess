namespace Cosmos.Text;

/// <summary>
/// Can truncate a string.
/// </summary>
public interface IStringTruncator
{
    /// <summary>
    /// Truncate a string
    /// </summary>
    /// <param name="text">The string to truncate</param>
    /// <param name="maxLength">The length to truncate to</param>
    /// <param name="truncationString">The string used to truncate with</param>
    /// <param name="shortTruncationString">The short string used to truncate with</param>
    /// <param name="truncateFrom">The enum value used to determine from where to truncate the string</param>
    /// <param name="extraSpace">额外的空格</param>
    /// <returns>The truncated string</returns>
    string Truncate(
        string text, int maxLength,
        string truncationString = "...", string shortTruncationString = ".",
        StringTruncateFrom truncateFrom = StringTruncateFrom.Right, bool extraSpace = false);
}