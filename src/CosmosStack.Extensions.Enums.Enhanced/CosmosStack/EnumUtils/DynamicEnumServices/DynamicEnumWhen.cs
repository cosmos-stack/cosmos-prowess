using System;

namespace CosmosStack.EnumUtils.DynamicEnumServices
{
    /// <summary>
    /// Set conditions or enumerations to determine whether to perform a given action. <br />
    /// 设置条件或枚举，用于判断是否执行给定的动作。
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public readonly struct DynamicEnumWhen<TEnum, TValue>
        where TEnum : IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly bool _isMatch;
        private readonly IDynamicEnum _instance;
        private readonly bool _stopEval;

        public DynamicEnumWhen(bool isMatch, bool stopEval, IDynamicEnum instance)
        {
            _isMatch = isMatch;
            _stopEval = stopEval;
            _instance = instance;
        }

        /// <summary>
        /// Then do... <br />
        /// 然后执行…
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public DynamicEnumThen<TEnum, TValue> Then(Action action)
        {
            if (!_stopEval && _isMatch)
                action?.Invoke();
            return new DynamicEnumThen<TEnum, TValue>(_stopEval || _isMatch, _instance);
        }
    }
}