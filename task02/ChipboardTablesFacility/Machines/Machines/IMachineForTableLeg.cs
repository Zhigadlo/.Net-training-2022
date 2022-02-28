using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public interface IMachineForTableLeg
    {
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int width, int length);
    }
}
