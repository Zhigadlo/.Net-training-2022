using System.Text.Json;

namespace Facility.Parsing
{
    public class JsonParsing<T>
    {
        public static void WriteObjectInJsonFile(T obj, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize<T>(obj, options);

            StreamWriter writer = new StreamWriter(path);
                
            writer.WriteLine(json);

            writer.Close();
        }

        public static T ReadObjectFromJsonFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string json = reader.ReadToEnd();

            var options = new JsonSerializerOptions { WriteIndented = true };
            var obj = JsonSerializer.Deserialize<T>(json, options);

            reader.Dispose();

            return obj;
        }

    }
}
