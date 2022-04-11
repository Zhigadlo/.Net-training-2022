using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    /// <summary>
    /// Machine class that contains methods for creating round details
    /// </summary>
    public class MachineForRoundDetails : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        public MachineForRoundDetails(MaterialType materialType, double maxHeight, double priceForProcessing)
        {
            MaterialForProcessing = materialType;
            PriceForProcessing = priceForProcessing;
            MaxHeight = maxHeight;
        }

        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius)
        {
            if (height < MaxHeight)
            {
                workPiece.Cut(height, radius * 2, radius * 2);

                RoundTableTop roundTableTop = new RoundTableTop(MaterialForProcessing, radius, height, PriceForProcessing);

                return roundTableTop;
            }
            else
            {
                throw new Exception("This work piece is too large for this machine");
            }
        }

        public override int GetHashCode() => MaterialForProcessing.GetHashCode() + PriceForProcessing.GetHashCode() + MaxHeight.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not MachineForRoundDetails)
                return false;
            else
            {
                MachineForRoundDetails newObj = obj as MachineForRoundDetails;

                return MaterialForProcessing == newObj.MaterialForProcessing &&
                        PriceForProcessing == newObj.PriceForProcessing &&
                        MaxHeight == newObj.MaxHeight;
            }
        }
        public override string ToString()
        {
            return "Machine for round details.";
        }
    }
}
