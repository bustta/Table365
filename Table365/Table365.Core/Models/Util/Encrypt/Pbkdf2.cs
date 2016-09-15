using System;
using System.Security.Cryptography;
using System.Text;

namespace Table365.Core.Models.Util.Encrypt
{
    public class Pbkdf2 : IEncrypt
    {
        //hash:salt
        private const int Roundnumber = 50000;
        private const int HashByteSize = 32;
        private const int SaltByteSize = 32;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 0;

        public string GetEncryptPassword(string pw)
        {
            var salt = GenerateSalt();
            return Convert.ToBase64String(GetPbkdf2Password(pw, salt)) + ":" +
                    Convert.ToBase64String(salt);
        }

        public bool IsCorrectedPassword(string plainPw, string encryptPw)
        {
            char[] delimiter = { ':' };
            var split = encryptPw.Split(delimiter);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Password(plainPw, salt);
            return SlowEquals(hash, testHash);
        }
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        private static byte[] GetPbkdf2Password(string passwordToHash, byte[] salt)
        {
            var pwToHash = Encoding.UTF8.GetBytes(passwordToHash);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(pwToHash, salt, Roundnumber))
            {
                return rfc2898DeriveBytes.GetBytes(HashByteSize);
            }
        }

        private static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltByteSize];
                randomNumberGenerator.GetBytes(salt);
                return salt;
            }
        }
    }
}