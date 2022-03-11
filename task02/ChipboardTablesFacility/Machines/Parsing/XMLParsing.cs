using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Tables;
using System.Xml;

namespace Facility.Parsing
{
    public class XMLParsing
    {
        public static void WriteClass(object obj, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(path, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement(obj.GetType().Name);

            Write(obj, writer);

            writer.WriteEndElement();
            writer.Close();

        }

        private static void Write(object obj, XmlWriter writer)
        {
            var properties = GetProperties(obj);

            foreach (var property in properties)
            {
                writer.WriteStartElement(property.Name);
                var value = property.GetValue(obj);
                if (!property.PropertyType.IsValueType && property.PropertyType != typeof(string))
                {
                    Write(value, writer);
                }
                else
                {
                    writer.WriteString(value.ToString());
                }
                writer.WriteEndElement();
            }
        }

        public void Read()
        {

        }

        private static System.Reflection.PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType()
                .GetProperties()
                .ToArray();
        }

    }
}
