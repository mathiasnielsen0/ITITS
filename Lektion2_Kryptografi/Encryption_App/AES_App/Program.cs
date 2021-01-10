using System;
using System.Security.Cryptography;
using System.Text;

namespace AES_Library
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                Console.WriteLine("Generated Key is: " + Encoding.UTF8.GetString(myAes.Key));
                Console.WriteLine("Generated Key is: " + Encoding.UTF8.GetString(myAes.IV));

                Console.WriteLine("");
                Console.WriteLine("*************************");
                Console.WriteLine("");
                Console.WriteLine("Enter plaintext to be encoded: ");
                var plaintext = Console.ReadLine();
                // Encrypt the string to an array of bytes.
                byte[] encrypted = AesEncrypter.EncryptStringToBytes_Aes(plaintext, myAes.Key, myAes.IV);

                Console.WriteLine("Encrypted message: " + Encoding.UTF8.GetString(encrypted));
                
                // Decrypt the bytes to a string.
                string roundtrip = AesEncrypter.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", plaintext);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }
    }
}