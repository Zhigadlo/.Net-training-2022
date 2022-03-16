using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;

namespace Facility.TablesCreator
{
    public class OvalTableWithRectangularChipboardLegsCreator : ITableCreator<OvalTableTop, RectangleChipboardLeg, OvalTableWithRectangularChipboardLegs>
    {
        public OvalTableWithRectangularChipboardLegs CreateTable(string name, OvalTableTop top, int countOfLegs, RectangleChipboardLeg leg)
        {
            return new OvalTableWithRectangularChipboardLegs(name, top, countOfLegs, leg);
        }

        public List<OvalTableWithRectangularChipboardLegs> GetTablesFromXmlFile(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<OvalTableWithRectangularChipboardLegs> tables = new List<OvalTableWithRectangularChipboardLegs>();

            xmlReader.ReadToFollowing("OvalTableWithRectangularChipboardLegs");
            do
            {
                xmlReader.ReadToFollowing("Name");
                string nameOfTable = xmlReader.ReadElementContentAsString();
                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();
                xmlReader.ReadToFollowing("OvalTableTop");
                xmlReader.ReadToFollowing("Height");
                double topHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                Materials.MaterialType material = Materials.Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("SmallRadius");
                double smallRadius = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("LargeRadius");
                double largeRadius = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                double priceForProcessing = xmlReader.ReadElementContentAsDouble();

                OvalTableTop top = new OvalTableTop(material, topHeight, largeRadius, smallRadius, priceForProcessing);

                xmlReader.ReadToFollowing("RectangleChipboardLeg");
                xmlReader.ReadToFollowing("Height");
                double legHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                material = Materials.Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Width");
                double width = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Length");
                double lenght = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                priceForProcessing = xmlReader.ReadElementContentAsDouble();
                RectangleChipboardLeg leg = new RectangleChipboardLeg(material, legHeight, width, lenght, priceForProcessing);
                tables.Add(new OvalTableWithRectangularChipboardLegs(nameOfTable, top, legsCount, leg));

            } while (xmlReader.ReadToFollowing("OvalTableWithRectangularChipboardLegs"));

            return tables;
        }

        public List<OvalTableWithRectangularChipboardLegs> GetTablesFromXmlFileStream(string path)
        {
            List<OvalTableWithRectangularChipboardLegs> tables = new List<OvalTableWithRectangularChipboardLegs>();

            StreamReader reader = new StreamReader(path);

            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundStr = Regex.Matches(str, @"<(OvalTableWithRectangularChipboardLegs)\b[^>]*>\s*([\w\W]*?)\s*</OvalTableWithRectangularChipboardLegs>");
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
                if (i == 16)
                {
                    objValues.Add(arr);
                    arr = new string[17];
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
                int legCount = int.Parse(obj[2]);

                double height = double.Parse(obj[4]);
                Materials.MaterialType material = Materials.Material.Parse(obj[5]);

                double smallRadius = double.Parse(obj[7]);
                double largeRadius = double.Parse(obj[8]);
                double priceForProcessing = double.Parse(obj[9]);

                OvalTableTop top = new OvalTableTop(material, height, largeRadius, smallRadius, priceForProcessing);

                height = double.Parse(obj[11]);
                material = Materials.Material.Parse(obj[13]);

                double width = double.Parse(obj[14]);
                double lenght = double.Parse(obj[15]);
                priceForProcessing = double.Parse(obj[16]);

                RectangleChipboardLeg leg = new RectangleChipboardLeg(material, height, width, lenght, priceForProcessing);

                tables.Add(new OvalTableWithRectangularChipboardLegs(name,top, legCount, leg));
            }

            reader.Close();

            return tables;
        }
    }
}
