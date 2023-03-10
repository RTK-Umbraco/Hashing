using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class HMAC
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private const int KeySize = 32;

        public byte[] GenerateKey()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[KeySize];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public byte[] SelectHmacMethod(int userinput, byte[] bytes, byte[] key)
        {
            switch (userinput)
            {
                case 1:
                    return ComputeHmacSha1(bytes, key);
                case 2:
                    return ComputeHmacSha256(bytes, key);
                case 3:
                    return ComputeHmacSha512(bytes, key);
                case 4:
                    return ComputeHmacMd5(bytes, key);
                default:
                    throw new ArgumentException("Input out of range");
            }
        }

        private byte[] ComputeHmacSha1(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA1(key))
            {
                _stopwatch.Start();
                var hash = hmac.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }

        private byte[] ComputeHmacSha256(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                _stopwatch.Start();
                var hash = hmac.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }

        private byte[] ComputeHmacSha512(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                _stopwatch.Start();
                var hash = hmac.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }

        private byte[] ComputeHmacMd5(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACMD5(key))
            {
                _stopwatch.Start();
                var hash = hmac.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }
    }
}
