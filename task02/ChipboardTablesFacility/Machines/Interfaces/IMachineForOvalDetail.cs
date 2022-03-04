using Facility.TableDetails;
using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IMachineForOvalDetail
    {
        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius);
    }
}
