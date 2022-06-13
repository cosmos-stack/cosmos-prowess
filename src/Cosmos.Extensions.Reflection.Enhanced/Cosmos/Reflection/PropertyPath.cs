using System.Diagnostics;

namespace Cosmos.Reflection;

/// <summary>
/// Property path <br />
/// 属性路径
/// </summary>
public class PropertyPath
{
    internal PropertyPath() : this(null) { }

    internal PropertyPath(PropertyPath root)
    {
        if (root is null)
        {
            _path = new Queue<PropertyInfo>();
            Root = this;
        }
        else
        {
            Root = root;
        }

        Debug.Assert(Root != null);
    }

    private readonly Queue<PropertyInfo> _path;

    /// <summary>
    /// Root <br />
    /// 根节点
    /// </summary>
    public PropertyPath Root { get; }

    /// <summary>
    /// Path <br />
    /// 路径
    /// </summary>
    public IEnumerable<PropertyInfo> Path => Root._path;

    /// <summary>
    /// Append <br />
    /// 附加
    /// </summary>
    /// <param name="property"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected void Append(PropertyInfo property)
    {
        if (property is null)
            throw new ArgumentNullException(nameof(property));

        Root._path.Enqueue(property);
    }

    /// <summary>
    /// Of <br />
    /// 创建一个新的 <see cref="PropertyPath{T}"/> 实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PropertyPath<T> Of<T>() => new();
}