using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;

namespace Facility
{
    public class ChipboardFacility
    {
        private List<ITable<IDetail, IDetail>> _tables;
        private List<IDetail> _tableDetails;
        private List<WorkPiece> _workPieces;
        private List<IMachine> _machines;
        private Dictionary<TableAccessoriesType, int> _tableAccessories;

        public ChipboardFacility(List<WorkPiece> workPieces, Dictionary<TableAccessoriesType, int> tableAccessories)
        {
            _tables = new List<ITable<IDetail, IDetail>>();
            _workPieces = new List<WorkPiece>();
            _tableDetails = new List<IDetail>();
            _tableAccessories = tableAccessories;
            _workPieces = workPieces;
            _machines = new List<IMachine>();
        }

        public int GetCountOfTables() => _tables.Count;
        public List<ITable<IDetail, IDetail>> GetTables() => _tables;
        public List<IDetail> GetTableDetails() => _tableDetails;
        public List<ITable<IDetail, IDetail>> SortTablesByName()
        {
            return _tables.OrderBy(t => t.Name).ToList();
        }
        public List<ITable<IDetail, IDetail>> SortTablesByPrice()
        {
            return _tables.OrderBy(p => p.Price).ToList();
        }

        public OvalTableWithMetalRectangularLegs MakeOvalTableWithMetalRectangularLegs(string name, OvalTableTop top, int countOflegs, MetalRectangleLeg leg)
        {
            return new OvalTableWithMetalRectangularLegs(name, top, countOflegs, leg);
        }

        public OvalTableWithMetalRectangularLegs MakeRectangularChipboardTable(string name, OvalTableTop top, int countOflegs, MetalRectangleLeg leg)
        {
            return new OvalTableWithMetalRectangularLegs(name, top, countOflegs, leg);
        }

        public void AddMachine(IMachine machine) => _machines.Add(machine);
        public void AddWorkPiece(WorkPiece workpiece) => _workPieces.Add(workpiece);
        public void RemoveMachine(IMachine machine) => _machines.Remove(machine);
        public void AddAccessories(TableAccessoriesType accessoryType, int count) => _tableAccessories.Add(accessoryType, count);
        public WorkPiece FindWorkPieceWithMinLossOfMaterial(IDetail detail)
        {
            WorkPiece requiredWorkPiece = _workPieces[0];

            double heightLoss = detail.Height - _workPieces[0].Height;
            double squareLoss = detail.Square - _workPieces[0].Square;

            foreach (WorkPiece workPiece in _workPieces)
            {
                if (detail.Height - workPiece.Height <= heightLoss && detail.Square - workPiece.Length * workPiece.Width <= squareLoss)
                {
                    heightLoss = detail.Height - workPiece.Height;
                    squareLoss = detail.Square - workPiece.Width * workPiece.Length;
                    requiredWorkPiece = workPiece;
                }
            }
            _workPieces.Remove(requiredWorkPiece);
            return requiredWorkPiece;
        }
        public ITable<IDetail, IDetail> FindTableByChipboardComsuption(double chipboardComsuption)
        {
            foreach (var table in _tables)
            {
                if (chipboardComsuption == table.GetChipboardConsumption())
                {
                    return table;
                }
            }

            throw new Exception("There is no table with this consuption of chipboard");
        }

    }

}
