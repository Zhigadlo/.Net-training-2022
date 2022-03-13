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
        public double PriceForProcessing { get; }

        public OvalTableTop(MaterialType material, double Height, double largeRadius, double smallRadius, double priceForProcessing)
        {
            Material = material;
            PriceForProcessing = priceForProcessing;
            this.Height = Height;
            Square = largeRadius * smallRadius * Math.PI;
            SmallRadius = smallRadius;
            LargeRadius = largeRadius;
            Price = Square * Height * (int)material + priceForProcessing;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + SmallRadius.GetHashCode() + LargeRadius.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not OvalTableTop)
                return false;
            else
            {
                OvalTableTop newObj = obj as OvalTableTop;

                return Square == newObj.Square && Height == newObj.Height && SmallRadius == newObj.SmallRadius &&
                        Price == newObj.Price && LargeRadius == newObj.LargeRadius && Material == newObj.Material &&
                        PriceForProcessing == newObj.PriceForProcessing;
            }
        }
        public override string ToString()
        {
            return $"Chipboard rectangle leg {SmallRadius}x{LargeRadius}x{Height}";
        }
    }
}
