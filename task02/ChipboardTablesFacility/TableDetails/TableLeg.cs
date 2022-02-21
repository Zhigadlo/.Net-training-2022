using Materials;

namespace TableDetails
{
    public class TableLeg : IDetail
    {
        public int Square { get; set; }
        public int Height { get; set; }
        public int Price { get; private set; }

        public TableLeg()
        {

        }
    }
}
