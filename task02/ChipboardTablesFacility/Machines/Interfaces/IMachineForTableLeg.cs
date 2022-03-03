using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IMachineForTableLeg
    {
        public ITableLeg GetTableLeg(WorkPiece workPiece, double height, double width, double length);
    }
}
