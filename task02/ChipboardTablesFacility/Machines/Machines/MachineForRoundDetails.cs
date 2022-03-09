using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public class MachineForRoundDetails : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

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
