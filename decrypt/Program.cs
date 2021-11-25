using System.Linq;
using libdata;

namespace decrypt
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string encryptedDataFile = "data-encrypted.json";
            const string decryptedDataFile = "data-decrypted.json";

            var encryptedItems = DataUtil.ReadJson(encryptedDataFile);

            var decryptedItems = encryptedItems.Select(x =>
            {
                if (x.IsEncrypted == 0)
                    return x;

                var encryptedText = x.EncryptedData;
                
                

                return x;
            });

            DataUtil.WriteJson(decryptedItems, decryptedDataFile);
        }
    }
}