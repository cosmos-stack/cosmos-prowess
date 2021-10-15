using System;

namespace CosmosStack.Text.CharMatchers
{
    /// <summary>
    /// Interface to flag 'NoneOf' mode of char matcher <br />
    /// 用于 NoneOf 模式（无一模式）的字符命中器接口
    /// </summary>
    public interface INoneOfModeCharMatcher : ICharMatcher
    {
        /// <summary>
        /// Negate <br />
        /// 否定
        /// </summary>
        /// <returns></returns>
        IAnyOfModeCharMatcher Negate();

        /// <summary>
        /// In range <br />
        /// 在区间内
        /// </summary>
        /// <param name="startInclusive"></param>
        /// <param name="endInclusive"></param>
        /// <returns></returns>
        string InRange(char startInclusive, char endInclusive);

        /// <summary>
        /// For predicate <br />
        /// 设置条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        string ForPredicate(Func<char, bool> predicate);

        /// <summary>
        /// Matches any of <br />
        /// 标记是否命中任一
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesAnyOf(string sequence);

        /// <summary>
        /// Matches all of <br />
        /// 标记是否命中全部
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesAllOf(string sequence);

        /// <summary>
        /// Matches none of <br />
        /// 标记是否无一命中
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesNoneOf(string sequence);

        /// <summary>
        /// Index in <br />
        /// 返回字符所在序列中的索引
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int IndexIn(string sequence);

        /// <summary>
        /// Index in <br />
        /// 返回字符所在序列中的索引
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        int IndexIn(string sequence, int startIndex);

        /// <summary>
        /// Last index in <br />
        /// 返回字符所在序列中的倒序索引
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int LastIndexIn(string sequence);

        /// <summary>
        /// Count in <br />
        /// 返回字符在序列中出现的次数
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int CountIn(string sequence);

        /// <summary>
        /// Remove from <br />
        /// 从序列中移除相同字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string RemoveFrom(string sequence);

        /// <summary>
        /// Retain from <br />
        /// 从序列中移除不同字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string RetainFrom(string sequence);

        /// <summary>
        /// Replace from <br />
        /// 在序列中用给定的字符代替命中器中设置的字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string ReplaceFrom(string sequence, char replacement);

        /// <summary>
        /// Replace from <br />
        /// 在序列中用给定的字符代替命中器中设置的字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string ReplaceFrom(string sequence, string replacement);

        /// <summary>
        /// Trim from <br />
        /// 从两端裁剪命中器中设置的字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimFrom(string sequence);

        /// <summary>
        /// Trim leading from <br />
        /// 从头部裁剪命中器中设置的字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimLeadingForm(string sequence);

        /// <summary>
        /// Trim trailing from <br />
        /// 从尾部裁剪命中器中设置的字符
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimTrailingFrom(string sequence);

        /// <summary>
        /// Collapse from <br />
        /// 折叠
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string CollapseFrom(string sequence, char replacement);

        /// <summary>
        /// Trim and collapse from <br />
        /// 折叠并裁剪
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string TrimAndCollapseFrom(string sequence, char replacement);

        /// <summary>
        /// Apply <br />
        /// 执行匹配
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool Apply(char character);
    }
}