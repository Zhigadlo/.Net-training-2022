using Materials;

namespace TableDetails
{
    public class TableLeg : IDetail
    {
        public int Square { get; set; }
        public int Height { get; set; }
        public int Price { get; private set; }
        public Material Material { get; set; }
        public TableLeg(int square, int height, Material material, int priceForProcessing)
        {
            Square = square;
            Height = height;
            Material = material;
            int Volume = Square * Height;
            Price = (int)material * Volume + priceForProcessing * Volume;
        }
    }
}
