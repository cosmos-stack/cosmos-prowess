using System.Reflection;

namespace Cosmos.Reflection.Assignment
{
    public static class AssignmentExtensions
    {
        public static object GetValue<T>(this T t, string memberName)
        {
            return t.GetValueAccessor().GetValue(memberName);
        }

        public static object GetValue<T>(this T t, string memberName, BindingFlags bindingAttr)
        {
            return t.GetValueAccessor().GetValue(memberName, bindingAttr);
        }

        public static TM GetValue<T, TM>(this T t, string memberName)
        {
            return (TM)t.GetValueAccessor().GetValue(memberName);
        }

        public static TM GetValue<T, TM>(this T t, string memberName, BindingFlags bindingAttr)
        {
            return (TM)t.GetValueAccessor().GetValue(memberName, bindingAttr);
        }
        
        public static void SetValue<T>(this T t, string memberName, object value)
        {
            t.GetValueAccessor().SetValue(memberName, value);
        }

        public static void SetValue<T>(this T t, string memberName, object value, BindingFlags bindingAttr)
        {
            t.GetValueAccessor().SetValue(memberName, bindingAttr, value);
        }
    }
}