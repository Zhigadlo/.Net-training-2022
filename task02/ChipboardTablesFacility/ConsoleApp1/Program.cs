using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Materials;
using Facility.Machines;
using Facility;

List<IDetail> list = new List<IDetail>
{
    new ChipboardRectangleLeg(MaterialType.SpecialChipboard, 1, 0.04, 0.03, 20),
    new MetalRoundLeg(0.9, 0.05, 100)
};


foreach (IDetail detail in list)
    Console.WriteLine(detail.GetType());

Factory facility = new Factory(new List<WorkPiece>(), new Dictionary<TableAccessoriesType, int>());

