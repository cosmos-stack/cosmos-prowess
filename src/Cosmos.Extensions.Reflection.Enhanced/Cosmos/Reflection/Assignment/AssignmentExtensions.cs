namespace Cosmos.Reflection.Assignment;

/// <summary>
/// Assignment Extensions <br />
/// 访问性扩展
/// </summary>
public static partial class AssignmentExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object GetValue<T>(this T t, string memberName)
    {
        return t.GetValueAccessor().GetValue(memberName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object GetValue<T>(this T t, string memberName, BindingFlags bindingAttr)
    {
        return t.GetValueAccessor().GetValue(memberName, bindingAttr);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TM GetValue<T, TM>(this T t, string memberName)
    {
        return (TM)t.GetValueAccessor().GetValue(memberName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TM GetValue<T, TM>(this T t, string memberName, BindingFlags bindingAttr)
    {
        return (TM)t.GetValueAccessor().GetValue(memberName, bindingAttr);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetValue<T>(this T t, string memberName, object value)
    {
        t.GetValueAccessor().SetValue(memberName, value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void SetValue<T>(this T t, string memberName, object value, BindingFlags bindingAttr)
    {
        t.GetValueAccessor().SetValue(memberName, bindingAttr, value);
    }
}