using Facility.Materials;

namespace Facility.Interfaces
{
    public interface IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
    }
}