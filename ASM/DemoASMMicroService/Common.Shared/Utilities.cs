using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Micro1.Common.Shared
{
    public class Utilities
    {
        private static string loggerFilePath = Directory.GetCurrentDirectory() + @"DataLog.txt";

        public static string ConvertObjectToJSONString<T>(T entity)
        {
            string jsonString = JsonSerializer.Serialize(entity, new JsonSerializerOptions
            {
                WriteIndented = false
            });
            return jsonString;

        }
        public static void WriteLoggerFile(string content)
        {
            try
            {
                var path = Directory.GetCurrentDirectory();

                using (var file = File.Open(loggerFilePath, FileMode.Append, FileAccess.Write))
                using (var writer = new StreamWriter(file))
                {
                    writer.WriteLineAsync(content);
                    writer.Flush();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
