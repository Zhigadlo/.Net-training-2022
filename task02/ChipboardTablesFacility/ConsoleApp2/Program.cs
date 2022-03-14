using Facility.Machines;
using Facility.Materials;
using Facility.Parsing;
using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator;

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
string path = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile2.xml";

XMLStreamParsing xmlParser = new XMLStreamParsing();
xmlParser.WriteObject(path, table2);
//xmlParser.WriteListOfObjects(path, table2, table, table1, table3, table4, table5);

/*RectangularChipboardTableWithAccessoriesCreator creator = new RectangularChipboardTableWithAccessoriesCreator();

var tables = creator.GetTablesFromXmlFile(path);

foreach (var tabl in tables)
{
    Console.WriteLine("Name: " + tabl.Name);
    Console.WriteLine("TablePrice: " + tabl.Price);
    Console.WriteLine("TableTopPrice: " + tabl.TableTop.Price);
    Console.WriteLine("TableLegPrice: " + tabl.TableLeg.Price);
    Console.WriteLine("LegMaterial: " + tabl.TableLeg.Material);
    Console.WriteLine("TopMaterial: " + tabl.TableTop.Material);
    Console.WriteLine("LegsCount: " + tabl.LegsCount);
}*/