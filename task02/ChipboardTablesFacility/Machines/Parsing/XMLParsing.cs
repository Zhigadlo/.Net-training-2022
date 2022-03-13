using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Tables;
using System.Xml;

namespace Facility.Parsing
{
    public class XMLParsing
    {
        public static void WriteObject(string path, object obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(path, settings);

            writer.WriteStartDocument();

            WriteItem(obj, writer);

            writer.Close();

        }

        public static void WriteListOfObjects(string path, params object[] objectList)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(path, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Tables");
            foreach (object objItem in objectList)
                WriteItem(objItem, writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Close();
        }

        public void Read()
        {

        }
        private static void WriteItem(object obj, XmlWriter writer)
        {
            writer.WriteStartElement(obj.GetType().Name);
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
                    //writer.WriteStartElement(property.PropertyType.Name);
                    writer.WriteElementString(property.Name, value.ToString());
                    //writer.WriteAttributeString(property.Name, value.ToString());
                    //writer.WriteEndElement();
                }
                
            }
            writer.WriteEndElement();
        }
        private static System.Reflection.PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType()
                .GetProperties()
                .ToArray();
        }

        private static void WriteDictionary(System.Reflection.PropertyInfo property, object obj, XmlWriter writer)
        {
            writer.WriteStartElement(property.Name);
            var dict = (Dictionary<TableAccessoriesType, int>)property.GetValue(obj);
            foreach(var item in dict)
            {
                writer.WriteStartElement(item.Key.ToString());
                writer.WriteAttributeString("count", item.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
