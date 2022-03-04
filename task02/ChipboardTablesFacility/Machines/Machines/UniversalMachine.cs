using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public class UniversalMachine : IMachine, IMachineForOvalDetail, IMachineForRoundDetails, IMachineForTableRectangleDetails
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        public UniversalMachine(MaterialType materialForProcessing, double priceForProcessing, double maxHeight)
        {
            MaterialForProcessing = materialForProcessing;
            PriceForProcessing = priceForProcessing;
            MaxHeight = maxHeight;
        }

        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius)
        {
            if (height < MaxHeight)
            {
                workPiece.Cut(height, smallRadius * 2, largeRadius * 2);

                OvalTableTop ovalTableTop = new OvalTableTop(MaterialForProcessing, height, largeRadius, smallRadius, PriceForProcessing);

                return ovalTableTop;
            }
            else
            {
                throw new Exception("This work piece is too large for this machine");
            }    
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
        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius)
        {
            if (height < MaxHeight)
            {
                workPiece.Cut(height, radius * 2, radius * 2);

                RoundTableTop roundTableTop = new RoundTableTop(MaterialForProcessing, height, radius, PriceForProcessing);

                return roundTableTop;
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
