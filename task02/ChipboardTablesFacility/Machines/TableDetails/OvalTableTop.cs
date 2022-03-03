using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class OvalTableTop : ITableTop
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        public double Price { get; }
        public double _smallRadius { get; }
        public double _largeRadius { get; }

        public OvalTableTop(MaterialType material, double Height, double largeRadius, double smallRadius, double priceForProcessing)
        {
            Material = material;
            this.Height = Height;
            Square = largeRadius * smallRadius * Math.PI;
            _smallRadius = smallRadius;
            _largeRadius = largeRadius;
            Price = Square * Height * (int)material + priceForProcessing;
        }
    }
}
