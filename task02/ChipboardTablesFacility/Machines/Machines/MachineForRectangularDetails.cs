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

        public MachineForRectangularDetails(MaterialType materialType, double maxHeight, double priceForProcessing)
        {
            MaterialForProcessing = materialType;
            PriceForProcessing = priceForProcessing;
            MaxHeight = maxHeight;
        }

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

        public override int GetHashCode() => MaterialForProcessing.GetHashCode() + PriceForProcessing.GetHashCode() + MaxHeight.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not MachineForRectangularDetails)
                return false;
            else
            {
                MachineForRectangularDetails newObj = obj as MachineForRectangularDetails;

                return MaterialForProcessing == newObj.MaterialForProcessing &&
                        PriceForProcessing == newObj.PriceForProcessing &&
                        MaxHeight == newObj.MaxHeight;
            }
        }
        public override string ToString()
        {
            return "Machine for rectangular details.";
        }
    }
}
