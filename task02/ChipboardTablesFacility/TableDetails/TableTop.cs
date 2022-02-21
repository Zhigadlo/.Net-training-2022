namespace TableDetails
{
    public class TableTop : IDetail
    {
        public int Square { get; set; }
        public int Height { get; set; }

        public TableTop(int Square, int Height)
        {
            this.Square = Square;
            this.Height = Height;
        }
    }
}
