using Facility.Materials;


namespace Facility.Interfaces
{
    public interface ITableTop : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        public double Price { get; }
    }
}
