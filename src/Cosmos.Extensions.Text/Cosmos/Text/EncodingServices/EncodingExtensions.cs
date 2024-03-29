﻿using System.Buffers;
using Cosmos.Exceptions;

namespace Cosmos.Text.EncodingServices;

/// <summary>
/// Encoding Extensions <br />
/// Encoding 扩展
/// </summary>
public static class EncodingExtensions
{
    /// <summary>
    /// Get the string safely <br />
    /// 安全地获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSafeString(this Encoding encoding, ReadOnlySpan<byte> bytes)
    {
        if (encoding is null)
            return string.Empty;

        if (bytes.IsEmpty)
            return string.Empty;

        return encoding.GetString(bytes);
    }

    /// <summary>
    /// Get the string safely <br />
    /// 安全地获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <param name="byteCount"></param>
    /// <returns></returns>
    public static unsafe string GetSafeString(this Encoding encoding, byte* bytes, int byteCount)
    {
        if (encoding is null)
            return string.Empty;

        return Try.Create(() => encoding.GetString(bytes, byteCount)).GetSafeValue(string.Empty);
    }

    /// <summary>
    /// Get the string safely <br />
    /// 安全地获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSafeString(this Encoding encoding, byte[] bytes)
    {
        if (encoding is null)
            return string.Empty;

        if (bytes is null || bytes.Length == 0)
            return string.Empty;

        return encoding.GetString(bytes);
    }

    /// <summary>
    /// Get the string safely <br />
    /// 安全地获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get the string safely <br />
    /// 安全地获取字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSafeString(this Encoding encoding, in ReadOnlySequence<byte> bytes)
    {
        if (encoding is null)
            return string.Empty;

        if (bytes.IsEmpty)
            return string.Empty;

        return encoding.GetString(in bytes);
    }
}