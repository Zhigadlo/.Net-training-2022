using Newtonsoft.Json;

namespace Facility.Parsing
{
    public class JsonParsing
    {
        public static void WriteJsonFile(object obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);
            
            StreamWriter writer = new StreamWriter(path);
                
            writer.WriteLine(json);

            writer.Close();
        }

    }
}
