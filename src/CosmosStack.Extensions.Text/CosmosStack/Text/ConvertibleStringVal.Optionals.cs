using System;
using CosmosStack.Optionals;

namespace CosmosStack.Text
{
    /// <summary>
    /// The structure used for string parsing can more easily convert the string
    /// to the type specified by the user through the Cosmos.Conversions and XConv toolset. <br />
    /// 用于字符串解析的结构体可以通过 Cosmos.Conversions 和 XConv 工具集更轻松地将字符串转换为用户指定的类型。
    /// </summary>
    public readonly partial struct ConvertibleStringVal: IMaybeable
    {
        /// <summary>
        /// Maybe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> AsOptionals<T>() => Optional.From(As<T>());

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> AsOptionals<T>(Func<T, bool> condition) => Optional.From(As<T>(), condition);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> AsOptionals<T>(T defaultVal) => Optional.From(As<T>()).Or(defaultVal);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> AsOptionals<T>(Func<T, bool> condition, T defaultVal) => Optional.From(As<T>(), condition).Or(defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>() => AsOptionals<T>().Value;

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(Func<T, bool> condition) => AsOptionals(condition).Value;

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(T defaultVal) => AsOptionals<T>().ValueOr(defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(Func<T, bool> condition, T defaultVal) => AsOptionals(condition).ValueOr(defaultVal);
    }
}