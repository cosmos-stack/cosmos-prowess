namespace Cosmos.Text;

internal class ToHtmlEncode : IStringTransformer
{
    public string Transform(string input)
    {
        return input.AsHtmlValue();
    }

    public static ToHtmlEncode Instance { get; } = new();
}