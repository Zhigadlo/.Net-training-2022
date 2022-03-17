using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;

namespace Facility.TablesCreator
{
    public class OvalTableWithMetalRectangularLegsCreator : ITableCreator<OvalTableTop, MetalRectangleLeg, OvalTableWithMetalRectangularLegs>
    {
        public OvalTableWithMetalRectangularLegs CreateTable(string name, OvalTableTop top, int countOfLegs, MetalRectangleLeg leg)
        {
            return new OvalTableWithMetalRectangularLegs(name, top, countOfLegs, leg);
        }
        
        public List<OvalTableWithMetalRectangularLegs> GetTablesFromXmlFile(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<OvalTableWithMetalRectangularLegs> tables = new List<OvalTableWithMetalRectangularLegs>();

            xmlReader.ReadToFollowing("OvalTableWithMetalRectangularLegs");
            do
            {
                xmlReader.ReadToFollowing("Name");
                string nameOfTable = xmlReader.ReadElementContentAsString();

                xmlReader.ReadToFollowing("MetalRectangleLeg");
                xmlReader.ReadToFollowing("Height");
                double legHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Price");
                double price = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Width");
                double width = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Length");
                double lenght = xmlReader.ReadElementContentAsDouble();

                MetalRectangleLeg leg = new MetalRectangleLeg(legHeight, width, lenght, price);

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

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new OvalTableWithMetalRectangularLegs(nameOfTable, top, legsCount, leg));

            } while (xmlReader.ReadToFollowing("OvalTableWithMetalRectangularLegs"));

            return tables;
        }

        public List<OvalTableWithMetalRectangularLegs> GetTablesFromXmlFileStream(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<OvalTableWithMetalRectangularLegs> tables = new List<OvalTableWithMetalRectangularLegs>();

            StreamReader reader = new StreamReader(path);

            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundStr = Regex.Matches(str, @"<(OvalTableWithMetalRectangularLegs)\b[^>]*>\s*([\w\W]*?)\s*</OvalTableWithMetalRectangularLegs>");
            var s = string.Join("\n", foundStr.Cast<Match>().Select(x => x.Value).ToArray());
            var foundValues = Regex.Matches(s, @"(?<=>)(\w+?)(\.[0-9]+)?(?=<)");
            var values = string.Join("\n", foundValues.Cast<Match>().Select(x => x.Value).ToArray());

            var strValues = values.Split('\n').ToList();

            List<string[]> objValues = new List<string[]>();
            int i = 0;
            string[] arr = new string[16];
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
                double legPrice = double.Parse(obj[3]);

                double width = double.Parse(obj[5]);
                double lenght = double.Parse(obj[6]);

                MetalRectangleLeg leg = new MetalRectangleLeg(height, width, lenght, legPrice);

                height = double.Parse(obj[8]);
                Materials.MaterialType material = Materials.Material.Parse(obj[9]);

                double smallRadius = double.Parse(obj[11]);
                double largeRadius = double.Parse(obj[12]);
                double priceForProcessing = double.Parse(obj[13]);

                OvalTableTop top = new OvalTableTop(material, height, largeRadius, smallRadius, priceForProcessing);

                int legCount = int.Parse(obj[15]);
                
                tables.Add(new OvalTableWithMetalRectangularLegs(name, top, legCount, leg));
            }

            return tables;
        }

        /*public List<OvalTableWithMetalRectangularLegs> GetTablesFromJsonFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string json = reader.ReadToEnd();

            List<OvalTableWithMetalRectangularLegs> tables = JsonConvert.DeserializeObject<List<OvalTableWithMetalRectangularLegs>>(json);
            
            reader.Close();

            return tables;
        }*/
    }
}
