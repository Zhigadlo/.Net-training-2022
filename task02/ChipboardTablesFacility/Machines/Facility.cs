using Facility.Machines;
using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;
using Facility.Interfaces;

namespace Facility
{
    public class Facility
    {
        private List<ITable> _tables;
        private List<IDetail> _tableDetails;
        private List<WorkPiece> _workPieces;
        private MachineForChipboard _machineForChipboard;
        private MachineForMetal _machineForMetal;
        private Dictionary<TableAccessoriesType, int> _tableAccessories;

        public Facility(List<WorkPiece> workPieces, Dictionary<TableAccessoriesType, int> tableAccessories)
        {
            _tables = new List<ITable>();
            _workPieces = new List<WorkPiece>();
            _tableDetails = new List<IDetail>();
            _machineForChipboard = new MachineForChipboard();
            _machineForMetal = new MachineForMetal();
            _tableAccessories = tableAccessories;
            _workPieces = workPieces;
        }


        public int GetCountOfTables() => _tables.Count;

        private void GetTable(List<ITableLeg> legsForTable, ITableTop topForTable)
        {
            int j = 0;

            for (int i = 0; j < legsForTable.Count; i++)
            {
                if (legsForTable[j].Equals(_tableDetails[i]))
                {
                    j++;
                    i = 0;
                    if (j == legsForTable.Count)
                        break;
                }
            }

            if (j < legsForTable.Count - 1)
                throw new Exception("There is no required table legs");


            _tables.Add(new OrdinaryTable(legsForTable, topForTable));
        }
        private void GetTable(List<ITableLeg> legsForTable, ITableTop topForTable, Dictionary<TableAccessoriesType, int> accessories)
        {
            _tables.Add(new TableWithAccessories(legsForTable, topForTable, accessories));
        }
        private void GetTable(double height, double width, double lenght)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(Materials.MaterialType.Chipboard, height, width, lenght);

            _tableDetails.Add(_machineForChipboard.GetTableTop(workPiece, height, width, lenght));
        }
        private void GetTableLeg(Materials.MaterialType material, double height, double width, double length)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(material, height, width, length);

            switch (material)
            {
                case Materials.MaterialType.Chipboard:
                    _tableDetails.Add(_machineForChipboard.GetTableLeg(workPiece, height, width, length));
                    break;
                case Materials.MaterialType.Metal:
                    _tableDetails.Add(_machineForMetal.GetTableLeg(workPiece, height, width, length));
                    break;
                default:
                    throw new Exception("Facility can't made this detail");
            }
        }
        private void GetTableLeg(Materials.MaterialType material, double height, double radius)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(material, height, radius);

            switch (material)
            {
                case Materials.MaterialType.Metal:
                    _tableDetails.Add(_machineForMetal.GetTableLeg(workPiece, height, radius));
                    break;
                default:
                    throw new Exception("Facility can't made this detail");
            }
        }
        private WorkPiece GetRequiredWorkPiece(Materials.MaterialType material, double height, double width, double length)
        {
            if (_workPieces.Count == 0)
                throw new Exception("There is no work pieces in the facility");

            foreach (var workPiece in _workPieces)
            {
                if (workPiece.Height >= height && workPiece.Width >= width && workPiece.Length >= length && workPiece.Material == material)
                {
                    return workPiece;
                }
            }

            throw new Exception("There is not suitable work pieces");
        }
        private WorkPiece GetRequiredWorkPiece(Materials.MaterialType material, double height, double radius)
        {
            if (_workPieces.Count == 0)
                throw new Exception("There is no work pieces in the facility");

            foreach (var workPiece in _workPieces)
            {
                if (workPiece.Height >= height && workPiece.Width >= 2 * radius && workPiece.Length >= 2 * radius && workPiece.Material == material)
                {
                    return workPiece;
                }
            }

            throw new Exception("There is not suitable work pieces");
        }
    }

}
