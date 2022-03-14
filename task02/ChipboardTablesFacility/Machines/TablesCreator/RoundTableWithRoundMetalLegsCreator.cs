using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator.Interfaces;
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

                RoundTableTop top = new RoundTableTop(material, topHeight, radius, priceForProcessing);

                xmlReader.ReadToFollowing("LegsCount");
                int legsCount = xmlReader.ReadElementContentAsInt();

                tables.Add(new RoundTableWithRoundMetalLegs(nameOfTable, top, legsCount, leg));

            } while (xmlReader.ReadToFollowing("RoundTableWithRoundMetalLegs"));

            return tables;
        }
    }
}
