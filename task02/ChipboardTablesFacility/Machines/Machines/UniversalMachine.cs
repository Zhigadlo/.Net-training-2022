using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
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
            _machineForOvalDetails = new MachineForOvalDetails();
            _machineForRectangularDetails = new MachineForRectangularDetails();
            _machineForRoundDetails = new MachineForRoundDetails();
        }

        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius)
        {
            return _machineForOvalDetails.GetOvalTableTop(workPiece, height, smallRadius, largeRadius);
        }
        public ChipboardRectangleLeg GetRectangleLeg(WorkPiece workPiece, double height, double width, double length)
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
    }
}
