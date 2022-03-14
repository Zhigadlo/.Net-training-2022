using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
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
    }
}
