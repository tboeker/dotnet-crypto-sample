using System;
using System.Security.Cryptography;
using System.Text;

namespace libcrypt
{
    public class AsymmetricEncryptDecrypt
    {
        // Decrypt with RSA using private key
        public string Decrypt(string text, RSA rsa)
        {
            var data = Convert.FromBase64String(text);
            var cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(cipherText);
        }

        // Encrypt with RSA using public key
        public string Encrypt(string text, RSA rsa)
        {
            var data = Encoding.UTF8.GetBytes(text);
            var cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(cipherText);
        }
    }
}