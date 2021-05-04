using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RedArbor.Employee.Utilities
{
    public class Encryptor
    {
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;

        /// <summary>
        /// Encripta un texto a SHA1
        /// </summary>
        /// <param name="prmText">Texto</param>
        /// <returns>Texto encriptado</returns>
        public static string EncryptSHA1Managed(string prmText)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(prmText));


            return String.Concat(hash.Select(x => x.ToString("x2")));
        }
    }
}
