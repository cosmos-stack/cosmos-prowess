using System;
using System.Text;
using CosmosStack.Text;

namespace CosmosStack.IdUtils
{
    /// <summary>
    /// Random NonceStr Provider <br />
    /// 随机字符串提供者程序
    /// </summary>
    public static class RandomNonceStrGenerator
    {
        // ReSharper disable once InconsistentNaming
        private const string NONCESTR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly object _lock = new();

        /// <summary>
        /// Create random NonceStr <br />
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string Create(bool forceToAvoidRepetition = false)
        {
            return Create(16, forceToAvoidRepetition);
        }

        /// <summary>
        /// Create random NonceStr <br />
        /// 生成随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <param name="forceToAvoidRepetition"></param>
        /// <returns></returns>
        public static string Create(int length, bool forceToAvoidRepetition = false)
        {
            if (length <= 16)
            {
                length = 16;
            }

            var sb = new StringBuilder();
            Random rd;

            if (forceToAvoidRepetition)
            {
                lock (_lock)
                {
                    rd = new Random(RandomIdGenerator.Create(8, RandomIdGenerator.ALLNUMBERS).CastToInt());
                }
            }
            else
            {
                rd = new Random();
            }

            for (var i = 0; i < length; i++)
                sb.Append(NONCESTR[rd.Next(NONCESTR.Length - 1)]);

            return sb.ToString();
        }
    }
}