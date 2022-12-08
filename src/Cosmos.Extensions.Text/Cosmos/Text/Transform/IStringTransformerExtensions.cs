namespace Cosmos.Text;

/// <summary>
/// Additional <see cref="string" /> extensions. <br />
/// 额外的字符串扩展
/// </summary>
public static partial class StringProwessExtensions
{
    /// <summary>
    /// Transforms a string using the provided transformers. Transformations are applied in the provided order. <br />
    /// 使用所提供的的转换器将字符串转换为指定的顺序。
    /// </summary>
    /// <param name="input"></param>
    /// <param name="transformers"></param>
    /// <returns></returns>
    public static string Transform(this string input, params IStringTransformer[] transformers)
        => transformers.Aggregate(input, (current, stringTransformer) => stringTransformer.Transform(current));

    /// <summary>
    /// Transforms a string using the provided transformers. Transformations are applied in the provided order. <br />
    /// 使用所提供的的转换器将字符串转换为指定的顺序。
    /// </summary>
    /// <param name="input"></param>
    /// <param name="culture"></param>
    /// <param name="transformers"></param>
    /// <returns></returns>
    public static string Transform(this string input, CultureInfo culture, params ICulturedStringTransformer[] transformers)
        => transformers.Aggregate(input, (current, stringTransformer) => stringTransformer.Transform(current, culture));
}