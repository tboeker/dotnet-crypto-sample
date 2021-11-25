using CertificateManager;
using CertificateManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EncryptDecryptLib
{
    public static class CreateRsaCertificates
    {
        public static X509Certificate2 LoadRsaCertficate(string pfxFile, string pwdFile)
        {
            var pwd = File.ReadAllText(pwdFile);
            var bytes = File.ReadAllBytes(pfxFile);
            
            var col = new X509Certificate2Collection();
            col.Import(bytes, pwd);
            return col[0];
        }
        
        
        public static X509Certificate2 CreateRsaCertificate(CreateCertificates createCertificates, int keySize,
            string name)
        {
            var basicConstraints = new BasicConstraints
            {
                CertificateAuthority = true,
                HasPathLengthConstraint = true,
                PathLengthConstraint = 2,
                Critical = false
            };
            var subjectAlternativeName = new SubjectAlternativeName
            {
                DnsName = new List<string>
                {
                    name,
                }
            };

            var x509KeyUsageFlags = X509KeyUsageFlags.KeyCertSign |
                                    X509KeyUsageFlags.DigitalSignature |
                                    X509KeyUsageFlags.KeyEncipherment |
                                    X509KeyUsageFlags.CrlSign |
                                    X509KeyUsageFlags.DataEncipherment |
                                    X509KeyUsageFlags.NonRepudiation |
                                    X509KeyUsageFlags.KeyAgreement;

            // only if mtls is used
            var enhancedKeyUsages = new OidCollection
            {
                //OidLookup.ClientAuthentication,
                //OidLookup.ServerAuthentication,
                OidLookup.CodeSigning,
                OidLookup.SecureEmail,
                OidLookup.TimeStamping
            };

            var certificate = createCertificates.NewRsaSelfSignedCertificate(
                new DistinguishedName { CommonName = name },
                basicConstraints,
                new ValidityPeriod
                {
                    ValidFrom = DateTimeOffset.UtcNow,
                    ValidTo = DateTimeOffset.UtcNow.AddYears(99)
                },
                subjectAlternativeName,
                enhancedKeyUsages,
                x509KeyUsageFlags,
                new RsaConfiguration
                {
                    KeySize = keySize,
                    RSASignaturePadding = RSASignaturePadding.Pkcs1,
                    HashAlgorithmName = HashAlgorithmName.SHA256
                });

            return certificate;
        }
    }
}