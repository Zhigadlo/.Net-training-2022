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
            XmlDocument document = new XmlDocument();
            document.Load(path);
            
            XmlElement? root = document.DocumentElement;

            var names = GetNames(obj);

            XmlElement item = document.CreateElement(obj.GetType().ToString());

            foreach (var name in names)
            {
                XmlElement xmlItem = document.CreateElement(name);
                var value = obj.GetType().GetProperty(name)?.GetValue(obj);

                XmlText text = document.CreateTextNode(value?.ToString());

                xmlItem.AppendChild(text);
                //Console.WriteLine($"{item} - {value}");
                /*if (value?.GetType() == typeof(OvalTableTop))
                {
                    Console.WriteLine(true);
                }*/

                item.AppendChild(xmlItem);

                
            }

            root?.AppendChild(item);
            
            document.Save(path);

        }

        public static void Write()
        {
            string path = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";

            XmlDocument document = new XmlDocument();
            document.Load(path);

            XmlElement? root = document.DocumentElement;

            XmlElement table = document.CreateElement("RectangularChipboardTable");

            XmlAttribute nameAttr = document.CreateAttribute("name");

            XmlElement tableTop =  document.CreateElement("RectanglularTableTop");
            XmlElement tableLeg = document.CreateElement("RectangleTableLeg");
            XmlElement countOfLegs = document.CreateElement("CountOfLegs");

            XmlText nameText = document.CreateTextNode("Mark");
            XmlText tableTopText = document.CreateTextNode("Top");
            XmlText tableLegText = document.CreateTextNode("Leg");
            XmlText countOfLegsText = document.CreateTextNode("5");

            nameAttr.AppendChild(nameText);
            tableTop.AppendChild(tableTopText);
            tableLeg.AppendChild(tableLegText);
            countOfLegs.AppendChild(countOfLegsText);

            table.Attributes.Append(nameAttr);
            table.AppendChild(tableTop);
            table.AppendChild(countOfLegs);
            table.AppendChild(tableLeg);

            root?.AppendChild(table);

            document.Save(path);
        }

        public void Read()
        {

        }

        private static IEnumerable<string> GetNames(object obj)
        {
                return obj.GetType()
                    .GetProperties()
                    .Select(x => x.Name)
                    .ToArray();
        }

    }
}
