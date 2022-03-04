using Facility.Materials;
using Facility.TableDetails;
using Facility.Interfaces;

namespace Facility.Machines
{
    public class MachineForRoundedDetails : IMachine, IMachineForOvalDetail, IMachineForRoundDetails
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        public MachineForRoundedDetails(MaterialType materialForProcessing, double priceForProcessing, double maxHeight)
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
    }
}
