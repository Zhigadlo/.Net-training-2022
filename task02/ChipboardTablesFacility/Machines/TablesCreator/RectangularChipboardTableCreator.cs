using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
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
    }
}
