using Facility.Materials;

namespace Facility.Interfaces
{
    /// <summary>
    /// Machine interface including next fields: material for processing,price for processing 
    /// and max height of work piece for processing 
    /// </summary>
    public interface IMachine
    {
        public MaterialType MaterialForProcessing { get; }
        public double PriceForProcessing { get; }
        public double MaxHeight { get; }
    }
}
