using System;
using Cosmos.Optionals;

namespace Cosmos.Text
{
    public partial struct ValueString
    {
        /// <summary>
        /// Maybe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> ToMaybe<T>() => Optional.From(As<T>());

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> ToMaybe<T>(Func<T, bool> condition) => Optional.From(As<T>(), condition);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> ToMaybe<T>(T defaultVal) => Optional.From(As<T>()).Or(defaultVal);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Maybe<T> ToMaybe<T>(Func<T, bool> condition, T defaultVal) => Optional.From(As<T>(), condition).Or(defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>() => ToMaybe<T>().Value;

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(Func<T, bool> condition) => ToMaybe(condition).Value;

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(T defaultVal) => ToMaybe<T>().ValueOr(defaultVal);

        /// <summary>
        /// Maybe value
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MaybeValue<T>(Func<T, bool> condition, T defaultVal) => ToMaybe(condition).ValueOr(defaultVal);
    }
}