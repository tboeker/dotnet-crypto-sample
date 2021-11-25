using CertificateManager;
using CertificateManager.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using EncryptDecryptLib;

namespace CreateCert
{
    class Program
    {
        static void Main(string[] args)
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

            var cc = serviceProvider.GetService<CreateCertificates>();
            
            var cert = CreateRsaCertificates.CreateRsaCertificate(cc, 3072, name);
            cert.FriendlyName = friendlyName;

            Console.WriteLine($"Created certificate: {cert.FriendlyName}");

            var iec = serviceProvider.GetService<ImportExportCertificate>();

            var certInPfxBtyes = iec.ExportSelfSignedCertificatePfx(password, cert);
            
            File.WriteAllBytes(pfxFile, certInPfxBtyes);
            Console.WriteLine($"Pfx file: {pfxFile}");

            var certInPEMBtyes = iec.PemExportPfxFullCertificate(cert);
            File.WriteAllText(pemFile, certInPEMBtyes);
            Console.WriteLine($"Pem file: {pemFile}");            

            File.WriteAllText(pwdFile, password);
            Console.WriteLine($"Password file: {pwdFile}");       
        }


       
    }
}