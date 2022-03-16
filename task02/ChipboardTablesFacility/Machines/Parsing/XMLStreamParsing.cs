using Facility.TableDetails;
using System.Text;

namespace Facility.Parsing
{
    public class XMLStreamParsing : IParsing
    {
        public void WriteListOfObjects(string path, params object[] objectList)
        {
            StreamWriter writer = new StreamWriter(path, false);

            WriteStartDocument(writer);
            WriteStartElement("Tables", writer);
            foreach (object objItem in objectList)
                WriteItem(objItem, writer);

            WriteEndElement("Tables", writer);

            writer.Close(); new NotImplementedException();
        }
        public void WriteObject(string path, object obj)
        {
            StreamWriter writer = new StreamWriter(path, false);

            WriteStartDocument(writer);

            WriteItem(obj, writer);

            writer.Close();
        }

        private void WriteItem(object obj, StreamWriter writer)
        {
            WriteStartElement(obj.GetType().Name, writer);
            var properties = GetProperties(obj);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (property.PropertyType == typeof(Dictionary<TableAccessoriesType, int>))
                {
                    WriteDictionary(property, obj, writer);
                }
                else if (!property.PropertyType.IsValueType && property.PropertyType != typeof(string))
                {
                    WriteItem(value, writer);
                }
                else
                {
                    WriteStringElement(property.Name, value.ToString(),writer);
                }

            }
            WriteEndElement(obj.GetType().Name, writer);
        }
        private System.Reflection.PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType()
                .GetProperties()
                .ToArray();
        }
        private void WriteDictionary(System.Reflection.PropertyInfo property, object obj, StreamWriter writer)
        {
            WriteStartElement(property.Name, writer);
            var dict = (Dictionary<TableAccessoriesType, int>)property.GetValue(obj);
            foreach (var item in dict)
            {
                WriteKeyValuePair(item.Key.ToString(), item.Value.ToString(), writer);
            }
            WriteEndElement(property.Name, writer);
        }
        private void WriteStartDocument(StreamWriter writer)
        {
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        }
        private void WriteStartElement(string str, StreamWriter writer)
        {
            writer.WriteLine($"<{str}>");
        }
        private void WriteEndElement(string str, StreamWriter writer)
        {
            writer.WriteLine($"</{str}>");
        }
        private void WriteKeyValuePair(string key, string value, StreamWriter writer)
        {
            writer.WriteLine($"\t<KeyValuePair key=\"{key}\" value=\"{value}\" />");
        }
        private void WriteStringElement(string name, string value, StreamWriter writer)
        {
            writer.WriteLine($"<{name}>{value}</{name}>");
        }
    }
}
