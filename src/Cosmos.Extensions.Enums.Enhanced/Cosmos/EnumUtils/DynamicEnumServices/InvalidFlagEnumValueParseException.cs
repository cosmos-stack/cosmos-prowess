namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// The exception that is thrown when a flag dynamic enum item is invalid. <br />
/// 当标志动态枚举项无效时抛出的异常。
/// </summary>
[Serializable]
public class InvalidFlagEnumValueParseException : CosmosException
{
    // ReSharper disable once InconsistentNaming
    private const string FLAG = "DY_INVAL_FLGPARSE_FLG";

    // ReSharper disable once InconsistentNaming
    private const string DEFAULT_MESSAGE = "Invalid flag enum value parse.";

    // ReSharper disable once InconsistentNaming
    private const long DEFAULT_CODE = 1091;

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    public InvalidFlagEnumValueParseException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    public InvalidFlagEnumValueParseException(string message) : base(DEFAULT_CODE, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    public InvalidFlagEnumValueParseException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public InvalidFlagEnumValueParseException(long code, string message) : base(code, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="innerException"></param>
    public InvalidFlagEnumValueParseException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public InvalidFlagEnumValueParseException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="InvalidFlagEnumValueParseException"/> instance.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected InvalidFlagEnumValueParseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}