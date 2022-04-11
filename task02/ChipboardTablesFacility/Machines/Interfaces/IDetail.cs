using Facility.Materials;

namespace Facility.Interfaces
{
    /// <summary>
    /// Some detail interface including Square, Height, Price and Material fields 
    /// </summary>
    public interface IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material { get; }
    }
}