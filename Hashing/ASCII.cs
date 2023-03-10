using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class ASCII
    {
        public string EncryptPlainTextToASCII(string input)
        {
            string encryptedText = "";
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(input);
            foreach (byte b in ASCIIValues)
            {
                encryptedText += (int)b;
            }

            return encryptedText;
        }
        public string EncryptHashASCII(byte[] bytes)
        {
            string encryptedText = "";
            foreach (byte b in bytes)
            {
                encryptedText += (int)b;
            }
            return encryptedText;
        }
    }
}
