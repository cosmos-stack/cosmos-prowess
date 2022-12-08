namespace Cosmos.Text;

internal class ToCapitalCase : IStringTransformer
{
    public string Transform(string input)
    {
        var result = new List<string>();
        foreach (var word in input.Split((char[])null, StringSplitOptions.RemoveEmptyEntries))
        {
            if (word.Length == 0 || StringWordHelper.AllCapitals(word))
                result.Add(word);
            else if (word.Length == 1)
                result.Add(word.ToUpper());
            else
                result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());
        }

        return string.Join(" ", result)
                     .Replace(" Y ", " y ")
                     .Replace(" De ", " de ")
                     .Replace(" O ", " o ");
    }

    public static ToCapitalCase Instance { get; } = new();
}