using System;
using System.Collections.Generic;

namespace CosmosStack.Text.Joiners
{
    /// <summary>
    /// Common join utils <br />
    /// 公共合并工具
    /// </summary>
    public static class CommonJoinUtils
    {
        /// <summary>
        /// Combine collections into strings.<br />
        /// 将集合合并为字符串。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContainer"></typeparam>
        /// <param name="container"></param>
        /// <param name="containerUpdateFunc"></param>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="to"></param>
        /// <param name="replaceFunc"></param>
        public static void JoinToString<T, TContainer>(
            TContainer container, Action<TContainer, string> containerUpdateFunc,
            IEnumerable<T> list, string delimiter,
            Func<T, bool> predicate, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            if (list is null)
                return;

            var head = true;

            foreach (var item in list)
            {
                var checker = item;
                if (!(predicate?.Invoke(checker) ?? true))
                {
                    if (replaceFunc == null)
                        continue;
                    checker = replaceFunc(item);
                }

                if (head)
                {
                    head = false;
                }
                else
                {
                    containerUpdateFunc.Invoke(container, delimiter);
                }

                containerUpdateFunc.Invoke(container, to(checker));
            }
        }

        /// <summary>
        /// Combine collections into strings.<br />
        /// 将集合合并为字符串。
        /// </summary>
        /// <param name="container"></param>
        /// <param name="containerUpdateFunc"></param>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="to"></param>
        /// <param name="replaceFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContainer"></typeparam>
        public static void JoinToString<T, TContainer>(
            TContainer container, Action<TContainer, string> containerUpdateFunc,
            IEnumerable<T> list, string delimiter,
            Func<T, int, bool> predicate, Func<T, int, string> to, Func<T, int, T> replaceFunc = null)
        {
            if (list is null)
                return;

            var head = true;
            var index = -1;

            foreach (var item in list)
            {
                var checker = item;
                index++;
                
                if (!(predicate?.Invoke(checker, index) ?? true))
                {
                    if (replaceFunc == null)
                        continue;
                    checker = replaceFunc(item, index);
                }

                if (head)
                {
                    head = false;
                }
                else
                {
                    containerUpdateFunc.Invoke(container, delimiter);
                }

                containerUpdateFunc.Invoke(container, to(checker, index));
            }
        }
    }
}