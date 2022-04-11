using Facility.Interfaces;
using Facility.Materials;
using System.Text.Json.Serialization;

namespace Facility.TableDetails
{
    public class RoundTableTop : IDetail
    {
        [JsonIgnore]
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        [JsonIgnore]
        public double Price { get; }
        public double Radius { get; }
        public double PriceForProcessing { get; }

        public RoundTableTop(MaterialType material, double radius, double height, double priceForProcessing)
        {
            Material = material;
            PriceForProcessing = priceForProcessing;
            Height = height;
            Radius = radius;
            Square = 2 * Math.PI * Radius;
            Price = Square * height * (int)material + priceForProcessing;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + Radius.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RoundTableTop)
                return false;
            else
            {
                RoundTableTop newObj = obj as RoundTableTop;

                return Square == newObj.Square && Height == newObj.Height && Radius == newObj.Radius &&
                        Price == newObj.Price && Material == newObj.Material && PriceForProcessing == newObj.PriceForProcessing;
            }
        }
        public override string ToString()
        {
            return $"Chipboard rectangle leg {Radius}x{Height}";
        }
    }
}
