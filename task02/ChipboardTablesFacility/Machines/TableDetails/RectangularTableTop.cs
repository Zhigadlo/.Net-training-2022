using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class RectangularTableTop : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public MaterialType Material { get; }
        public double Price { get; }
        public double Width { get; }
        public double Length { get; }

        public RectangularTableTop(MaterialType material, double height, double width, double lenght, double priceForProcessing)
        {
            Square = width * lenght;
            Height = height;
            Width = width;
            Length = lenght;
            Material = material;
            Price = Square * height * (int)material + priceForProcessing;
        }
    }
}
