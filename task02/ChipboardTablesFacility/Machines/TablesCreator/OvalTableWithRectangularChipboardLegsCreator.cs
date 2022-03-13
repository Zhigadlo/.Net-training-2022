using Facility.TablesCreator.Interfaces;
using Facility.TableDetails;
using Facility.Tables;
using System.Xml;

namespace Facility.TablesCreator 
{
    public class OvalTableWithRectangularChipboardLegsCreator : ITableCreator<OvalTableTop, RectangleChipboardLeg, OvalTableWithRectangularChipboardLegs>
    {
        public OvalTableWithRectangularChipboardLegs CreateTable(string name, OvalTableTop top, int countOfLegs, RectangleChipboardLeg leg)
        {
            return new OvalTableWithRectangularChipboardLegs(name, top, countOfLegs, leg);
        }
    
        /*public OvalTableWithRectangularChipboardLegs GetTableFromXml(string path)
        {
            XmlReader xmlReader = XmlReader.Create(path);

            XmlDocument document = new XmlDocument();

            document.Load(xmlReader);

            XmlNodeList nodeList = document.GetElementsByTagName("OvalTableWithRectangularChipboardLegs");
            string name;
            int legCount;
            foreach (XmlNode node in nodeList)
            {
                name = node.SelectSingleNode("Name").InnerText;
                legCount = int.Parse(node.SelectSingleNode("LegsCount").Value);
            }

            return new OvalTableWithRectangularChipboardLegs(name, legCount);
        }*/
    }
}
