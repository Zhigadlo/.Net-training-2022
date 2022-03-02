using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public interface IMachineForTableLeg
    {
        public TableLeg GetTableLeg(WorkPiece workPiece, double height, double width, double length);
    }
}
