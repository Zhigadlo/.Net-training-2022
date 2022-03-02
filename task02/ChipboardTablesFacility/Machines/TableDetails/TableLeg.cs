using Facility.Materials;

namespace Facility.TableDetails
{
    public class TableLeg : IDetail
    {
        public double Square { get; set; }
        public double Height { get; set; }
        public double Price { get; private set; }
        public Material Material { get; set; }
        public TableLeg(double square, double height, Material material, double priceForProcessing)
        {
            Square = square;
            Height = height;
            Material = material;
            double Volume = Square * Height;
            Price = Volume * ((int)material + priceForProcessing);
        }
    }
}
