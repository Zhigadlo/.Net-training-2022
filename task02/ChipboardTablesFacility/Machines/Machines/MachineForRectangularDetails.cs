using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public class MachineForRectangularDetails : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        public ChipboardRectangleLeg GetRectangleLeg(WorkPiece workPiece, double height, double width, double length)
        {
            if (height < MaxHeight)
            {
                workPiece.Cut(height, width, length);

                ChipboardRectangleLeg rectangleLeg = new ChipboardRectangleLeg(MaterialForProcessing, height, width, length, PriceForProcessing);

                return rectangleLeg;
            }
            else
            {
                throw new Exception("This work piece is too large for this machine");
            }
        }

        public RectangularTableTop GetRectangularTableTop(WorkPiece workPiece, double height, double width, double length)
        {
            if (height < MaxHeight)
            {
                workPiece.Cut(height, width, length);

                RectangularTableTop rectangleTableTop = new RectangularTableTop(MaterialForProcessing, height, width, length, PriceForProcessing);

                return rectangleTableTop;
            }
            else
            {
                throw new Exception("This work piece is too large for this machine");
            }
        }
    }
}
