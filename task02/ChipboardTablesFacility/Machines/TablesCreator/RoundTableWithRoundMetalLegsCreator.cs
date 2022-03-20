using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;

namespace Facility.TablesCreator
{
    public class RoundTableWithRoundMetalLegsCreator : ITableCreator<RoundTableTop, MetalRoundLeg, RoundTableWithRoundMetalLegs>
    {
        public RoundTableWithRoundMetalLegs CreateTable(string name, RoundTableTop top, int countOfLegs, MetalRoundLeg leg)
        {
            return new RoundTableWithRoundMetalLegs(name, top, countOfLegs, leg);
        }

        public List<RoundTableWithRoundMetalLegs> GetTablesFromXmlFile(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<RoundTableWithRoundMetalLegs> tables = new List<RoundTableWithRoundMetalLegs>();

            xmlReader.ReadToFollowing("RoundTableWithRoundMetalLegs");
            do
            {
                xmlReader.ReadToFollowing("Name");
                string nameOfTable = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("MetalRoundLeg");
                xmlReader.ReadToFollowing("Height");
                double legHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Price");
                double price = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Radius");
                double radius = xmlReader.ReadElementContentAsDouble();

                MetalRoundLeg leg = new MetalRoundLeg(legHeight, radius, price);

                xmlReader.ReadToFollowing("RoundTableTop");
                xmlReader.ReadToFollowing("Height");
                double topHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                Materials.MaterialType material = Materials.Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Radius");
                radius = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                double priceForProcessing = xmlReader.ReadElementContentAsDouble();

                RoundTableTop top = new RoundTableTop(material, radius, topHeight, priceForProcessing);

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new RoundTableWithRoundMetalLegs(nameOfTable, top, legsCount, leg));

            } while (xmlReader.ReadToFollowing("RoundTableWithRoundMetalLegs"));

            return tables;
        }

        public List<RoundTableWithRoundMetalLegs> GetTablesFromXmlFileStream(string path)
        {
            List<RoundTableWithRoundMetalLegs> tables = new List<RoundTableWithRoundMetalLegs>();

            StreamReader reader = new StreamReader(path);

            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundStr = Regex.Matches(str, @"<(RoundTableWithRoundMetalLegs)\b[^>]*>\s*([\w\W]*?)\s*</RoundTableWithRoundMetalLegs>");
            var s = string.Join("\n", foundStr.Cast<Match>().Select(x => x.Value).ToArray());
            var foundValues = Regex.Matches(s, @"(?<=>)(\w+?)(\.[0-9]+)?(?=<)");
            var values = string.Join("\n", foundValues.Cast<Match>().Select(x => x.Value).ToArray());

            var strValues = values.Split('\n').ToList();

            List<string[]> objValues = new List<string[]>();
            int i = 0;
            string[] arr = new string[14];
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

                double height = double.Parse(obj[3]);
                double legPrice = double.Parse(obj[4]);
                double radius = double.Parse(obj[6]);

                MetalRoundLeg leg = new MetalRoundLeg(height, radius, legPrice);

                height = double.Parse(obj[8]);
                Materials.MaterialType material = Materials.Material.Parse(obj[9]);

                radius = double.Parse(obj[11]);
                double priceForProcessing = double.Parse(obj[12]);

                RoundTableTop top = new RoundTableTop(material, height, radius, priceForProcessing);

                int legCount = int.Parse(obj[13]);

                tables.Add(new RoundTableWithRoundMetalLegs(name, top, legCount, leg));
            }

            reader.Close();

            return tables;
        }
    }
}
