namespace Cosmos.Text.Splitters;

/// <summary>
/// MapSplitter interface <br />
/// MapSplitter 接口
/// </summary>
public interface IMapSplitter
{
    /// <summary>
    /// Trim results <br />
    /// 裁剪结果
    /// </summary>
    /// <returns></returns>
    IMapSplitter TrimResults();

    /// <summary>
    /// Trim results <br />
    /// 裁剪结果
    /// </summary>
    /// <param name="keyTrimFunc"></param>
    /// <param name="valueTrimFunc"></param>
    /// <returns></returns>
    IMapSplitter TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc);

    /// <summary>
    /// Limit <br />
    /// 限制
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    IMapSplitter Limit(int limit);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <param name="originalString"></param>
    /// <returns></returns>
    IEnumerable<KeyValuePair<string, string>> Split(string originalString);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, IObjectSerializer serializer);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, ITypeConverter<string, T> converter);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <typeparam name="TMiddle"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    IEnumerable<KeyValuePair<string, T>> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);

    /// <summary>
    /// Split to dictionary <br />
    /// 切割为字典
    /// </summary>
    /// <param name="originalString"></param>
    /// <returns></returns>
    Dictionary<string, string> SplitToDictionary(string originalString);

    /// <summary>
    /// Split to dictionary <br />
    /// 切割为字典
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer);

    /// <summary>
    /// Split to dictionary <br />
    /// 切割为字典
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter);

    /// <summary>
    /// Split to dictionary <br />
    /// 切割为字典
    /// </summary>
    /// <typeparam name="TMiddle"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);
}