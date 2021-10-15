using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.EnumUtils.DynamicEnumServices
{
    /// <summary>
    /// When the specified conditions are met, or the specified enumeration is matched, the given action is executed. <br />
    /// 当满足指定条件，或匹配指定枚举时，执行给定的动作。
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public readonly struct DynamicEnumThen<TEnum, TValue>
        where TEnum : IDynamicEnum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private readonly IDynamicEnum _instance;
        private readonly bool _stopEval;

        internal DynamicEnumThen(bool stopEval, IDynamicEnum instance)
        {
            _stopEval = stopEval;
            _instance = instance;
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="action"></param>
        public void Default(Action action)
        {
            if (!_stopEval)
                action?.Invoke();
        }

        /// <summary>
        /// When... <br />
        /// 当… （添加一个新的条件或枚举）
        /// </summary>
        /// <param name="instanceWhen"></param>
        /// <returns></returns>
        public DynamicEnumWhen<TEnum, TValue> When(IDynamicEnum instanceWhen)
        {
            return new DynamicEnumWhen<TEnum, TValue>(_instance.Equals(instanceWhen), _stopEval, _instance);
        }

        /// <summary>
        /// When... <br />
        /// 当… （添加一个新的条件或枚举）
        /// </summary>
        /// <param name="instances"></param>
        /// <returns></returns>
        public DynamicEnumWhen<TEnum, TValue> When(params IDynamicEnum[] instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }

        /// <summary>
        /// When... <br />
        /// 当… （添加一个新的条件或枚举）
        /// </summary>
        /// <param name="instances"></param>
        /// <returns></returns>
        public DynamicEnumWhen<TEnum, TValue> When(IEnumerable<IDynamicEnum> instances)
        {
            return new DynamicEnumWhen<TEnum, TValue>(instances.Contains(_instance), _stopEval, _instance);
        }
    }
}