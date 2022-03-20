using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    /// <summary>
    /// Machine class that contains methods for creating round and oval details
    /// </summary>
    public class MachineForRoundedDetails : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        private MachineForRoundDetails _machineForRoundDetails;
        private MachineForOvalDetails _machineForOvalDetails;

        public MachineForRoundedDetails(MaterialType materialForProcessing, double priceForProcessing, double maxHeight)
        {
            MaterialForProcessing = materialForProcessing;
            PriceForProcessing = priceForProcessing;
            MaxHeight = maxHeight;
            _machineForOvalDetails = new MachineForOvalDetails(materialForProcessing, maxHeight, priceForProcessing);
            _machineForRoundDetails = new MachineForRoundDetails(materialForProcessing, maxHeight, priceForProcessing);
        }
        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius)
        {
            return _machineForOvalDetails.GetOvalTableTop(workPiece, height, smallRadius, largeRadius);
        }
        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius)
        {
            return _machineForRoundDetails.GetRoundTableTop(workPiece, height, radius);
        }

        public override int GetHashCode() => MaterialForProcessing.GetHashCode() + PriceForProcessing.GetHashCode() + MaxHeight.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not MachineForRoundedDetails)
                return false;
            else
            {
                MachineForRoundedDetails newObj = obj as MachineForRoundedDetails;

                return MaterialForProcessing == newObj.MaterialForProcessing &&
                        PriceForProcessing == newObj.PriceForProcessing &&
                        MaxHeight == newObj.MaxHeight;
            }
        }
        public override string ToString()
        {
            return "Machine for rounded details.";
        }


    }
}
