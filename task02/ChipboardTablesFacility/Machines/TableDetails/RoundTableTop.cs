using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class RoundTableTop : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        public double Price { get; }
        public double Radius { get; }

        public RoundTableTop(MaterialType material, double radius, double height, double priceForProcessing)
        {
            Material = material;
            Height = height;
            Radius = radius;
            Square = 2 * Math.PI * Radius;
            Price = Square * height * (int)material + priceForProcessing;
        }
    }
}
