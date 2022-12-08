using Cosmos.Collections;

namespace Cosmos.Text.Joiners;

/// <summary>
/// Joiner<br />
/// 连接器
/// </summary>
public partial class Joiner : IMapJoiner
{
    #region SkipValueNulls

    /// <summary>
    /// Skip null<br />
    /// 跳过 null
    /// </summary>
    /// <returns></returns>
    IMapJoiner IMapJoiner.SkipNulls()
    {
        Options.SetSkipValueNulls();
        return this;
    }

    /// <summary>
    /// Skip null<br />
    /// 跳过 null
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.SkipNulls(SkipNullType type)
    {
        Options.SetSkipValueNulls(type);
        return this;
    }

    #endregion

    #region UseForNull

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull(string key, string value)
    {
        Options.SetMapReplace<string, string, string, string>(_ => key, _ => value);
        return this;
    }

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <param name="keyFunc"></param>
    /// <param name="valueFunc"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull(Func<string, string> keyFunc, Func<string, string> valueFunc)
    {
        Options.SetMapReplace(keyFunc, valueFunc);
        return this;
    }

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <param name="keyFunc"></param>
    /// <param name="valueFunc"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull(Func<string, int, string> keyFunc, Func<string, int, string> valueFunc)
    {
        Options.SetIndexedMapReplace(keyFunc, valueFunc);
        return this;
    }

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull<T1, T2>(T1 key, T2 value)
    {
        Options.SetMapReplace<T1, T1, T2, T2>(_ => key, _ => value);
        return this;
    }

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="keyFunc"></param>
    /// <param name="valueFunc"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull<T1, T2>(Func<T1, int, T1> keyFunc, Func<T2, int, T2> valueFunc)
    {
        Options.SetIndexedMapReplace(keyFunc, valueFunc);
        return this;
    }

    /// <summary>
    /// If null, then use the special value.<br />
    /// 如果为 null，则使用指定的值来替代
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="keyFunc"></param>
    /// <param name="valueFunc"></param>
    /// <returns></returns>
    IMapJoiner IMapJoiner.UseForNull<T1, T2>(Func<T1, T1> keyFunc, Func<T2, T2> valueFunc)
    {
        Options.SetMapReplace(keyFunc, valueFunc);
        return this;
    }

    #endregion

    #region FromTuple

    /// <summary>
    /// Switch to tuple mode<br />
    /// 切换为 Tuple 模式
    /// </summary>
    /// <returns></returns>
    ITupleJoiner IMapJoiner.FromTuple() => this;

    #endregion

