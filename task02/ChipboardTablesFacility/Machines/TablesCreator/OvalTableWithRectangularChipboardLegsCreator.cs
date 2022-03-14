using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
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
    }
}
