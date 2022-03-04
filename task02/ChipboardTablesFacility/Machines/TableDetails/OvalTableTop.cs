using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class OvalTableTop : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        public double Price { get; }
        public double SmallRadius { get; }
        public double LargeRadius { get; }

        public OvalTableTop(MaterialType material, double Height, double largeRadius, double smallRadius, double priceForProcessing)
        {
            Material = material;
            this.Height = Height;
            Square = largeRadius * smallRadius * Math.PI;
            SmallRadius = smallRadius;
            LargeRadius = largeRadius;
            Price = Square * Height * (int)material + priceForProcessing;
        }
    }
}
