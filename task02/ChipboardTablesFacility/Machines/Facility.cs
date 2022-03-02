using Facility.Tables;
using Facility.TableDetails;
using Facility.Materials;
using Facility.Machines;

namespace Facility
{
    public class Facility
    {
        private List<Table> _tables;
        private List<IDetail> _tableDetails;
        private List<WorkPiece> _workPieces;
        private MachineForChipboard _machineForChipboard;
        private MachineForMetal _machineForMetal;
        private List<TableAccessories> _tableAccessories;

        public Facility(List<WorkPiece> workPieces, List<TableAccessories> tableAccessories)
        {
            _tables = new List<Table>();
            _workPieces = new List<WorkPiece>();
            _tableDetails = new List<IDetail>();
            _machineForChipboard = new MachineForChipboard();
            _machineForMetal = new MachineForMetal();
            _tableAccessories = tableAccessories;
            _workPieces = workPieces;
        }


        private void GetTable()
        {

        }
        public int GetCountOfTables() => _tables.Count;
        private void GetTable(double height, double width, double lenght)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(Material.Chipboard, height, width, lenght);

            _tableDetails.Add(_machineForChipboard.GetTableTop(workPiece, height, width, lenght));
        }
        private void GetTableLeg(Material material, double height, double width, double length)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(material, height, width, length);

            switch(material)
            {
                case Material.Chipboard:
                    _tableDetails.Add(_machineForChipboard.GetTableLeg(workPiece, height, width, length));
                    break;
                case Material.Metal:
                    _tableDetails.Add(_machineForMetal.GetTableLeg(workPiece, height, width, length));
                    break;
                default:
                    throw new Exception("Facility can't made this detail");
            }
        }
        private void GetTableLeg(Material material, double height, double radius)
        {
            WorkPiece workPiece = GetRequiredWorkPiece(material, height, radius);

            switch (material)
            {
                case Material.Metal:
                    _tableDetails.Add(_machineForMetal.GetTableLeg(workPiece, height, radius));
                    break;
                default:
                    throw new Exception("Facility can't made this detail");
            }
        }
        private WorkPiece GetRequiredWorkPiece(Material material, double height, double width, double length)
        {
            if (_workPieces.Count == 0)
                throw new Exception("There is no work pieces in the facility");

            foreach (var workPiece in _workPieces)
            {
                if(workPiece.Height >= height && workPiece.Width >= width && workPiece.Length >= length && workPiece.Material == material)
                {
                    return workPiece;
                }
            }

            throw new Exception("There is not suitable work pieces");
        }
        private WorkPiece GetRequiredWorkPiece(Material material, double height, double radius)
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
