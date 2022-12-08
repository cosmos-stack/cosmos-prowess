namespace Cosmos.Text;

internal class ToCamelCase : IStringTransformer
{
    public string Transform(string input)
    {
        if (input is null)
            return string.Empty;
        if (input.Length <= 1)
            return input.ToLower();
        return char.ToLower(input[0]) + input.Substring(1);
    }

    public static ToCamelCase Instance { get; } = new();
}