using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Interfaces
{
    public interface IMachineForTableRectangleDetails
    {
        public RectangularTableTop GetRectangularTableTop(WorkPiece workPiece, double height, double width, double length);
        public ChipboardRectangleLeg GetRectangleLeg(WorkPiece workPiece, double height, double width, double length);
    }
}