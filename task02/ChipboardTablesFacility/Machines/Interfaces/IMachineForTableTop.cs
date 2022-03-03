using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IMachineForTableRoundDetails
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }

        public ITableTop GetTableTop(WorkPiece workPiece, double height, double width, double length);
    }
}