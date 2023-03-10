using System.Security.Cryptography;
using System.Text;

namespace Hashing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                var plainText = "Hello world";

                Console.WriteLine("Choose hash algoritme");
                Console.WriteLine("1. Hash");
                Console.WriteLine("2. HMAC");

                var userInput = Convert.ToInt32(Console.ReadLine());

                ChooseHashAlgoritme(plainText, userInput);

                Console.ReadKey();

                Console.Clear();
            }
        }

        private static void ChooseHashAlgoritme(string plainText, int userInput)
        {
            switch (userInput)
            {
                case 1:
                    HashAlgoritme(plainText);
                    break;
                case 2:
                    HMACAlgoritme(plainText);
                    break;
                default:
                    break;
            }
        }

        private static void HMACAlgoritme(string plainText)
        {

            HMAC hMAC = new HMAC();
            var bytes = Encoding.UTF8.GetBytes(plainText);
            var key = hMAC.GenerateKey();

            Console.WriteLine($"Text that is being hashed {plainText}");
            Console.WriteLine();
            Console.WriteLine("Choose hash algoritme");
            Console.WriteLine("1. SHA1");
            Console.WriteLine("2. SHA256");
            Console.WriteLine("3. SHA512");
            Console.WriteLine("4. MD5");

            var userinput = Convert.ToInt32(Console.ReadLine());

            var hashedText = hMAC.SelectHmacMethod(userinput, bytes, key);

            Console.WriteLine("Hashed text of the choosen hash algoritme");
            Console.WriteLine(Convert.ToBase64String(hashedText));

            DisplayASCII(plainText, hashedText);

            DisplayHex(plainText, hashedText);
        }


        private static void HashAlgoritme(string plainText)
        {

            Hash hash = new Hash();

            var bytes = Encoding.UTF8.GetBytes(plainText);

            Console.WriteLine($"Text that is being hashed {plainText}");
            Console.WriteLine();
            Console.WriteLine("Choose hash algoritme");
            Console.WriteLine("1. SHA1");
            Console.WriteLine("2. SHA256");
            Console.WriteLine("3. SHA512");
            Console.WriteLine("4. MD5");

            var userinput = Convert.ToInt32(Console.ReadLine());

            var hashedText = hash.SelectHashMethod(userinput, bytes);

            Console.WriteLine("Hashed text of the choosen hash algoritme");
            Console.WriteLine(Convert.ToBase64String(hashedText));

            DisplayASCII(plainText, hashedText);

            DisplayHex(plainText, hashedText);

        }

        private static void DisplayASCII(string plainText, byte[] hashedText)
        {
            ASCII aSCII = new ASCII();

            Console.WriteLine();
            Console.WriteLine($"Plain text '{plainText}'converted to ASCII");
            Console.WriteLine(aSCII.EncryptPlainTextToASCII(plainText));

            Console.WriteLine();
            Console.WriteLine($"Hashed '{Convert.ToBase64String(hashedText)}'converted to ASCII");
            Console.WriteLine(aSCII.EncryptHashASCII(hashedText));
        }

        private static void DisplayHex(string plainText, byte[] hashedText)
        {
            Hex hex = new Hex();

            Console.WriteLine();
            Console.WriteLine($"Plain text '{plainText}'converted to HEX");
            Console.WriteLine(hex.EncryptPlainTextToHex(plainText));

            Console.WriteLine();
            Console.WriteLine($"Hashed '{Convert.ToBase64String(hashedText)}'converted to HEX");
            Console.WriteLine(hex.EncryptHashToHex(hashedText));
        }
    }
}