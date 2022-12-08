using Cosmos.Collections;

namespace Cosmos.Text;

/// <summary>
/// Additional <see cref="string" /> extensions. <br />
/// 额外的字符串扩展
/// </summary>
public static partial class StringProwessExtensions
{
    #region Join

    /// <summary>
    /// Combine the given set with a specific string as the delimiter. <br />
    /// 将给定的集合以特定的字符串为分隔符进行合并。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="separator"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static string JoinStringFor<T>(this string separator, IEnumerable<T> list) => list.JoinToString(separator);

    #endregion

    #region Split

    /// <summary>
    /// Split the specified text according to the given index position,
    /// and return the two parts of the characters obtained as a tuple. <br />
    /// 将指定文本根据给定的索引位置进行分割，
    /// 并将分割所得的两部分字符以元组形式返回。
    /// </summary>
    /// <param name="that"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Tuple<string, string> SplitByIndex(this string that, int index)
    {
        if (that.IsNullOrEmpty())
            return new Tuple<string, string>("", "");

        if (index >= that.Length)
            return new Tuple<string, string>(that, "");

        if (index <= 0)
            return new Tuple<string, string>("", that);

        return new Tuple<string, string>(that.Substring(0, index - 1), that.Substring(index - 1));
    }

    /// <summary>
    /// Split the specified text according to the given delimiter,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 将指定文本根据给定的分隔符进行分割，并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static T[] SplitTyped<T>(this string that, char delimiter) where T : IComparable
    {
        if (that.IsNullOrWhiteSpace())
            return Arrays.Empty<T>();

        return that
               .Trim()
               .Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
               .Select(p => (T)Convert.ChangeType(p, typeof(T)))
               .ToArray();
    }

    /// <summary>
    /// Split the specified text according to the given delimiter,
    /// and convert the resulting character array into instance data of the specified type. <br />
    /// 将指定文本根据给定的分隔符进行分割，并将分割所得的字符数组转换为指定类型的实例数据。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static T[] SplitTyped<T>(this string that, string delimiter) where T : IComparable
    {
        if (that.IsNullOrWhiteSpace())
            return Arrays.Empty<T>();

        return that
               .Trim()
               .Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
               .Select(p => (T)Convert.ChangeType(p, typeof(T)))
               .ToArray();
    }

    #endregion
}