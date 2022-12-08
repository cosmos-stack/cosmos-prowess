namespace Cosmos.Text;

internal class ToHtmlDecode : IStringTransformer
{
    public string Transform(string input)
    {
        return input.FromHtmlValue();
    }

    public static ToHtmlDecode Instance { get; } = new();
}