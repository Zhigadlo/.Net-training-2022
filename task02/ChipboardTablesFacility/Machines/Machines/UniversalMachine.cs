using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    /// <summary>
    /// Universal machine class that contains methods for creating all details 
    /// </summary>
    public class UniversalMachine : IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }

        private MachineForRoundDetails _machineForRoundDetails;
        private MachineForRectangularDetails _machineForRectangularDetails;
        private MachineForOvalDetails _machineForOvalDetails;

        public UniversalMachine(MaterialType materialForProcessing, double priceForProcessing, double maxHeight)
        {
            MaterialForProcessing = materialForProcessing;
            PriceForProcessing = priceForProcessing;
            MaxHeight = maxHeight;
            _machineForOvalDetails = new MachineForOvalDetails(materialForProcessing, maxHeight, priceForProcessing);
            _machineForRectangularDetails = new MachineForRectangularDetails(materialForProcessing, maxHeight, priceForProcessing);
            _machineForRoundDetails = new MachineForRoundDetails(materialForProcessing, maxHeight, priceForProcessing);
        }

        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius)
        {
            return _machineForOvalDetails.GetOvalTableTop(workPiece, height, smallRadius, largeRadius);
        }
        public RectangleChipboardLeg GetRectangleLeg(WorkPiece workPiece, double height, double width, double length)
        {
            return _machineForRectangularDetails.GetRectangleLeg(workPiece, height, width, length);
        }
        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius)
        {
            return _machineForRoundDetails.GetRoundTableTop(workPiece, height, radius);
        }
        public RectangularTableTop GetRectangularTableTop(WorkPiece workPiece, double height, double width, double length)
        {
            return _machineForRectangularDetails.GetRectangularTableTop(workPiece, height, width, length);
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
            return "Machine for all types of details.";
        }
    }
}
