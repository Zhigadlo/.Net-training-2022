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
        public List<ITable> GetTables() => _tables;
        public List<IDetail> GetTableDetails() => _tableDetails;
        
        public List<ITable> SortTablesByName()
        {
            return _tables.OrderBy(t => t.Name).ToList();
        }

        public List<ITable> SortTablesByPrice()
        {
            return _tables.OrderBy(p => p.Price).ToList();
        }

        public List<WorkPiece> FindRequiredWorkPiecesForTable(List<IDetail> details)
        {
            List<WorkPiece> requiredWorkPieces = new List<WorkPiece>();

            int j = 0;

            for(int i = 0; i < _workPieces.Count; i++)
            {
                if(_workPieces[i].Height <=)
                {

                }
            }

            return requiredWorkPieces;
        }

        public WorkPiece GetWorkPieceWithMinLossOfMaterial(IDetail detail)
        {
            WorkPiece requiredWorkPiece;

            double heightLoss = detail.Height - _workPieces[0].Height;
            double squareLoss = detail.Square - _workPieces[0].Width * _workPieces[0].Length;

            foreach (WorkPiece workPiece in _workPieces)
            {
                if (detail.Height - workPiece.Height <= heightLoss && detail.Square - workPiece.Length * workPiece.Width <= squareLoss)
                {
                    heightLoss = detail.Height - workPiece.Height;
                    squareLoss = detail.Square - workPiece.Width * workPiece.Length;
                    requiredWorkPiece = workPiece;
                }
            }

            return requiredWorkPiece;
        }
    }

}
