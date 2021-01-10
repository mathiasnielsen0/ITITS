using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HashLibrary
{
    public class Hasher
    {
        private readonly SHA256 _sha;
        
        public Hasher()
        {
            _sha = SHA256.Create();
        }

        public byte[] HashPassword(string password)
        {
            byte[] result = _sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return result;
        }

        public bool IsPasswordCorrect(byte[] hash, string password)
        {
            byte[] result = _sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (hash.Length == result.Length)
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != result[i])
                        return false;
                }
            }
            else
                return false;

            return true;
        }
        public bool IsPasswordWithSaltCorrect(byte[] hash, byte[] salt, string password)
        {
            var result = _sha.ComputeHash((salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray()));

            if (hash.Length == result.Length)
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != result[i])
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        public void HashPasswordWithSalt(string password, string name, out byte[] hash, out byte[] salt)
        {
            salt = _sha.ComputeHash(Encoding.UTF8.GetBytes(name));
            hash = _sha.ComputeHash((salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray()));
        }
    }
}