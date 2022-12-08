namespace Cosmos.Text;

public static class To
{
    /// <summary>
    /// Changes string to title case
    /// </summary>
    /// <example>
    /// "INvalid caSEs arE corrected" -> "Invalid Cases Are Corrected"
    /// </example>
    public static ICulturedStringTransformer TitleCase => ToTitleCase.Instance;

    /// <summary>
    /// Changes the string to lower case
    /// </summary>
    /// <example>
    /// "Sentence casing" -> "sentence casing"
    /// </example>
    public static ICulturedStringTransformer LowerCase => ToLowerCase.Instance;

    /// <summary>
    /// Changes the string to upper case
    /// </summary>
    /// <example>
    /// "lower case statement" -> "LOWER CASE STATEMENT"
    /// </example>
    public static ICulturedStringTransformer UpperCase => ToUpperCase.Instance;

    /// <summary>
    /// Changes the string to sentence case
    /// </summary>
    /// <example>
    /// "lower case statement" -> "Lower case statement"
    /// </example>
    public static ICulturedStringTransformer SentenceCase => ToSentenceCase.Instance;

    /// <summary>
    /// Changes the string to Url encoded
    /// </summary>
    public static IEncodedStringTransformer UrlEncodeCase => ToUrlEncode.Instance;

    /// <summary>
    /// Changes the string to Url decoded
    /// </summary>
    public static IEncodedStringTransformer UrlDecodeCase => ToUrlDecode.Instance;

    /// <summary>
    /// Changes the string to HTML encoded
    /// </summary>
    public static IStringTransformer HtmlEncodeCase => ToHtmlEncode.Instance;

    /// <summary>
    /// Changes the string to HTML decoded
    /// </summary>
    public static IStringTransformer HtmlDecodeCase => ToHtmlDecode.Instance;

    /// <summary>
    /// Changes the string to CapitalCase
    /// </summary>
    public static IStringTransformer CapitalCase => ToCapitalCase.Instance;

    /// <summary>
    /// Changes the string to CamelCase
    /// </summary>
    public static IStringTransformer CamelCase => ToCamelCase.Instance;
}