using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class MetalRectangleLeg : ITableLeg
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material{ get; }
        public double Width { get; }
        public double Length { get; }

        public MetalRectangleLeg(double height, double width, double length, double Price)
        {
            Material = MaterialType.Metal;
            this.Price = Price;
            Square = width * length;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}
