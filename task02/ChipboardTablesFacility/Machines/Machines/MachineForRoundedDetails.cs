using Facility.Materials;
using Facility.TableDetails;
using Facility.Interfaces;

namespace Facility.Machines
{
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
            _machineForOvalDetails = new MachineForOvalDetails();
            _machineForRoundDetails = new MachineForRoundDetails();
        }
        
        public OvalTableTop GetOvalTableTop(WorkPiece workPiece, double height, double smallRadius, double largeRadius)
        {
            return _machineForOvalDetails.GetOvalTableTop(workPiece, height, smallRadius, largeRadius);
        }

        public RoundTableTop GetRoundTableTop(WorkPiece workPiece, double height, double radius)
        {
            return _machineForRoundDetails.GetRoundTableTop(workPiece, height, radius);
        }
    }
}
