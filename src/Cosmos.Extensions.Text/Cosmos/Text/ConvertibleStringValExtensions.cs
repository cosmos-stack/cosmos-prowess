namespace Cosmos.Text;

/// <summary>
/// Cosmos ConvertibleStringVal extensions <br />
/// 可转换性字符串值扩展
/// </summary>
public static class ConvertibleStringValExtensions
{
    /// <summary>
    /// Try get value from dictionary <br />
    /// 尝试从字典中获得值
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static bool TryGetValue<TKey, TValue>(
        this IReadOnlyDictionary<TKey, ConvertibleStringVal> source, TKey key, out TValue value)
        where TValue : struct
    {
        return TryGetValue(source, key, CultureInfo.InvariantCulture, out value);
    }

    /// <summary>
    /// Try get value from dictionary <br />
    /// 尝试从字典中获得值
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key"></param>
    /// <param name="provider"></param>
    /// <param name="value"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool TryGetValue<TKey, TValue>(
        this IReadOnlyDictionary<TKey, ConvertibleStringVal> source, TKey key, IFormatProvider provider, out TValue value)
        where TValue : struct
    {
        try
        {
            if (source.TryGetValue(key, out var v) && v.Is(provider, out value))
                return true;
        }
        catch (NullReferenceException)
        {
            throw new ArgumentNullException(nameof(source));
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Add <br />
    /// 添加
    /// </summary>
    /// <param name="target"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Add<TKey, TValue>(
        this IDictionary<TKey, ConvertibleStringVal> target, TKey key, TValue value)
    {
        try
        {
            target.Add(key, ConvertibleStringVal.Of(value));
        }
        catch (NullReferenceException)
        {
            throw new ArgumentNullException(nameof(target));
        }
    }

    /// <summary>
    /// Set <br />
    /// 设置
    /// </summary>
    /// <param name="target"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Set<TKey, TValue>(
        this IDictionary<TKey, ConvertibleStringVal> target, TKey key, TValue value)
    {
        try
        {
            target[key] = ConvertibleStringVal.Of(value);
        }
        catch (NullReferenceException)
        {
            throw new ArgumentNullException(nameof(target));
        }
    }
}