    #region Join - KeyValuePair

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    string IMapJoiner.Join(IEnumerable<string> list)
    {
        var replacer = Options.GetMapReplace<string, string, string, string>();
        var defaultKey = replacer.KeyFunc?.Invoke(string.Empty) ?? string.Empty;
        var defaultValue = replacer.ValueFunc?.Invoke(string.Empty) ?? string.Empty;
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, s => s, v => v, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    string IMapJoiner.Join(IEnumerable<string> list, string defaultKey, string defaultValue)
    {
        var replacer = Options.GetMapReplace<string, string, string, string>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, s => s, v => v, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var defaultKey = replacer.KeyFunc == null ? default : replacer.KeyFunc(default);
        var defaultValue = replacer.ValueFunc == null ? default : replacer.ValueFunc(default);
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, converter.To, converter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, IIndexedTypeConverter<T, string> converter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, i => replacer.KeyFunc(default, i), i => replacer.ValueFunc(default, i), converter.To, converter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, ITypeConverter<T, string> keyConverter, ITypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var defaultKey = replacer.KeyFunc == null ? default : replacer.KeyFunc(default);
        var defaultValue = replacer.ValueFunc == null ? default : replacer.ValueFunc(default);
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, keyConverter.To, valueConverter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, IIndexedTypeConverter<T, string> keyConverter, IIndexedTypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, i => replacer.KeyFunc(default, i), i => replacer.ValueFunc(default, i), keyConverter.To, valueConverter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="defaultValue"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <param name="defaultKey"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> keyConverter, ITypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, keyConverter.To, valueConverter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="defaultValue"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <param name="defaultKey"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, IIndexedTypeConverter<T, string> keyConverter, IIndexedTypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, _ => defaultKey, _ => defaultValue, keyConverter.To, valueConverter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, converter.To, converter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, IIndexedTypeConverter<T, string> converter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        var middle = new List<string>();
        JoinToKeyValuePairString(
            middle, (c, k, v, _) => c.Add($"{k}{Options.MapSeparator}{v}"),
            list, _ => defaultKey, _ => defaultValue, converter.To, converter.To, replacer);
        return middle.JoinToString(_on, JoinerUtils.GetMapPredicate(Options));
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <param name="restStrings"></param>
    /// <returns></returns>
    string IMapJoiner.Join(string str1, string str2, params string[] restStrings)
    {
        var list = new List<string> { str1, str2 };
        list.AddRange(restStrings);
        return ((IMapJoiner)this).Join(list);
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="converter"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="restTs"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs)
    {
        var list = new List<T> { t1, t2 };
        list.AddRange(restTs);
        return ((IMapJoiner)this).Join(list, converter);
    }

    /// <summary>
    /// Join<br />
    /// 连接
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="converter"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="restTs"></param>
    /// <returns></returns>
    string IMapJoiner.Join<T>(IIndexedTypeConverter<T, string> converter, T t1, T t2, params T[] restTs)
    {
        var list = new List<T> { t1, t2 };
        list.AddRange(restTs);
        return ((IMapJoiner)this).Join(list, converter);
    }

    private void JoinToKeyValuePairString<T, TContainer>(
        TContainer container, Action<TContainer, string, string, int> containerUpdateFunc,
        IEnumerable<T> list, T defaultKey, T defaultValue, Func<T, string> keyFunc, Func<T, string> valueFunc,
        (Func<T, T> KeyFunc, Func<T, T> ValueFunc) replacer)
    {
        if (list == null)
            return;

        var instances = list.ToList();
        if (!instances.Any())
            return;

        if (instances.Count % 2 == 1)
            instances.Add(defaultValue);

        var timesToLoops = instances.Count / 2;
        var index = 0;
        for (var i = 0; i < timesToLoops; i++)
        {
            var k = instances[index++];
            var v = instances[index++];
            var key = keyFunc(k);
            var value = valueFunc(v);

            if (JoinerUtils.SkipMap(Options, key, value))
                continue;
            if (JoinerUtils.NeedFixMapValue(Options, key, value))
            {
                key = JoinerUtils.FixMapKeySafety(k, key, value, defaultKey, keyFunc, replacer.KeyFunc, Options.SkipValueNullType);
                value = JoinerUtils.FixMapValueSafety(v, value, key, defaultValue, valueFunc, replacer.ValueFunc, Options.SkipValueNullType);
            }

            containerUpdateFunc(container, key, value, i);
        }
    }

    private void JoinToKeyValuePairString<T, TContainer>(
        TContainer container, Action<TContainer, string, string, int> containerUpdateFunc,
        IEnumerable<T> list, Func<int, T> defaultKeyFunc, Func<int, T> defaultValueFunc, Func<T, int, string> keyFunc, Func<T, int, string> valueFunc,
        (Func<T, int, T> KeyFunc, Func<T, int, T> ValueFunc) replacer)
    {
        if (list == null)
            return;

        var instances = list.ToList();
        if (!instances.Any())
            return;

        if (instances.Count % 2 == 1)
        {
            instances.Add(defaultKeyFunc is null ? default : defaultKeyFunc.Invoke(instances.Count));
        }

        var timesToLoops = instances.Count / 2;
        var index = 0;
        for (var i = 0; i < timesToLoops; i++)
        {
            var indexK = index++;
            var indexV = index++;

            var k = instances[indexK];
            var v = instances[indexV];
            var key = keyFunc(k, indexK);
            var value = valueFunc(v, indexV);

            if (JoinerUtils.SkipMap(Options, key, value))
                continue;
            if (JoinerUtils.NeedFixMapValue(Options, key, value))
            {
                var defaultKey = defaultKeyFunc is null ? default : defaultKeyFunc.Invoke(indexK);
                var defaultValue = defaultValueFunc is null ? default : defaultValueFunc.Invoke(indexV);
                key = JoinerUtils.FixMapKeySafety(k, key, value, indexK, defaultKey, keyFunc, replacer.KeyFunc, Options.SkipValueNullType);
                value = JoinerUtils.FixMapValueSafety(v, value, key, indexV, defaultValue, valueFunc, replacer.ValueFunc, Options.SkipValueNullType);
            }

            containerUpdateFunc(container, key, value, i);
        }
    }

    #endregion

    #region AppendTo

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo(StringBuilder builder, IEnumerable<string> list)
    {
        var replacer = Options.GetMapReplace<string, string, string, string>();
        var defaultKey = replacer.KeyFunc?.Invoke(string.Empty) ?? string.Empty;
        var defaultValue = replacer.ValueFunc?.Invoke(string.Empty) ?? string.Empty;
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, s => s, v => v, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo(StringBuilder builder, IEnumerable<string> list, string defaultKey, string defaultValue)
    {
        var replacer = Options.GetMapReplace<string, string, string, string>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, s => s, v => v, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <param name="restStrings"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo(StringBuilder builder, string str1, string str2, params string[] restStrings)
    {
        var list = new List<string> { str1, str2 };
        list.AddRange(restStrings);
        return ((IMapJoiner)this).AppendTo(builder, list);
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> converter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var defaultKey = replacer.KeyFunc == null ? default : replacer.KeyFunc(default);
        var defaultValue = replacer.ValueFunc == null ? default : replacer.ValueFunc(default);
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, converter.To, converter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, IIndexedTypeConverter<T, string> converter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, i => replacer.KeyFunc(default, i), i => replacer.ValueFunc(default, i), converter.To, converter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> keyConverter, ITypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        var defaultKey = replacer.KeyFunc == null ? default : replacer.KeyFunc(default);
        var defaultValue = replacer.ValueFunc == null ? default : replacer.ValueFunc(default);
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, keyConverter.To, valueConverter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, IIndexedTypeConverter<T, string> keyConverter, IIndexedTypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, i => replacer.KeyFunc(default, i), i => replacer.ValueFunc(default, i), keyConverter.To, valueConverter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, converter.To, converter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, IIndexedTypeConverter<T, string> converter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, _ => defaultKey, _ => defaultValue, converter.To, converter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> keyConverter, ITypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, defaultKey, defaultValue, keyConverter.To, valueConverter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="list"></param>
    /// <param name="defaultKey"></param>
    /// <param name="defaultValue"></param>
    /// <param name="keyConverter"></param>
    /// <param name="valueConverter"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, IIndexedTypeConverter<T, string> keyConverter, IIndexedTypeConverter<T, string> valueConverter)
    {
        var replacer = Options.GetIndexedMapReplace<T, T, T, T>();
        JoinToKeyValuePairString(
            builder, (c, k, v, i) => c.Append($"{(i > 0 ? _on : string.Empty)}{k}{Options.MapSeparator}{v}"),
            list, _ => defaultKey, _ => defaultValue, keyConverter.To, valueConverter.To, replacer);
        return builder;
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="converter"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="restTs"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs)
    {
        var list = new List<T> { t1, t2 };
        list.AddRange(restTs);
        return ((IMapJoiner)this).AppendTo(builder, list, converter);
    }

    /// <summary>
    /// Append to...<br />
    /// 附加到...
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="builder"></param>
    /// <param name="converter"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="restTs"></param>
    /// <returns></returns>
    StringBuilder IMapJoiner.AppendTo<T>(StringBuilder builder, IIndexedTypeConverter<T, string> converter, T t1, T t2, params T[] restTs)
    {
        var list = new List<T> { t1, t2 };
        list.AddRange(restTs);
        return ((IMapJoiner)this).AppendTo(builder, list, converter);
    }

    #endregion

    #region Private class

    private partial class JoinerOptions
    {
        #region Skip Value Nulls - Map

        public bool SkipValueNullsFlag { get; private set; }

        public SkipNullType SkipValueNullType { get; private set; } = SkipNullType.Nothing;

        public void SetSkipValueNulls()
        {
            SkipValueNullsFlag = true;
            SkipValueNullType = SkipNullType.WhenBoth;
        }

        public void SetSkipValueNulls(SkipNullType type)
        {
            SkipValueNullsFlag = type != SkipNullType.Nothing;
            SkipValueNullType = type;
        }

        #endregion

        #region UseForNull - Map

        private JoinerObjectReplacer MapReplacer { get; set; }
        private bool MapValueReplacerFlag { get; set; }
        private bool MapValueReplacerIndexedFlag { get; set; }

        public (Func<T1, T2> KeyFunc, Func<T3, T4> ValueFunc) GetMapReplace<T1, T2, T3, T4>()
        {
            var keyFunc = MapValueReplacerFlag ? MapReplacer?.GetMapKey<T1, T2>() : null;
            var valueFunc = MapValueReplacerFlag ? MapReplacer?.GetMapValue<T3, T4>() : null;
            return (keyFunc, valueFunc);
        }

        public (Func<T1, int, T2> KeyFunc, Func<T3, int, T4> ValueFunc) GetIndexedMapReplace<T1, T2, T3, T4>()
        {
            var keyFunc = MapValueReplacerFlag && MapValueReplacerIndexedFlag ? MapReplacer?.GetIndexedMapKey<T1, T2>() : null;
            var valueFunc = MapValueReplacerFlag && MapValueReplacerIndexedFlag ? MapReplacer?.GetIndexedMapValue<T3, T4>() : null;
            return (keyFunc, valueFunc);
        }

        public void SetMapReplace<T1, T2, T3, T4>(Func<T1, T2> mapKeyFunc, Func<T3, T4> mapValueFunc)
        {
            MapValueReplacerFlag = true;
            MapReplacer = JoinerObjectReplacer.CreateForMap(mapKeyFunc, mapValueFunc);
            SetSkipValueNulls(SkipNullType.Nothing);
        }

        public void SetIndexedMapReplace<T1, T2, T3, T4>(Func<T1, int, T2> mapKeyFunc, Func<T3, int, T4> mapValueFunc)
        {
            MapValueReplacerFlag = true;
            MapValueReplacerIndexedFlag = true;
            MapReplacer = JoinerObjectReplacer.CreateForMap(mapKeyFunc, mapValueFunc);
            SetSkipValueNulls(SkipNullType.Nothing);
        }

        #endregion

        #region WithKeyValueSeparator

        public string MapSeparator { get; private set; }

        public void SetMapSeparator(string separator)
        {
            MapSeparator = separator;
        }

        public void SetMapSeparator(char separator)
        {
            MapSeparator = $"{separator}";
        }

        #endregion
    }

    private static partial class JoinerUtils
    {
        public static bool SkipMap(JoinerOptions options, string key, string value)
        {
            if (options.SkipValueNullsFlag)
            {
                switch (options.SkipValueNullType)
                {
                    case SkipNullType.Nothing:
                        return false;

                    case SkipNullType.WhenBoth:
                        return string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value);

                    case SkipNullType.WhenEither:
                        return string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value);

                    case SkipNullType.WhenKeyIsNull:
                        return string.IsNullOrWhiteSpace(key);

                    case SkipNullType.WhenValueIsNull:
                        return string.IsNullOrWhiteSpace(value);
                }
            }

            return false;
        }

        public static bool NeedFixMapValue(JoinerOptions options, string key, string value)
        {
            switch (options.SkipValueNullType)
            {
                case SkipNullType.Nothing:
                    return string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value);

                case SkipNullType.WhenBoth:
                    return false;

                case SkipNullType.WhenEither:
                    return false;

                case SkipNullType.WhenKeyIsNull:
                    return !string.IsNullOrWhiteSpace(key) && string.IsNullOrWhiteSpace(value);

                case SkipNullType.WhenValueIsNull:
                    return string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value);
            }

            return false;
        }

        public static string FixMapKeySafety<T>(T k, string key, string value, T defaultKey, Func<T, string> to, Func<T, T> keyFunc, SkipNullType type)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return key;

            if (type == SkipNullType.WhenEither)
                return key;

            if (type == SkipNullType.Nothing || (type == SkipNullType.WhenValueIsNull && !string.IsNullOrWhiteSpace(value)))
                return to(keyFunc == null ? defaultKey : keyFunc(k));

            return key;
        }

        public static string FixMapKeySafety<T>(T k, string key, string value, int index, T defaultKey, Func<T, int, string> to, Func<T, int, T> keyFunc, SkipNullType type)
        {
            if (!string.IsNullOrWhiteSpace(key))
                return key;

            if (type == SkipNullType.WhenEither)
                return key;

            if (type == SkipNullType.Nothing || (type == SkipNullType.WhenValueIsNull && !string.IsNullOrWhiteSpace(value)))
                return to(keyFunc == null ? defaultKey : keyFunc(k, index), index);

            return key;
        }

        public static string FixMapValueSafety<T>(T v, string value, string key, T defaultValue, Func<T, string> to, Func<T, T> valueFunc, SkipNullType type)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value;

            if (type == SkipNullType.WhenEither)
                return value;

            if (type == SkipNullType.Nothing || (type == SkipNullType.WhenKeyIsNull && !string.IsNullOrWhiteSpace(key)))
                return to(valueFunc == null ? defaultValue : valueFunc(v));

            return value;
        }

        public static string FixMapValueSafety<T>(T v, string value, string key, int index, T defaultValue, Func<T, int, string> to, Func<T, int, T> valueFunc, SkipNullType type)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return value;

            if (type == SkipNullType.WhenEither)
                return value;

            if (type == SkipNullType.Nothing || (type == SkipNullType.WhenKeyIsNull && !string.IsNullOrWhiteSpace(key)))
                return to(valueFunc == null ? defaultValue : valueFunc(v, index), index);

            return value;
        }

        public static Func<string, bool> GetMapPredicate(JoinerOptions options)
        {
            if (options.SkipValueNullsFlag)
                return s => s != options.MapSeparator;
            return null;
        }
    }

    #endregion
}