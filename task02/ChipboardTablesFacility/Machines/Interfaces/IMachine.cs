using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }
    }
}
