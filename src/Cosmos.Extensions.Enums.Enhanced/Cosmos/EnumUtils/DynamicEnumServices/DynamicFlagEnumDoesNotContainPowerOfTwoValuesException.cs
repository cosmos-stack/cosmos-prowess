namespace Cosmos.EnumUtils.DynamicEnumServices;

/// <summary>
/// The exception that is thrown when a <see cref="DynamicFlagEnum{TEnum}"/> does not contain consecutive power of two values. <br />
/// 当 <see cref="DynamicFlagEnum{TEnum}"/> 不包含两个值的连续幂时抛出的异常。
/// </summary>
[Serializable]
public class DynamicFlagEnumDoesNotContainPowerOfTwoValuesException : CosmosException
{
    // ReSharper disable once InconsistentNaming
    private const string FLAG = "DY_NEGATIVE_VAL_INFLAG_FLG";

    // ReSharper disable once InconsistentNaming
    private const string DEFAULT_MESSAGE = "Dynamic flag enum does not contains power of two values.";

    // ReSharper disable once InconsistentNaming
    private const long DEFAULT_CODE = 1094;

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(string message) : base(DEFAULT_CODE, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(long code, string message) : base(code, message, FLAG) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="innerException"></param>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }

    /// <summary>
    /// Create a new <see cref="DynamicFlagEnumDoesNotContainPowerOfTwoValuesException"/> instance.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected DynamicFlagEnumDoesNotContainPowerOfTwoValuesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}