namespace Cosmos.Text;

internal class ToUrlDecode : IEncodedStringTransformer
{
    public string Transform(string input)
    {
        return input.FromUrlValue();
    }

    public string Transform(string input, Encoding encoding)
    {
        return input.FromUrlValue(encoding);
    }

    public static ToUrlDecode Instance { get; } = new();
}