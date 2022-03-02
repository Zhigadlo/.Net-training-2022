using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public interface IMachineForTableTop
    {
        public TableTop GetTableTop(WorkPiece workPiece, double height, double width, double length);
    }
}