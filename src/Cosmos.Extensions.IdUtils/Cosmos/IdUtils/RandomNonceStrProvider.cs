using System;
using System.Text;
using Cosmos.Date;
using Cosmos.Text;

namespace Cosmos.IdUtils
{
    /// <summary>
    /// Random NonceStr Provider
    /// </summary>
    public static class RandomNonceStrProvider
    {
        // ReSharper disable once InconsistentNaming
        private const string NONCESTR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly object _lock = new();

        /// <summary>
        /// Create random noncestr
        /// </summary>
        /// <returns></returns>
        public static string Create(bool forceToAvoidRepetition = false)
        {
            return Create(16, forceToAvoidRepetition);
        }

        /// <summary>
        /// Create random noncestr
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
                    rd = new Random(RandomIdProvider.Create(8, RandomIdProvider.ALLNUMBERS).CastToInt());
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