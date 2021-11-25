using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace libcrypt
{
    public static class Utils
    {
        public static RSA CreateRsaPrivateKey(X509Certificate2 certificate)
        {
            var privateKeyProvider = certificate.GetRSAPrivateKey();
            return privateKeyProvider;
        }

        public static RSA CreateRsaPublicKey(X509Certificate2 certificate)
        {
            var publicKeyProvider = certificate.GetRSAPublicKey();
            return publicKeyProvider;
        }
    }
}