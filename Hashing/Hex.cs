using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class Hex
    {
        public string EncryptPlainTextToHex(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToHexString(bytes);

        }
        public string EncryptHashToHex(byte[] bytes)
        {
            return Convert.ToHexString(bytes);
        }
    }
}
