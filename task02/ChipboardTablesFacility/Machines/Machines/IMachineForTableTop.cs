using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public interface IMachineForTableTop
    {
        public TableTop GetTableTop(WorkPiece workPiece, int height, int width, int length);
    }
}