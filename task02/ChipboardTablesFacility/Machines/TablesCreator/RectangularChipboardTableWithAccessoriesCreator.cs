using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
using System.Text.RegularExpressions;
using System.Xml;

namespace Facility.TablesCreator
{
    public class RectangularChipboardTableWithAccessoriesCreator : ITableWIthAccessoriesCreator<RectangularTableTop, RectangleChipboardLeg, RectangularChipboardTableWithAccessories>
    {
        public RectangularChipboardTableWithAccessories CreateTable(string name, RectangularTableTop top, int countOfLegs, RectangleChipboardLeg leg, Dictionary<TableAccessoriesType, int> tableAccessories)
        {
            return new RectangularChipboardTableWithAccessories(name, top, countOfLegs, leg, tableAccessories);
        }

        public List<RectangularChipboardTableWithAccessories> GetTablesFromXmlFile(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            List<RectangularChipboardTableWithAccessories> tables = new List<RectangularChipboardTableWithAccessories>();

            xmlReader.ReadToFollowing("RectangularChipboardTableWithAccessories");
            do
            {
                Dictionary<TableAccessoriesType, int> tableAccessories = new Dictionary<TableAccessoriesType, int>();
                xmlReader.ReadToFollowing("TableAccessories");
                var dictReader = xmlReader.ReadSubtree();
                while (dictReader.ReadToFollowing("KeyValuePair"))
                {
                    string key = dictReader.GetAttribute("key");
                    int value = int.Parse(dictReader.GetAttribute("value"));
                    tableAccessories.Add(TableAccessory.Parse(key), value);

                }

                xmlReader.ReadToFollowing("Name");
                string nameOfTable = xmlReader.ReadElementContentAsString();
                xmlReader.ReadToFollowing("Square");
                xmlReader.ReadToFollowing("Height");
                double legHeight = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Material");
                MaterialType material = Material.Parse(xmlReader.ReadElementContentAsString());
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
                material = Material.Parse(xmlReader.ReadElementContentAsString());
                xmlReader.ReadToFollowing("Width");
                width = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("Length");
                lenght = xmlReader.ReadElementContentAsDouble();
                xmlReader.ReadToFollowing("PriceForProcessing");
                priceForProcessing = xmlReader.ReadElementContentAsDouble();

                RectangularTableTop top = new RectangularTableTop(material, topHeight, width, lenght, priceForProcessing);

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new RectangularChipboardTableWithAccessories(nameOfTable, top, legsCount, leg, tableAccessories));

            } while (xmlReader.ReadToFollowing("RectangularChipboardTableWithAccessories"));

            return tables;
        }

        public List<RectangularChipboardTableWithAccessories> GetTablesFromXmlFileStream(string path)
        {
            List<RectangularChipboardTableWithAccessories> tables = new List<RectangularChipboardTableWithAccessories>();

            StreamReader reader = new StreamReader(path);

            

            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundStr = Regex.Matches(str, @"<(RectangularChipboardTableWithAccessories)\b[^>]*>\s*([\w\W]*?)\s*</RectangularChipboardTableWithAccessories>");
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
            reader.Close();

            List<Dictionary<TableAccessoriesType, int>> accessoryList = GetTableAccessories(path);

            for (i = 0; i < accessoryList.Count; i++)
            {
                string name = objValues[i][0];
                double height = double.Parse(objValues[i][2]);
                MaterialType material = Material.Parse(objValues[i][4]);

                double width = double.Parse(objValues[i][5]);
                double lenght = double.Parse(objValues[i][6]);
                double priceForProcessing = double.Parse(objValues[i][7]);

                RectangleChipboardLeg leg = new RectangleChipboardLeg(material, height, lenght, width, priceForProcessing);

                height = double.Parse(objValues[i][9]);
                material = Material.Parse(objValues[i][10]);

                width = double.Parse(objValues[i][12]);
                lenght = double.Parse(objValues[i][13]);
                priceForProcessing = double.Parse(objValues[i][14]);

                RectangularTableTop top = new RectangularTableTop(material, height, width, lenght, priceForProcessing);

                int legCount = int.Parse(objValues[i][16]);

                tables.Add(new RectangularChipboardTableWithAccessories(name, top, legCount, leg, accessoryList[i]));
            }

            return tables;
        }

        private List<Dictionary<TableAccessoriesType, int>> GetTableAccessories(string path)
        {
            StreamReader reader = new StreamReader(path);  
            string textFromXml = reader.ReadToEnd();
            var str = string.Concat(textFromXml.Split('\t'));

            var foundTables = Regex.Matches(str, @"<(RectangularChipboardTableWithAccessories)\b[^>]*>\s*([\w\W]*?)\s*</RectangularChipboardTableWithAccessories>");

            string[] xmltables = foundTables.Cast<Match>().Select(x => x.Value).ToArray();

            List<Dictionary<TableAccessoriesType, int>> listOfDict = new List<Dictionary<TableAccessoriesType, int>>();

            foreach (var xmltable in xmltables)
            {
                var foundDict = Regex.Matches(xmltable, @"<(TableAccessories)\b[^>]*>\s*([\w\W]*?)\s*</TableAccessories>");
                var dict = string.Join("\n", foundDict.Cast<Match>().Select(x => x.Value).ToArray());

                var foundKeys = Regex.Matches(dict, "\"(\\w+)\"");
                string[] keyvalue = foundKeys.Cast<Match>().Select(x => x.Value).ToArray();

                var KeyValuePairs = string.Join("\n", foundKeys.Cast<Match>().Select(x => x.Value).ToArray());
                KeyValuePairs = KeyValuePairs.Replace("\"", "");

                List<int> values = new List<int>();
                List<TableAccessoriesType> keys = new List<TableAccessoriesType>();

                for (int i = 0; i < keyvalue.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        keys.Add(TableAccessory.Parse(keyvalue[i].Replace("\"", "")));
                    }
                    else
                    {
                        values.Add(int.Parse(keyvalue[i].Replace("\"", "")));
                    }
                }
                Dictionary<TableAccessoriesType, int> mydict = new Dictionary<TableAccessoriesType, int>();

                for (int i = 0; i < keys.Count; i++)
                {
                    mydict.Add(keys[i], values[i]);
                }


                listOfDict.Add(mydict);

            }
            
            reader.Close();

            return listOfDict;
        }

    }
}
