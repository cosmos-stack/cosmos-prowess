﻿/*!
 * CSharpVerbalExpressions v0.1
 * https://github.com/VerbalExpressions/CSharpVerbalExpressions
 */

/*
 * Reference to:
 *      VerbalExpressions/CSharpVerbalExpressions
 *      Author: VerbalExpressions Team
 *      URL: https://github.com/VerbalExpressions/CSharpVerbalExpressions
 *      MIT
 *
 * Changed and updated by Alex Lewis
 */

namespace Cosmos.Text.RegexUtils;

/// <summary>
/// This class is used to fake an enum. You'll be able to use it as an enum. <br />
/// 此类用于伪造枚举。 您将能够将其用作枚举。
/// <para>
/// Note: type save enum, found on stackoverflow: http://stackoverflow.com/a/424414/603309
/// </para>
/// </summary>
public sealed class RegexTypes
{
    private RegexTypes(int value, string name)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Values
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// URL
    /// </summary>
    public static readonly RegexTypes Url = new(1, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[^-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+(:[0-9]+)?|(?:www.|[^-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w_]*)?\??(?:[-\+=&;%@.\w-_]*)#?‌​(?:[\w]*))?)");

    /// <summary>
    /// Email
    /// </summary>
    public static readonly RegexTypes Email = new(2, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}");
}