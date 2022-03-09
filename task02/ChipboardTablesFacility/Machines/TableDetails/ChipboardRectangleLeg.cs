using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class ChipboardRectangleLeg : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material { get; }
        public double Width { get; }
        public double Length { get; }

        public ChipboardRectangleLeg(MaterialType material, double height, double width, double lenght, double priceForProcessing) 
        {
            Material = material;
            Height = height;
            Width = width;
            Length = lenght;
            Square = width * lenght;
            Price = Square * Height * (int)material + priceForProcessing;
        }
    }
}
