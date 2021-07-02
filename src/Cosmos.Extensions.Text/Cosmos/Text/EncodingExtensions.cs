using System;
using System.Buffers;
using System.Text;
using Cosmos.Exceptions;

namespace Cosmos.Text
{
    public static class EncodingExtensions
    {
#if !NETFRAMEWORK
        public static string GetSafeString(this Encoding encoding, ReadOnlySpan<byte> bytes)
        {
            if (encoding is null)
                return string.Empty;

            if (bytes.IsEmpty)
                return string.Empty;

            return encoding.GetString(bytes);
        }

#endif

#if !NET451 && !NET452
        public static unsafe string GetSafeString(this Encoding encoding, byte* bytes, int byteCount)
        {
            if (encoding is null)
                return string.Empty;

            return Try.Create(() => encoding.GetString(bytes, byteCount)).GetSafeValue(string.Empty);
        }

#endif

        public static string GetSafeString(this Encoding encoding, byte[] bytes)
        {
            if (encoding is null)
                return string.Empty;

            if (bytes is null || bytes.Length == 0)
                return string.Empty;

            return encoding.GetString(bytes);
        }

        public static string GetSafeString(this Encoding encoding, byte[] bytes, int index, int count)
        {
            if (encoding is null)
                return string.Empty;

            if (bytes is null || bytes.Length == 0)
                return string.Empty;

            if (index >= bytes.Length || index + count > bytes.Length)
                return string.Empty;

            return encoding.GetString(bytes, index, count);
        }

#if !NETFRAMEWORK && !NETCOREAPP3_1
        public static string GetSafeString(this Encoding encoding, in ReadOnlySequence<byte> bytes)
        {
            if (encoding is null)
                return string.Empty;

            if (bytes.IsEmpty)
                return string.Empty;

            return encoding.GetString(in bytes);
        }

#endif
    }
}