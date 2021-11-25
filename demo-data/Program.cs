using System;
using System.Linq;
using lib;

namespace demo_data
{
    static class Program
    {
        static void Main(string[] args)
        {
            const int count = 99;
            const string rawDataFile = "data-raw.json";
            
            string GetType(int i)
            {
                if (i % 2 == 0)
                    return "V";
                return "T";
            }

            int GetResult(int i)
            {
                if (i % 3 == 0)
                    return 1;
                return 0;
            }

            var items = Enumerable.Range(0, count)
                .Select(i =>
                    new DataItem()
                    {
                        Id = i + 1,
                        Type = GetType(i),
                        Result = GetResult(i),
                        Name1 = $"Name 1 Cleartext  {i + 1}",
                        Name2 = $"Name 1 Cleartext  {i + 2}",
                        TimeStampUtc = DateTime.UtcNow.AddSeconds(i)
                    }
                );

            DataUtil.WriteJson(items, rawDataFile);
        }
    }
}