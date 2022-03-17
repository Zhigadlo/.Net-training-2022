using Facility.Interfaces;
using Facility.Materials;
using System.Text.Json.Serialization;

namespace Facility.TableDetails
{
    public class RectangularTableTop : IDetail
    {
        [JsonIgnore]
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        [JsonIgnore]
        public double Price { get; }
        public double Width { get; }
        public double Length { get; }
        public double PriceForProcessing { get; }

        public RectangularTableTop(MaterialType material, double height, double width, double length, double priceForProcessing)
        {
            Square = width * length;
            PriceForProcessing = priceForProcessing;
            Height = height;
            Width = width;
            Length = length;
            Material = material;
            Price = Square * height * (int)material + priceForProcessing;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + Width.GetHashCode() + Length.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RectangularTableTop)
                return false;
            else
            {
                RectangularTableTop newObj = obj as RectangularTableTop;

                return Square == newObj.Square && Height == newObj.Height && Width == newObj.Width &&
                        Price == newObj.Price && Length == newObj.Length && Material == newObj.Material &&
                        PriceForProcessing == newObj.PriceForProcessing;
            }
        }
        public override string ToString()
        {
            return $"Rectangular table top {Width}x{Length}x{Height}";
        }
    }
}
