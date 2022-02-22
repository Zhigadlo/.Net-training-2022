using TableDetails;
using Materials;

namespace Machines
{
    public interface IMachineForTableTop
    {
        public TableTop GetTableTop(WorkPiece workPiece, int height, int width, int length);
    }
}