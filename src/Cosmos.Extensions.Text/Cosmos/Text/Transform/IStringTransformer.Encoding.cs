namespace Cosmos.Text;

public interface IEncodedStringTransformer : IStringTransformer
{
    /// <summary>
    /// Transform the input
    /// </summary>
    /// <param name="input">String to be transformed</param>
    /// <param name="encoding">The encoding</param>
    /// <returns></returns>
    string Transform(string input, Encoding encoding);
}