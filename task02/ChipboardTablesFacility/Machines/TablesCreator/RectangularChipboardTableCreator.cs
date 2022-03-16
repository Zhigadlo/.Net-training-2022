using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;

namespace Facility.TablesCreator
{
    public class RectangularChipboardTableCreator : ITableCreator<RectangularTableTop, RectangleChipboardLeg, RectangularChipboardTable>
    {
        public RectangularChipboardTable CreateTable(string name, RectangularTableTop top, int countOfLegs, RectangleChipboardLeg leg)
        {
            return new RectangularChipboardTable(name, top, countOfLegs, leg);
        }

        public List<RectangularChipboardTable> GetTablesFromXmlFile(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<RectangularChipboardTable> tables = new List<RectangularChipboardTable>();

            xmlReader.ReadToFollowing("RectangularChipboardTable");
            do
            {
                xmlReader.ReadToFollowing("Name");
                string nameOfTable = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("RectangleChipboardLeg");
                xmlReader.ReadToFollowing("Height");
                double legHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                Materials.MaterialType material = Materials.Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Width");
                double width = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Length");
                double lenght = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                double priceForProcessing = xmlReader.ReadElementContentAsDouble();

                RectangleChipboardLeg leg = new RectangleChipboardLeg(material, legHeight, width, lenght, priceForProcessing);

                xmlReader.ReadToFollowing("RectangularTableTop");
                xmlReader.ReadToFollowing("Height");
                double topHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                material = Materials.Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Width");
                width = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Length");
                lenght = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                priceForProcessing = xmlReader.ReadElementContentAsDouble();

                RectangularTableTop top = new RectangularTableTop(material, topHeight, lenght, width, priceForProcessing);

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new RectangularChipboardTable(nameOfTable, top, legsCount, leg));

            } while (xmlReader.ReadToFollowing("RectangularChipboardTable"));

            return tables;
        }

        public List<RectangularChipboardTable> GetTablesFromXmlFileStream(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<RectangularChipboardTable> tables = new List<RectangularChipboardTable>();

            StreamReader reader = new StreamReader(path);

            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundStr = Regex.Matches(str, @"<(RectangularChipboardTable)\b[^>]*>\s*([\w\W]*?)\s*</RectangularChipboardTable>");
            var s = string.Join("\n", foundStr.Cast<Match>().Select(x => x.Value).ToArray());
            var foundValues = Regex.Matches(s, @"(?<=>)(\w+?)(\.[0-9]+)?(?=<)");
            var values = string.Join("\n", foundValues.Cast<Match>().Select(x => x.Value).ToArray());

            var strValues = values.Split('\n').ToList();

            List<string[]> objValues = new List<string[]>();
            int i = 0;
            string[] arr = new string[17];
            foreach (string value in strValues)
            {
                arr[i] = value;
                if (i == arr.Length - 1)
                {
                    objValues.Add(arr);
                    arr = new string[arr.Length];
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            foreach (string[] obj in objValues)
            {
                string name = obj[0];

                double height = double.Parse(obj[2]);
                Materials.MaterialType material = Materials.Material.Parse(obj[4]);
                double width = double.Parse(obj[5]);
                double lenght = double.Parse(obj[6]);
                double priceForProcessing = double.Parse(obj[7]);

                RectangleChipboardLeg leg = new RectangleChipboardLeg(material, height, width, lenght, priceForProcessing);

                height = double.Parse(obj[9]);
                material = Materials.Material.Parse(obj[10]);

                double smallRadius = double.Parse(obj[12]);
                double largeRadius = double.Parse(obj[13]);
                priceForProcessing = double.Parse(obj[14]);

                RectangularTableTop top = new RectangularTableTop(material, height, largeRadius, smallRadius, priceForProcessing);

                int legCount = int.Parse(obj[16]);

                tables.Add(new RectangularChipboardTable(name, top, legCount, leg));
            }

            reader.Close();

            return tables;
        }
    }
}
