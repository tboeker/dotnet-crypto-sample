using System;
using System.Linq;
using System.Text.Json;
using CryptLib;
using EncryptDecryptLib;
using lib;

namespace encrypt_data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string pfxFile = "cert.pfx";
            const string pwdFile = "cert.txt";

            const string rawDataFile = "data-raw.json";

            var rawItems = DataUtil.ReadJson(rawDataFile);

            Console.WriteLine($"Loading Cert from file: {pfxFile} {pwdFile}");
            var cert = CreateRsaCertificates.LoadRsaCertficate(pfxFile, pwdFile);
            Console.WriteLine($"Loaded certificate: {cert.FriendlyName}");

            var asymmetricEncryptDecrypt = new AsymmetricEncryptDecrypt();

            var encryptedItems = rawItems.Select(x =>
            {
                var enc = new DataItemToEncrypt
                {
                    Name1 = x.Name1,
                    Name2 = x.Name2
                };

                var json = JsonSerializer.Serialize(enc);
                //  var encryptedText = asymmetricEncryptDecrypt.Encrypt(text, Utils.CreateRsaPublicKey(cert));

                return x;
            });
        }
    }
}