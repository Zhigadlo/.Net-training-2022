using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
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

                RectangularTableTop top = new RectangularTableTop(material, topHeight, lenght, width, priceForProcessing);

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new RectangularChipboardTableWithAccessories(nameOfTable, top, legsCount, leg, tableAccessories));

            } while (xmlReader.ReadToFollowing("RectangularChipboardTableWithAccessories"));

            return tables;
        }
    }
}
