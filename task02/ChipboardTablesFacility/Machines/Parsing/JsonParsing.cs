using System.Text.Json;

namespace Facility.Parsing
{
    /// <summary>
    /// Json parser, can parse some object to json file
    /// </summary>
    /// <typeparam name="T">Type of object for parse</typeparam>
    public class JsonParsing<T>
    {

        /// <summary>
        /// Write object in json file
        /// </summary>
        /// <param name="obj">onject</param>
        /// <param name="path">file path</param>
        public static void WriteObjectInJsonFile(T obj, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize<T>(obj, options);

            StreamWriter writer = new StreamWriter(path);
                
            writer.WriteLine(json);

            writer.Close();
        }

        /// <summary>
        /// Read object from json file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>object</returns>
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
