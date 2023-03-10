using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace Hashing
{
    public class Hash
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public byte[] SelectHashMethod(int userinput, byte[] bytes)
        {
            switch (userinput)
            {
                case 1:
                    return ComputeHashSha1(bytes);
                case 2:
                    return ComputeHashSha256(bytes);
                case 3:
                    return ComputeHashSha512(bytes);
                case 4:
                    return ComputeHashMd5(bytes);
                default:
                    throw new ArgumentException("Input out of range");
            }
        }

        private byte[] ComputeHashSha1(byte[] toBeHashed)
        {

            using (var sha1 = SHA1.Create())
            {
                _stopwatch.Start();
                var hash = sha1.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }

        private byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                _stopwatch.Start();
                var hash = sha256.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }
        private byte[] ComputeHashSha512(byte[] toBeHashed)
        {
            using (var sha512 = SHA512.Create())
            {
                _stopwatch.Start();
                var hash = sha512.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }

        private byte[] ComputeHashMd5(byte[] toBeHashed)
        {
            using (var md5 = MD5.Create())
            {
                _stopwatch.Start();
                var hash = md5.ComputeHash(toBeHashed);
                _stopwatch.Stop();
                Console.WriteLine();
                Console.WriteLine($"Time: {_stopwatch.Elapsed}");

                return hash;
            }
        }
    }
}
