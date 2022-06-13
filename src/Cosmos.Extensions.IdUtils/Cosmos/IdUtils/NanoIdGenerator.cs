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
        if (random is null)
            throw new ArgumentNullException(nameof(random), "random cannot be null.");

        if (alphabet is null)
            throw new ArgumentNullException(nameof(alphabet), "alphabet cannot be null.");

        if (alphabet.Length <= 0 || alphabet.Length >= 256)
            throw new ArgumentOutOfRangeException(nameof(alphabet.Length), "alphabet must contain between 1 and 255 symbols.");

        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "size must be greater than zero.");

        // See https://github.com/ai/nanoid/blob/master/format.js for
        // explanation why masking is use (`random % alphabet` is a common
        // mistake security-wise).
        var mask = (2 << 31 - Clz32((alphabet.Length - 1) | 1)) - 1;
        var step = (int)Math.Ceiling(1.6 * mask * size / alphabet.Length);

#if !NETFRAMEWORK
        Span<char> idBuilder = stackalloc char[size];
        Span<byte> bytes = stackalloc byte[step];
#else
            var idBuilder = new char[size];
            var bytes = new byte[step];
#endif

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

#if NETFRAMEWORK
        private readonly byte[] _uint32Buffer = new byte[4];
#endif

    static RandomForNanoId()
    {
        _generator = RandomNumberGenerator.Create();
    }

    public override void NextBytes(byte[] buffer)
    {
        if (buffer is null)
            throw new ArgumentNullException(nameof(buffer));
        _generator.GetBytes(buffer);
    }

#if !NETFRAMEWORK
    public override void NextBytes(Span<byte> buffer)
    {
        RandomNumberGenerator.Fill(buffer);
    }
#endif

    public override double NextDouble()
    {
#if !NETFRAMEWORK
        Span<byte> uint32Buffer = stackalloc byte[4];
        RandomNumberGenerator.Fill(uint32Buffer);
        return BitConverter.ToUInt32(uint32Buffer) / (1.0 + UInt32.MaxValue);
#else
            _generator.GetBytes(_uint32Buffer);
            return BitConverter.ToUInt32(_uint32Buffer, 0) / (1.0 + UInt32.MaxValue);
#endif
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