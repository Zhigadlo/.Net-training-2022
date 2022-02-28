namespace Facility.Materials
{
    /// <summary>
    /// Piece of material for getting details for tables
    /// </summary>
    public class WorkPiece
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        private double _price;
        public Material Material { get; private set; }

        public WorkPiece(int height, int width, int length, Material material)
        {
            Width = width;
            Height = height;
            Length = length;
            Material = material;
            _price = (int)material * width * height * length;
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
