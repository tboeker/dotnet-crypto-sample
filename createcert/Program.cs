using System;
using System.IO;
using CertificateManager;
using libcrypt;
using Microsoft.Extensions.DependencyInjection;

namespace createcert
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string name = "SigningCertificateTest";
            const string friendlyName = "tb demo certificate";
            const string password = "1234";
            const string pfxFile = "cert.pfx";
            const string pemFile = "pem.pfx";
            const string pwdFile = "cert.txt";

            // see https://github.com/damienbod/SendingEncryptedData/blob/main/ConsoleAsymmetricEncryption/Program.cs

            var serviceProvider = new ServiceCollection()
                .AddCertificateManager()
                .BuildServiceProvider();

            var cc = serviceProvider.GetRequiredService<CreateCertificates>();

            var cert = CreateRsaCertificates.CreateRsaCertificate(cc, 3072, name);
            cert.FriendlyName = friendlyName;

            Console.WriteLine($"Created certificate: {cert.FriendlyName}");

            var iec = serviceProvider.GetRequiredService<ImportExportCertificate>();

            var certInPfxBtyes = iec.ExportSelfSignedCertificatePfx(password, cert);

            File.WriteAllBytes(pfxFile, certInPfxBtyes);
            Console.WriteLine($"Pfx file: {pfxFile}");

            var certInPemBytes = iec.PemExportPfxFullCertificate(cert);
            File.WriteAllText(pemFile, certInPemBytes);
            Console.WriteLine($"Pem file: {pemFile}");

            File.WriteAllText(pwdFile, password);
            Console.WriteLine($"Password file: {pwdFile}");
        }
    }
}