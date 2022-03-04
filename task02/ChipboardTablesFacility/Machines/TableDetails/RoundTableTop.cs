using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class RoundTableTop : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public Materials.MaterialType Material { get; }
        public double Price { get; }

        private double _radius;

        public RoundTableTop(MaterialType material, double radius, double height, double priceForProcessing)
        {
            Material = material;
            Height = height;
            _radius = radius;
            Square = 2 * Math.PI * _radius;
            Price = Square * height * (int)material + priceForProcessing;
        }
    }
}
