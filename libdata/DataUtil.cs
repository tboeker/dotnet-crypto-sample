using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace libdata
{
    public static class DataUtil
    {
        public static IEnumerable<DataItem> ReadJson(string file)
        {
            Console.WriteLine($"Reading Items from file: {file}");
            var json = File.ReadAllText(file, Encoding.UTF8);
            var items = JsonSerializer.Deserialize<DataItem[]>(json);
            return items;
        }

        public static void WriteJson(IEnumerable<DataItem> items, string file)
        {
            var json = JsonSerializer.Serialize(items,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(file, json, Encoding.UTF8);
            Console.WriteLine($"Written Items Json to file: {file}");
        }
    }
}