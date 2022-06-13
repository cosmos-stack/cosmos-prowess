namespace Cosmos.Text.Splitters;

/// <summary>
/// Splitter interface <br />
/// Splitter 接口
/// </summary>
public interface ISplitter
{
    /// <summary>
    /// Omit empty strings <br />
    /// 忽略空字符串
    /// </summary>
    /// <returns></returns>
    ISplitter OmitEmptyStrings();

    /// <summary>
    /// Trim results <br />
    /// 裁剪结果
    /// </summary>
    /// <returns></returns>
    ISplitter TrimResults();

    /// <summary>
    /// Trim results <br />
    /// 裁剪结果
    /// </summary>
    /// <param name="trimFunc"></param>
    /// <returns></returns>
    ISplitter TrimResults(Func<string, string> trimFunc);

    /// <summary>
    /// Limit <br />
    /// 限制
    /// </summary>
    /// <param name="limit"></param>
    /// <returns></returns>
    ISplitter Limit(int limit);

    /// <summary>
    /// With KeyValue separator <br />
    /// 设置键值对分隔符
    /// </summary>
    /// <param name="separator"></param>
    /// <returns></returns>
    IMapSplitter WithKeyValueSeparator(char separator);

    /// <summary>
    /// With KeyValue separator <br />
    /// 设置键值对分隔符
    /// </summary>
    /// <param name="separator"></param>
    /// <returns></returns>
    IMapSplitter WithKeyValueSeparator(string separator);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <param name="originalString"></param>
    /// <returns></returns>
    IEnumerable<string> Split(string originalString);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    IEnumerable<T> Split<T>(string originalString, IObjectSerializer serializer);

    /// <summary>
    /// Split <br />
    /// 切割
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    IEnumerable<T> Split<T>(string originalString, ITypeConverter<string, T> converter);

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
    IEnumerable<T> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);

    /// <summary>
    /// Split to list <br />
    /// 切割为列表
    /// </summary>
    /// <param name="originalString"></param>
    /// <returns></returns>
    List<string> SplitToList(string originalString);

    /// <summary>
    /// Split to list <br />
    /// 切割为列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    List<T> SplitToList<T>(string originalString, IObjectSerializer serializer);

    /// <summary>
    /// Split to list <br />
    /// 切割为列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter);

    /// <summary>
    /// Split to list <br />
    /// 切割为列表
    /// </summary>
    /// <typeparam name="TMiddle"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);

    /// <summary>
    /// Split to array <br />
    /// 切割为数组
    /// </summary>
    /// <param name="originalString"></param>
    /// <returns></returns>
    string[] SplitToArray(string originalString);

    /// <summary>
    /// Split to array <br />
    /// 切割为数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    T[] SplitToArray<T>(string originalString, IObjectSerializer serializer);

    /// <summary>
    /// Split to array <br />
    /// 切割为数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    T[] SplitToArray<T>(string originalString, ITypeConverter<string, T> converter);

    /// <summary>
    /// Split to array <br />
    /// 切割为数组
    /// </summary>
    /// <typeparam name="TMiddle"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="originalString"></param>
    /// <param name="serializer"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    T[] SplitToArray<TMiddle, T>(string originalString, IObjectSerializer serializer, IGenericObjectMapper mapper);
}