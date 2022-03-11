using Facility.Parsing;
using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Materials;
using Facility.Tables;
using Facility.Machines;
//using System.Reflection;

//XMLParsing.WriteClass();

ChipboardRectangleLeg leg = new ChipboardRectangleLeg(MaterialType.ConstructionChipboard, 10, 1, 1, 5);
OvalTableTop top = new OvalTableTop(MaterialType.GeneralPurposeChipboard, 0.05, 2, 1, 50);
OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", top, 5, leg);

MachineForOvalDetails machine = new MachineForOvalDetails(MaterialType.SpecialChipboard, 3, 45);

string path = @"D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";

XMLParsing.WriteClass(machine, path);
foreach(var item in table.GetType().GetProperties().ToArray())
{
    Console.Write(item.PropertyType);
    if (item.PropertyType.IsValueType || item.PropertyType == typeof(System.String))
        Console.Write(" - not class\n");
    else
        Console.Write(" - class\n");
}