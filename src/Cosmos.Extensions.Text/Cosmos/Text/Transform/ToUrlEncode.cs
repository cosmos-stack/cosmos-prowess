namespace Cosmos.Text;

internal class ToUrlEncode : IEncodedStringTransformer
{
    public string Transform(string input)
    {
        return input.AsUrlValue();
    }

    public string Transform(string input, Encoding encoding)
    {
        return input.AsUrlValue(encoding);
    }

    public static ToUrlEncode Instance { get; } = new();
}