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

        public MetalRoundLeg(MaterialType material, double height, double radius, double priceForProcessing)
        {
            Square = radius * radius * Math.PI;
            Height = height;
            Material = material;
            Radius = radius;
            Price = Square * height * (int)material + priceForProcessing;
        }
    }
}
