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
        public double Square { get; }
        public MaterialType ChipboardType { get; private set; }

        private double _price;
        public WorkPiece(MaterialType chipboardType, int height, int width, int length)
        {
            Width = width;
            Height = height;
            Length = length;
            Square = Width * Height;
            ChipboardType = chipboardType;
            _price = (int)chipboardType * width * height * length;
        }

        public void Cut(double height, double width, double length)
        {
            if (Height >= height && Width >= width && Length >= length)
                Height -= height;
            else
                throw new Exception("This work piece is too small for this detail");
        }
        public double GetPrice() => _price;
        public override int GetHashCode()
        {
            return Width.GetHashCode() + Length.GetHashCode() + Height.GetHashCode() + Square.GetHashCode();
        }
        public override string ToString()
        {
            return $"{ChipboardType} {Width}x{Length}x{Height}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not WorkPiece)
                return false;
            else
            {
                WorkPiece newObj = obj as WorkPiece;

                return Width == newObj.Width &&
                        Length == newObj.Length &&
                        Height == newObj.Length &&
                        ChipboardType == newObj.ChipboardType;
            }
        }
    }
}
