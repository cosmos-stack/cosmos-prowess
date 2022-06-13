namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// The exception that is thrown when a dynamic enum item is not found. <br />
/// 未找到动态枚举项时引发的异常。
/// </summary>
[Serializable]
public class DynamicEnumNotFoundException : CosmosException
{
    // ReSharper disable once InconsistentNaming
    private const string FLAG = "DY_ENUM_FLG";

    // ReSharper disable once InconsistentNaming
    private const string DEFAULT_MESSAGE = "Dynamic enum not found.";

    // ReSharper disable once InconsistentNaming
    private const long DEFAULT_CODE = 1090;

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    public DynamicEnumNotFoundException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    public DynamicEnumNotFoundException(string message) : base(DEFAULT_CODE, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    public DynamicEnumNotFoundException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public DynamicEnumNotFoundException(long code, string message) : base(code, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="innerException"></param>
    public DynamicEnumNotFoundException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DynamicEnumNotFoundException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="DynamicEnumNotFoundException"/> instance.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DynamicEnumNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}