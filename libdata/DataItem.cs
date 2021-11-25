using System;

namespace libdata
{
    public class DataItem
    {
        public string EncryptedData { get; set; }
        public int Id { get; set; }

        public int IsEncrypted { get; set; }

        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public int Result { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public string Type { get; set; }


        public DataItemEncryptPart GetDataToEncrypt() => new DataItemEncryptPart
        {
            Name1 = Name1,
            Name2 = Name2
        };

        public void SetEncryptedData(string encryptedData)
        {
            EncryptedData = encryptedData;
            Name1 = null;
            Name2 = null;
            IsEncrypted = 1;
        }
    }

    public class DataItemEncryptPart
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}