using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Interfaces
{
    public interface IMachineForRoundDetails
    {
        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius);
    }
}
