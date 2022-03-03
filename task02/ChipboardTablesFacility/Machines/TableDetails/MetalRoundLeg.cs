using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class MetalRoundLeg : ITableLeg
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material { get; }
        public double Radius { get; }

        public MetalRoundLeg(double height, double radius, double price)
        {
            Square = radius * radius * Math.PI;
            Height = height;
            Material = MaterialType.Metal;
            Radius = radius;
            Price = price;
        }
    }
}
