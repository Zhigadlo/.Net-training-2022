using Facility.Materials;

namespace Facility.TableDetails
{
    public class TableTop : IDetail
    {
        public double Square { get; set; }
        public double Height { get; set; }
        public Material Material { get; set; }
        public double Price { get; private set; }

        public TableTop(double Square, double Height, Material material, double priceForProcessing)
        {
            this.Square = Square;
            this.Height = Height;
            Material = material;
            double Volume = Square * Height;
            Price = Volume * ((int)material + priceForProcessing);
        }
    }
}
