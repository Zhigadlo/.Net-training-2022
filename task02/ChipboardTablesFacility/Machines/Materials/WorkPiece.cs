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
        public MaterialType ChipboardType { get; private set; }

        private double _price;
        public WorkPiece(MaterialType chipboardType, int height, int width, int length)
        {
            Width = width;
            Height = height;
            Length = length;
            ChipboardType = chipboardType;
            _price = (int)chipboardType * width * height * length;
        }

        public double GetPrice() => _price;
    }
}
