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
        private Dictionary<TableAccessoriesType, int> _tableAccessories;

        public Facility(List<WorkPiece> workPieces, Dictionary<TableAccessoriesType, int> tableAccessories)
        {
            _tables = new List<ITable>();
            _workPieces = new List<WorkPiece>();
            _tableDetails = new List<IDetail>();
            _tableAccessories = tableAccessories;
            _workPieces = workPieces;
        }


        public int GetCountOfTables() => _tables.Count;

    }

}
