using Materials;
using TableDetails;

namespace Machines
{
    public interface IMachineForTableLeg
    {
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int width, int length);
    }
}
