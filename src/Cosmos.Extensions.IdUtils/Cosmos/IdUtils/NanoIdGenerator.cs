using System.Security.Cryptography;

namespace Cosmos.IdUtils;

/// <summary>
/// Nano Id Generator <br />
/// Nano Id 生成器
/// </summary>
public static class NanoIdGenerator
{
    private static readonly RandomForNanoId Random = new();

    /// <summary>
    /// Generate NanoId <br />
    /// 生成 Nano Id
    /// </summary>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static string Generate(string alphabet = RandomIdGenerator.NANOWORDS, int size = 21)
    {
        return Generate(Random, alphabet, size);
    }

    /// <summary>
    /// Generate NanoId <br />
    /// 生成 Nano Id
    /// </summary>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static async Task<string> GenerateAsync(string alphabet = RandomIdGenerator.NANOWORDS, int size = 21)
    {
        return await Task.Run(() => Generate(Random, alphabet, size));
    }

    /// <summary>
    /// Generate NanoId <br />
    /// 生成 Nano Id
    /// </summary>
    /// <param name="random"></param>
    /// <param name="alphabet"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string Generate(Random random, string alphabet = RandomIdGenerator.NANOWORDS, int size = 21)
    {
        ArgumentNullException.ThrowIfNull(random);
        ArgumentNullException.ThrowIfNull(alphabet);

        if (alphabet.Length <= 0 || alphabet.Length >= 256)
            throw new ArgumentOutOfRangeException(nameof(alphabet.Length), "alphabet must contain between 1 and 255 symbols.");

        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "size must be greater than zero.");

        // See https://github.com/ai/nanoid/blob/master/format.js for
        // explanation why masking is use (`random % alphabet` is a common
        // mistake security-wise).
        var mask = (2 << 31 - Clz32((alphabet.Length - 1) | 1)) - 1;
        var step = (int)Math.Ceiling(1.6 * mask * size / alphabet.Length);

        Span<char> idBuilder = stackalloc char[size];
        Span<byte> bytes = stackalloc byte[step];

        int cnt = 0;

        while (true)
        {
            random.NextBytes(bytes);

            for (var i = 0; i < step; i++)
            {
                var alphabetIndex = bytes[i] & mask;

                if (alphabetIndex >= alphabet.Length) continue;
                idBuilder[cnt] = alphabet[alphabetIndex];
                if (++cnt == size)
                {
                    return new string(idBuilder);
                }
            }
        }
    }

    /// <summary>
    /// Counts leading zeros of <paramref name="x"/>.
    /// </summary>
    /// <param name="x">Input number.</param>
    /// <returns>Number of leading zeros.</returns>
    /// <remarks>
    /// Courtesy of spender/Sunsetquest see https://stackoverflow.com/a/10439333/623392.
    /// </remarks>
    private static int Clz32(int x)
    {
        const int numIntBits = sizeof(int) * 8; //compile time constant
        //do the smearing
        x |= x >> 1;
        x |= x >> 2;
        x |= x >> 4;
        x |= x >> 8;
        x |= x >> 16;
        //count the ones
        x -= x >> 1 & 0x55555555;
        x = (x >> 2 & 0x33333333) + (x & 0x33333333);
        x = (x >> 4) + x & 0x0f0f0f0f;
        x += x >> 8;
        x += x >> 16;
        return numIntBits - (x & 0x0000003f); //subtract # of 1s from 32
    }
}

internal class RandomForNanoId : Random
{
    private static RandomNumberGenerator _generator;

    static RandomForNanoId()
    {
        _generator = RandomNumberGenerator.Create();
    }

    public override void NextBytes(byte[] buffer)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        _generator.GetBytes(buffer);
    }

    public override void NextBytes(Span<byte> buffer)
    {
        RandomNumberGenerator.Fill(buffer);
    }

    public override double NextDouble()
    {
        Span<byte> uint32Buffer = stackalloc byte[4];
        RandomNumberGenerator.Fill(uint32Buffer);
        return BitConverter.ToUInt32(uint32Buffer) / (1.0 + UInt32.MaxValue);
    }

    public override int Next(int minValue, int maxValue)
    {
        if (minValue > maxValue)
            throw new ArgumentOutOfRangeException(nameof(minValue));

        if (minValue == maxValue)
            return minValue;

        var range = (long)maxValue - minValue;
        return (int)((long)Math.Floor(NextDouble() * range) + minValue);
    }

    public override int Next()
    {
        return Next(0, int.MaxValue);
    }

    public override int Next(int maxValue)
    {
        if (maxValue < 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        return Next(0, maxValue);
    }
}