using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IMachineForTableTop
    {
        public ITableTop GetTableTop(WorkPiece workPiece, double height, double width, double length);
    }
}