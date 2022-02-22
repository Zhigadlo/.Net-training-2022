using Materials;

namespace TableDetails
{
    public class TableTop : IDetail
    {
        public int Square { get; set; }
        public int Height { get; set; }
        public Material Material { get ; set ; }
        public int Price { get; private set; }

        public TableTop(int Square, int Height, Material material, int priceForProcessing)
        {
            this.Square = Square;
            this.Height = Height;
            Material = material;
            int Volume = Square * Height;
            Price = Volume * (int)material * Volume * priceForProcessing;
        }
    }
}
