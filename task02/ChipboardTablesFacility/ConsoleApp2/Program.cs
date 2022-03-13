using Facility.Parsing;
using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Materials;
using Facility.Tables;
using Facility.Machines;
using System.Xml;

//XMLParsing.WriteClass();

RectangleChipboardLeg leg = new RectangleChipboardLeg(MaterialType.ConstructionChipboard, 10, 1, 1, 5);
OvalTableTop top = new OvalTableTop(MaterialType.GeneralPurposeChipboard, 0.05, 2, 1, 50);
OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", top, 5, leg);
RectangularTableTop rectangularTableTop = new RectangularTableTop(MaterialType.SpecialChipboard, 0.07, 2, 3, 100);
MachineForOvalDetails machine = new MachineForOvalDetails(MaterialType.SpecialChipboard, 3, 45);
Dictionary<TableAccessoriesType, int> accessories = new Dictionary<TableAccessoriesType, int>
{
    { TableAccessoriesType.Shkants, 5 },
    { TableAccessoriesType.Corners, 3 },
    { TableAccessoriesType.BoltNut, 10 }
};

RectangularChipboardTableWithAccessories table2 = new RectangularChipboardTableWithAccessories("Eban", rectangularTableTop, 3, leg, accessories);

string path = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";

//XMLParsing.WriteListOfObjects(path, table2, table);

XmlReader xmlReader = XmlReader.Create(path);
XmlDocument document = new XmlDocument();

document.Load(xmlReader);

XmlNodeList nodeList = document.DocumentElement.SelectNodes("/OvalTableWithRectangularChipboardLegs");

Console.WriteLine(document.DocumentElement.ChildNodes.Count);

var NodeStr = "";



/*foreach (XmlNode node in nodeList)
{
    var tableNode = node;
    NodeStr += tableNode.Name;
    NodeStr += node.ChildNodes.Count;
    NodeStr += "\n\tName " + node;
    NodeStr += "\n\tPrice " + node.Attributes["Price"].Value.ToString();
    NodeStr += "\n\tLegsCount " + node.Attributes["LegsCount"].Value.ToString();
    var topNode = node.ChildNodes[0];
    var legNode = node.ChildNodes[1];
    NodeStr += "\n" + topNode.Name;
    NodeStr += "\n\tSquare " + topNode.Attributes["Square"].Value.ToString();
    NodeStr += "\n\tHeight " + topNode.Attributes["Height"].Value.ToString();
    NodeStr += "\n\tMaterial " + topNode.Attributes["Material"].Value.ToString();
    NodeStr += "\n\tPrice " + topNode.Attributes["Price"].Value.ToString();
    NodeStr += "\n" + legNode.Name;
    NodeStr += "\n\tSquare " + legNode.Attributes["Square"].Value.ToString();
    NodeStr += "\n\tHeight " + legNode.Attributes["Height"].Value.ToString();
    NodeStr += "\n\tMaterial " + legNode.Attributes["Material"].Value.ToString();
    NodeStr += "\n\tPrice " + legNode.Attributes["Price"].Value.ToString();
}*/

Console.WriteLine(NodeStr);
/*string className = "";




while(xmlReader.Read())
{
    if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "OvalTableWithRectangularChipboardLegs")
    {
        Console.WriteLine(xmlReader.Name);
        
        if(xmlReader.HasAttributes)
            Console.WriteLine("Name: " + xmlReader.GetAttribute("Name") + "\nPrice: " + xmlReader.GetAttribute("Price") +
                "\nLegsCount: " + xmlReader.GetAttribute("LegsCount"));
    }

    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "OvalTableTop")
    {
        Console.WriteLine(xmlReader.Name);
        if (xmlReader.HasAttributes)
            Console.WriteLine("Square: " + xmlReader.GetAttribute("Square") + "\nHeight: " + xmlReader.GetAttribute("Height")
                + "\nMaterial: " + xmlReader.GetAttribute("Material") +
                "\nPrice: " + xmlReader.GetAttribute("Price"));
    }

}    */
