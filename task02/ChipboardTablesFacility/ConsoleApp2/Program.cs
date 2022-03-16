using Facility.Machines;
using Facility.Materials;
using Facility.Parsing;
using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator;
using System.Text.RegularExpressions;

RectangleChipboardLeg leg = new RectangleChipboardLeg(MaterialType.ConstructionChipboard, 10, 1, 1, 5);
OvalTableTop top = new OvalTableTop(MaterialType.GeneralPurposeChipboard, 0.05, 2, 1, 50);
RectangularTableTop rectangularTableTop = new RectangularTableTop(MaterialType.SpecialChipboard, 0.07, 2, 3, 100);
MachineForOvalDetails machine = new MachineForOvalDetails(MaterialType.SpecialChipboard, 3, 45);
MetalRectangleLeg metalRectangleLeg = new MetalRectangleLeg(5, 0.03, 0.04, 20);
MetalRoundLeg metalRoundLeg = new MetalRoundLeg(0.8, 0.3, 23);
RoundTableTop roundTop = new RoundTableTop(MaterialType.GeneralPurposeChipboard, 3, 0.8, 15);
Dictionary<TableAccessoriesType, int> accessories = new Dictionary<TableAccessoriesType, int>
{
    { TableAccessoriesType.Shkants, 5 },
    { TableAccessoriesType.Corners, 3 },
    { TableAccessoriesType.BoltNut, 10 }
};
OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", top, 5, leg);
OvalTableWithRectangularChipboardLegs table1 = new OvalTableWithRectangularChipboardLegs("OvalTable2", top, 5, leg);
RectangularChipboardTableWithAccessories table2 = new RectangularChipboardTableWithAccessories("Eban", rectangularTableTop, 3, leg, accessories);
OvalTableWithMetalRectangularLegs table3 = new OvalTableWithMetalRectangularLegs("OvalTable3", top, 3, metalRectangleLeg);
RectangularChipboardTable table4 = new RectangularChipboardTable("RectangularTable4", rectangularTableTop, 6, leg);
RoundTableWithRoundMetalLegs table5 = new RoundTableWithRoundMetalLegs("OvalTable5", roundTop, 5, metalRoundLeg);
string path1 = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";
string path2 = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile2.xml";
string newpath = @"C:/Users/Lenovo/Desktop/xmlfile.xml";
XMLStreamParsing xmlParser = new XMLStreamParsing();
//XMLParsing parser = new XMLParsing();
//parser.WriteListOfObjects(path1, table, table1, table2, table3, table4, table5);
xmlParser.WriteListOfObjects(path2, table, table1, table2, table3, table4, table5);

//xmlParser.WriteListOfObjects(path, table2, table, table1, table3, table4, table5);

RectangularChipboardTableWithAccessoriesCreator creator = new RectangularChipboardTableWithAccessoriesCreator();

var tables = creator.GetTablesFromXmlFileStream(path2);

foreach (var tabl in tables)
{
    Console.WriteLine("Name: " + tabl.Name);
    Console.WriteLine("TablePrice: " + tabl.Price);
    Console.WriteLine("TableTopPrice: " + tabl.TableTop.Price);
    Console.WriteLine("TableLegPrice: " + tabl.TableLeg.Price);
    Console.WriteLine("LegMaterial: " + tabl.TableLeg.Material);
    Console.WriteLine("TopMaterial: " + tabl.TableTop.Material);
    Console.WriteLine("LegsCount: " + tabl.LegsCount + "\n");
    foreach (KeyValuePair<TableAccessoriesType, int> kvp in tabl.TableAccessories)
        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
    Console.WriteLine("=========");

}

/*StreamReader reader = new StreamReader(newpath);

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
foreach (var dict in listOfDict)
{
    foreach (KeyValuePair<TableAccessoriesType, int> kvp in dict)
        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
    Console.WriteLine("=========");
}
reader.Close();*/