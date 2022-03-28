using Newtonsoft.Json;

namespace Eatery
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
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

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

            T obj = JsonConvert.DeserializeObject<T>(json);

            reader.Dispose();

            return obj;
        }
    }
}