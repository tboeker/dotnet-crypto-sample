using System;
using System.Linq;
using System.Text.Json;
using libcrypt;
using libdata;

namespace encrypt
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string pfxFile = "cert.pfx";
            const string pwdFile = "cert.txt";

            const string rawDataFile = "data-raw.json";
            const string encryptedDataFile = "data-encrypted.json";

            var rawItems = DataUtil.ReadJson(rawDataFile);

            Console.WriteLine($"Loading Cert from file: {pfxFile} {pwdFile}");
            var cert = CreateRsaCertificates.LoadRsaCertficate(pfxFile, pwdFile);
            Console.WriteLine($"Loaded certificate: {cert.FriendlyName}");

            var asymmetricEncryptDecrypt = new AsymmetricEncryptDecrypt();

            var encryptedItems = rawItems.Select(x =>
            {
                if (x.IsEncrypted == 1)
                    return x;

                var enc = x.GetDataToEncrypt();
                var json = JsonSerializer.Serialize(enc);

                // TODO
                var encryptedText = asymmetricEncryptDecrypt.Encrypt(json, Utils.CreateRsaPublicKey(cert));
                x.SetEncryptedData(encryptedText);

                return x;
            });

            DataUtil.WriteJson(encryptedItems, encryptedDataFile);
        }
    }
}