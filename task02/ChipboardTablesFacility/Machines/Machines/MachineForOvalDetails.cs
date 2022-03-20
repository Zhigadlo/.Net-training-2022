using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    /// <summary>
    /// Machine class that contains methods for creating oval details
    /// </summary>
    public class MachineForOvalDetails : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        public MachineForOvalDetails(MaterialType materialType, double maxHeight, double priceForProcessing)
        {
            MaterialForProcessing = materialType;
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

        public override int GetHashCode() => MaterialForProcessing.GetHashCode() + PriceForProcessing.GetHashCode() + MaxHeight.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not MachineForOvalDetails)
                return false;
            else
            {
                MachineForOvalDetails newObj = obj as MachineForOvalDetails;

                return MaterialForProcessing == newObj.MaterialForProcessing &&
                        PriceForProcessing == newObj.PriceForProcessing &&
                        MaxHeight == newObj.MaxHeight;
            }
        }
        public override string ToString()
        {
            return "Machine for oval details.";
        }

    }
}
